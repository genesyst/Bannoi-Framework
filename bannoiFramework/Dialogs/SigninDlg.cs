using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bannoiFramework.Dataset;
using bannoiFramework.Models;

namespace bannoiFramework.Dialogs
{
    public partial class SigninDlg : Form
    {
        #region members
        private int frmWidth, frmHight;
        private BNSDATA_EHREntities BNSDATA_EHRentity;

        private bool requestExit;

        public bool RequestExit
        {
            get { return requestExit; }
            set { requestExit = value; }
        }
        private bool isSignin;

        public bool IsSignin
        {
            get { return isSignin; }
            set { isSignin = value; }
        }

        private decimal userId;

        public decimal UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private SiginModel siginModel;

        public SiginModel SiginModel
        {
            get { return siginModel; }
            set { siginModel = value; }
        }

        private UserGantModel userGantModel;

        public UserGantModel UserGantModel
        {
            get { return userGantModel; }
            set { userGantModel = value; }
        }

        private string systemCode;

        #endregion

        public SigninDlg(string systemCode,string imagePath)
        {
            InitializeComponent();
            this.frmHight = this.Height;
            this.frmWidth = this.Width;

            this.BNSDATA_EHRentity = new BNSDATA_EHREntities();
            this.systemCode = systemCode;

            if(imagePath!=null)
                this.pictureBox1.ImageLocation = imagePath;
        }

        public SigninDlg(string systemCode, string imagePath, string defaultUser,string usernameDisplay,string passwordDisplay)
        {
            InitializeComponent();
            this.frmHight = this.Height;
            this.frmWidth = this.Width;

            if(!String.IsNullOrEmpty(defaultUser))
                this.usernameTxt.Text = defaultUser.Trim();

            this.label1.Text = usernameDisplay;
            this.label2.Text = passwordDisplay;

            this.BNSDATA_EHRentity = new BNSDATA_EHREntities();
            this.systemCode = systemCode;

            if (imagePath != null)
                this.pictureBox1.ImageLocation = imagePath;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.RequestExit = true;
        }

        private void validationSigin()
        {
            try
            {
                this.isSignin = false;
                if (!String.IsNullOrEmpty(this.usernameTxt.Text) && !String.IsNullOrEmpty(this.userpasswordTxt.Text))
                {
                    
                    var userSign = this.BNSDATA_EHRentity.SIN_USER.Where(
                            c => c.USERNAME == this.usernameTxt.Text.Trim() && c.USERPW == this.userpasswordTxt.Text).FirstOrDefault();
                    if (userSign != null)
                    {
                        this.siginModel = new SiginModel();
                        this.siginModel.userId = userSign.REC_ID;
                        this.siginModel.userName = userSign.USERNAME;
                        this.siginModel.userPassword = userSign.USERPW;
                        this.siginModel.empCode = userSign.EMPCODE;

                        #region gant
                        var userGant = BNSDATA_EHRentity.SIN_USERGANT.Where(
                            c => c.SIGNID == userSign.REC_ID && c.SYSTEMCODE.ToUpper() == this.systemCode.ToUpper()).FirstOrDefault();
                        if (userGant != null)
                        {
                            this.userGantModel = new UserGantModel();
                            this.userGantModel.groupCode = userGant.GROUPCODE;
                            this.userGantModel.signId = userGant.SIGNID;
                            this.userGantModel.levelCode = userGant.LEVELCODE;
                            this.userGantModel.systemCode = userGant.SYSTEMCODE;
                            this.userGantModel.systemVersion = userGant.SYSTEMVERSION;
                            this.userGantModel.isAdmin = userGant.ISADMIN;

                            this.isSignin = true;
                        }
                        #endregion

                        this.BNSDATA_EHRentity.Dispose();
                        this.BNSDATA_EHRentity = null;

                        this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                        this.Close();
                    }
                }
            }
            catch { throw; }
        }

        private void usernameTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(this.usernameTxt.Text.Length > 3 || this.userpasswordTxt.Text.Length > 3)
                    this.validationSigin();
            }
            catch { throw; }
        }

        private void SigninDlg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
