using Poker.Service;
using Poker.Utils;
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
    public partial class ChangePasswordForm : Form
    {
        public Form form;
        public bool changeOrForget;
        public string currentUsername;
        public ChangePasswordForm(Form form, bool changeOrForget, string currentUsername)
        {
            this.form = form;
            this.changeOrForget = changeOrForget;
            this.currentUsername = currentUsername;
            form.Enabled = false;
            InitializeComponent();
            usernameTextBox.Text = currentUsername;
            if (!changeOrForget)
            {
                cfLabel.Text = "忘记密码";
            }
            Text = cfLabel.Text;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            form.Enabled = true;
        }

        private void codeButton_Click(object sender, EventArgs e)
        {
            if (codeButton.Enabled)
            {
                codeButton.Enabled = false;
                string username = usernameTextBox.Text;
                if (StringUtil.checkUsername(username) || StringUtil.isEmail(username))
                {
                    errorMessage.Visible = false;
                    bool success = false;
                    new Thread(() =>
                    {
                        int errno = HttpService.forgetPasswordEmail(username);
                        switch (errno)
                        {
                            case -1:
                                showErrorMessage("无法连接至服务器");
                                break;
                            case 0:
                                success = true;
                                new Thread(() =>
                                {
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
                                break;
                            case 1:
                                showErrorMessage("数据格式有误");
                                break;
                            case 2:
                                showErrorMessage("用户不存在");
                                break;
                            default:
                                showErrorMessage("无法解析返回数据");
                                break;
                        }
                        if (!success)
                        {
                            try
                            {
                                BeginInvoke(new MethodInvoker(() =>
                                {
                                    codeButton.Enabled = true;
                                }));
                            }
                            catch (InvalidOperationException error)
                            {

                            }
                        }
                    }).Start();
                }
                else
                {
                    showErrorMessage("用户名或邮箱格式错误，现只支持通用邮箱");
                    codeButton.Enabled = true;
                }
            }
        }

        public void showErrorMessage(string message)
        {
            try
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    errorMessage.Text = message;
                    errorMessage.Visible = true;
                }));
            }
            catch (InvalidOperationException error)
            {

            }
        }

        private void okButton_MouseClick(object sender, EventArgs e)
        {
            if (okButton.Enabled)
            {
                okButton.Enabled = false;
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                string passwordAgain = passwordAgainTextBox.Text;
                string code = codeTextBox.Text;
                if (StringUtil.check(password))
                {
                    if (password.Equals(passwordAgain))
                    {
                        if (code.Length == 4)
                        {
                            errorMessage.Visible = false;
                            Dictionary<string, string> map = new Dictionary<string, string>();
                            map.Add("username", username);
                            map.Add("password", password);
                            map.Add("code", code);
                            new Thread(() => {
                                int errno = HttpService.forgetPassword(map);
                                switch (errno)
                                {
                                    case 0:
                                        if (Const.user != null)
                                        {
                                            Const.user.password = password;
                                            new Thread(() => { DataUtil.save(); }).Start();
                                        }
                                        BeginInvoke(new MethodInvoker(() =>
                                        {
                                            form.Enabled = true;
                                            Dispose(false);
                                        }));
                                        MessageBox.Show("修改密码已成功", "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    case 1:
                                        showErrorMessage("数据格式有误");
                                        break;
                                    case 2:
                                        showErrorMessage("用户不存在");
                                        break;
                                    case 3:
                                        showErrorMessage("验证码错误");
                                        break;
                                    default:
                                        showErrorMessage("无法解析返回数据");
                                        break;
                                }
                            }).Start();
                        }
                        else
                            showErrorMessage("验证码格式错误");
                    }
                    else
                        showErrorMessage("密码不一致");
                }
                else
                    showErrorMessage("用户名或密码格式错误");
                okButton.Enabled = true;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            form.Enabled = true;
            Dispose(false);
        }
    }
}
