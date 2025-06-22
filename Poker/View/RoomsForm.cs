using Poker.Netty;
using Poker.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker.View
{
    public partial class RoomsForm : Form
    {

        public static RoomsForm instance;
        public static bool first = true;
        public EnterPasswordDialog enterPasswordDialog;
        public RoomsForm()
        {
            instance = this;
            InitializeComponent();
            usernameLabel.Text = "欢迎，"+Const.user.username;
            moneyLabel.Text = "豆子："+Const.user.money;
            if (first)
            {
                first = false;
                ConnectionHandler.connect();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void roomsChanged(JArray rooms)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                roomsPanel.Controls.Clear();
                int i = 0;
                foreach (JObject room in rooms)
                {
                    RoomListItem roomListItem = new RoomListItem();
                    roomListItem.titleLabel.Text = (string)room["title"];
                    roomListItem.descriptionLabel.Text = (string)room["description"];
                    roomListItem.playerCountLabel.Text = "人数：" + (int)room["playerCount"];
                    roomListItem.noPasswordLabel.Visible = (bool)room["noPassword"];
                    roomListItem.enterButton.Click += new EventHandler((object sender, EventArgs e) => {
                        if (roomListItem.enterButton.Enabled)
                        {
                            roomListItem.enterButton.Enabled = false;
                            if ((bool)room["noPassword"])
                            {
                                new Thread(() =>
                                {
                                    Const.roomTitle = (string)room["title"];
                                    Const.roomDescription = (string)room["description"];
                                    Const.roomId = (int)room["roomId"];
                                    JObject jobject = HttpService.enterRoom(Const.roomId, null);
                                    switch ((int)jobject["errno"])
                                    {
                                        case 0:
                                            break;
                                        default:
                                            BeginInvoke(new MethodInvoker(() =>
                                            {
                                                MessageBox.Show((string)jobject["errMsg"]);
                                                roomListItem.enterButton.Enabled = true;
                                            }));
                                            break;
                                    }
                                }).Start();
                            } else
                            {
                                roomListItem.enterButton.Enabled = true;
                                Const.roomTitle = (string)room["title"];
                                Const.roomDescription = (string)room["description"];
                                enterPasswordDialog = new EnterPasswordDialog(this, (int)room["roomId"]);
                                enterPasswordDialog.Show();
                            }
                        }
                    });
                    roomListItem.Location = new Point(0, roomListItem.Height * i);
                    roomsPanel.Controls.Add(roomListItem);
                    i = i + 1;
                }
            }));
        }

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            new CreateRoomForm(this).Show();
        }

        public void StartMainForm()
        {
            if(enterPasswordDialog!=null)
            {
                enterPasswordDialog.Dispose();
            }
            Dispose();
            instance = null;
            new MainForm().Show();
        }
    }
}
