using Poker.Service;
using NettyCSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Poker.View
{
    public partial class MainPanel : UserControl
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            if(readyButton.Enabled)
            {
                readyButton.Enabled = false;
                new Thread(() =>
                {
                    JObject jobject = HttpService.ready();
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        readyButton.Enabled = true;
                    }));
                    switch ((int)jobject["errno"])
                    {
                        case 0:
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                readyButton.Visible = false;
                            }));
                            break;
                    }
                }).Start();
            }
        }

        private void lookButton_Click(object sender, EventArgs e)
        {
            lookButton.Visible = false;
            MainForm.instance.showCards(NettyClientHandler.cards);
            HttpService.lookCards();
        }

        private void throwButton_Click(object sender, EventArgs e)
        {
            MainForm.instance.hideCards();
            MainForm.instance.mainPanel.lookButton.Visible = false;
            MainForm.instance.mainPanel.throwButton.Visible = false;
            MainForm.instance.mainPanel.haveButton.Visible = false;
            MainForm.instance.mainPanel.readyButton.Visible = true;
            HttpService.throwCards();
        }

        private void haveButton_Click(object sender, EventArgs e)
        {
            new ChooseTypeForm(MainForm.instance, !lookButton.Visible, NettyClientHandler.playerCount == 2, NettyClientHandler.currentMoney).Show();
        }

        private void card1Label_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click:" + e);
        }

        private void card1Label_Enter(object sender, EventArgs e)
        {
            Console.WriteLine("Enter:" + e);
        }

        private void card1Label_Leave(object sender, EventArgs e)
        {
            Console.WriteLine("Leave:" + e);
        }

        private void card1Label_Down(object sender, EventArgs e)
        {
            Console.WriteLine("Down:" + e);
        }

        private void card1Label_Up(object sender, EventArgs e)
        {
            Console.WriteLine("Up:" + e);
        }

        private void card1Label_DragEnter(object sender, EventArgs e)
        {
            Console.WriteLine("Drag Enter:" + e);
        }

        private void card1Label_DragLeave(object sender, EventArgs e)
        {
            Console.WriteLine("Drag Leave:" + e);
        }

        private void card1Label_MouseMove(object sender, EventArgs e)
        {
            Console.WriteLine("Mouse Move" + e);
        }
    }
}
