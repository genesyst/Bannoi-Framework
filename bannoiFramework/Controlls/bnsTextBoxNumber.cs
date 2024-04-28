using bannoiFramework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Controlls
{
    public partial class bnsTextBoxNumber : TextBox
    {
        #region properties
        private bool bnscomma=false;
        [Category("bannoi Options")]
        public bool bnsComma
        {
            get { return bnscomma; }
            set { bnscomma = value; }
        }

        private int bnsvalue=0;
        [Category("bannoi Options")]
        public int bnsValue
        {
            get
            {
                this.bnsvalue = this.getValue();
                return this.bnsvalue;
            }
        }
        #endregion

        #region event handle
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (int.TryParse(this.Text.Trim(), out this.bnsvalue))
            {
                if(this.bnscomma)
                    this.Text = this.bnsvalue.ToString("#,##");
                else
                    this.Text = this.bnsvalue.ToString();
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (String.IsNullOrEmpty(this.Text))
                this.Text = "0";
        }
        #endregion

        public bnsTextBoxNumber()
        {
            InitializeComponent();
            this.TextAlign = HorizontalAlignment.Right;
            this.Text = "0";
        }

        protected int getValue()
        {
            int Res = 0;
            string repComm = this.Text;
            if (String.IsNullOrEmpty(repComm)) repComm = "0";
            if (this.bnscomma)
            {
                if (!String.IsNullOrEmpty(this.Text))
                    repComm = repComm.Replace(",", "");
            }

            Res = Convert.ToInt32(repComm.Replace(",",""));
            return Res;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.bnscomma)
                e.Handled = bnsServiceControl.isHandleNumberNCommaOnly(e);
            else
                e.Handled = bnsServiceControl.isHandleNumberOnly(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
