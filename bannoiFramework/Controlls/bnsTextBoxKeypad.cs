using bannoiFramework.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Controlls
{
    
    public partial class bnsTextBoxKeypad : bnsTextBox
    {
        public enum padMode{pmDefault,pmNumber,pmDecimal}
        #region event handler
        [Category("bannoi Actions")]
        public event EventHandler bnsKeyPadClick;
        protected virtual void bnsKeyPad_Click(object sender, EventArgs e)
        {
            if (bnsKeyPadClick != null)
            {
                bnsKeyPadClick(this, e);
            }
            else
            {
                if (this.padModeValue == padMode.pmDefault)
                {
                    string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
                    string keyboardPath = Path.Combine(progFiles, "TabTip.exe");
                    if (File.Exists(keyboardPath))
                        Process.Start(keyboardPath);

                    this.Focus();
                }
                else if (this.padModeValue == padMode.pmNumber)
                {
                    dlgTouchNumber tNumber = new dlgTouchNumber(false);
                    if (tNumber.ShowDialog() == DialogResult.OK)
                    {
                        this.Text = tNumber.NumberResult;
                    }
                }
                else if (this.padModeValue == padMode.pmDecimal)
                {
                    dlgTouchNumber tDec = new dlgTouchNumber(true);
                    if (tDec.ShowDialog() == DialogResult.OK)
                    {
                        this.Text = tDec.NumberResult;
                    }
                }
            }
        }
        #endregion

        #region properties
        private padMode padModeValue = padMode.pmDefault;

        public padMode bnsPadModeValue
        {
            get { return padModeValue; }
            set { padModeValue = value; }
        }
        #endregion

        public bnsTextBoxKeypad()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
