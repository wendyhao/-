using System;
using Newtonsoft.Json;

namespace Maxcms
{
    /// <summary>
    /// Maxcms公共方法
    /// </summary>
    public static class MaxcmsCommon
    {
        /// <summary>
        /// 模块注入
        /// </summary>
        /// <param name="Name">网站名称</param>
        /// <param name="Url">网站地址</param>
        /// <param name="CallBack">存储结果事件,回调函数</param>
        /// <returns> Maxcms实例</returns>
        public static MaxcmsEntity ModuleInject(string Name, string Url, Action<string, VideoInfo> CallBack)
        {
            var Entity = new MaxcmsEntity();
            Entity.ServerName = Name;
            Entity.ServerUrl = Url;
            Entity.CompletFunction = CallBack;
            Entity.SetCompletEvent();
            Entity.InitClassList();
            return Entity; 
        }
        /// <summary>
        /// 从本地json载入实例
        /// </summary>
        /// <param name="EntityJson">本地json文本</param>
        /// <param name="CallBack">存储结果事件,回调函数</param>
        /// <returns></returns>
        public static MaxcmsEntity ModuleLoadJson(string EntityJson, Action<string, VideoInfo> CallBack)
        {
            var Entity=JsonConvert.DeserializeObject<MaxcmsEntity>(EntityJson);
            Entity.CompletFunction = CallBack;
            Entity.SetCompletEvent();
            return Entity;
        }
        /// <summary>
        /// 将当前实例保存到Json中
        /// </summary>
        /// <param name="Entity">待保存的实例</param>
        /// <returns>Json文本</returns>
        public static string ModuleSaveJson(MaxcmsEntity Entity)
        {
            return JsonConvert.SerializeObject(Entity);
        }


    }




}
