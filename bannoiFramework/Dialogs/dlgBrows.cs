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
    public partial class dlgBrows : Form
    {
        private object[] returnValue;

        public object[] ReturnValue
        {
            get { return returnValue; }
            set { returnValue = value; }
        }
        private string[] keyName;
        private DataTable defaultTable;
        private BindingSource BDS;
        private string[] showCol;

        private string[] fieldsDisableFilter;

        public string[] FieldsDisableFilter
        {
            get { return fieldsDisableFilter; }
            set { fieldsDisableFilter = value; }
        }

        public dlgBrows()
        {
            InitializeComponent();
        }

        public dlgBrows(string title,DataTable tableSource,string defaultText,
            string[] displayCaption,string[] collumnShow,string[] keyCollumn)
        {
            InitializeComponent();

            this.keyName = keyCollumn;
            this.showCol = collumnShow;
            this.Text = title;
            this.defaultTable = tableSource;

            this.BDS = new BindingSource(this.defaultTable,null);
            this.dataGridList1.DataSource = this.BDS;
            this.findText.Text = defaultText;

            foreach (string colItem in displayCaption)
            {
                if(this.isFilter(colItem))
                    this.comboBox1.Items.Add(colItem);
            }

            this.comboBox1.SelectedIndex = 0;

            //display caption
            int cIndex = 0;
            for (int i = 0; i < this.dataGridList1.ColumnCount; i++)
            {
                if (this.dataGridList1.Columns[i].DataPropertyName.ToUpper() == this.showCol[cIndex].ToUpper())
                {
                    this.dataGridList1.Columns[i].HeaderText = displayCaption[cIndex];
                    cIndex++;

                    if (cIndex == this.showCol.Length) break;
                }
            }

            //visible collumn
            for (int i = 0; i < this.dataGridList1.ColumnCount; i++)
            {
                string colName=this.dataGridList1.Columns[i].DataPropertyName;
                string[] findCol=Array.FindAll(collumnShow,s=>s.Equals(colName));
                if (findCol.Length == 0)
                    this.dataGridList1.Columns[i].Visible = false;
                else
                {
                    this.dataGridList1.Columns[i].Visible = true;

                    if (colName == this.keyName[0])
                    {
                        this.dataGridList1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        this.dataGridList1.Columns[i].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    }
                }
            }
        }

        private void dlgBrows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private bool isFilter(string fieldName)
        {
            bool Res = true;
            if (this.fieldsDisableFilter != null)
            {
                foreach (string itm in this.fieldsDisableFilter)
                {
                    if (itm.ToUpper() == fieldName.ToUpper())
                    {
                        Res = false;
                        break;
                    }
                }
            }
            return Res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridList1.RowCount < 1)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    return;
                }
                string filterString = null;
                string findValue=this.findText.Text.Trim();

                if (!String.IsNullOrEmpty(findValue))
                {
                    if (this.comboBox1.SelectedIndex == 0)
                    {
                        for (int i = 0; i < this.showCol.Length; i++)
                        {
                            if (i == 0)
                                //filterString += " (" + this.showCol[i] + " LIKE '%" + findValue + "%') ";
                                filterString += string.Format("CONVERT({0}, System.String) like '%{1}%'", this.showCol[i], findValue);
                            else
                                //filterString += " OR (" + this.showCol[i] + " LIKE '%" + findValue + "%')";
                                filterString += string.Format(" OR CONVERT({0}, System.String) like '%{1}%'", this.showCol[i], findValue);
                        }
                    }
                    else
                    {
                        //filterString = " (" + this.showCol[this.comboBox1.SelectedIndex-1] + " LIKE '%" + findValue + "%') ";
                        filterString += string.Format(" CONVERT({0}, System.String) like '%{1}%'", this.showCol[this.comboBox1.SelectedIndex - 1], findValue);
                    }
                    
                    this.BDS.Filter = filterString;
                }
                else
                {
                    this.BDS.Filter = null;
                }
            }
            catch { throw; }
        }

        private void dataGridList1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    this.returnValue=new object[this.dataGridList1.ColumnCount];
                    for (int i = 0; i < this.dataGridList1.ColumnCount; i++)
                    {
                        this.returnValue[i] = this.dataGridList1.Rows[e.RowIndex].Cells[i].Value;
                    }

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch { throw; }
        }

        private void findText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(null, null);
            }
        }
    }
}
