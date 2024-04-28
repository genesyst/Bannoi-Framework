using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private BNSDATA_EHREntities db = new BNSDATA_EHREntities();

        public Form1()
        {
            InitializeComponent();

            this.dataGridList1.DataSource = this.db.EMPLOYEE.ToList();
            this.dataGridList1.Dock = DockStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.bnsTextBoxDecimal1.bnsValue.ToString());
            MessageBox.Show(this.bnsTextBoxNumber1.bnsValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tb = this.dataGridList1.getDataTable(true);
        }
    }
}
