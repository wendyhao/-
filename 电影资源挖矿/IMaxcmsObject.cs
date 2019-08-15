using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maxcms
{
    /// <summary>
    /// Maxcms采集接口
    /// </summary>
    public interface IMaxcmsObject
    {
        /// <summary>
        /// 采集网站的地址
        /// </summary>
        string ServerUrl { get; set; }
        /// <summary>
        /// 采集网站的名称
        /// </summary>
        string ServerName { get; set; }
        /// <summary>
        /// 分类表
        /// </summary>
        List<MaxcmsClassItem> ServerClassList { get; set; }
        /// <summary>
        /// 采集分类表
        /// </summary>
        /// <param name="LocalClassList"></param>
        void InitClassList(List<MaxcmsClassItem> LocalClassList);       
        /// <summary>
        /// 采集视频信息
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <param name="AutoAllCollect"></param>
        void VideoInfoCollect(MaxcmsRequestOptions requestOptions, bool AutoAllCollect = false);
        /// <summary>
        /// 采集视频列表
        /// </summary>
        /// <param name="requestOptions"></param>
        /// <param name="AutoAllCollect"></param>
        void VideoListCollect(MaxcmsRequestOptions requestOptions, bool AutoAllCollect = false);

    }
}
