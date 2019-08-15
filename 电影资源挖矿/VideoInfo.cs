using System;

namespace Maxcms
{
    public class VideoInfo : IVideoItem
    {
        /// <summary>
        /// 影片ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 类型ID
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime last { get; set; }
        /// <summary>
        /// 片名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// 海报地址
        /// </summary>
        public string pic { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string lang { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string area { get; set; }
        /// <summary>
        /// 年份
        /// </summary>
        public int year { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 演员
        /// </summary>
        public string actor { get; set; }
        /// <summary>
        /// 导演
        /// </summary>
        public string director { get; set; }
        /// <summary>
        /// 剧情简介
        /// </summary>
        public string des { get; set; }
        /// <summary>
        /// 播放队列
        /// </summary>
        public VideoPackSerial list { get; set; }
    }
}
