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
    public partial class bnsTextBoxDecimal : TextBox
    {
        #region properties
        private int bnsdecimalDigit = 2;
        [DefaultValue(2)]
        [Category("bannoi Options")]
        public int bnsDecimalDigit
        {
            get { return bnsdecimalDigit; }
            set { bnsdecimalDigit = value; }
        }

        private bool bnscomma = false;
        [Category("bannoi Options")]
        public bool bnsComma
        {
            get { return bnscomma; }
            set { bnscomma = value; }
        }

        private decimal bnsvalue = 0;
        [Category("bannoi Options")]
        public decimal bnsValue
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

            if (decimal.TryParse(this.Text.Trim(), out this.bnsvalue))
            {
                if (this.bnscomma)
                {
                    string formatDif = "";
                    while (this.bnsdecimalDigit > formatDif.Length)
                        formatDif += "0";

                    this.Text = this.bnsvalue.ToString("#,##0." + formatDif);
                }
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

        public bnsTextBoxDecimal()
        {
            InitializeComponent();
            this.TextAlign = HorizontalAlignment.Right;
            this.Text = "0";
        }

        protected decimal getValue()
        {
            decimal Res = 0;
            string repComm = this.Text;
            if (String.IsNullOrEmpty(repComm)) repComm = "0";
            if (this.bnscomma)
            {
                if (!String.IsNullOrEmpty(this.Text))
                    repComm = repComm.Replace(",", "");
            }

            Res = Convert.ToDecimal(repComm.Replace(",",""));
            return Res;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (this.bnscomma)
                bnsServiceControl.isHandleDecimalNCommaOnly(this.bnsdecimalDigit, this, e);
            else
                bnsServiceControl.isHandleDecimalOnly(this.bnsdecimalDigit, this, e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
