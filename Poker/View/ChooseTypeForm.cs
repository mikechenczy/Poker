using Poker.Service;
using NettyCSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Poker
{
    public partial class ChooseTypeForm : Form
    {
        public MainForm parent;
        public int minMoney;
        public int baseMoney;
        public bool looked;
        public ChooseTypeForm(MainForm parent, bool looked, bool open, int baseMoney)
        {
            this.parent = parent;
            this.baseMoney = baseMoney;
            this.looked = looked;
            parent.Enabled = false;
            InitializeComponent();
            minMoney = (looked ? 2 : 1) * baseMoney;
            button4.Visible = open;
            button4.Text = minMoney + "个开牌";
            button1.Text = minMoney + "个";
            button2.Text = ((baseMoney + 2) * (looked ? 2 : 1)) + "个";
            button3.Text = (minMoney*2) + "个";
            button5.Text = (minMoney * 3) + "个看他人牌";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Dispose(false);
            parent.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose(false);
            parent.Enabled = true;
            new Thread(() =>
            {
                HttpService.have(minMoney, 0);
            }).Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose(false);
            parent.Enabled = true;
            new Thread(() =>
            {
                HttpService.have(((baseMoney + 2) * (looked ? 2 : 1)), 0);
            }).Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dispose(false);
            parent.Enabled = true;
            new Thread(() =>
            {
                HttpService.have(minMoney * 2, 0);
            }).Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose(false);
            parent.Enabled = true;
            new Thread(() =>
            {
                HttpService.have(minMoney, 1);
            }).Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new ChoosePlayerForm(this, NettyClientHandler.players).Show();
        }
    }
}
