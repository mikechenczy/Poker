
namespace Poker.View
{
    partial class MainPanel
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
            this.userPanel = new System.Windows.Forms.Panel();
            this.throwButton = new System.Windows.Forms.Button();
            this.lookButton = new System.Windows.Forms.Button();
            this.readyButton = new System.Windows.Forms.Button();
            this.yourCards = new System.Windows.Forms.Label();
            this.moneyOnTable = new System.Windows.Forms.Label();
            this.currentPlayer = new System.Windows.Forms.Label();
            this.card3Label = new System.Windows.Forms.Label();
            this.card2Label = new System.Windows.Forms.Label();
            this.card1Label = new System.Windows.Forms.Label();
            this.haveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userPanel
            // 
            this.userPanel.AutoScroll = true;
            this.userPanel.Location = new System.Drawing.Point(0, 53);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(799, 123);
            this.userPanel.TabIndex = 21;
            // 
            // throwButton
            // 
            this.throwButton.Location = new System.Drawing.Point(388, 342);
            this.throwButton.Name = "throwButton";
            this.throwButton.Size = new System.Drawing.Size(75, 23);
            this.throwButton.TabIndex = 20;
            this.throwButton.Text = "弃牌";
            this.throwButton.UseVisualStyleBackColor = true;
            this.throwButton.Visible = false;
            this.throwButton.Click += new System.EventHandler(this.throwButton_Click);
            // 
            // lookButton
            // 
            this.lookButton.Location = new System.Drawing.Point(275, 342);
            this.lookButton.Name = "lookButton";
            this.lookButton.Size = new System.Drawing.Size(75, 23);
            this.lookButton.TabIndex = 19;
            this.lookButton.Text = "看牌";
            this.lookButton.UseVisualStyleBackColor = true;
            this.lookButton.Visible = false;
            this.lookButton.Click += new System.EventHandler(this.lookButton_Click);
            // 
            // readyButton
            // 
            this.readyButton.Location = new System.Drawing.Point(344, 194);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(75, 23);
            this.readyButton.TabIndex = 18;
            this.readyButton.Text = "准备";
            this.readyButton.UseVisualStyleBackColor = true;
            this.readyButton.Click += new System.EventHandler(this.readyButton_Click);
            // 
            // yourCards
            // 
            this.yourCards.AutoSize = true;
            this.yourCards.Location = new System.Drawing.Point(190, 283);
            this.yourCards.Name = "yourCards";
            this.yourCards.Size = new System.Drawing.Size(47, 12);
            this.yourCards.TabIndex = 17;
            this.yourCards.Text = "你的牌:";
            // 
            // moneyOnTable
            // 
            this.moneyOnTable.AutoSize = true;
            this.moneyOnTable.Location = new System.Drawing.Point(430, 38);
            this.moneyOnTable.Name = "moneyOnTable";
            this.moneyOnTable.Size = new System.Drawing.Size(83, 12);
            this.moneyOnTable.TabIndex = 16;
            this.moneyOnTable.Text = "桌面上的豆子:";
            // 
            // currentPlayer
            // 
            this.currentPlayer.AutoSize = true;
            this.currentPlayer.Location = new System.Drawing.Point(234, 38);
            this.currentPlayer.Name = "currentPlayer";
            this.currentPlayer.Size = new System.Drawing.Size(59, 12);
            this.currentPlayer.TabIndex = 14;
            this.currentPlayer.Text = "当前发话:";
            // 
            // card3Label
            // 
            this.card3Label.Image = global::Poker.Properties.Resources.背面;
            this.card3Label.Location = new System.Drawing.Point(450, 248);
            this.card3Label.Name = "card3Label";
            this.card3Label.Size = new System.Drawing.Size(60, 90);
            this.card3Label.TabIndex = 24;
            this.card3Label.Visible = false;
            // 
            // card2Label
            // 
            this.card2Label.Image = global::Poker.Properties.Resources.背面;
            this.card2Label.Location = new System.Drawing.Point(359, 248);
            this.card2Label.Name = "card2Label";
            this.card2Label.Size = new System.Drawing.Size(60, 90);
            this.card2Label.TabIndex = 23;
            this.card2Label.Visible = false;
            // 
            // card1Label
            // 
            this.card1Label.AllowDrop = true;
            this.card1Label.Image = global::Poker.Properties.Resources.背面;
            this.card1Label.Location = new System.Drawing.Point(266, 248);
            this.card1Label.Name = "card1Label";
            this.card1Label.Size = new System.Drawing.Size(60, 90);
            this.card1Label.TabIndex = 22;
            this.card1Label.Visible = false;
            this.card1Label.Click += new System.EventHandler(this.card1Label_Click);
            this.card1Label.DragEnter += new System.Windows.Forms.DragEventHandler(this.card1Label_DragEnter);
            this.card1Label.DragLeave += new System.EventHandler(this.card1Label_DragLeave);
            this.card1Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.card1Label_Down);
            this.card1Label.MouseEnter += new System.EventHandler(this.card1Label_Enter);
            this.card1Label.MouseLeave += new System.EventHandler(this.card1Label_Leave);
            this.card1Label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.card1Label_Up);
            this.card1Label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.card1Label_MouseMove);
            // 
            // haveButton
            // 
            this.haveButton.Location = new System.Drawing.Point(500, 342);
            this.haveButton.Name = "haveButton";
            this.haveButton.Size = new System.Drawing.Size(75, 23);
            this.haveButton.TabIndex = 25;
            this.haveButton.Text = "要";
            this.haveButton.UseVisualStyleBackColor = true;
            this.haveButton.Visible = false;
            this.haveButton.Click += new System.EventHandler(this.haveButton_Click);
            // 
            // MainPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.haveButton);
            this.Controls.Add(this.card3Label);
            this.Controls.Add(this.card2Label);
            this.Controls.Add(this.card1Label);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.throwButton);
            this.Controls.Add(this.lookButton);
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.yourCards);
            this.Controls.Add(this.moneyOnTable);
            this.Controls.Add(this.currentPlayer);
            this.Name = "MainPanel";
            this.Size = new System.Drawing.Size(799, 391);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label card3Label;
        public System.Windows.Forms.Label card2Label;
        public System.Windows.Forms.Label card1Label;
        public System.Windows.Forms.Panel userPanel;
        public System.Windows.Forms.Button throwButton;
        public System.Windows.Forms.Button lookButton;
        public System.Windows.Forms.Button readyButton;
        public System.Windows.Forms.Label yourCards;
        public System.Windows.Forms.Label moneyOnTable;
        public System.Windows.Forms.Label currentPlayer;
        public System.Windows.Forms.Button haveButton;
    }
}
