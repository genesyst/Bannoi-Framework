using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Dialogs
{
    public partial class dlgTouchNumber : Form
    {
        private string numberResult;

        public string NumberResult
        {
            get { return numberResult; }
            set { numberResult = value; }
        }

        public dlgTouchNumber(bool isDecimal)
        {
            InitializeComponent();

            if (!isDecimal) this.uc_touchNumber1.button11.Visible = false;

            this.uc_touchNumber1.okBtn.Click += okBtn_Click;
            this.uc_touchNumber1.button12.Click += button12_Click;
        }

        void button12_Click(object sender, EventArgs e)
        {
            this.numberResult = "";
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        void okBtn_Click(object sender, EventArgs e)
        {
            this.numberResult = this.uc_touchNumber1.ResultTxt;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
