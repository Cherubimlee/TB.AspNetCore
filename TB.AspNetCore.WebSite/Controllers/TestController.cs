using Microsoft.AspNetCore.Mvc;
using TB.AspNetCore.Application.Action;
using TB.AspNetCore.Infrastructrue.Caches.Redis.Extensions;
using TB.AspNetCore.Infrastructrue.Config;
using TB.AspNetCore.Infrastructrue.Logs;

namespace TB.AspNetCore.WebSite.Controllers
{
    public class Persion
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
    public class TestController : WebBase
    {
        [Action("Redis测试栏目", ActionType.Test, 1)]
        public IActionResult Index()
        {
            //Log4Net.Info("Info");
            //Log4Net.Error("Error");
            //Log4Net.Debug("Debug");
            //Log4Net.Warn("Warn");
            #region 高级redisceshi
            //发布TestPubSub
            var result = RedisServiceExtensions.Publish(Infrastructrue.Caches.Redis.Models.RedisChannels.TestPubSub, null);

            for (int i = 0; i < 1000; i++)
            {
                //发布MemberRegister
                var result2 = RedisServiceExtensions.Publish(Infrastructrue.Caches.Redis.Models.RedisChannels.MemberRegister, "哥就是哥_不一样的烟火...");
            }
            #endregion


            return View();
        }
        #region 测试基础redis
        //public IActionResult Index()
        //{
        //    var key = "Test_Redis_Key";

        //    var result = RedisServiceExtensions.Insert(key, "good");

        //    var value = RedisServiceExtensions.Get(key);
        //    return View();
        //} 
        #endregion

        #region 测试config
        //public IActionResult Index()
        //{
        //    var log4net = ConfigLocator.Instance["Log4NetConfig"];

        //    var persion = ConfigLocator.Instance.Get<Persion>("Persion");


        //    return View();
        //} 
        #endregion
    }
}