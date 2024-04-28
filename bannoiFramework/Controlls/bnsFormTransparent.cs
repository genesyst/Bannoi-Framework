using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Controlls
{
    public partial class bnsFormTransparent : Component
    {
        #region properties
        private ContainerControl bnscontainerControl = null;
        [Category("bannoi Options")]
        public ContainerControl bnsContainerControl
        {
            get { return bnscontainerControl; }
            set { 
                bnscontainerControl = value;
            }
        }

        //private bool enable;
        //[Category("bannoi Options")]
        //public bool Enable
        //{
        //    get { return enable; }
        //    set { 
        //        enable = value;
        //        this.setTransparant(enable);
        //    }
        //}

        #endregion

        public bnsFormTransparent()
        {
            InitializeComponent();
        }

        public bnsFormTransparent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void setTransparant()
        {
            if (bnscontainerControl is Form)
            {
                Form f = (Form)bnscontainerControl;
                f.BackColor = Color.Magenta;
                f.TransparencyKey = Color.Magenta;
            }
        }
    }
}
