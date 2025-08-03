#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 类 名 称 ：NettyClient
* 类 描 述 ：Netty C#客户端
* 作    者 ：lucher
* 版 本 号 ：v1.0.0
*******************************************************************
* Copyright @ lucher 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using Poker;
using Poker.Netty;
using DotNetty.Codecs;
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNetty.Codecs.Http;
using DotNetty.Codecs.Http.WebSockets;
using System.Net.Http;

namespace Poker.Netty.Client
{
    public class NettyClient
    {
        public ClientHandler clientHandler = new ClientHandler();

        public void sendMessage(String msg)
        {
            clientHandler.sendMessage(msg);
        }

        public async Task<bool> ConnectAsync(string url)
        {
            // DotNetty 的 EventLoopGroup，使用 MultithreadEventLoopGroup 替代 NioEventLoopGroup
            IEventLoopGroup group = new MultithreadEventLoopGroup();

            try
            {
                var bootstrap = new Bootstrap();
                bootstrap
                    .Group(group)
                    .Option(ChannelOption.SoKeepalive, true)
                    .Option(ChannelOption.TcpNodelay, true)
                    // DotNetty 的 ConnectTimeout 需要 TimeSpan
                    .Option(ChannelOption.ConnectTimeout, TimeSpan.FromMilliseconds(Const.connectTimeout))
                    .Channel<TcpSocketChannel>();

                NettyClientHandler handler = null;

                bootstrap.Handler(new ActionChannelInitializer<ISocketChannel>(socketChannel =>
                {
                    IChannelPipeline pipeline = socketChannel.Pipeline;
                    pipeline.AddLast(new HttpClientCodec());
                    pipeline.AddLast(new HttpObjectAggregator(2155380 * 10));
                    handler = new NettyClientHandler(this); // 需你自己定义好 NettyClientWebSocket.This
                    pipeline.AddLast("handler", handler);
                }));

                var uri = new Uri(url);
                string host = uri.Host;
                int port = uri.Port;

                // 这里你需要自己实现或改写 NetWorkUtil.GetRealURI() 方法
                Uri realURI = uri;
                    /*await GetRealURI(new UriBuilder
                {
                    Scheme = uri.Scheme == "wss" ? "https" : "http",
                    UserName = uri.UserInfo,
                    Host = uri.Host,
                    Port = uri.Port,
                    Path = uri.AbsolutePath,
                    Query = uri.Query,
                    Fragment = uri.Fragment
                }.Uri.ToString());*/

                Console.WriteLine("connect: " + realURI);

                if (realURI != null)
                {
                    host = realURI.Host;
                    port = realURI.Port;
                }

                Console.WriteLine($"Connecting to host: {host}, port: {port}");
                // ConnectAsync 返回 Task<IChannel>
                //IChannel channel = await bootstrap.ConnectAsync(host, port);
                IChannel channel;
                // 判断 host 是 IP 字符串还是域名
                if (IPAddress.TryParse(host, out var ipAddress))
                {
                    channel = await bootstrap.ConnectAsync(new IPEndPoint(ipAddress, port));
                }
                else
                {
                    // 只有在是域名时才让 DotNetty 解析 DNS
                    channel = await bootstrap.ConnectAsync(host, port);
                    
                }

                Console.WriteLine($"连接websocket服务器: {url} isSuccess={channel.Active}");

                if (channel.Active)
                {
                    // 进行握手
                    handler = (NettyClientHandler)channel.Pipeline.Get("handler");

                    Console.WriteLine("ipv6:" + Const.ipv6Support);
                    string wsHost = uri.Host;

                    // 使用DotNetty自带握手器创建工厂方法
                    var handshaker = WebSocketClientHandshakerFactory.NewHandshaker(
                        uri,
                        WebSocketVersion.V13,
                        null,
                        true,
                        new DefaultHttpHeaders(),
                        2155380 * 10);
                    handler.SetHandshaker(handshaker);
                    handshaker.HandshakeAsync(channel).Wait(); // 同步等待握手完成，或者用 await

                    // 等待握手完成 Task（如果你改成异步，可以改为 await）
                    await handler.HandshakeCompletion;
                }

                await channel.CloseCompletion;

                return !handler.exceptionCaught;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
            }
            return false;
        }

        //开启客户端
        public async void doConnect()
        {
            do
            {
                long start = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                var connected = await ConnectAsync(Const.wsAddr + Const.user.userId);
                long time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - start;
                if (time < Const.connectTimeout)
                {
                    Thread.Sleep((int)(Const.connectTimeout - time));
                }
            } while (true);
            /*try
            {
                // 发起连接操作
                channel = await bootstrap.ConnectAsync(new IPEndPoint(Host, Port));
                JObject jObject = new JObject();
                jObject["name"] = "123";
                SendMessage(jObject.ToString());
                // 等待客户端链路关闭
                //await clientChannel.CloseAsync();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                //new Task(() => {
                //
                //                  Thread.Sleep(1000);
                //                ConnectionHandler.connect();
                //          }).Start();
            }
            finally
            {
                //group.ShutdownGracefullyAsync().Wait(1000);
                //await group.ShutdownGracefullyAsync(TimeSpan.FromMilliseconds(100), TimeSpan.FromSeconds(1));
            }*/
        }

        public static async Task<Uri> GetRealURI(string url)
        {
            try
            {
                var handler = new HttpClientHandler
                {
                    AllowAutoRedirect = true,
                    // 连接和接收超时在 HttpClient 外层用 CancellationToken 控制
                    // 如果想设置代理、证书等，可在这里配置
                };

                var httpClient = new HttpClient(handler);

                // 设置超时时间（等同于连接超时和读取超时）
                httpClient.Timeout = TimeSpan.FromMilliseconds(Const.connectTimeout);

                // 发送请求（GET），HttpClient 自动跟踪重定向
                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                // 返回响应请求的最终 Uri 地址（经过所有重定向后）
                return response.RequestMessage.RequestUri;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
