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
    public partial class bnsTextBox : TextBox
    {
        #region properties
        private bool clearButton=true;
        [Category("bannoi Options")]
        public bool bnsClearButton
        {
            get { return clearButton; }
            set { clearButton = value; this.pictureBox1.Visible = this.clearButton; }
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

        public bnsTextBox()
        {
            InitializeComponent();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.pictureBox1.Visible = this.Enabled;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Text = "";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Image = global::bannoiFramework.Properties.Resources.edit_clear;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            this.pictureBox1.Image = global::bannoiFramework.Properties.Resources.delete;
        }
    }
}
