using Poker.Model;
using Poker.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Poker
{
    internal static class Const
    {
        public static bool isDebug = false;
        public static string appName = "炸金花";
        public static string version = "1.0";
        public static string server = isDebug ? "192.168.1.99" : "server.mjczy.xyz";
        public static int socketTimeout = 6000;
        public static int connectTimeout = 6000;

        public static List<string> baseDomains = new List<string>();
        public static string baseDomain;
        public static JObject serverAddrs;
        public static int timeoutMillies = 6000;
        public static string serverAddr;
        public static string wsAddr;
        public static bool ipv6Support;
        public static bool ipGot;

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
                baseDomains.Add("mjczy.top");
                baseDomains.Add("mjczy.us.kg");
                baseDomains.Add("mjczy.xyz");
                baseDomains.Add("mjczy.life");
                baseDomains.Add("mjczy.club");
                baseDomains.Add("mjczy.info");
                baseDomains.Add("mjczy.org");
                baseDomains.Add("mjczy.net");
                baseDomain = baseDomains[0];
                if (isDebug)
                {
                    serverAddrs = new JObject();
                    serverAddrs["ipv4"] = "http://192.168.1.100:9082/";
                    serverAddrs["ipv6"] = "http://127.0.0.1:9082/";
                    serverAddrs["ipv4ws"] = "ws://192.168.1.100:9082/websocket/";
                    serverAddrs["ipv6ws"] = "ws://ipv6.mjczy.top:9082/websocket/";
                    serverAddr = ipv6Support ? (string)serverAddrs["ipv6"] : (string)serverAddrs["ipv4"];
                    wsAddr = ipv6Support ? (string)serverAddrs["ipv6ws"] : (string)serverAddrs["ipv4ws"];
                    ipGot = true;
                    return;
                }
                
                serverAddrs = new JObject();
                serverAddrs["ipv4"] = "http://home.mjczy.top/poker/";
                serverAddrs["ipv6"] = "http://ipv6.mjczy.top:9082/";
                new Thread(() => {
                    ipGot = false;
                    try
                    {
                        serverAddrs = ServerUtil.getAddress();
                        serverAddr = ipv6Support ? (string)serverAddrs["ipv6"] : (string)serverAddrs["ipv4"];
                        wsAddr = ipv6Support ? (string)serverAddrs["ipv6ws"] : (string)serverAddrs["ipv4ws"];
                        new Thread(() => ipv6Support = ServerUtil.ipv6Test()).Start();
                        Console.WriteLine(serverAddr);
                        Console.WriteLine(wsAddr);
                        ipGot = true;
                        return;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    getDomainAndIp();
                }).Start();
            }
        }
        public static void getDomainAndIp()
        {
            new Thread(() => {
                ipGot = false;
                while (true)
                {
                    foreach (string domain in baseDomains)
                    {
                        baseDomain = domain;
                        try
                        {
                            serverAddrs = ServerUtil.getAddress();
                            serverAddr = ipv6Support ? (string)serverAddrs["ipv6"] : (string)serverAddrs["ipv4"];
                            Console.WriteLine(baseDomain);
                            ipGot = true;
                            return;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }
            }).Start();
        }
    }
}
