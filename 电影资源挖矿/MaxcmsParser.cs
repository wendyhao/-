using System;
using System.Collections.Generic;
using System.Xml;

namespace Maxcms
{
    /// <summary>
    ///  Maxcms解析模块
    /// </summary>
    public class MaxcmsParser
    {
        /// <summary>
        /// 文档
        /// </summary>
        public XmlDocument Document { get; set; }
        /// <summary>
        /// rss 内容
        /// </summary>
        public MaxcmsRss Rss { get; set; }
        public MaxcmsParser(XmlDocument doc)
        {

            Document = doc;
            if (doc["rss"] != null)
            {
                Rss = new MaxcmsRss();
                
                Rss.type = ParserClass(doc["rss"]["class"]);
                Rss.list = Rss.type.Count>0? ParserVideoList(doc["rss"]["list"]) : ParserVideoInfo(doc["rss"]["list"]);
            }
        }
        /// <summary>
        /// 解析类型列表
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private MaxcmsRssClass ParserClass(XmlElement xml)
        {
           
            var RssClassDataContainer = new MaxcmsRssClass();
            if (xml == null) return RssClassDataContainer;
            foreach (XmlElement ty in xml.ChildNodes)
            {
                MaxcmsClassItem item = new MaxcmsClassItem();
                var id = ty.Attributes["id"];
                if (id != null)
                {
                    item.ID = int.Parse(ty.Attributes["id"].Value);
                    item.Name = ty.InnerText;
                    RssClassDataContainer.Add(item);
                }
            }
            return RssClassDataContainer;
        }
        /// <summary>
        /// 解析视频列表
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private MaxcmsRssList ParserVideoList(XmlElement xml)
        {

            var RssList = CreateMaxcmsRssList(xml);
            RssList.ListVideo = new List<IVideoItem>();
            foreach (XmlElement item in xml.ChildNodes)
            {

                RssList.ListVideo.Add(new Video()
                {
                    id = int.Parse(item["id"].InnerText),
                    last = DateTime.Parse(item["last"].InnerText),
                    name = item["name"].InnerText,
                    note = item["note"].InnerText,
                    tid = int.Parse(item["tid"].InnerText),
                    type = item["type"].InnerText
                });
            }
            return RssList;
        }
        /// <summary>
        /// 解析视频信息
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private MaxcmsRssList ParserVideoInfo(XmlElement xml)
        {
            var RssList = CreateMaxcmsRssList(xml);
            RssList.ListVideo = new List<IVideoItem>();
            foreach (XmlElement item in xml.ChildNodes)
            {

                RssList.ListVideo.Add(new VideoInfo()
                {
                    id = int.Parse(item["id"].InnerText),
                    last = DateTime.Parse(item["last"].InnerText),
                    name = item["name"].InnerText,
                    note = item["note"].InnerText,
                    tid = int.Parse(item["tid"].InnerText),
                    type = item["type"].InnerText,
                    pic= item["pic"].InnerText,
                    lang = item["lang"].InnerText,
                    area = item["area"].InnerText,
                    year = int.Parse(item["year"].InnerText),
                    state = int.Parse(item["state"].InnerText),
                    actor = item["actor"].InnerText,
                    director = item["director"].InnerText,
                    des= item["des"].InnerText
                });
            }
            return RssList;
        }
        /// <summary>
        /// 解析页面列表
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private MaxcmsRssList CreateMaxcmsRssList(XmlElement xml)
        {
            return new MaxcmsRssList()
            {
                page = int.Parse(xml.Attributes["page"].Value),
                pagecount = int.Parse(xml.Attributes["pagecount"].Value),
                pagesize = int.Parse(xml.Attributes["pagesize"].Value),
                recordcount = int.Parse(xml.Attributes["recordcount"].Value)
                

            };
        }

    }






}
