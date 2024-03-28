using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMqSim
{
    public partial class AddMessageDialog : Form
    {
        public string MessageName { get; set; }
        public AddMessageDialog()
        {
            InitializeComponent();
        }

        private void BtnAddMsg_Click(object sender, EventArgs e)
        {
            MessageName = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
