
using System.Drawing;

namespace Poker
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.errorMessage = new System.Windows.Forms.Label();
            this.loginForPrivacyLabel = new System.Windows.Forms.Label();
            this.privacyLabel = new System.Windows.Forms.LinkLabel();
            this.forgetPasswordLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginLabel.Location = new System.Drawing.Point(170, 18);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(58, 24);
            this.loginLabel.TabIndex = 10;
            this.loginLabel.Text = "登录";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usernameLabel.Location = new System.Drawing.Point(39, 63);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(143, 19);
            this.usernameLabel.TabIndex = 9;
            this.usernameLabel.Text = "用户名或邮箱: ";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.usernameTextBox.Location = new System.Drawing.Point(174, 63);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(184, 23);
            this.usernameTextBox.TabIndex = 8;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordLabel.Location = new System.Drawing.Point(39, 120);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(57, 19);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "密码:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwordTextBox.Location = new System.Drawing.Point(174, 121);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(184, 23);
            this.passwordTextBox.TabIndex = 6;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton.Location = new System.Drawing.Point(113, 174);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(177, 37);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // registerButton
            // 
            this.registerButton.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.registerButton.Location = new System.Drawing.Point(113, 238);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(177, 37);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "注册";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(110, 289);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(42, 16);
            this.errorMessage.TabIndex = 3;
            this.errorMessage.Text = "错误";
            this.errorMessage.UseMnemonic = false;
            this.errorMessage.Visible = false;
            // 
            // loginForPrivacyLabel
            // 
            this.loginForPrivacyLabel.AutoSize = true;
            this.loginForPrivacyLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginForPrivacyLabel.Location = new System.Drawing.Point(113, 352);
            this.loginForPrivacyLabel.Name = "loginForPrivacyLabel";
            this.loginForPrivacyLabel.Size = new System.Drawing.Size(105, 14);
            this.loginForPrivacyLabel.TabIndex = 2;
            this.loginForPrivacyLabel.Text = "登录即代表同意";
            // 
            // privacyLabel
            // 
            this.privacyLabel.AutoSize = true;
            this.privacyLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.privacyLabel.Location = new System.Drawing.Point(225, 352);
            this.privacyLabel.Name = "privacyLabel";
            this.privacyLabel.Size = new System.Drawing.Size(63, 14);
            this.privacyLabel.TabIndex = 1;
            this.privacyLabel.TabStop = true;
            this.privacyLabel.Text = "用户协议";
            this.privacyLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.privacyLabel_LinkClicked);
            // 
            // forgetPasswordLabel
            // 
            this.forgetPasswordLabel.AutoSize = true;
            this.forgetPasswordLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.forgetPasswordLabel.Location = new System.Drawing.Point(165, 320);
            this.forgetPasswordLabel.Name = "forgetPasswordLabel";
            this.forgetPasswordLabel.Size = new System.Drawing.Size(63, 14);
            this.forgetPasswordLabel.TabIndex = 0;
            this.forgetPasswordLabel.TabStop = true;
            this.forgetPasswordLabel.Text = "忘记密码";
            this.forgetPasswordLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgetPasswordLabel_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 409);
            this.Controls.Add(this.forgetPasswordLabel);
            this.Controls.Add(this.privacyLabel);
            this.Controls.Add(this.loginForPrivacyLabel);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.loginLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.Label loginForPrivacyLabel;
        private System.Windows.Forms.LinkLabel privacyLabel;
        private System.Windows.Forms.LinkLabel forgetPasswordLabel;
    }
}

