using Poker.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Poker
{
    public partial class ChoosePlayerForm : Form
    {
        public ChooseTypeForm parent;
        public string selected;
        public ChoosePlayerForm(ChooseTypeForm parent, JArray names)
        {
            this.parent = parent;
            parent.Enabled = false;
            InitializeComponent();
            int i = 1;
            foreach (string name in names) {
                if (!name.Equals(Const.user.username))
                {
                    RadioButton radioButton = new RadioButton();
                    radioButton.AutoSize = true;
                    radioButton.Location = new Point(50, 45 * i);
                    radioButton.TabIndex = 0;
                    radioButton.TabStop = true;
                    radioButton.Text = name;
                    radioButton.UseVisualStyleBackColor = true;
                    radioButton.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
                    Controls.Add(radioButton);
                    if (i == 1)
                    {
                        radioButton.Select();
                        selected = name;
                    }
                    i = i + 1;
                }
            }
            
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                selected = ((RadioButton)sender).Text;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Dispose(false);
            parent.Enabled = true;
        }

        private void commitButton_Click(object sender, EventArgs e)
        {
            Dispose(false);
            parent.Dispose();
            parent.parent.Enabled = true;
            parent.parent.mainPanel.lookButton.Enabled = false;
            parent.parent.mainPanel.throwButton.Enabled = false;
            parent.parent.mainPanel.haveButton.Enabled = false;
            new Thread(() =>
            {
                HttpService.have(parent.minMoney * 3, 2, selected);
            }).Start();      
        }
    }
}
