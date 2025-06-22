using Poker.Properties;
using Poker.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Poker.Utils
{
    internal static class HttpUtil
    {
        public static string setParamToUrl(string url, Dictionary<string, string> map)
        {
            if (url == null || map == null)
                return null;
            if (url.EndsWith("/"))
                url.Substring(0, url.Length - 1);
            url = url + (url.Contains("?") ? (map.Count() == 0 ? "" : "&") : "?");

            foreach (var item in map)
            {
                url = url + item.Key + "=" + HttpUtil.UrlEncode(item.Value) + "&";
            }
            return url.Substring(0, url.Length - 1);
        }

        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

        public static long GetFileContentLength(string url)
        {
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url);
                //request.Timeout = TimeOutWait;
                //request.ReadWriteTimeout = ReadWriteTimeOut;
                //向服务器请求，获得服务器回应数据流
                WebResponse respone = request.GetResponse();
                request.Abort();
                return respone.ContentLength;
            }
            catch (WebException e)
            {
                if (request != null)
                    request.Abort();
                return 0;
            }
        }


        public static void update(UpdateForm updateForm)
        {
            new Thread(() =>
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Const.domain80 + "Poker.exe");
                //向服务器请求，获得服务器回应数据流
                Stream ns = request.GetResponse().GetResponseStream();
                byte[] nbytes = new byte[1024];
                int nReadSize = 0;
                int proc = 0;
                long curReadSize = 0;
                long totalSize = GetFileContentLength(Const.domain80 + "Poker.exe");
                FileStream fs = new FileStream(Program.WorkingDirectory + "\\PokerUpdate.exe", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                do
                {
                    try
                    {
                        nReadSize = ns.Read(nbytes, 0, 1024);
                        fs.Write(nbytes, 0, nReadSize);
                        //已下载大小
                        curReadSize += nReadSize;
                        //进度百分比
                        proc = (int)(curReadSize * 100 / totalSize);
                        updateForm.BeginInvoke(new MethodInvoker(() =>
                        {
                            updateForm.progressBar.Value = proc;
                        }));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("下载失败", "下载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                } while (nReadSize > 0);

                fs.Close();
                ns.Close();

                if (curReadSize == totalSize)
                {
                    try
                    {
                        string path = Program.WorkingDirectory + "\\Update.exe";
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        FileUtil.ExtractResFile(path, Resources.Update_exe);
                        Process process = new Process
                        {
                            StartInfo =
                    {
                        FileName = Program.WorkingDirectory + "\\Update.exe",
                        Arguments = "\""+Program.ExecutablePath+"\" \""+Program.WorkingDirectory + "\\BestVPNUpdate.exe\"",
                        WorkingDirectory = Program.WorkingDirectory,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        UseShellExecute = true,
                        CreateNoWindow = true
                    }
                        };
                        process.Start();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("下载失败", "下载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Environment.Exit(0);
                }
                else
                {
                    MessageBox.Show("更新失败", "更新失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }).Start();
        }

        /// <summary>
        /// 传入域名返回对应的IP 
        /// </summary>
        /// <param name="domainName">域名</param>
        /// <returns></returns>
        public static string GetIp(string domainName)
        {
            domainName = domainName.Replace("http://", "").Replace("https://", "");
            IPHostEntry hostEntry = Dns.GetHostEntry(domainName);
            IPEndPoint ipEndPoint = new IPEndPoint(hostEntry.AddressList[0], 0);
            return ipEndPoint.Address.ToString();
        }
    }
}