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
    public partial class bnsComboBox : ComboBox
    {
        public bnsComboBox()
        {
            InitializeComponent();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.DroppedDown = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.DroppedDown = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
