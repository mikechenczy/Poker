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
    public partial class EnterPasswordDialog : Form
    {
        public RoomsForm parent;
        public int roomId;

        public EnterPasswordDialog(RoomsForm parent, int roomId)
        {
            this.parent = parent;
            parent.Enabled = false;
            this.roomId = roomId;
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Dispose(false);
            parent.Enabled = true;
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (commitButton.Enabled)
            {
                commitButton.Enabled = false;
                new Thread(() =>
                {
                    JObject jobject = HttpService.enterRoom(roomId, passwordTextBox.Text);
                    switch ((int)jobject["errno"])
                    {
                        case 0:
                            break;
                        case -1:
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                MessageBox.Show("无法连接");
                                commitButton.Enabled = true;
                            }));
                            break;
                        default:
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                MessageBox.Show((string)jobject["errMsg"]);
                                commitButton.Enabled = true;
                            }));
                            break;
                    }

                }).Start();
            }
        }
    }
}
