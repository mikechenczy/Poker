#region << 版 本 注 释 >>
/*----------------------------------------------------------------
* 类 名 称 ：NettyClientHandler
* 类 描 述 ：处理客户端的channel
* 作    者 ：lucher
* 版 本 号 ：v1.0.0
*******************************************************************
* Copyright @ lucher 2019. All rights reserved.
*******************************************************************
//----------------------------------------------------------------*/
#endregion
using Poker.View;
using DotNetty.Codecs.Http.WebSockets;
using EventBus;
using System;
using System.Windows.Forms;
using DotNetty.Codecs.Http;
using DotNetty.Transport.Channels;
using System.Threading.Tasks;

namespace Poker.Netty.Client
{
    public class NettyClientHandler : SimpleChannelInboundHandler<Object>
    {
        private WebSocketClientHandshaker handshaker;
        private TaskCompletionSource<bool> completionSource;
        public NettyClient webSocket;
        public bool exceptionCaught;

        public NettyClientHandler(NettyClient webSocket)
        {
            this.webSocket = webSocket;
        }
        
        public override void ChannelActive(IChannelHandlerContext ctx)
        {
            webSocket.clientHandler.setCtx(ctx);
            SimpleEventBus.GetDefaultEventBus().Post("建立连接：" + ctx, TimeSpan.Zero);
        }

        public Task HandshakeCompletion => completionSource?.Task;

        public void SetHandshaker(WebSocketClientHandshaker handshaker)
        {
            this.handshaker = handshaker;
        }

        public override void HandlerAdded(IChannelHandlerContext context)
        {
            this.completionSource = new TaskCompletionSource<bool>();
        }

        protected override void ChannelRead0(IChannelHandlerContext ctx, object msg)
        {
            // 握手协议返回，设置结束握手
            if (!this.handshaker.IsHandshakeComplete)
            {
                var response = msg as IFullHttpResponse;
                if (response != null)
                {
                    handshaker.FinishHandshake(ctx.Channel, response);
                    completionSource.TrySetResult(true);
                    //TODO webSocket.clientHandler.startHeartbeat();
                }
                return;
            }

            if (msg is TextWebSocketFrame textFrame) {
                //System.out.println("WebSocketClientHandler::channelRead0 textFrame: " + textFrame.text());
                webSocket.clientHandler.handleMessage(textFrame.Text());
            }

            if (msg is CloseWebSocketFrame){
                //System.out.println("WebSocketClientHandler::channelRead0 CloseWebSocketFrame");
            }
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            base.ChannelReadComplete(context);
            context.Flush();
            //Console.WriteLine("ChannelReadComplete:" + context);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            base.ChannelInactive(context);
            Console.WriteLine("Client ChannelInactive:" + context);
            SimpleEventBus.GetDefaultEventBus().Post("连接断开：" + context, TimeSpan.Zero);
            if(MainForm.instance!=null)
            {
                MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                {
                    MainForm.instance.Dispose();
                    Const.roomId = 0;
                    new RoomsForm().Show();
                    MessageBox.Show("无法连接至服务器", "无法连接至服务器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
            ConnectionHandler.connect();
        }

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            //Console.WriteLine("Exception: " + exception);
            context.CloseAsync();
        }
    }
}