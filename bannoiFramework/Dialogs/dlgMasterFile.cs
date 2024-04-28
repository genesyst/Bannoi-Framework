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
    public enum masterFileUiType {fuiInputgrid,fuiCriterias }
    public partial class dlgMasterFile : Form
    {
        public dlgMasterFile()
        {
            InitializeComponent();

        }

        public dlgMasterFile(masterFileUiType uiType)
        {
            InitializeComponent();

            if (uiType == masterFileUiType.fuiInputgrid)
            {
                this.panel1.Visible = false;
                this.editBTN.Visible = false;
                this.cancelBTN.Visible = false;
                this.delBTN.Visible = false;
            }
        }

        private void dlgMasterFile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
    }
}
