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
    public partial class DataGridList : DataGridView
    {
        public DataGridList()
        {
            InitializeComponent();

            this.defaultSet();

        }

        private void defaultSet()
        {
            this.Dock = DockStyle.Fill;
            this.RowHeadersVisible = false;
            this.RowTemplate.Height = 27;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BackgroundColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReadOnly = true;
            this.RowTemplate.Resizable = DataGridViewTriState.False;
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Cursor = Cursors.Hand;
            this.MultiSelect = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
