using DnsClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Poker.Service;
using Poker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;

namespace Poker.Utils
{
    public class ServerUtil
    {
        public static void refreshIpv4AndIpv6()
        {
            //Console.WriteLine("REFRESHING!");
            new Thread(() => {
                if (checkNetwork())
                {
                    bool ipv6 = ipv6Test();
                    Const.serverAddr = (string)Const.serverAddrs[ipv6 ? "ipv6" : "ipv4"];
                    Const.wsAddr = (string)Const.serverAddrs[ipv6 ? "ipv6ws" : "ipv4ws"];
                }
           
            }).Start();
        }

        public static JObject getAddress()
        {
            List<JObject> got = new List<JObject>();
            new Thread(() =>
            {
                try
                {
                    got.Add(getJson());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }).Start();
            List<string> dnsServers = new List<string>();
            dnsServers.Add("223.5.5.5");
            dnsServers.Add("114.114.114.114");
            dnsServers.Add("1.1.1.1");
            dnsServers.Add("8.8.8.8");
            dnsServers.Add("2400:3200::1");
            dnsServers.Add("2400:3200:baba::1");
            dnsServers.Add("2001:dc7:1000::1");

            for (int i = 0; i < dnsServers.Count(); i++)
            {
                int finalI = i;
                new Thread(() =>
                {
                    try
                    {
                        got.Add(getJson(dnsServers[finalI]));
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine(e);
                    }
                }).Start();
            }
            bool wait = true;
            new Thread(() =>
            {
                Thread.Sleep(5000);
                wait = false;
            }).Start();
            while (wait)
            {
                Thread.Sleep(0);
                if (got.Count != 0)
                {
                    return got[0];
                }
            }
            return null;
        }

        public static JObject getJson()
        {
            JObject answer = new JObject();
            answer["ipv4"] = getOne("ipv4.poker.");
            answer["ipv6"] = getOne("ipv6.poker.");
            answer["ipv4ws"] = getOne("ipv4ws.poker.");
            answer["ipv6ws"] = getOne("ipv6ws.poker.");
            //Console.WriteLine("getJson RESULT:" + answer);

            return answer;
        }

        public static JObject getJson(string dnsServer)
        {
            JObject answer = new JObject();
            answer["ipv4"] = getOne(dnsServer, "ipv4.poker.");
            answer["ipv6"] = getOne(dnsServer, "ipv6.poker.");
            answer["ipv4ws"] = getOne(dnsServer, "ipv4ws.poker.");
            answer["ipv6ws"] = getOne(dnsServer, "ipv6ws.poker.");
            //Console.WriteLine("getJson RESULT:" + answer);

            return answer;
        }

        public static string getOne(string prefix)
        {
            return getOneWithClient(new LookupClient(), prefix);
        }

        public static string getOne(string dnsServer, string prefix)
        {
            return getOneWithClient(new LookupClient(new IPEndPoint(IPAddress.Parse(dnsServer), 53)), prefix);
        }

        private static string getOneWithClient(LookupClient client, string prefix)
        {
            var result = client.Query(prefix + Const.baseDomain, QueryType.TXT);
            string s = "";
            var record = result.Answers.TxtRecords().FirstOrDefault();
            //Console.WriteLine(record);
            if (record == null)
                throw new Exception("Cannot get record from " + client);
            //Console.WriteLine(record.Text);
            //Console.WriteLine(record.Text.Count);
            foreach (String str in record.Text)
            {
                s += str;
            }
            return Base64.DecodeBase64(s);
        }

        public static bool ipv6Test()
        {
            return HttpService.getMessageContent((string)Const.serverAddrs["ipv6"]) != null;
        }

        public static bool isReachableHost(string host)
        {
            return isReachableHost(host, 80);
        }

        public static bool isReachableHost(string host, int port)
        {
            return isReachableHost(host, port, Const.timeoutMillies);
        }

        public static bool isReachableHost(string address, int port, int millisecondsTimeout)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.Proxy = null;
            httpClientHandler.UseProxy = false;
            HttpClient httpClient = new HttpClient(httpClientHandler);
            httpClient.Timeout = new TimeSpan(0, 0, 0, millisecondsTimeout / 1000);
            string rst = null;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = httpClient.GetAsync("http://" + address + ":" + port + "/").Result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
            try
            {
                rst = response.Content.ReadAsStringAsync().Result;
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            return false;
            /*try
            {
                Console.WriteLine(address);
                Console.WriteLine(port);
                IPHostEntry host = Dns.GetHostEntry(address);
                IPAddress ip = host.AddressList[0];
                IPEndPoint point = new IPEndPoint(ip, port);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(point);
                Console.WriteLine("连接TCP端口{0}成功！", point);
                return true;
            }
            catch (SocketException e)
            {
                Console.WriteLine("连接TCP端口失败！");
                return false;
            }*/
        }

        public static bool isReachable(string url, int millisecondsTimeout)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.Proxy = null;
            httpClientHandler.UseProxy = false;
            HttpClient httpClient = new HttpClient(httpClientHandler);
            httpClient.Timeout = new TimeSpan(0, 0, 0, millisecondsTimeout / 1000);
            string rst = null;
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = httpClient.GetAsync(url).Result;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
            try
            {
                rst = response.Content.ReadAsStringAsync().Result;
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            return false;
            /*try
            {
                Console.WriteLine(address);
                Console.WriteLine(port);
                IPHostEntry host = Dns.GetHostEntry(address);
                IPAddress ip = host.AddressList[0];
                IPEndPoint point = new IPEndPoint(ip, port);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(point);
                Console.WriteLine("连接TCP端口{0}成功！", point);
                return true;
            }
            catch (SocketException e)
            {
                Console.WriteLine("连接TCP端口失败！");
                return false;
            }*/
        }

        public static bool checkNetwork()
        {
            return isReachableHost("www.baidu.com");
        }

        public static double tcping(EndPoint endPoint)
        {
            Console.WriteLine(endPoint.ToString());
            try
            {
                var times = new List<double>();
                for (int i = 0; i < 2; i++)
                {
                    var addressFamily = endPoint.AddressFamily == AddressFamily.InterNetworkV6 ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork;
                    var sock = new Socket(addressFamily, SocketType.Stream, ProtocolType.Tcp);
                    sock.Blocking = true;
                    sock.SendTimeout = 5000;

                    var stopwatch = new Stopwatch();

                    // Measure the Connect call only
                    stopwatch.Start();
                    sock.Connect(endPoint);
                    stopwatch.Stop();

                    double t = stopwatch.Elapsed.TotalMilliseconds;
                    //Console.WriteLine("{0:0.00}ms", t);
                    times.Add(t);

                    sock.Close();
                }
                return times.Min();
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
