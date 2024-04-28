using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Forms
{
    public partial class frmEntry : Form
    {
        public frmEntry()
        {
            InitializeComponent();
        }

        public frmEntry(string text, FormStartPosition position)
        {
            InitializeComponent();

            this.Text = text;
            this.StartPosition = position;
        }

        public frmEntry(string text,FormStartPosition position,string[] tabCaption)
        {
            InitializeComponent();

            this.Text = text;
            this.StartPosition = position;

            if (tabCaption != null)
            {
                if (tabCaption.Length == 2)
                {
                    this.tabPage1.Text = tabCaption[0];
                    this.tabPage2.Text = tabCaption[1];
                }
            }
        }

        private void frmEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
