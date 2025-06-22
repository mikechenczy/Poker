
namespace Poker.View
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.registerLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordAgainlabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordAgainTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.codeButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorMessage = new System.Windows.Forms.Label();
            this.privacyLabel = new System.Windows.Forms.LinkLabel();
            this.registerForPrivacyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.registerLabel.Location = new System.Drawing.Point(172, 19);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(47, 19);
            this.registerLabel.TabIndex = 0;
            this.registerLabel.Text = "注册";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(66, 57);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(63, 14);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "用户名: ";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(69, 98);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(49, 14);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "密码: ";
            // 
            // passwordAgainlabel
            // 
            this.passwordAgainlabel.AutoSize = true;
            this.passwordAgainlabel.Location = new System.Drawing.Point(69, 137);
            this.passwordAgainlabel.Name = "passwordAgainlabel";
            this.passwordAgainlabel.Size = new System.Drawing.Size(105, 14);
            this.passwordAgainlabel.TabIndex = 3;
            this.passwordAgainlabel.Text = "再次输入密码: ";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(69, 179);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(49, 14);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "邮箱: ";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(69, 222);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(63, 14);
            this.codeLabel.TabIndex = 5;
            this.codeLabel.Text = "验证码: ";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(176, 57);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(166, 23);
            this.usernameTextBox.TabIndex = 6;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(176, 98);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(166, 23);
            this.passwordTextBox.TabIndex = 7;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordAgainTextBox
            // 
            this.passwordAgainTextBox.Location = new System.Drawing.Point(176, 137);
            this.passwordAgainTextBox.Name = "passwordAgainTextBox";
            this.passwordAgainTextBox.Size = new System.Drawing.Size(166, 23);
            this.passwordAgainTextBox.TabIndex = 8;
            this.passwordAgainTextBox.UseSystemPasswordChar = true;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(176, 179);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(166, 23);
            this.emailTextBox.TabIndex = 9;
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(176, 222);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(166, 23);
            this.codeTextBox.TabIndex = 10;
            // 
            // codeButton
            // 
            this.codeButton.Location = new System.Drawing.Point(87, 274);
            this.codeButton.Name = "codeButton";
            this.codeButton.Size = new System.Drawing.Size(216, 33);
            this.codeButton.TabIndex = 11;
            this.codeButton.Text = "获取验证码";
            this.codeButton.UseVisualStyleBackColor = true;
            this.codeButton.Click += new System.EventHandler(this.codeButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(87, 313);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(216, 30);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "注册";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(87, 349);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(216, 32);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(72, 388);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(42, 16);
            this.errorMessage.TabIndex = 14;
            this.errorMessage.Text = "错误";
            this.errorMessage.Visible = false;
            // 
            // privacyLabel
            // 
            this.privacyLabel.AutoSize = true;
            this.privacyLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.privacyLabel.Location = new System.Drawing.Point(226, 416);
            this.privacyLabel.Name = "privacyLabel";
            this.privacyLabel.Size = new System.Drawing.Size(63, 14);
            this.privacyLabel.TabIndex = 15;
            this.privacyLabel.TabStop = true;
            this.privacyLabel.Text = "用户协议";
            this.privacyLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.privacyLabel_LinkClicked);
            // 
            // registerForPrivacyLabel
            // 
            this.registerForPrivacyLabel.AutoSize = true;
            this.registerForPrivacyLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.registerForPrivacyLabel.Location = new System.Drawing.Point(114, 416);
            this.registerForPrivacyLabel.Name = "registerForPrivacyLabel";
            this.registerForPrivacyLabel.Size = new System.Drawing.Size(105, 14);
            this.registerForPrivacyLabel.TabIndex = 16;
            this.registerForPrivacyLabel.Text = "注册即代表同意";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 457);
            this.Controls.Add(this.privacyLabel);
            this.Controls.Add(this.registerForPrivacyLabel);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.codeButton);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.passwordAgainTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.passwordAgainlabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.registerLabel);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label passwordAgainlabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox passwordAgainTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.Button codeButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.LinkLabel privacyLabel;
        private System.Windows.Forms.Label registerForPrivacyLabel;
    }
}