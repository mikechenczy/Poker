
namespace Poker.View
{
    partial class EnterPasswordDialog
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
            parent.enterPasswordDialog = null;
            parent.Enabled = true;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commitButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.pleaseEnterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // commitButton
            // 
            this.commitButton.Location = new System.Drawing.Point(172, 115);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(75, 23);
            this.commitButton.TabIndex = 0;
            this.commitButton.Text = "确认";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(110, 61);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(195, 23);
            this.passwordTextBox.TabIndex = 1;
            // 
            // pleaseEnterLabel
            // 
            this.pleaseEnterLabel.AutoSize = true;
            this.pleaseEnterLabel.Location = new System.Drawing.Point(155, 18);
            this.pleaseEnterLabel.Name = "pleaseEnterLabel";
            this.pleaseEnterLabel.Size = new System.Drawing.Size(105, 14);
            this.pleaseEnterLabel.TabIndex = 2;
            this.pleaseEnterLabel.Text = "请输入房间密码";
            // 
            // EnterPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 162);
            this.Controls.Add(this.pleaseEnterLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.commitButton);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EnterPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请输入房间密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label pleaseEnterLabel;
    }
}