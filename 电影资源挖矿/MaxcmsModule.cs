using System;
using System.Collections.Generic;

namespace Maxcms
{
   
    public abstract class MaxcmsModule : IMaxcmsObject
    {
        /// <summary>
        /// 采集地址
        /// </summary>
        public abstract string ServerUrl { get; set; }
        /// <summary>
        /// 采集站点名称
        /// </summary>
        public abstract string ServerName { get; set; }
       /// <summary>
       /// 采集完成处理,用于处理存储过程
       /// </summary>
       /// <param name="ServerName">采集站点的名称</param>
       /// <param name="info">影片信息</param>
        public delegate void OnCompleteHandler(string ServerName, VideoInfo info);
        /// <summary>
        /// 采集完成事件
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="info"></param>
        public event OnCompleteHandler OnComplet;
        /// <summary>
        /// 分类表
        /// </summary>
        public abstract List<MaxcmsClassItem> ServerClassList { get; set; }
        /// <summary>
        /// 初始化分类表
        /// </summary>
        /// <param name="LocalClassList">本地的分类表,本参数预留给以后扩展</param>
        public virtual void InitClassList(List<MaxcmsClassItem> LocalClassList=null)
        {
            
            MaxcmsRequestOptions requestOptions = new MaxcmsRequestOptions(ServerUrl, MaxcmsAccess.list);
            MaxcmsHttp http = new MaxcmsHttp(requestOptions);
            if (http.isComplete)
            {
                var ClassItem = new MaxcmsParser(http.XmlDoc).Rss.type;
                if (ClassItem != null)
                {
                    ServerClassList = ClassItem as List<MaxcmsClassItem>;
                }
                if (LocalClassList == null) return;
                for (int i = 0; i < ServerClassList.Count; i++)
                {
                    for (int j = 0; j < LocalClassList.Count; j++)
                    {
                        if (ServerClassList[i].ID == LocalClassList[j].BindID)
                        {
                            ServerClassList[i].BindID = LocalClassList[j].ID;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 采集视频列表
        /// </summary>
        /// <param name="maxcmsRequestOptions"></param>
        /// <param name="AutoAllCollect"></param>
        public virtual void VideoListCollect(MaxcmsRequestOptions requestOptions, bool AutoAllCollect = false)
        {
            MaxcmsHttp http = new MaxcmsHttp(requestOptions);
            if (http.isComplete)
            {
                MaxcmsRssList VideoLists = new MaxcmsParser(http.XmlDoc).Rss.list;
                string idstring = "";
                VideoLists.ListVideo.ForEach(x => idstring += "," + x.ToString());
                VideoInfoCollect(new MaxcmsRequestOptions(ServerUrl, MaxcmsAccess.videolist)
                {
                    ids = idstring.TrimStart(new char[] { ',' })
                });
                if (AutoAllCollect)
                {
                    var page = VideoLists.page + 1;
                    if (VideoLists.page > VideoLists.pagecount) return;
                    requestOptions.page = page.ToString();
                    VideoListCollect(requestOptions, AutoAllCollect);
                }
            }

        }
        /// <summary>
        /// 按当天采集
        /// </summary>
        /// <param name="AutoAllCollect"></param>
        public virtual void VideoInfoCollectByDay(bool AutoAllCollect = false)
        {
            MaxcmsRequestOptions requestOptions = new MaxcmsRequestOptions(ServerUrl, MaxcmsAccess.videolist);
            requestOptions.hour = "24";
            VideoInfoCollect(requestOptions, AutoAllCollect);
        }
        /// <summary>
        /// 按分类采集 (扩展方法)
        /// </summary>
        /// <param name="VideoType"></param>
        /// <param name="AutoAllCollect">是否自动翻页</param>
        public virtual void VideoInfoCollectByClass(int VideoType, bool AutoAllCollect = false)
        {
            MaxcmsRequestOptions requestOptions = new MaxcmsRequestOptions(ServerUrl, MaxcmsAccess.videolist);                      
            requestOptions.type = VideoType.ToString();
            VideoInfoCollect(requestOptions, AutoAllCollect);
        }
        /// <summary>
        /// 按关键字采集(复合扩展方法)
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="AutoAllCollect">是否自动翻页</param>
        public virtual void VideoInfoCollectByKeyword(string keyword,bool AutoAllCollect = false)
        {
            MaxcmsRequestOptions requestOptions = new MaxcmsRequestOptions(ServerUrl, MaxcmsAccess.list);            
            requestOptions.keyword = keyword;
            VideoListCollect(requestOptions, AutoAllCollect);
        }
        /// <summary>
        /// 按ID采集(复合扩展方法)
        /// </summary>
        /// <param name="ids">视频ID,可多个,一般不超过30个</param>
        public virtual void VideoInfoCollectByID(params string[] ids)
        {
            MaxcmsRequestOptions requestOptions = new MaxcmsRequestOptions(ServerUrl, MaxcmsAccess.videolist);
            string idstring = "";
            for (int i = 0; i < ids.Length; i++) idstring += "," + ids[i].ToString();           
            requestOptions.ids = idstring.TrimStart(new char[] { ',' });
            VideoInfoCollect(requestOptions, false);
        }
        /// <summary>
        /// 视频采集(原始方法)
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <param name="AutoAllCollect"></param>
        public virtual void VideoInfoCollect(MaxcmsRequestOptions requestOptions,bool AutoAllCollect = false)
        {
            requestOptions.access = MaxcmsAccess.videolist;
            MaxcmsHttp http = new MaxcmsHttp(requestOptions);            
            if (http.isComplete)
            {
                var Rss = new MaxcmsParser(http.XmlDoc).Rss;             
                if (Rss != null)
                {
                    Rss.list.ListVideo.ForEach(x =>
                    {
                        if (OnComplet != null)
                        {
                            VideoInfo n = x as VideoInfo;                            
                            OnComplet(ServerName,n);
                        }
                    });
                    if (AutoAllCollect)
                    {
                        var page = Rss.list.page + 1;
                        if (page > Rss.list.pagecount) return;
                        requestOptions.page = page.ToString();
                        VideoInfoCollect(requestOptions, AutoAllCollect);
                    }
                }
            }

        }

    }
}
