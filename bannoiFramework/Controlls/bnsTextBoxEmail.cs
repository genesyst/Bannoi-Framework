using bannoiFramework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Controlls
{
    public partial class bnsTextBoxEmail : TextBox
    {
        #region
        private bool isValidEmail=false;
        [Category("bannoi Options")]
        public bool bnsIsValidEmail
        {
            get {
                this.isValidation();
                return isValidEmail; 
            }
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

        public bnsTextBoxEmail()
        {
            InitializeComponent();

            this.toolTip1.SetToolTip(this, "รูปแบบ e-mail \n ตัวอย่างเช่น youremail@company หรือ youremail@domain.com");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void isValidation()
        {
            try
            {
                this.BackColor = SystemColors.Window;
                this.ForeColor = SystemColors.WindowText;
                string textValue = this.Text.Trim();

                if (!String.IsNullOrEmpty(textValue))
                {
                    string[] emailValue = textValue.Split(',');
                    bool isValid = true;
                    foreach (string email in emailValue)
                    {
                        isValid = bnsServiceUtils.IsValidEmailPattern(email);
                        if (!isValid)
                        {
                            this.isValidEmail = isValid;
                            this.BackColor = Color.Red;
                            this.ForeColor = Color.White;
                            break;
                        }
                    }
                }
                else
                    this.isValidEmail = true;
            }
            catch { throw; }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.isValidation();
        }
    }
}
