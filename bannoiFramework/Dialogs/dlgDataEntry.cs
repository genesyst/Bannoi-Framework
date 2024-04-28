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
    public partial class dlgDataEntry : Form
    {
        public dlgDataEntry()
        {
            InitializeComponent();
        }

        public dlgDataEntry(string text,FormBorderStyle formStyle)
        {
            InitializeComponent();

            this.Text = text.Trim();
            this.FormBorderStyle = formStyle;
        }

        public dlgDataEntry(string text, FormBorderStyle formStyle,string[] tabCaption)
        {
            InitializeComponent();

            this.Text = text.Trim();
            this.FormBorderStyle = formStyle;
            if (tabCaption.Length == 2)
            {
                this.tabPage1.Text = tabCaption[0];
                this.tabPage2.Text = tabCaption[1];
            }
        }

        private void dlgDataEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
