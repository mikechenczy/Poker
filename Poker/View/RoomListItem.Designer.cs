
namespace Poker.View
{
    partial class RoomListItem
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.playerCountLabel = new System.Windows.Forms.Label();
            this.noPasswordLabel = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(28, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 14);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "标题";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(28, 41);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(35, 14);
            this.descriptionLabel.TabIndex = 1;
            this.descriptionLabel.Text = "描述";
            // 
            // playerCountLabel
            // 
            this.playerCountLabel.AutoSize = true;
            this.playerCountLabel.Location = new System.Drawing.Point(298, 40);
            this.playerCountLabel.Name = "playerCountLabel";
            this.playerCountLabel.Size = new System.Drawing.Size(49, 14);
            this.playerCountLabel.TabIndex = 2;
            this.playerCountLabel.Text = "人数：";
            // 
            // noPasswordLabel
            // 
            this.noPasswordLabel.AutoSize = true;
            this.noPasswordLabel.Location = new System.Drawing.Point(284, 14);
            this.noPasswordLabel.Name = "noPasswordLabel";
            this.noPasswordLabel.Size = new System.Drawing.Size(63, 14);
            this.noPasswordLabel.TabIndex = 3;
            this.noPasswordLabel.Text = "没有密码";
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(364, 20);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(51, 23);
            this.enterButton.TabIndex = 4;
            this.enterButton.Text = "加入";
            this.enterButton.UseVisualStyleBackColor = true;
            // 
            // RoomListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.noPasswordLabel);
            this.Controls.Add(this.playerCountLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "RoomListItem";
            this.Size = new System.Drawing.Size(436, 68);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label titleLabel;
        public System.Windows.Forms.Label descriptionLabel;
        public System.Windows.Forms.Label playerCountLabel;
        public System.Windows.Forms.Label noPasswordLabel;
        public System.Windows.Forms.Button enterButton;
    }
}
