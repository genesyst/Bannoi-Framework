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
    public partial class bnsTextBoxLookUp : TextBox
    {
        #region declear object
        private AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
        #endregion

        #region properties
        private bool isNumberOnly=false;

        public bool bnsIsNumberOnly
        {
            get { return isNumberOnly; }
            set { isNumberOnly = value; }
        }

        [Category("bannoi Options")]
        private bool bnsvisibleButtonLookup = true;
        public bool bnsVisibleButtonLookup
        {
            get { return bnsvisibleButtonLookup; }
            set { bnsvisibleButtonLookup = value;
            this.ButtonLookup.Visible = bnsvisibleButtonLookup;
            }
        }

        //property hiding
        [Browsable(false)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public bool Multiline
        {
            get;
            set;
        }
        #endregion

        #region event handler
        [Category("bannoi Actions")]
        public event EventHandler bnsLookupClick;
        protected virtual void OnLookup_Click(object sender, EventArgs e)
        {
            if (bnsLookupClick != null)
                bnsLookupClick(this, e);
        }
        #endregion

        public bnsTextBoxLookUp()
        {
            InitializeComponent();

            this.ReadOnly = true;
            this.BackColor = SystemColors.Info;
            this.TextAlign = HorizontalAlignment.Left;
        }

        public void bnsSetAutoComplete(List<string> DataItems)
        {
            try
            {
                foreach (string itm in DataItems)
                    this.autoComplete.Add(itm);

                this.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.AutoCompleteCustomSource = this.autoComplete;
            }
            catch { throw; }
        }

        public void bnsSetAutoComplete(string[] DataItems)
        {
            try
            {
                foreach (string itm in DataItems)
                    this.autoComplete.Add(itm);

                this.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.AutoCompleteCustomSource = this.autoComplete;
            }
            catch { throw; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (this.isNumberOnly)
                e.Handled = bnsServiceControl.isHandleNumberOnly(e);

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Delete)
            {
                this.Text = "";
            }
        }
    }
}
