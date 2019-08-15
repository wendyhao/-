using System;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;

namespace Maxcms
{
    
    /// <summary>
    /// Maxcms网络访问
    /// </summary>
    public class MaxcmsHttp
    {
        /// <summary>
        /// 返回内容
        /// </summary>
        public string body { get; protected set; }
        /// <summary>
        /// 访问地址
        /// </summary>
        public string RequestUrl { get; protected set; }
        /// <summary>
        /// 文档实例
        /// </summary>
        public XmlDocument XmlDoc { get; protected set; }
        /// <summary>
        /// 编码方法,默认使用UTF8
        /// </summary>
        public Encoding Encoding { get; set; }
        /// <summary>
        /// 访问是否完成
        /// </summary>
        public bool isComplete { get; protected set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; protected set; }
        public virtual void HttpCollect(MaxcmsRequestOptions Request)
        {
            isComplete = false;
            XmlDoc = null;
            Error = string.Empty;
            body = string.Empty;
            Encoding = new UTF8Encoding(false);//默认utf8          
            RequestUrl = Request.GetUrl();//按照请求设置取得访问地址
            HttpWebRequest req = WebRequest.Create(RequestUrl) as HttpWebRequest;
            try
            {
                HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                using (StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding))
                {
                    body = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                isComplete = false;
                body = string.Empty;
                Error = ex.Message;//错误信息
            }
            if (body.Length > 5 && body.Substring(0, 5) == "<?xml")//body 内容是 xml 文本
            {
                try
                {
                    XmlDoc = new XmlDocument();
                    XmlDoc.LoadXml(body);//载入文档
                    isComplete = true;

                }
                catch (Exception ex)
                {

                    isComplete = false;
                    body = string.Empty;
                    Error = ex.Message;//错误信息
                }

            }
            else
            {
                isComplete = false;
                body = string.Empty;
                Error = "Response data is Not Maxcms XML!";
            }
        }
        /// <summary>
        /// 实例化网络访问
        /// </summary>
        /// <param name="Request">网络请求选项</param>
        public  MaxcmsHttp(MaxcmsRequestOptions Request)
        {
            HttpCollect(Request);
        }
        public MaxcmsHttp()
        {

        }
    }






}
