using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Open.WeiXin
{
    public class WeiXinBase
    {
        public static string Token = "WSTianZhuDing";  //你的token
        public static string appID = "wx7ce11d3352a8e0e6"; //公众帐号的appID
        public static string appsecret = "7c16d083c7f4c08d1bb4e00e7f769942"; //公众帐号的appsecret
        private string access_token = ""; //公众帐号对应的access_token，有效时间为7200秒
        public DateTime access_token_createtime;

        private static WeiXinBase m_instance = null;
        private WeiXinBase()
        {
        }

        public static WeiXinBase getInstance()
        {
            if (m_instance == null)
            {
                m_instance = new WeiXinBase();
            }

            return m_instance;
        }

        public string Access_Token
        {
            get
            {
                if (!string.IsNullOrEmpty(access_token) && DateTime.Now < access_token_createtime.AddSeconds(7000))
                {
                    return access_token;
                }
                else
                {
                    
                    string para="grant_type=client_credential&appid="+appID+"&secret="+appsecret;
                    string requestURL="https://api.weixin.qq.com/cgi-bin/token";
                    string results=Helpler.SendGetRequest(para, requestURL);
                    TokenResult deToken = JsonConvert.DeserializeObject<TokenResult>(results);
                    this.access_token = deToken.access_token;
                    this.access_token_createtime = DateTime.Now;
                    return access_token;
                }
            }
        }
    }

}
