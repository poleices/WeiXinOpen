using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Runtime.Serialization;
//using System.ComponentModel;
//using System.Text.RegularExpressions;
using System.IO;
//using System.Runtime.Serialization.Json;
using System.Net;
//using System.Security.Cryptography;
//using System.Data;


namespace Open.WeiXin
{
    public class Helpler
    {
        /// <summary>
        /// 发送GET请求
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string SendGetRequest(string paramsStr, string requestStr)//模拟Http请求
        {
            string str = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(requestStr + "?" + paramsStr);
                request.ContentType = "application/x-www-form-urlencoded";
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                str = reader.ReadToEnd();
                reader.Close();
                responseStream.Close();
                response.Close();
            }
            catch
            {
            }
            return str;
        }
    }
}
