using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.CTRL
{
    public partial class uc_touchNumber : UserControl
    {
        #region members class
        private string resultTxt;

        public string ResultTxt
        {
            get { return resultTxt; }
            set { resultTxt = value; }
        }

        #endregion

        public uc_touchNumber()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.resultTxt += ((Button)sender).Text.Trim();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string dot = this.resultTxt += ((Button)sender).Text.Trim();
            if (this.resultTxt.IndexOf(dot) > -1)
            {
                this.resultTxt += dot;
            }
        }
    }
}
