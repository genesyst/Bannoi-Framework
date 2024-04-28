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
    public partial class uc_topFilterTools : UserControl
    {
        #region properties
        [Category("bannoi Options")]
        private bool bnsisAddNewButton;
        public bool bnsIsAddNewButton
        {
            get { return bnsisAddNewButton; }
            set { bnsisAddNewButton = value;
            this.addnewBTN.Visible = bnsisAddNewButton;
            }
        }

        [Category("bannoi Options")]
        private bool bnsisRefreshButton;
        public bool bnsIsRefreshButton
        {
            get { return bnsisRefreshButton; }
            set { bnsisRefreshButton = value;
            this.refreshBTN.Visible = bnsisRefreshButton;
            }
        }

        [Category("bannoi Options")]
        private bool bnsisFindButton;
        public bool bnsIsFindButton
        {
            get { return bnsisFindButton; }
            set { bnsisFindButton = value;
            this.findBTN.Visible = bnsisFindButton;
            }
        }

        [Category("bannoi Options")]
        private string bnsfindValue;
        public string bnsFindValue
        {
            get {
                bnsfindValue = this.findTxt.Text.Trim();
                return bnsfindValue; }
            set { bnsfindValue = value;
            this.findTxt.Text = bnsfindValue;
            }
        }

        [Category("bannoi Options")]
        private Font bnsfindValueSetFont;
        public Font bnsFindValueSetFont
        {
            get { return bnsfindValueSetFont; }
            set { bnsfindValueSetFont = value;
            this.findTxt.Font = bnsfindValueSetFont;
            }
        }

        [Category("bannoi Options")]
        private Color bnsfindValueSetFontColor;
        public Color bnsFindValueSetFontColor
        {
            get { return bnsfindValueSetFontColor; }
            set { bnsfindValueSetFontColor = value;
            this.findTxt.ForeColor = bnsfindValueSetFontColor;
            }
        }

        
        [Category("bannoi Options")]
        private int activeFindForCharectorCount = 3;
        public int bnsActiveFindForMinimumCount
        {
            get { return activeFindForCharectorCount; }
            set { activeFindForCharectorCount = value; }
        }

        #endregion

        #region event handler
        [Category("bannoi Actions")]
        public event EventHandler bnsFindButtonClick;
        protected virtual void findBTN_Click(object sender, EventArgs e)
        {
            if (bnsFindButtonClick != null)
                bnsFindButtonClick(this, e);
        }

        [Category("bannoi Actions")]
        public event EventHandler bnsRefreshButtonClick;
        protected virtual void refreshBTN_Click(object sender, EventArgs e)
        {
            if (bnsRefreshButtonClick != null)
                bnsRefreshButtonClick(this, e);
        }

        [Category("bannoi Actions")]
        public event EventHandler bnsAddNewButtonClick;
        protected virtual void addnewBTN_Click(object sender, EventArgs e)
        {
            if (bnsAddNewButtonClick != null)
                bnsAddNewButtonClick(this, e);
        }

        [Category("bannoi Actions")]
        public event EventHandler bnsFindValueChanged;
        protected virtual void findTxt_TextChanged(object sender, EventArgs e)
        {
            if (this.findTxt.Text.Length > this.activeFindForCharectorCount)
            {
                if (bnsFindValueChanged != null)
                    bnsFindValueChanged(this, e);
            }
        }

        [Category("bannoi Actions")]
        public event EventHandler bnsEnterFindValue;
        protected virtual void findTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bnsEnterFindValue != null)
                    bnsEnterFindValue(this, e);
            }
            
        }

        #endregion

        public uc_topFilterTools()
        {
            InitializeComponent();

            this.Dock = DockStyle.Top;
        }
    }
}
