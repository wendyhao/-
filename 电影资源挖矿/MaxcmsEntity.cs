using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Maxcms
{
    /// <summary>
    /// Maxcms实例
    /// </summary>
    public class MaxcmsEntity : MaxcmsModule
    {
        /// <summary>
        /// 实例化
        /// </summary>
        public MaxcmsEntity()
        {

        }
        /// <summary>
        /// 设置完成事件事件
        /// </summary>
        public void SetCompletEvent()
        {
            OnComplet += MaxcmsEntity_OnComplet;
        }
        /// <summary>
        /// 结果储存事件
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="info"></param>
        private void MaxcmsEntity_OnComplet(string ServerName, VideoInfo info)
        {
            CompletFunction(ServerName, info);
        }
        /// <summary>
        /// 结果储存事件属性
        /// </summary>
        [JsonIgnore]
        public Action<string, VideoInfo> CompletFunction { get; set; }
        /// <summary>
        /// 采集网站地址
        /// </summary>
        public override string ServerUrl { get; set; }
        /// <summary>
        /// 采集网站名称
        /// </summary>
        public override string ServerName { get; set; }
        /// <summary>
        /// 分类表
        /// </summary>
        public override List<MaxcmsClassItem> ServerClassList { get; set; }
    }




}
