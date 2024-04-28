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
    public partial class bnsPanel : Panel
    {
        #region properties
        private string bnscaption = "Header Label" ;
        [Category("bannoi Options")]
        public string bnsCaption
        {
            get { return bnscaption; }
            set
            {
                bnscaption = value;
                this.headerLabel.Text = bnscaption;
            }
        }

        private bool bnsactiveheader=false;
        [Category("bannoi Options")]
        public bool bnsActiveHeader
        {
            get { return bnsactiveheader; }
            set { 
                bnsactiveheader = value;
                if (bnsactiveheader)
                    this.headerLabel.Cursor = Cursors.Hand;
                else
                    this.headerLabel.Cursor = Cursors.Default;
            }
        }

        private int bnspanelDefaultHeight=150;
        [Category("bannoi Options")]
        public int bnsPanelDefaultHeight
        {
            get { return bnspanelDefaultHeight; }
            set { bnspanelDefaultHeight = value; }
        }

        private ContentAlignment bnsheaderlabeltextalign;
        [Category("bannoi Options")]
        public ContentAlignment bnsHeaderLabelTextAlign
        {
            get { return this.headerLabel.TextAlign; }
            set { this.headerLabel.TextAlign = value; }
        }

        private Font bnsheaderlabelfont;
        [Category("bannoi Options")]
        public Font bnsHeaderLabelFont
        {
            get { return this.headerLabel.Font; }
            set { this.headerLabel.Font = value; }
        }

        private Color bnsheaderlabelfontcolor;
        [Category("bannoi Options")]
        public Color bnsHeaderLabelFontColor
        {
            get { return this.headerLabel.ForeColor; }
            set { this.headerLabel.ForeColor = value; }
        }

        private Color bnsheaderLabelBgColor=Color.Turquoise;
        [Category("bannoi Options")]
        public Color bnsHeaderLabelBgColor
        {
            get { return this.headerLabel.BackColor; }
            set { this.headerLabel.BackColor = value;}
        }

        #endregion

        public bnsPanel()
        {
            InitializeComponent();

            this.bnspanelDefaultHeight = this.Height;
            this.BackColor = Color.White;
            this.headerLabel.MouseDown += headerLabel_MouseDown;
        }

        public void setCompact()
        {
            this.Height = this.headerLabel.Height;
        }

        public bool isExpended()
        {
            if (this.Height == this.headerLabel.Height)
                return false;
            else
                return true;
        }

        protected void headerLabel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.bnsactiveheader)
                {
                    if (this.Height == this.headerLabel.Height)
                    {
                        while (this.Height < this.bnspanelDefaultHeight)
                        {
                            this.Height++;
                            System.Threading.Thread.Sleep(2);
                        }
                    }
                    else
                    {
                        while (this.Height > this.headerLabel.Height)
                        {
                            this.Height--;
                            System.Threading.Thread.Sleep(2);
                        }
                    }
                }
            }
            catch { throw; }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            
        }
    }
}
