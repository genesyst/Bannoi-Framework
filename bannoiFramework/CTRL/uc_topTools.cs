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
    public partial class uc_topTools : UserControl
    {
        #region properties
        private dbStatus bnsdbStatus = dbStatus.dbNone;

        [Category("bannoi Options")]
        public dbStatus bnsDBStatus
        {
            get { return bnsdbStatus; }
            set
            {
                bnsdbStatus = value;
                this.setButtonWithStatus();
            }
        }

        [Category("bannoi Options")]
        private bool bnsisAddNewButton;
        public bool bnsIsAddNewButton
        {
            get { return bnsisAddNewButton; }
            set { bnsisAddNewButton = value; 
                this.addnewBTN.Visible = bnsisAddNewButton; }
        }

        [Category("bannoi Options")]
        private bool bnsisSaveButton;
        public bool bnsIsSaveButton
        {
            get { return bnsisSaveButton; }
            set { bnsisSaveButton = value;
            this.saveBTN.Visible = bnsisSaveButton;
            }
        }

        [Category("bannoi Options")]
        private bool bnsisEditButton;
        public bool bnsIsEditButton
        {
            get { return bnsisEditButton; }
            set { bnsisEditButton = value;
            this.editBTN.Visible = bnsisEditButton;
            }
        }

        [Category("bannoi Options")]
        private bool bnsisCancelButton;
        public bool bnsIsCancelButton
        {
            get { return bnsisCancelButton; }
            set { bnsisCancelButton = value;
            this.cancelBTN.Visible = bnsisCancelButton;
            }
        }

        [Category("bannoi Options")]
        private bool bnsisDeleteButton;
        public bool bnsIsDeleteButton
        {
            get { return bnsisDeleteButton; }
            set { bnsisDeleteButton = value;
            this.delBTN.Visible = bnsisDeleteButton;
            }
        }
        #endregion

        #region event handler
        [Category("bannoi Actions")]
        public event EventHandler bnsAddNewButtonClick;
        protected virtual void addnewBTN_Click(object sender, EventArgs e)
        {
            if (bnsAddNewButtonClick != null)
                bnsAddNewButtonClick(this, e);
        }

        [Category("bannoi Actions")]
        public event EventHandler bnsEditButtonClick;
        protected virtual void editBTN_Click(object sender, EventArgs e)
        {
            if (bnsEditButtonClick != null)
                bnsEditButtonClick(this, e);
        }

        [Category("bannoi Actions")]
        public event EventHandler bnsSaveButtonClick;
        protected virtual void saveBTN_Click(object sender, EventArgs e)
        {
            if (bnsSaveButtonClick != null)
                bnsSaveButtonClick(this, e);
        }

        [Category("bannoi Actions")]
        public event EventHandler bnsCancelButtonClick;
        protected virtual void cancelBTN_Click(object sender, EventArgs e)
        {
            if (bnsCancelButtonClick != null)
                bnsCancelButtonClick(this, e);
        }

        [Category("bannoi Actions")]
        public event EventHandler bnsDeleteButtonClick;
        protected virtual void delBTN_Click(object sender, EventArgs e)
        {
            if (bnsDeleteButtonClick != null)
                bnsDeleteButtonClick(this, e);
        }
        #endregion

        public uc_topTools()
        {
            InitializeComponent();
        }

        private void setButtonWithStatus()
        {
            try
            {
                if (this.bnsdbStatus == dbStatus.dbAddNew || this.bnsdbStatus == dbStatus.dbUpdate
                   || this.bnsdbStatus == dbStatus.dbFilter || this.bnsdbStatus == dbStatus.dbInsert)
                {
                    this.addnewBTN.Enabled = false;
                    this.saveBTN.Enabled = true;
                    this.editBTN.Enabled = false;
                    this.cancelBTN.Enabled = true;
                    this.delBTN.Enabled = false;
                }
                else if (this.bnsdbStatus == dbStatus.dbEdit)
                {
                    this.addnewBTN.Enabled = false;
                    this.saveBTN.Enabled = false;
                    this.editBTN.Enabled = true;
                    this.cancelBTN.Enabled = false;
                    this.delBTN.Enabled = false;
                }
                else if (this.bnsdbStatus == dbStatus.dbCancel || this.bnsdbStatus == dbStatus.dbDelete)
                {
                    this.addnewBTN.Enabled = true;
                    this.saveBTN.Enabled = false;
                    this.editBTN.Enabled = false;
                    this.cancelBTN.Enabled = false;
                    this.delBTN.Enabled = false;
                }
                else if (this.bnsdbStatus == dbStatus.dbNone)
                {
                    this.addnewBTN.Enabled = true;
                    this.saveBTN.Enabled = true;
                    this.editBTN.Enabled = true;
                    this.cancelBTN.Enabled = true;
                    this.delBTN.Enabled = true;
                }
            }
            catch { throw; }
        }
    }
}
