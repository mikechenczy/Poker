using Newtonsoft.Json.Linq;
using Poker.Model;
using Poker.Service;
using Poker.Utils;
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
    public partial class RegisterForm : Form
    {
        public LoginForm form;

        public RegisterForm(LoginForm form)
        {
            this.form = form;
            form.Enabled = false;
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            form.Enabled = true;
        }

        private void codeButton_Click(object sender, EventArgs e)
        {
            if (codeButton.Enabled)
            {
                codeButton.Enabled = false;
                bool success = false;
                string email = emailTextBox.Text;
                if (StringUtil.isEmail(email))
                {
                    errorMessage.Visible = false;
                    Dictionary<string, string> map = new Dictionary<string, string>();
                    map.Add("email", email);
                    map.Add("getCode", "1");
                    User user = HttpService.register(map);
                    if (user == null)
                    {
                        showErrorMessage("无法连接至服务器");
                    }
                    else if (string.IsNullOrEmpty(user.username)) {
                        switch (user.userId)
                        {
                            case 1:
                                showErrorMessage("数据格式有误");
                                break;
                            case 2:
                                showErrorMessage("此用户名已注册");
                                break;
                            case 3:
                                showErrorMessage("此邮箱已注册");
                                break;
                            case 4:
                                success = true;
                                break;
                            case 5:
                                showErrorMessage("验证码错误");
                                break;
                            default:
                                showErrorMessage("无法解析返回数据");
                                break;
                        }
                    }
                    else
                    {
                        Dispose(false);
                        form.StartMainForm(); 
                    }
                }
                else
                    showErrorMessage("邮箱格式错误，现只支持通用邮箱");
                if (!success)
                    codeButton.Enabled = true;
                else
                    new Thread(() => {
                        for (int i = 60; i > 0; i--)
                        {
                            try
                            {
                                BeginInvoke(new MethodInvoker(() =>
                                {
                                    codeButton.Text = "请等待" + i + "秒后重新发送";
                                }));
                            }
                            catch (InvalidOperationException error)
                            {

                            }
                            Thread.Sleep(1000);
                        }
                        try
                        {
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                codeButton.Text = "获取验证码";
                                codeButton.Enabled = true;
                            }));
                        }
                        catch (InvalidOperationException error)
                        {

                        }
                    }).Start();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            register();
        }

        private void register()
        {
            if (okButton.Enabled)
            {
                okButton.Enabled = false;
                if (!form.readUpdate)
                {
                    JObject json = HttpService.needUpdate();
                    form.readUpdate = true;
                    if (json == null)
                    {
                        form.readUpdate = false;
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
                        }
                    }
                    okButton.Enabled = true;
                    return;
                }
                if (!form.readMessage)
                {
                    string messageContent = HttpService.getMessageContent();
                    if (messageContent == null)
                        MessageBox.Show("无法连接至服务器", "无法连接至服务器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        form.readMessage = true;
                        if (!(messageContent.Equals(Const.neverShowMessageDialog) || messageContent.Equals("No message")))
                        {
                            new MessageForm(this, messageContent).Show();
                        }
                        else
                        {
                            register();
                        }
                    }
                    okButton.Enabled = true;
                    return;
                }
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string passwordAgain = passwordAgainTextBox.Text;
                string email = emailTextBox.Text;
                string code = codeTextBox.Text;
                if (StringUtil.check(username, password))
                {
                    if (password.Equals(passwordAgain))
                    {
                        if (StringUtil.isEmail(email))
                        {
                            if (code.Length == 4)
                            {
                                errorMessage.Visible = false;
                                Dictionary<string, string> map = new Dictionary<string, string>();
                                map.Add("username", username);
                                map.Add("password", password);
                                map.Add("email", email);
                                map.Add("code", code);
                                User user = HttpService.register(map);
                                if (user == null)
                                {
                                    showErrorMessage("无法连接至服务器");
                                }
                                else if (string.IsNullOrEmpty(user.username))
                                {
                                    switch (user.userId)
                                    {
                                        case 0:
                                            break;
                                        case 1:
                                            showErrorMessage("数据格式有误");
                                            break;
                                        case 2:
                                            showErrorMessage("此用户名已注册");
                                            break;
                                        case 3:
                                            showErrorMessage("此邮箱已注册");
                                            break;
                                        case 4:
                                            showErrorMessage("需要验证码");
                                            break;
                                        case 5:
                                            showErrorMessage("验证码错误");
                                            break;
                                        default:
                                            showErrorMessage("无法解析返回数据");
                                            break;
                                    }
                                }
                                else
                                {
                                    Dispose(false);
                                    form.StartMainForm();
                                }
                            }
                            else
                                showErrorMessage("验证码格式错误");
                        }
                        else
                            showErrorMessage("邮箱格式错误，现只支持通用邮箱");
                    }
                    else
                        showErrorMessage("密码不一致");
                }
                else
                    showErrorMessage("用户名或密码格式错误");
                okButton.Enabled = true;
            }
        }

        public void showErrorMessage(string message)
        {
            errorMessage.Text = message;
            errorMessage.Visible = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            form.Enabled = true;
            Dispose(false);
        }

        private void privacyLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("        本软件只适用于小型场景娱乐使用\n" +
                        "        本软件不支持任何的充值或提现\n" +
                        "        严禁用本软件进行赌博行为\n" +
                        "        如造成法律责任，本软件概不负责", "用户协议", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
