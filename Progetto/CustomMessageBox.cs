using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progetto
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(string msg)
        {
            Message = msg;

            InitializeComponent();
        }

        public string Message { get; }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {
            labelCustomBox.Text = Message;
        }

        private void buttonCustomBox_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
