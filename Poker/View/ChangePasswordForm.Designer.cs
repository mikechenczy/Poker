
namespace Poker.View
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.cfLabel = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordAgainTextBox = new System.Windows.Forms.TextBox();
            this.codeButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorMessage = new System.Windows.Forms.Label();
            this.codeLabel = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cfLabel
            // 
            this.cfLabel.AutoSize = true;
            this.cfLabel.Location = new System.Drawing.Point(158, 21);
            this.cfLabel.Name = "cfLabel";
            this.cfLabel.Size = new System.Drawing.Size(72, 16);
            this.cfLabel.TabIndex = 0;
            this.cfLabel.Text = "修改密码";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(27, 61);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(120, 16);
            this.username.TabIndex = 1;
            this.username.Text = "用户名或邮箱: ";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(153, 58);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(186, 26);
            this.usernameTextBox.TabIndex = 2;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(27, 112);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(64, 16);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "新密码:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(153, 112);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(186, 26);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "再次输入新密码:";
            // 
            // passwordAgainTextBox
            // 
            this.passwordAgainTextBox.Location = new System.Drawing.Point(153, 161);
            this.passwordAgainTextBox.Name = "passwordAgainTextBox";
            this.passwordAgainTextBox.Size = new System.Drawing.Size(186, 26);
            this.passwordAgainTextBox.TabIndex = 6;
            this.passwordAgainTextBox.UseSystemPasswordChar = true;
            // 
            // codeButton
            // 
            this.codeButton.Location = new System.Drawing.Point(91, 248);
            this.codeButton.Name = "codeButton";
            this.codeButton.Size = new System.Drawing.Size(203, 35);
            this.codeButton.TabIndex = 7;
            this.codeButton.Text = "获取验证码";
            this.codeButton.UseVisualStyleBackColor = true;
            this.codeButton.Click += new System.EventHandler(this.codeButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(91, 289);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(203, 32);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.okButton_MouseClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(91, 327);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(203, 31);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(65, 369);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(42, 16);
            this.errorMessage.TabIndex = 10;
            this.errorMessage.Text = "错误";
            this.errorMessage.Visible = false;
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(27, 209);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(72, 16);
            this.codeLabel.TabIndex = 11;
            this.codeLabel.Text = "验证码: ";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(153, 206);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(186, 26);
            this.codeTextBox.TabIndex = 12;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 409);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.codeButton);
            this.Controls.Add(this.passwordAgainTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.username);
            this.Controls.Add(this.cfLabel);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cfLabel;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordAgainTextBox;
        private System.Windows.Forms.Button codeButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox codeTextBox;
    }
}