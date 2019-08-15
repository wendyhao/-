using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Maxcms;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] webconfpath = { "OK资源网.json", "永久资源.json" };


            List<MaxcmsEntity> weblist = new List<MaxcmsEntity>();
            for (int i = 0; i < webconfpath.Length; i++)
            {
                var json=File.ReadAllText(webconfpath[i], new UTF8Encoding(false));
                weblist.Add( MaxcmsCommon.ModuleLoadJson(json, Save));
            }
            foreach (MaxcmsEntity web in weblist)
            {
                web.VideoInfoCollectByDay();
            }
            Console.ReadKey();
           
        }

        private static void Save(string ServerName,VideoInfo info)
        {
            Console.WriteLine("{0}:{1} | {2} | {3}", ServerName, info.type, info.name, info.actor);
        }
    }
    public class site : MaxcmsModule
    {
        public override string ServerUrl { get; set; }
        public override string ServerName { get; set; }
        public override List<MaxcmsClassItem> ServerClassList { get; set; }
    }
   
   

}
