using bannoiFramework.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Controlls
{
    public partial class bnsTimer : Timer
    {
        #region properties
        private string ConnectionString=null;
        [Category("bannoi Options")]
        public string bnsConnectionString
        {
            get { return ConnectionString; }
            set { ConnectionString = value; }
        }

        private bool setLocalTime=false;
        [Category("bannoi Options")]
        public bool bnssetLocalTime
        {
            get { return setLocalTime; }
            set { setLocalTime = value; }
        }

        #endregion

        public bnsTimer()
        {
            InitializeComponent();
        }

        protected override void OnTick(EventArgs e)
        {
            base.OnTick(e);
            if (this.setLocalTime)
            {
                if(!String.IsNullOrEmpty(this.ConnectionString))
                    bnsServiceUtils.setMCHTime(this.ConnectionString);
            }
        }
    }
}
