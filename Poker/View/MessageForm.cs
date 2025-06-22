using Poker.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker.View
{
    public partial class MessageForm : Form
    {
        public Form form;

        public MessageForm(Form form, string message)
        {
            this.form = form;
            form.Enabled = false;
            InitializeComponent();
            contentLabel.Text = message;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            form.Enabled = true;
            Dispose(false);
        }

        private void neverShowButton_Click(object sender, EventArgs e)
        {
            Const.neverShowMessageDialog = contentLabel.Text;
            DataUtil.save();
            form.Enabled = true;
            Dispose(false);
        }
    }
}
