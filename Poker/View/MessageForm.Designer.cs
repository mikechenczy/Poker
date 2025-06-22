
namespace Poker.View
{
    partial class MessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.okButton = new System.Windows.Forms.Button();
            this.neverShowButton = new System.Windows.Forms.Button();
            this.contentLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(49, 197);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(127, 27);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // neverShowButton
            // 
            this.neverShowButton.Location = new System.Drawing.Point(182, 197);
            this.neverShowButton.Name = "neverShowButton";
            this.neverShowButton.Size = new System.Drawing.Size(123, 27);
            this.neverShowButton.TabIndex = 1;
            this.neverShowButton.Text = "不再显示";
            this.neverShowButton.UseVisualStyleBackColor = true;
            this.neverShowButton.Click += new System.EventHandler(this.neverShowButton_Click);
            // 
            // contentLabel
            // 
            this.contentLabel.Location = new System.Drawing.Point(31, 43);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(294, 137);
            this.contentLabel.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(155, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(40, 16);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "公告";
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 243);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.contentLabel);
            this.Controls.Add(this.neverShowButton);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MessageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公告";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button neverShowButton;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}