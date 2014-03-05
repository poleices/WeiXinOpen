using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using Open.WeiXin;
using Newtonsoft.Json;
using System.Xml.Linq;
using Td.Weixin.Public.Common;
using Td.Weixin.Public.Message;



namespace WeiXinOpen.Controllers
{
    public class HomeController : Controller
    {
        //public static string RmRequest = null;
        //public ResponseTextMessage RmResponse = null;

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    //WeiXinBase weixin = WeiXinBase.getInstance();
        //    //return Content(weixin.Access_Token);

        //    var sign = EntrySign.ParseFromContext();
        //    if (/*sign.Check()*/true)
        //    {
        //        if (EntrySign.IsEntryCheck())
        //        {
        //            sign.Response();
        //        }
        //        else
        //        {
        //            var msg = ReceiveMessage.ParseFromContext();
        //            var rep = msg.Process();
        //            rep.Response();
        //        }
        //    }
        //    //return Content("request:" + rq + "\r\n" + "response:" + rp + "\r\n" + "xmlrequest:" + xmlResult);
        //    return View();

        //}

        public ActionResult Index()
        {
            //注册事件处理程序
            ReceiveMessage.ResisterHandler(new WxMsgHandler());

            //var request = System.Web.HttpContext.Current.Request;
            //var sr = new StreamReader(request.InputStream);
            //var msg = Parse();
            //string text = sr.ReadToEnd();
            //var e = XElement.Parse(text);
            //var t = e.Element("MsgType").Value;


            //var sign = EntrySign.ParseFromContext();

            string respose = "回复出错!";
            //if (/*sign.Check()*/true)
            //{
            //    if (/*EntrySign.IsEntryCheck()*/false)
            //    {
            //        sign.Response();
            //    }
            //    else
            //    {
            //LogHelper.Log(text);
                    var msg = ReceiveMessage.ParseFromContext();
                    //LogHelper.Log(msg.ToString());
                    var rep = msg.Process();
                    //LogHelper.Log(rep.ToXmlText());
                    respose= rep.Response();
            //    }
            //}

                    return Content(respose);
        }

        [HttpGet]
        public ActionResult About(string signature,string timestamp,string nonce, string echostr)
        {
            return Content(echostr);
        }

        [HttpPost]
        public ActionResult About()
        {
            //ViewBag.Message = "Your app description page.";

            return Content("post");
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
