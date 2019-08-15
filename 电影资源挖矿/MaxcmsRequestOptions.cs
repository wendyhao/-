namespace Maxcms
{
    /// <summary>
    /// Maxcms网络请求选项
    /// </summary>
    public class MaxcmsRequestOptions
    {
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="_url">地址</param>
        /// <param name="_ac">操作方法</param>
        public MaxcmsRequestOptions(string _url,MaxcmsAccess _ac)
        {
            
            access = _ac;
            url = _url;
        }
        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="_ac">操作方法</param>
        public MaxcmsRequestOptions(MaxcmsAccess _ac)
        {
            access = _ac;
            url = string.Empty;
        }
        /// <summary>
        /// 实例化
        /// </summary>
        public MaxcmsRequestOptions()
        {

        }

        /// <summary>
        /// 获得请求地址,此规则符合Maxcms的通用,如果不同可以继承本类重新规则
        /// </summary>
        /// <returns></returns>
        public virtual string GetUrl()
        {
            string u = string.Format("{0}?ac={1}", url, access.ToString());
            if (!string.IsNullOrEmpty(rid))
            {
                u += string.Format("&rid={0}",rid);
            }
            if (!string.IsNullOrEmpty(hour))
            {
                u += string.Format("&h={0}", hour);
            }
            if (!string.IsNullOrEmpty(page))
            {
                u += string.Format("&pg={0}", page);
            }
            if (!string.IsNullOrEmpty(type))
            {
                u += string.Format("&t={0}", type);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                u += string.Format("&wd={0}", keyword);
            }
            if (!string.IsNullOrEmpty(ids))
            {
                u += string.Format("&ids={0}", ids);
            }
            return u;
        }
        /// <summary>
        /// 操作
        /// </summary>
        public MaxcmsAccess access { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 记录类别,具体还没搞清楚,不适用此参数也可正常访问
        /// </summary>
        public string rid { get; set; }
        /// <summary>
        /// 小时
        /// </summary>
        public string hour { get; set; }
        /// <summary>
        /// 页数
        /// </summary>
        public string page { get; set; }
        /// <summary>
        /// 类型ID
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public string ids { get; set; }
    }
   

   
}
