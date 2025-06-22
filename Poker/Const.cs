using Poker.Model;
using Poker.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal static class Const
    {
        public static bool isDebug = true;
        public static string appName = "炸金花";
        public static string version = "1.0";
        public static string server = isDebug ? "192.168.1.99" : "server.mjczy.xyz";
        public static int httpPort = 9082;
        public static int port = 9080;
        public static string httpIp = "http://" + server + ":" + httpPort + "/";
        public static User user;
        public static bool connected;
        public static string aes = "BestVpnIsTheBest";

        public static bool autoLogin;
        public static string username;
        public static string password;
        public static bool autoStart;
        public static string domain80;
        public static bool first = true;
        public static string neverShowMessageDialog;
        public static int roomId;
        public static string roomTitle;
        public static string roomDescription;

        static Const()
        {
            if (first)
            {
                first = false;
                if (!isDebug)
                {
                    server = HttpUtil.GetIp(server);
                }
                httpIp = "http://" + server + ":" + httpPort + "/";
                domain80 = "http://" + server + ":80/";
            }
        }
    }
}
