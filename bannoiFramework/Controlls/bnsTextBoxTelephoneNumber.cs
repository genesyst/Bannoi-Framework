using bannoiFramework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Controlls
{
    public partial class bnsTextBoxTelephoneNumber : TextBox
    {
        #region
        private bool isValidatValue = true;
        [Category("bannoi Options")]
        public bool bnsIsValidatValue
        {
            get { return isValidatValue; }
            set { isValidatValue = value; }
        }

        private bool isValidPhoneNumber=true;
        [Category("bannoi Options")]
        public bool bnsIsValidPhoneNumber
        {
            get {
                this.validation();
                return isValidPhoneNumber; 
            }
        }

        private string matchPhonePattern = @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$";
        [Category("bannoi Options")]
        public string bnsMatchPhonePattern
        {
            get { return matchPhonePattern; }
            set { matchPhonePattern = value; }
        }
        #endregion

        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private string watermarkText;
        public string WatermarkText
        {
            get { return watermarkText; }
            set
            {
                watermarkText = value;
                SetWatermark(watermarkText);
            }
        }
        private void SetWatermark(string watermarkText)
        {
            SendMessage(this.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }

        public bnsTextBoxTelephoneNumber()
        {
            InitializeComponent();

            this.toolTip1.SetToolTip(this, "หมายเลขโทรศัพท์หรือโทรสาร รูปแบบโดยทั่วไปคือ (087)797-0556 \n หรืออาจเปลี่ยนแปลงตามประเทศ");
        }

        private void validation()
        {
            try
            {
                this.BackColor = SystemColors.Window;
                this.ForeColor = SystemColors.WindowText;
                if (this.isValidatValue)
                {
                    if (!String.IsNullOrEmpty(this.Text) && !String.IsNullOrEmpty(this.matchPhonePattern))
                    {
                        Match matches = Regex.Match(this.Text.Trim(), this.matchPhonePattern);
                        if (!matches.Success)
                        {
                            this.isValidPhoneNumber = false;
                            this.BackColor = Color.Red;
                            this.ForeColor = Color.White;
                        }
                    }
                }
            }
            catch { throw; }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.validation();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if(!this.isValidatValue)
                e.Handled = bnsServiceControl.isHandleNumberOnly(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
