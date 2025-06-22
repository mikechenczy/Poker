using Poker.Model;
using Poker.Service;
using Poker.Utils;
using Poker.View;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Poker
{
    public partial class LoginForm : Form
    {

        public bool firstStart;
        public bool readUpdate;
        public bool readMessage;
        public LoginForm(bool firstStart)
        {
            this.firstStart = firstStart;
            InitializeComponent();
            if (Const.username != null)
            {
                usernameTextBox.Text = Const.username;
            }
            if (firstStart && Const.autoLogin && (Const.password != null))
            {
                passwordTextBox.Text = Const.password;
            }
            Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginButton.Enabled)
            {
                login();
            }
        }

        public void login()
        {
            if(!readUpdate)
            {
                JObject json = HttpService.needUpdate();
                readUpdate = true;
                if (json == null)
                {
                    readUpdate = false;
                    MessageBox.Show("无法连接至服务器", "无法连接至服务器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (json["force"] != null)
                {
                    if ((bool)json["force"])
                    {
                        if (DialogResult.Yes == MessageBox.Show("发现新版本:\n版本:" + (string)json["version"] + "\n更新内容:" + (string)json["description"] + "\n必须更新后使用，取消将退出程序，是否更新？", "有新版本", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            Dispose();
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
                            Dispose();
                            new UpdateForm(json).Show();
                        }
                        else
                        {
                            if (Const.autoLogin)
                            {
                                login();// WithNewThread();
                            }
                        }
                    }
                }
                else
                {
                    if (Const.autoLogin)
                    {
                        login();// WithNewThread();
                    }
                }
                loginButton.Enabled = true;
                return;
            }
            if (!readMessage)
            {
                string messageContent = HttpService.getMessageContent();
                if (messageContent == null)
                {
                    MessageBox.Show("无法连接至服务器", "无法连接至服务器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    readMessage = true;
                    if (!(messageContent.Equals(Const.neverShowMessageDialog) || messageContent.Equals("No message")))
                    {
                        new MessageForm(this, messageContent).Show();
                    }
                    else
                    {
                        if (Const.autoLogin)
                        {
                            login();
                        }
                    }
                }
                loginButton.Enabled = true;
                return;
            }
            loginButton.Enabled = false;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            if (StringUtil.check(username, password))
            {
                errorMessage.Visible = false;
                User user = HttpService.login(username, password);
                if (user == null)
                {
                    showErrorMessage("无法连接至服务器");
                }
                else if (string.IsNullOrEmpty(user.username)){
                    if (user.userId == 1)
                        showErrorMessage("用户名或密码格式错误");
                    else
                        showErrorMessage("用户名或密码错误");
                }else
                {
                    StartMainForm();
                }
            }
            else
                showErrorMessage("用户名或密码格式错误");
            loginButton.Enabled = true;
        }

        public void showErrorMessage(string message)
        {
            errorMessage.Text = message;
            errorMessage.Visible = true;
        }

        private void forgetPasswordLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new ChangePasswordForm(this, false, usernameTextBox.Text).Show();
        }

        private void privacyLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("        本软件只适用于小型场景娱乐使用\n" +
                        "        本软件不支持任何的充值或提现\n" +
                        "        严禁用本软件进行赌博行为\n" +
                        "        如造成法律责任，本软件概不负责", "用户协议", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            new RegisterForm(this).Show();
        }

        public void StartMainForm()
        {
            Dispose(false);
            //MainForm mainForm = new MainForm();
            //mainForm.Show();
            RoomsForm roomsForm = new RoomsForm();
            roomsForm.Show();
        }
    }
}
