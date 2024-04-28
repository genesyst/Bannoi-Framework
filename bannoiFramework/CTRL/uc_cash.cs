using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bannoiFramework.Services;

namespace bannoiFramework.CTRL
{
    public partial class uc_cash : UserControl
    {
        #region members
        private string cashFormat;

        public string CashFormat
        {
            get { return cashFormat; }
            set { cashFormat = value; }
        }

        private bool isDecimalCash;

        public bool IsDecimalCash
        {
            get { return isDecimalCash; }
            set { 
                isDecimalCash = value;
                if (!this.isDecimalCash)
                    this.button12.Enabled = false;
                else
                    this.button12.Enabled = true;
            }
        }

        private decimal cash=0;
        private string valueTxt;
        #endregion

        public uc_cash()
        {
            InitializeComponent();

            this.textBox3.Text = "";
            
        }

        public void setCashValues(decimal[] cashValue)
        {
            try
            {
                this.textBox2.Text = "";
                if (cashValue.Length == 2)
                {
                    this.textBox1.Text = cashValue[0].ToString(this.cashFormat);
                    if (cashValue[1] > 0)
                        this.textBox2.Text = cashValue[1].ToString(this.cashFormat);
                }
            }
            catch { throw; }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string btnCaption = ((Button)sender).Text.Trim();

                if (btnCaption == ".")
                {
                    if (this.textBox2.Text.IndexOf(".") != -1)
                        this.valueTxt += btnCaption;

                }
                else
                {
                    this.valueTxt += btnCaption;
                }

                this.textBox2.Text = this.valueTxt;
                this.cash = Convert.ToDecimal(this.textBox2.Text);

                this.textBox2.Text = this.cash.ToString(this.cashFormat);

                this.textBox3.Text = this.changeValue(this.cash).ToString(this.cashFormat);
            }
            catch { throw; }
        }

        private decimal changeValue(decimal chg)
        {
            decimal Res = 0;
            try
            {
                Res = chg - Convert.ToDecimal(this.textBox1.Text.Replace(",",""));
            }
            catch { throw; }
            return Res;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.button12.Enabled)
                bnsServiceControl.isHandleDecimalOnly(sender, e);
            else
                e.Handled = bnsServiceControl.isHandleNumberOnly(e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.valueTxt = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }

        public decimal[] getCashValues()
        {
            decimal[] cashValues = new decimal[3];
            if (!String.IsNullOrEmpty(this.textBox1.Text))
                cashValues[0] = Convert.ToDecimal(this.textBox1.Text);
            if (!String.IsNullOrEmpty(this.textBox2.Text))
                cashValues[1] = Convert.ToDecimal(this.textBox2.Text);
            if (!String.IsNullOrEmpty(this.textBox3.Text))
                cashValues[2] = Convert.ToDecimal(this.textBox3.Text);

            return cashValues;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal cash = 0;
                string cashValue = this.textBox2.Text;
                if (!String.IsNullOrEmpty(cashValue))
                {
                    cash = Convert.ToDecimal(cashValue.Replace(",", ""));
                    this.textBox2.Text = cash.ToString(this.cashFormat);

                    this.textBox3.Text = this.changeValue(cash).ToString(this.cashFormat);
                }
            }
            catch { throw; }
        }
    }
}
