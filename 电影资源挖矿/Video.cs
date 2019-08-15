using System;

namespace Maxcms
{
    public class Video : IVideoItem
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
    }




}
