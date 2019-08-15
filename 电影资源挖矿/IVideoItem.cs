using System;

namespace Maxcms
{
    /// <summary>
    /// 视频信息接口
    /// </summary>
    public interface IVideoItem
    {
        /// <summary>
        /// 影片ID
        /// </summary>
        int id { get; set; }
        /// <summary>
        /// 类型ID
        /// </summary>
        int tid { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        DateTime last { get; set; }
        /// <summary>
        /// 片名
        /// </summary>
        string name { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        string type { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        string note { get; set; }
    }






}
