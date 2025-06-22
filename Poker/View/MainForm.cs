using Poker.Netty;
using Poker.Properties;
using Poker.Service;
using Poker.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Poker
{
    public partial class MainForm : Form
    {
        public static MainForm instance;
        public MainForm()
        {
            instance = this;
            InitializeComponent();
            init();
        }

        private void init()
        {
            titleLabel.Text += Const.roomTitle;
            roomDescriptionLabel.Text += Const.roomDescription;
            name.Text = "你的名字:" + Const.user.username;
            money.Text = "豆子: " + Const.user.money;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public Panel currentPanel;

        public void updatePlayers(Dictionary<string, string> map, string currentPlayer)
        {
            mainPanel.userPanel.Controls.Clear();
            int i = 0;
            
            foreach (string key in map.Keys)
            {
                Panel panel = new Panel();
                panel.Location = new Point(100 * i, 0);
                panel.AutoScroll = true;
                panel.Size = new System.Drawing.Size(100, 100);
                Label label = new Label();
                label.Text = Convert.ToString(key);
                label.Location = new Point(0, 0);
                label.AutoSize = true;
                panel.Controls.Add(label);
                label = new Label();
                label.Text = Convert.ToString(map[key]);
                label.Location = new Point(0, 40);
                label.AutoSize = true;
                panel.Controls.Add(label);
                if(currentPlayer!=null && currentPlayer.Equals(key))
                {
                    currentPanel = panel;
                    panel.Paint += new PaintEventHandler(panel_Paint);
                }
                mainPanel.userPanel.Controls.Add(panel);
                i = i + 1;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, currentPanel.ClientRectangle,
            Color.Red, 3, ButtonBorderStyle.Solid, //左边
            Color.Red, 3, ButtonBorderStyle.Solid, //上边
            Color.Red, 3, ButtonBorderStyle.Solid, //右边
            Color.Red, 3, ButtonBorderStyle.Solid);//底边
        }

        public void showCards()
        {
            Image i = ImageUtil.resizeImage((Bitmap)Resources.ResourceManager.GetObject("背面", Resources.Culture), mainPanel.card1Label.Size.Width, mainPanel.card1Label.Size.Height);
            mainPanel.card1Label.Image = i;
            mainPanel.card2Label.Image = i;
            mainPanel.card3Label.Image = i;
            mainPanel.card1Label.Visible = true;
            mainPanel.card2Label.Visible = true;
            mainPanel.card3Label.Visible = true;
        }

        public void showCards(string cards)
        {
            string[] cs = cards.Replace("[", "").Replace("]", "").Split(',');
            string r = cs[0].Replace(" ", "").Replace("♠", "黑桃").Replace("♦", "方片").Replace("♥", "红桃").Replace("♣", "梅花");
            Image i = ImageUtil.resizeImage((Bitmap)Resources.ResourceManager.GetObject(r, Resources.Culture), mainPanel.card1Label.Size.Width, mainPanel.card1Label.Size.Height);
            mainPanel.card1Label.Image = i;
            r = cs[1].Replace(" ", "").Replace("♠", "黑桃").Replace("♦", "方片").Replace("♥", "红桃").Replace("♣", "梅花");
            i = ImageUtil.resizeImage((Bitmap)Resources.ResourceManager.GetObject(r, Resources.Culture), mainPanel.card1Label.Size.Width, mainPanel.card1Label.Size.Height);
            mainPanel.card2Label.Image = i;
            r = cs[2].Replace(" ", "").Replace("♠", "黑桃").Replace("♦", "方片").Replace("♥", "红桃").Replace("♣", "梅花");
            i = ImageUtil.resizeImage((Bitmap)Resources.ResourceManager.GetObject(r, Resources.Culture), mainPanel.card1Label.Size.Width, mainPanel.card1Label.Size.Height);
            mainPanel.card3Label.Image = i;
            mainPanel.card1Label.Visible = true;
            mainPanel.card2Label.Visible = true;
            mainPanel.card3Label.Visible = true;
        }

        public void hideCards()
        {
            mainPanel.card1Label.Visible = false;
            mainPanel.card2Label.Visible = false;
            mainPanel.card3Label.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (exitButton.Enabled)
            {
                exitButton.Enabled = false;
                new Thread(() =>
                {
                    JObject jobject = HttpService.exitRoom();
                    switch((int)jobject["errno"])
                    {
                        case 0:
                            break;
                    }
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        Dispose(false);
                        Const.roomId = 0;
                        new RoomsForm().Show();
                    }));
                }).Start();
            }
        }
    }
}
