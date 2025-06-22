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
using Poker;
using Poker.Netty;
using Poker.Service;
using Poker.View;
using DotNetty.Buffers;
using DotNetty.Transport.Channels;
using EventBus;
using MessagePack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NettyCSharp
{
    public class NettyClientHandler : SimpleChannelInboundHandler<Object>
    {

        public static string cards;
        public static int currentMoney;
        public static int playerCount;
        public static int lastMoney;
        public static JArray players;

        protected override void ChannelRead0(IChannelHandlerContext ctx, object msg)
        {
            //String json = msg as String;
            //MessagePackSerializer.;
            //读取到消息，对消息进行解析
            //这样判断感觉有些尴尬，由于对C#不熟，暂时还没有更好的办法，有好的实现方法还望给出宝贵建议
            //Console.WriteLine(msg);
            JObject json = JObject.Parse((string)msg);
            switch ((string)json["type"])
            {
                case "rooms":
                    if (RoomsForm.instance != null && !RoomsForm.instance.IsDisposed)
                    {
                        RoomsForm.instance.roomsChanged((JArray)json["rooms"]);
                    }
                    break;
                case "roomPlayersChanged":
                    {
                        JArray players = (JArray)json["players"];
                        if (MainForm.instance == null || MainForm.instance.IsDisposed)
                        {
                            if (CreateRoomForm.instance != null && !CreateRoomForm.instance.IsDisposed) {
                                CreateRoomForm.instance.BeginInvoke(new MethodInvoker(() =>
                                {
                                    CreateRoomForm.instance.StartMainForm();
                                    Dictionary<string, string> map = new Dictionary<string, string>();
                                    for (int i = 0; i < players.Count; i++)
                                    {
                                        JObject o = (JObject)players[i];
                                        map.Add((string)o["name"], (string)o["state"]);
                                    }
                                    MainForm.instance.updatePlayers(map, (string)json["currentPlayer"]);
                                }));
                            } else {
                                RoomsForm.instance.BeginInvoke(new MethodInvoker(() =>
                                {
                                    RoomsForm.instance.StartMainForm();
                                    Dictionary<string, string> map = new Dictionary<string, string>();
                                    for (int i = 0; i < players.Count; i++)
                                    {
                                        JObject o = (JObject)players[i];
                                        map.Add((string)o["name"], (string)o["state"]);
                                    }
                                    MainForm.instance.updatePlayers(map, (string)json["currentPlayer"]);
                                }));
                            }
                        }
                        else
                        {
                            MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                            {
                                Dictionary<string, string> map = new Dictionary<string, string>();
                                for (int i = 0; i < players.Count; i++)
                                {
                                    JObject o = (JObject)players[i];
                                    map.Add((string)o["name"], (string)o["state"]);
                                }
                                MainForm.instance.updatePlayers(map, (string)json["currentPlayer"]);
                            }));
                        }
                        break;
                    }
                case "GameStart":
                    {
                        lastMoney = Convert.ToInt32(MainForm.instance.money.Text.Replace("豆子:", ""));
                        cards = (string)json["cards"];
                        currentMoney = (int)json["currentMoney"];
                        playerCount = (int)json["playerCount"];
                        players = (JArray)json["players"];
                        MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                        {
                            MainForm.instance.showCards();
                            MainForm.instance.mainPanel.lookButton.Visible = true;
                            if (Const.user.username.Equals((string)json["current"]))
                            {
                                MainForm.instance.mainPanel.throwButton.Visible = true;
                                MainForm.instance.mainPanel.haveButton.Visible = true;
                            }
                            MainForm.instance.mainPanel.currentPlayer.Text = "当前发话:" + (string)json["current"];
                            MainForm.instance.mainPanel.moneyOnTable.Text = "桌面上的豆子:" + (string)json["totalMoney"];
                        }));
                        break;
                    }
                case "Money":
                    {
                        Const.user.money = (string)json["money"];
                        MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                        {
                            MainForm.instance.money.Text = "豆子:" + (string)json["money"];
                        }));
                        break;
                    }
                case "win":
                    {
                        MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                        {
                            MainForm.instance.mainPanel.lookButton.Visible = false;
                            MainForm.instance.mainPanel.throwButton.Visible = false;
                            MainForm.instance.mainPanel.haveButton.Visible = false;
                            MainForm.instance.mainPanel.readyButton.Visible = true;
                            MessageBox.Show(MainForm.instance, "你赢得了" + (Convert.ToInt32(MainForm.instance.money.Text.Replace("豆子:", "")) - lastMoney) + "个豆子\n" + (json["cards"] != null ? "对手的牌是:" + (string)json["cards"] : ""), "你赢了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm.instance.hideCards();
                        }));
                        break;
                    }
                case "gameState":
                    {
                        currentMoney = (int)json["currentMoney"];
                        playerCount = (int)json["playerCount"];
                        players = (JArray)json["players"];
                        MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                        {
                            if (Const.user.username.Equals((string)json["current"]))
                            {
                                MainForm.instance.mainPanel.throwButton.Visible = true;
                                MainForm.instance.mainPanel.haveButton.Visible = true;
                            }
                            else
                            {
                                MainForm.instance.mainPanel.throwButton.Visible = false;
                                MainForm.instance.mainPanel.haveButton.Visible = false;
                            }
                            MainForm.instance.mainPanel.currentPlayer.Text = "当前发话:" + (string)json["current"];
                            MainForm.instance.mainPanel.moneyOnTable.Text = "桌面上的豆子:" + (string)json["totalMoney"];
                        }));
                        break;
                    }
                case "lose":
                    {
                        MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                        {
                            MainForm.instance.mainPanel.lookButton.Visible = false;
                            MainForm.instance.mainPanel.throwButton.Visible = false;
                            MainForm.instance.mainPanel.haveButton.Visible = false;
                            MainForm.instance.mainPanel.readyButton.Visible = true;
                            MessageBox.Show(MainForm.instance, "你输了" + (lastMoney - Convert.ToInt32(MainForm.instance.money.Text.Replace("豆子:", ""))) + "个豆子，对手的牌是" + json["playerCards"], "开牌", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm.instance.hideCards();
                        }));
                        break;
                    }
                case "lookPlayerCards":
                    {
                        MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                        {
                            MainForm.instance.mainPanel.lookButton.Enabled = true;
                            MainForm.instance.mainPanel.throwButton.Enabled = true;
                            MainForm.instance.mainPanel.haveButton.Enabled = true;
                            if (DialogResult.Yes == MessageBox.Show(MainForm.instance, "你查看了玩家" + (string)json["name"] + "的牌，是" + json["cards"] + "\n是否继续要牌", "看牌", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                            {
                                new Thread(() =>
                                {
                                    HttpService.haveCardsAfterLook();
                                }).Start();
                            }
                            else
                            {
                                new Thread(() =>
                                {
                                    HttpService.throwCards();
                                }).Start();
                            }
                        }));
                        break;
                    }
                case "lookedBy":
                    {
                        MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                        {
                            MessageBox.Show(MainForm.instance, (string)json["name"] + "看了你的牌", "看牌", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }));
                        break;
                    }
                case "GameStop":
                    {
                        MainForm.instance.BeginInvoke(new MethodInvoker(() =>
                        {
                            MainForm.instance.mainPanel.lookButton.Visible = false;
                            MainForm.instance.mainPanel.throwButton.Visible = false;
                            MainForm.instance.mainPanel.haveButton.Visible = false;
                            MainForm.instance.mainPanel.readyButton.Visible = true;
                            MainForm.instance.mainPanel.moneyOnTable.Text = "桌面上的豆子:";
                            MainForm.instance.mainPanel.currentPlayer.Text = "当前发话:";
                            MessageBox.Show(MainForm.instance, (string)json["reason"]+((bool)json["backMoney"]?"，豆子返还":""), "游戏结束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainForm.instance.hideCards();
                        }));
                        break;
                    }
            }
        }

        public override void ChannelReadComplete(IChannelHandlerContext context)
        {
            base.ChannelReadComplete(context);
            context.Flush();
            //Console.WriteLine("ChannelReadComplete:" + context);
        }

        public override void ChannelActive(IChannelHandlerContext context)
        {
            //Console.WriteLine("Client channelActive:" + context);
            SimpleEventBus.GetDefaultEventBus().Post("建立连接：" + context, TimeSpan.Zero);
        }

        public override void ChannelInactive(IChannelHandlerContext context)
        {
            base.ChannelInactive(context);
            //Console.WriteLine("Client ChannelInactive:" + context);
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