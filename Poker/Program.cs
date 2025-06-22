using Poker.Netty;
using Poker.Properties;
using Poker.Service;
using Poker.View;
using Poker.Utils;
using NettyCSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Poker
{
    static class Program
    {
        public static readonly string ExecutablePath = Process.GetCurrentProcess().MainModule?.FileName;
        public static readonly string WorkingDirectory = Path.GetDirectoryName(ExecutablePath);

        public static string[] Args { get; internal set; }

        public static LoginForm loginForm;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*new Thread(() =>
            {
                try
                {
                    int port = 24138;
                    string host = "127.0.0.1";
                    IPAddress ip = IPAddress.Parse(host);//把ip地址字符串转换为IPAddress类型的实例
                    IPEndPoint ipe = new IPEndPoint(ip, port);//用指定的端口和ip初始化IPEndPoint类的新实例
                    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建一个socket对像，如果用udp协议，则要用SocketType.Dgram类型的套接字
                    s.Bind(ipe);//绑定EndPoint对像（2000端口和ip地址）
                    s.Listen(0);//开始监听
                    while (true)
                    {
                        try
                        {
                            Socket temp = s.Accept();//为新建连接创建新的socket
                            temp.Close();
                            if (MainForm.instance != null)
                            {
                                MainForm.instance.Visible = true;
                            }
                            HandleRunningInstance(Process.GetCurrentProcess());
                        }
                        catch (SocketException e)
                        {
                        }
                    }
                }
                catch (SocketException e)
                {
                    IPAddress serverIpaddress;
                    IPAddress.TryParse("127.0.0.1", out serverIpaddress);
                    IPEndPoint servetEndPoint = new IPEndPoint(serverIpaddress, 24138);
                    Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket.Connect(servetEndPoint);
                    Environment.Exit(0);
                }
            }).Start();*/
            EmbeddedAssembly.Load(Resources.DotNetty_Buffers, "DotNetty.Buffers.dll");
            EmbeddedAssembly.Load(Resources.DotNetty_Codecs, "DotNetty.Codecs.dll");
            EmbeddedAssembly.Load(Resources.DotNetty_Common, "DotNetty.Common.dll");
            EmbeddedAssembly.Load(Resources.DotNetty_Transport, "DotNetty.Transport.dll");
            EmbeddedAssembly.Load(Resources.EventBus, "EventBus.dll");
            EmbeddedAssembly.Load(Resources.MessagePack_Annotations, "MessagePack_Annotations.dll");
            EmbeddedAssembly.Load(Resources.MessagePack, "MessagePack.dll");
            EmbeddedAssembly.Load(Resources.Microsoft_Bcl_AsyncInterfaces, "Microsoft_Bcl_AsyncInterfaces.dll");
            EmbeddedAssembly.Load(Resources.Microsoft_Extensions_DependencyInjection_Abstractions, "Microsoft_Extensions_DependencyInjection_Abstractions.dll");
            EmbeddedAssembly.Load(Resources.Microsoft_Extensions_DependencyInjection, "Microsoft_Extensions_DependencyInjection.dll");
            EmbeddedAssembly.Load(Resources.Microsoft_Extensions_Logging_Abstractions, "Microsoft.Extensions.Logging.Abstractions.dll");
            EmbeddedAssembly.Load(Resources.Microsoft_Extensions_Logging, "Microsoft.Extensions.Logging.dll");
            EmbeddedAssembly.Load(Resources.Microsoft_Extensions_Options, "Microsoft.Extensions.Options.dll");
            EmbeddedAssembly.Load(Resources.Microsoft_Extensions_Primitives, "Microsoft_Extensions_Primitives.dll");
            EmbeddedAssembly.Load(Resources.Newtonsoft_Json, "Newtonsoft.Json.dll");
            EmbeddedAssembly.Load(Resources.System_Buffers, "System_Buffers.dll");
            EmbeddedAssembly.Load(Resources.System_Collections_Immutable, "System_Collections_Immutable.dll");
            EmbeddedAssembly.Load(Resources.System_Diagnostics_DiagnosticSource, "System_Diagnostics_DiagnosticSource.dll");
            EmbeddedAssembly.Load(Resources.System_Memory, "System_Memory.dll");
            EmbeddedAssembly.Load(Resources.System_Numerics_Vectors, "System_Numerics_Vectors.dll");
            EmbeddedAssembly.Load(Resources.System_Runtime_CompilerServices_Unsafe, "System_Runtime_CompilerServices_Unsafe.dll");
            EmbeddedAssembly.Load(Resources.System_Threading_Tasks_Extensions, "System_Threading_Tasks_Extensions.dll");
            EmbeddedAssembly.Load(Resources.System_ValueTuple, "System_ValueTuple.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            DataUtil.load();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new LoginForm(true);
            Application.Idle += new EventHandler(autoLogin);
            Application.Run();
        }

        public static bool first = true;

        public static void autoLogin(object sender, EventArgs e)
        {
            if (first)
            {
                first = false;
                new Thread(() =>
                {
                    loginForm.BeginInvoke(new MethodInvoker(() =>
                    {
                        loginForm.Show();
                        
                        JObject json = HttpService.needUpdate();
                        loginForm.readUpdate = true;
                        if (json == null)
                        {
                            loginForm.readUpdate = false;
                            MessageBox.Show("无法连接至服务器", "无法连接至服务器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (json["force"] != null)
                        {
                            if ((bool)json["force"])
                            {
                                if (DialogResult.Yes == MessageBox.Show("发现新版本:\n版本:" + (string)json["version"] + "\n更新内容:" + (string)json["description"] + "\n必须更新后使用，取消将退出程序，是否更新？", "有新版本", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                                {
                                    loginForm.Dispose();
                                    new UpdateForm(json).Show();
                                }
                                else
                                {
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                if (DialogResult.Yes == MessageBox.Show("发现新版本:\n版本:" + (string)json["version"] + "\n更新内容:" + (string)json["description"] + "\n是否更新？", "有新版本", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                                {
                                    loginForm.Dispose();
                                    new UpdateForm(json).Show();
                                }
                                else
                                {
                                    string messageContent = HttpService.getMessageContent();
                                    if (messageContent == null)
                                    {

                                        MessageBox.Show("无法连接至服务器", "无法连接至服务器", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                    else
                                    {
                                        loginForm.readMessage = true;
                                        if (!(messageContent.Equals(Const.neverShowMessageDialog) || messageContent.Equals("No message")))
                                        {
                                            new MessageForm(loginForm, messageContent).Show();
                                        }
                                        else
                                        {
                                            if (Const.autoLogin)
                                            {
                                                loginForm.login();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            string messageContent = HttpService.getMessageContent();
                            if (messageContent == null)
                            {
                                MessageBox.Show("无法连接至服务器", "无法连接至服务器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                loginForm.readMessage = true;
                                if (!(messageContent.Equals(Const.neverShowMessageDialog) || messageContent.Equals("No message")))
                                {
                                    new MessageForm(loginForm, messageContent).Show();
                                }
                                else
                                {
                                    if (Const.autoLogin)
                                    {
                                        loginForm.login();
                                    }
                                }
                            }
                        }
                    }));
                }).Start();
            }
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }

        #region 确保程序只运行一个实例
        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表 
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程 
                if (process.Id != current.Id)
                {
                    //保证要打开的进程同已经存在的进程来自同一文件路径
                    //if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    //{
                    //返回已经存在的进程
                    return process;
                    //}
                }
            }
            return null;
        }
        //3.已经有了就把它激活，并将其窗口放置最前端
        public static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, 1); //调用api函数，正常显示窗口
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        #endregion
    }
}
