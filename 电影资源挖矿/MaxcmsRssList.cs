using System.Collections.Generic;

namespace Maxcms
{
    /// <summary>
    /// Maxcms页面信息
    /// </summary>
    public class MaxcmsRssList
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        ///总页数
        /// </summary>
        public int pagecount { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int pagesize { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int recordcount { get; set; }
        /// <summary>
        /// 视频信息集合
        /// </summary>
        public List<IVideoItem> ListVideo { get; set; }
    }






}
