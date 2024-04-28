using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Dialogs
{
    public partial class dlgInput : Form
    {
        private string inputText;

        public string InputText
        {
            get { return inputText; }
            set { inputText = value; }
        }

        private bool enter;

        public dlgInput(bool enterActive)
        {
            InitializeComponent();
            this.enter = enterActive;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.inputText = this.textBox1.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button2_Click(null, null);
            }
        }
    }
}
