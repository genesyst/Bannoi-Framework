using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bannoiFramework.CTRL
{
    public partial class uc_QueryView : UserControl
    {
        private int constrIndex;

        public int ConstrIndex
        {
            get { return constrIndex; }
            set { constrIndex = value; }
        }


        public uc_QueryView()
        {
            InitializeComponent();
        }

        public string executeQuery(string conStr)
        {
            string Res = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    conn.Open();
                    SqlDataAdapter adap = new SqlDataAdapter(this.richTextBox1.Text.Trim(), conn);
                    DataSet DS=new DataSet();
                    adap.Fill(DS);
                    this.dataGridList1.DataSource = DS.Tables[0];
                    //this.bindingSource1.DataSource = DS.Tables[0];
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Res = "Source:" + ex.Source;
                Res += "\n" + "Number:" + ex.Number.ToString();
                Res += "\n" + "Message:" + ex.Message;
                Res += "\n" + "Class:" + ex.Class.ToString();
                Res += "\n" + "Procedure:" + ex.Procedure.ToString();
                Res += "\n" + "Line Number:" + ex.LineNumber.ToString();
                Res += "\n" + "Server:" + ex.Server.ToString();
            }
            return Res;
        }
    }
}
