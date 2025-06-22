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
    public partial class CreateRoomForm : Form
    {
        public static CreateRoomForm instance;
        public Form parent;

        public CreateRoomForm(Form parent)
        {
            instance = this;
            this.parent = parent;
            parent.Enabled = false;
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != null && !nameTextBox.Text.Equals("") && descriptionTextBox.Text != null && !descriptionTextBox.Text.Equals(""))
            {
                if (commitButton.Enabled)
                {
                    commitButton.Enabled = false;
                    new Thread(() =>
                    {
                        string password = passwordTextBox.Text;
                        JObject jobject = HttpService.createRoom(nameTextBox.Text, descriptionTextBox.Text, password);
                        switch((int)jobject["errno"])
                        {
                            case 0:
                                BeginInvoke(new MethodInvoker(() =>
                                {
                                    Const.roomTitle = nameTextBox.Text;
                                    Const.roomDescription = descriptionTextBox.Text;
                                    Const.roomId = (int)jobject["roomId"];
                                    StartMainForm();
                                    new Thread(() =>
                                    {
                                        HttpService.enterRoom(Const.roomId, password);
                                    }).Start();
                                }));
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
                return;
            }
            MessageBox.Show("请正确输入");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        public void CloseForm()
        {
            parent.Enabled = true;
            Dispose(false);
        }

        public void StartMainForm()
        {
            CloseForm();
            parent.Dispose();
            new MainForm().Show();
        }
    }
}
