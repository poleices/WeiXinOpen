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


namespace WeiXinOpen.Controllers
{
    public class HomeController : Controller
    {
        public RequestTextMessage RmRequest = null;
        public ResponseTextMessage RmResponse = null;

        [HttpGet]
        public ActionResult Index()
        {
            //WeiXinBase weixin = WeiXinBase.getInstance();
            //return Content(weixin.Access_Token);

            string xmlResult = string.Empty;

            ResponseTextMessage txtMsg = new ResponseTextMessage();
            txtMsg.MsgType = "text";
            txtMsg.Content = "你好！";

            RmResponse = txtMsg;

            string rq=JsonConvert.SerializeObject(RmRequest);
            string rp=JsonConvert.SerializeObject(RmResponse);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RequestTextMessage));
            using (MemoryStream ms = new MemoryStream())
            {
                xmlSerializer.Serialize(ms, RmRequest);
                xmlResult = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }

            //return Content("request:"+xmlRequest+"\r\n"+"response:"+RmResponse);
            return Content("request:" + rq + "\r\n" + "response:" + rp + "\r\n" + "xmlrequest:" + xmlResult);

        }

        [HttpPost]
        public ContentResult Index(RequestTextMessage Msg)
        {
            RmRequest = Msg;

            //Msg = new RequestTextMessage();
            string xmlResult = string.Empty;

            //switch (Msg.MsgType)
            //{
            //    case "text":
            //        {
            ResponseTextMessage txtMsg = new ResponseTextMessage();
            txtMsg.ToUserName = Msg.FromUserName;
            txtMsg.FromUserName = Msg.ToUserName;
            txtMsg.CreateTime = Msg.CreateTime;
            txtMsg.MsgType = "text";
            txtMsg.Content = "你好！";

            RmResponse = txtMsg;

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(ResponseTextMessage));
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    xmlSerializer.Serialize(ms, txtMsg);
            //    xmlResult = System.Text.Encoding.UTF8.GetString(ms.ToArray());

            //}
            //            break;
            //        }
            //    default:
            //        break;
            //}
            ////Response.Write(xmlResult);
            RmResponse = txtMsg;

            return Content("");
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
