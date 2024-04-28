using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Dialogs
{
    public partial class dlgMultiCode : Form
    {
        public bool isUptoDate = false;

        private DataTable CodeListTable = new DataTable();

        private string referanceCode;

        public string bnsReferanceCode
        {
            get { return referanceCode; }
            set { referanceCode = value; }
        }

        private List<string> codeList;

        public List<string> bnsCodeList
        {
            get {
                codeList.Clear();
                foreach (DataRow dr in this.CodeListTable.Rows)
                {
                    codeList.Add(dr["CODE"].ToString());
                }
                return codeList;
            }
            set { 
                codeList = value;

                foreach (string itm in this.codeList)
                {
                    DataRow dr = this.CodeListTable.NewRow();
                    dr["CODE"] = itm;
                    this.CodeListTable.Rows.Add(dr);
                }

                this.bindingSource1.DataSource = this.CodeListTable;
            }
        }


        public dlgMultiCode()
        {
            InitializeComponent();
        }

        public dlgMultiCode(string referCode)
        {
            InitializeComponent();

            this.referanceCode = referCode;
            this.CodeListTable.Columns.Add(new DataColumn("CODE",typeof(System.String)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void bnsTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(this.bnsTextBox1.Text))
                {
                    DataRow[] isExist = this.CodeListTable.Select("CODE='"+this.bnsTextBox1.Text.Trim()+"' ");
                    if (isExist.Length == 0)
                    {
                        DataRow dr = this.CodeListTable.NewRow();
                        dr["CODE"] = this.bnsTextBox1.Text.Trim();
                        this.CodeListTable.Rows.Add(dr);

                        this.bindingSource1.DataSource = this.CodeListTable;

                        this.isUptoDate = true;
                    }

                    this.bnsTextBox1.Clear();
                }
            }
        }

        private void dataGridList1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    if (e.ColumnIndex == this.dataGridList1.Columns["DEL"].Index)
                    {
                        string exCode = this.dataGridList1.CurrentRow.Cells["CODE"].Value.ToString();
                        DataRow[] dr = this.CodeListTable.Select("(CODE='"+exCode+"') ");
                        if (dr.Length > 0)
                        {
                            this.CodeListTable.Rows.Remove(dr[0]);

                            this.isUptoDate = true;
                        }
                    }
                }
            }
            catch { throw; }
        }

        
    }
}
