using Poker.Model;
using Poker.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Poker.Service
{
    internal static class HttpService
    {

        public static HttpClient httpClient;

        static HttpService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.Proxy = null;
            httpClientHandler.UseProxy = false;
            httpClient = new HttpClient(httpClientHandler);
            httpClient.Timeout = new TimeSpan(0, 0, 0, 3);
        }

        /// <summary>
        /// GET方式发送得结果
        /// </summary>
        /// <param name="url">请求的url</param>
        public static string GetRequest(string url)
        {
            /*HttpWebRequest hwRequest = null;
            HttpWebResponse hwResponse = null;

            string strResult = null;
            try
            {
                hwRequest = (HttpWebRequest)WebRequest.Create(url);
                hwRequest.Timeout = 3000;
                hwRequest.Method = "GET";
                hwRequest.ContentType = "application/json;charset=UTF-8";
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
            }
            try
            {
                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.UTF8);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
            }
            return strResult;*/
            string rst = null;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = httpClient.GetAsync(url).Result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                return rst;
            }
            try
            {
                rst = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
            }
            return rst;
        }

        public static string url = "";

        public static User login(string usernameOrEmail, string password)
        {

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("username", usernameOrEmail);
            map.Add("password", password);
            map.Add("device", "Windows");
            map.Add("ipAddress", GetIPFromHtml(HttpGetPageHtml("http://www.net.cn/static/customercare/yourip.asp", "utf-8")));
            url = Const.serverAddr + "user/login";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
                return null;
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            int errno = (int)json["errno"];
            User user = new User();
            switch (errno)
            {
                case 0:
                    user = JsonConvert.DeserializeObject<User>((string)json["user"]);
                    Const.user = user;
                    DataUtil.save();
                    return user;
                default:
                    user.userId = errno;
                    return user;
            }
        }

        public static User loginWithoutData(string usernameOrEmail, string password)
        {

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("username", usernameOrEmail);
            map.Add("password", password);
            url = Const.serverAddr + "user/loginWithoutData";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
                return null;
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            int errno = (int)json["errno"];
            User user = new User();
            switch (errno)
            {
                case 0:
                    user = JsonConvert.DeserializeObject<User>((string)json["user"]);
                    Const.user = user;
                    DataUtil.save();
                    return user;
                default:
                    user.userId = errno;
                    return user;
            }
        }

        public static string getAndroidUrl()
        {
            url = Const.serverAddr + "core/getAndroidUrl";
            return GetRequest(url);
        }

        public static int signIn()
        {
            url = Const.serverAddr + "core/signIn";
            string content = GetRequest(url);
            if (content == null)
            {
                return -1;
            }
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            return (int)json["errno"];
        }

        public static string getSignInInfo()
        {
            url = Const.serverAddr + "core/getSignInInfo";
            string content = GetRequest(url);
            if (content == null)
            {
                return null;
            }
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            return (string)json["signInInfo"];
        }

        public static List<PayType> getPayTypes()
        {
            url = Const.serverAddr + "pay/getPayTypes";
            string content = GetRequest(url);
            if (content == null)
            {
                return null;
            }
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            return ((JArray)json["payTypes"]).ToObject<List<PayType>>();
        }

        public static string[] pay(PayType payType)
        {
            url = Const.serverAddr + "pay/pay";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("payType", payType.payType.ToString());
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
            string[] result = new string[2];
            result[0] = content.Substring(content.Length - 40, 40);
            result[1] = content.Substring(0, content.Length - 40);
            return result;
        }

        public static object[] query(string payNo)
        {
            url = Const.serverAddr + "pay/query";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("payNo", payNo);
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                object[] result2 = new Object[1];
                result2[0] = -1;
                return result2;
            }
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            object[] result = new object[2];
            result[0] = (int)json["errno"];
            if ((int)json["errno"] == 0)
            {
                result[1] = (bool)json["result"];
            }
            return result;
        }

        public static int forgetPasswordEmail(string username)
        {
            url = Const.serverAddr + "user/forgetPasswordEmail";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("username", username);
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                return -1;
            }
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            return (int)json["errno"];
        }

        public static int forgetPassword(Dictionary<string, string> map)
        {
            url = Const.serverAddr + "user/forgetPassword";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                return -1;
            }
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            return (int)json["errno"];
        }

        public static User register(Dictionary<string, string> map)
        {
            url = Const.serverAddr + "user/register";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                return null;
            }
            JObject json = (JObject)JsonConvert.DeserializeObject(content);
            int errno = (int)json["errno"];
            User user = new User();
            switch (errno)
            {
                case 0:
                    user = JsonConvert.DeserializeObject<User>((string)json["user"]);
                    Const.user = user;
                    DataUtil.save();
                    return user;
                default:
                    user.userId = errno;
                    return user;
            }
        }

        public static JObject needUpdate()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("version", Const.version);
            url = Const.serverAddr + "core/checkVersionNew";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                return null;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }

        public static string getMessageContent(string serverAddr)
        {
            url = serverAddr + "core/getMessageContent";
            return GetRequest(url);
        }

        public static string getMessageContent()
        {
            url = Const.serverAddr + "core/getMessageContent";
            return GetRequest(url);
        }

        public static JObject createRoom(string title, string description, string password)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("userId", ""+Const.user.userId);
            map.Add("title", title);
            map.Add("description", description);
            map.Add("password", password);
            url = Const.serverAddr + "room/createRoom";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                JObject o = new JObject();
                o["errno"] = -1;
                return o;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }

        public static JObject enterRoom(int roomId, string password)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("userId", "" + Const.user.userId);
            map.Add("roomId", "" + roomId);
            if(password!=null)
            {
                map.Add("password", password);
            }
            url = Const.serverAddr + "room/enterRoom";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                JObject o = new JObject();
                o["errno"] = -1;
                o["errMsg"] = "无法连接至服务器";
                return o;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }

        public static JObject exitRoom()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("userId", "" + Const.user.userId);
            url = Const.serverAddr + "room/exitRoom";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                JObject o = new JObject();
                o["errno"] = -1;
                return o;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }

        public static JObject ready()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("userId", "" + Const.user.userId);
            url = Const.serverAddr + "room/ready";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                JObject o = new JObject();
                o["errno"] = -1;
                return o;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }
        public static JObject throwCards()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("userId", "" + Const.user.userId);
            url = Const.serverAddr + "room/throwCards";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                JObject o = new JObject();
                o["errno"] = -1;
                return o;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }

        public static JObject haveCardsAfterLook()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("userId", "" + Const.user.userId);
            url = Const.serverAddr + "room/haveCardsAfterLook";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                JObject o = new JObject();
                o["errno"] = -1;
                return o;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }

        public static JObject lookCards()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("userId", "" + Const.user.userId);
            url = Const.serverAddr + "room/lookCards";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                JObject o = new JObject();
                o["errno"] = -1;
                return o;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }

        public static void have(int baseMoney, int type)
        {
            have(baseMoney, type, null);
        }

        public static JObject have(int baseMoney, int type, string name)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("userId", "" + Const.user.userId);
            map.Add("money", "" + baseMoney);
            map.Add("haveType", "" + type);
            if (name != null)
            {
                map.Add("name", name);
            }
            url = Const.serverAddr + "room/have";
            url = HttpUtil.setParamToUrl(url, map);
            string content = GetRequest(url);
            if (content == null)
            {
                JObject o = new JObject();
                o["errno"] = -1;
                return o;
            }
            return (JObject)JsonConvert.DeserializeObject(content);
        }

        public static string HttpGetPageHtml(string url, string encoding)
        {
            string pageHtml = string.Empty;
            try
            {
                using (WebClient MyWebClient = new WebClient())
                {
                    Encoding encode = Encoding.GetEncoding(encoding);
                    MyWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.84 Safari/537.36");
                    MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据
                    Byte[] pageData = MyWebClient.DownloadData(url); //从指定网站下载数据
                    pageHtml = encode.GetString(pageData);
                }
            }
            catch (Exception e)
            {

            }
            return pageHtml;
        }
        public static string GetIPFromHtml(String pageHtml)
        {
            //验证ipv4地址
            string reg = @"(?:(?:(25[0-5])|(2[0-4]\d)|((1\d{2})|([1-9]?\d)))\.){3}(?:(25[0-5])|(2[0-4]\d)|((1\d{2})|([1-9]?\d)))";
            string ip = "";
            Match m = Regex.Match(pageHtml, reg);
            if (m.Success)
            {
                ip = m.Value;
            }
            return ip;
        }
    }
}
