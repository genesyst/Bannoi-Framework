using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.ConnectionUI;
using System.Data.SqlClient;
using bannoiFramework.Services;
using bannoiFramework.Controlls;

namespace bannoiFramework.CTRL
{
    public partial class uc_Query : UserControl
    {
        private List<string> connectionList = new List<string>();
        private string defaultConStr = null;
        private int defaultConStrIndex = -1;
        private string listQuery = "select TABLE_NAME,TABLE_TYPE from INFORMATION_SCHEMA.TABLES ORDER BY TABLE_TYPE,TABLE_NAME ASC ";

        public uc_Query()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.connectionList.Count < 1)
                {
                    MessageBox.Show("ไม่มีข้อมูลการเชื่อมต่อ", ((ToolStripButton)sender).Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    uc_QueryView view = new uc_QueryView();
                    view.Dock = DockStyle.Fill;
                    if (String.IsNullOrEmpty(this.defaultConStr))
                    {
                        this.defaultConStrIndex = 0;
                        this.defaultConStr = this.connectionList[this.defaultConStrIndex];
                        view.ConstrIndex = 0;
                    }

                    view.ConstrIndex = this.defaultConStrIndex;
                    view.label1.Text = this.defaultConStr.Remove(this.defaultConStr.IndexOf("User"));

                    string pageCap = "#" + (this.tabControl1.TabPages.Count + 1).ToString("#,##0");
                    TabPage queryPage = new TabPage(pageCap);
                    queryPage.Controls.Add(view);
                    this.tabControl1.TabPages.Add(queryPage);
                }
            }
            catch { throw; }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectStr=null;
                if (bnsServiceDb.TryGetDataConnectionStringFromUser(out connectStr))
                {
                    if (this.connectionList.IndexOf(connectStr) == -1)
                    {
                        this.connectionList.Add(connectStr);
                        ToolStripMenuItem connectItem = new ToolStripMenuItem(connectStr.Remove(connectStr.IndexOf("User")));
                        connectItem.Tag = this.connectionList.Count - 1;
                        connectItem.Click += connectItem_Click;
                        this.toolStripDropDownButton1.DropDownItems.Add(connectItem);
                        this.defaultConStrIndex = (int)connectItem.Tag;
                        this.defaultConStr = connectStr;
                        this.viewList();
                    }
                }
            }
            catch { throw; }
        }

        private void viewList()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.defaultConStr))
                {
                    SqlDataAdapter adap = new SqlDataAdapter(this.listQuery, conn);
                    DataSet DS = new DataSet();
                    adap.Fill(DS);
                    this.bindingSource1.DataSource = DS.Tables[0];
                }
            }
            catch { throw; }
        }

        void connectItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.defaultConStrIndex = (int)((ToolStripMenuItem)sender).Tag;
                this.defaultConStr = this.connectionList[this.defaultConStrIndex];
                this.viewList();
            }
            catch { throw; }
        }

        private void dataGridList1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    if (e.ColumnIndex == this.dataGridList1.Columns["SEL"].Index)
                    {
                        uc_QueryView view = new uc_QueryView();
                        view.Dock = DockStyle.Fill;
                        view.ConstrIndex = this.defaultConStrIndex;
                        view.label1.Text = this.defaultConStr.Remove(this.defaultConStr.IndexOf("User"));
                        string tableName=this.dataGridList1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        view.richTextBox1.Text = "SELECT * FROM "+tableName;


                        string pageCap = "#" + (this.tabControl1.TabPages.Count + 1).ToString("#,##0") + " "+tableName;
                        TabPage queryPage = new TabPage(pageCap);
                        queryPage.Controls.Add(view);
                        this.tabControl1.TabPages.Add(queryPage);
                        this.tabControl1.SelectedTab=this.tabControl1.TabPages[this.tabControl1.TabCount-1];

                        string msg = view.executeQuery(this.defaultConStr);
                        if (msg != null)
                            MessageBox.Show(msg, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { throw; }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl1.TabCount < 1) return;
                foreach (Control c in this.tabControl1.SelectedTab.Controls)
                {
                    if (c is uc_QueryView)
                    {
                        int tag=((uc_QueryView)c).ConstrIndex;
                        string msg=((uc_QueryView)c).executeQuery(this.connectionList[tag]);
                        if(msg!=null)
                            MessageBox.Show(msg, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { throw; }
        }

        private void bnsTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.bindingSource1.Filter = "(TABLE_NAME LIKE '%"+((bnsTextBox)sender).Text.Trim()+"%')";
            }
            catch { throw; }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.tabControl1.TabCount > 0)
                    this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
            }
            catch { throw; }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(!String.IsNullOrEmpty(this.defaultConStr))
                    this.viewList();
            }
            catch { throw; }
        }

        
    }
}
