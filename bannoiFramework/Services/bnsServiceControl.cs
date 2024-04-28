using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using serviceLib;

namespace bannoiFramework.Services
{
    public enum hideStatus{hsShow,hsHiden}
    public partial class bnsServiceControl
    {
        public delegate void HidePanel(Panel panel, int defaultHeight, int delay, hideStatus hs);
        public bnsServiceControl()
        {
        }

        public static void setDisplayIndex(DataGridView dgv, string fieldName, int displayIndex)
        {
            int colIndex = serviceControl.getGridCellIndex(dgv, fieldName);
            dgv.Columns[colIndex].DisplayIndex = displayIndex;
        }

        public static string TextInputControl(Control c)
        {
            try
            {
                string Res = null;
                if (c is TextBox)
                {
                    if (!String.IsNullOrEmpty(((TextBox)c).Text))
                        Res = ((TextBox)c).Text;
                }
                else if (c is ComboBox)
                {
                    if (!String.IsNullOrEmpty(((ComboBox)c).Text))
                        Res = ((ComboBox)c).Text;
                }

                return Res;
            }
            catch { throw; }
        }

        public static void clearInputControl(Control control)
        {
            try
            {
                if (control is TextBox)
                    ((TextBox)control).Text = "";
                else if (control is ComboBox)
                {
                    ((ComboBox)control).Text = "";
                    ((ComboBox)control).SelectedIndex = -1;
                }
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control is DateTimePicker)
                    ((DateTimePicker)control).Value = DateTime.Now.Date;
                else if (control is CheckedListBox)
                {
                    for (int i = 0; i < ((CheckedListBox)control).Items.Count; i++)
                        ((CheckedListBox)control).SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            catch { throw; }
        }

        public static void clearContainerControl(Control container)
        {
            try
            {
                foreach (Control c in container.Controls)
                {
                    if (c is GroupBox)
                    {
                        foreach (Control g in c.Controls)
                            serviceControl.clearInputControl(g);
                    }
                    else if (c is Panel)
                    {
                        foreach (Control p in c.Controls)
                            serviceControl.clearInputControl(p);
                    }
                    else if (c is TabPage)
                    {
                        foreach (Control t in c.Controls)
                            serviceControl.clearInputControl(t);
                    }
                    else
                    {
                        serviceControl.clearInputControl(c);
                    }
                }
            }
            catch { throw; }
        }

        #region DataGridView Group ColumnHeader
        //************************************************************************************
        private Color groupColHeaderColor;

        public Color GroupColHeaderColor
        {
            get { return groupColHeaderColor; }
            set { groupColHeaderColor = value; }
        }
        private DataGridView dgv;

        public DataGridView Dgv
        {
            get { return dgv; }
            set { dgv = value; }
        }
        public ArrayList colHeaderSet;
        public void setDataGridViewHeaderGroup(int fixSize, int heightResize)
        {
            try
            {
                if (colHeaderSet.Count > 0)
                {
                    if (fixSize > 0)
                    {
                        for (int j = 0; j < dgv.ColumnCount; j++)
                            dgv.Columns[j].Width = fixSize;
                    }

                    switch (heightResize)
                    {
                        case 0: dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; break;
                        case 1: dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing; break;
                        case 2: dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; break;
                    }

                    dgv.ColumnHeadersHeight = dgv.ColumnHeadersHeight * 2;
                    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    dgv.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridViewHeaderGroup);
                }
            }
            catch
            {
                throw;
            }
        }

        public void dataGridViewHeaderGroup(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            try
            {                
                //colHeaderSet "HeaderText|ColIndex 1 ,ColIndex 2"
                for (int i = 0; i < colHeaderSet.Count; i++)
                {
                    string Htext=colHeaderSet[i].ToString().Split('|')[0];
                    string colSet = colHeaderSet[i].ToString().Split('|')[1];
                    string[] col = colSet.Split(',');

                    int allWidth = 0;
                    foreach (string s in col)
                    {
                        int index = Convert.ToInt32(s);
                        allWidth += dgv.Columns[index].Width;
                    }
                    Rectangle r1 = dgv.GetCellDisplayRectangle(Convert.ToInt32(col[0]), -1, true); //get the column header cell
                    r1.X += 1;
                    r1.Y += 1;
                    r1.Width = allWidth - 2;
                    r1.Height = r1.Height / 2 - 2;

                    if(groupColHeaderColor==null)
                        e.Graphics.FillRectangle(new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.BackColor), r1);
                    else
                        e.Graphics.FillRectangle(new SolidBrush(groupColHeaderColor), r1);

                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    e.Graphics.DrawString(Htext, dgv.ColumnHeadersDefaultCellStyle.Font,
                                          new SolidBrush(dgv.ColumnHeadersDefaultCellStyle.ForeColor), r1, format);
                }
            }
            catch
            {
                throw;
            }
        }
        //************************************************************************************
        #endregion

        public static void listSaveToTextFile(ListBox lb,string defaultFileName)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "บันทึกเป็นไฟล์";
                sfd.Filter = "Text file(.txt)|*.txt|All file|*.*";
                sfd.FileName = defaultFileName;

                string valueTxt = "";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string itm in lb.Items)
                    {
                        valueTxt += itm + Environment.NewLine;
                    }

                    File.WriteAllText(sfd.FileName, valueTxt);
                }

                sfd.Dispose();
            }
            catch { throw; }
        }

        public static void scollHidePanel(Panel panel,int defaultHeight, int delay, hideStatus hs)
        {
            if (hs == hideStatus.hsHiden)
            {
                while (panel.Height > 0)
                {
                    Application.DoEvents();
                    panel.Height -= 1;
                    Thread.Sleep(delay);
                }
            }
            else if (hs == hideStatus.hsShow)
            {
                while (panel.Height < defaultHeight)
                {
                    Application.DoEvents();
                    panel.Height += 1;
                    Thread.Sleep(delay);
                }
            }
        }

        public static void setComboboxData(ComboBox cbx, string displayData, string valueData, Array DataResult)
        {
            cbx.DataSource = DataResult;
            cbx.DisplayMember = displayData;
            cbx.ValueMember = valueData;
        }

        public static void hideGridViewENGCollunm(DataGridView dataGridView)
        {
            try
            {
                for (int i = 0; i < dataGridView.ColumnCount; i++)
                {
                    string HEADTEXT = dataGridView.Columns[i].HeaderText;
                    if (!new serviceUtils().isThi.IsMatch(HEADTEXT))
                    {
                        dataGridView.Columns[i].Visible = false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static void clearCheckedContextMenuStrip(ContextMenuStrip contextMenuStrip)
        {
            foreach (ToolStripMenuItem cItm in contextMenuStrip.Items)
            {
                cItm.Checked = false;
            }
        }

        public static string getGridFieldValue(DataGridView grid, string fieldName, int rowindex)
        {
            string Res = "";
            int colIndex = 0;
            try
            {
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (col.Name == fieldName)
                    {
                        colIndex = col.Index;
                        break;
                    }
                }
                Res = grid.Rows[rowindex].Cells[colIndex].Value.ToString();
            }
            catch
            {
                throw;
            }
            return Res;
        }

        public static string getGridFieldValue(DataGridView grid, string fieldName)
        {
            string Res = "";
            int colIndex = 0;
            try
            {
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    if (col.DataPropertyName == fieldName)
                    {
                        colIndex = col.Index;
                        break;
                    }
                }
                Res = grid.SelectedRows[0].Cells[colIndex].Value.ToString();
            }
            catch
            {
                throw;
            }
            return Res;
        }

        public static int getGridCellIndex(DataGridView grid, string cellName)
        {
            int Res = 0;
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                if (grid.Columns[i].Name == cellName)
                {
                    Res = i;
                    break;
                }
            }
            return Res;
        }

        public static bool isHandleNumberOnly(KeyPressEventArgs e)
        {
            bool Res = false;
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b'))
            {
                //MessageBox.Show("only numbers allowed");
                Res = true;
            }
            return Res;
        }

        public static bool isHandleNumberNCommaOnly(KeyPressEventArgs e)
        {
            bool Res = false;
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar!=','))
            {
                //MessageBox.Show("only numbers allowed");
                Res = true;
            }
            return Res;
        }

        public static void isHandleDecimalOnly(object sender,KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            {
                TextBox tb = sender as TextBox;
                int cursorPosLeft = tb.SelectionStart;
                int cursorPosRight = tb.SelectionStart + tb.SelectionLength;
                string result = tb.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb.Text.Substring(cursorPosRight);
                string[] parts = result.Split('.');
                if (parts.Length > 1)
                {
                    if (parts[1].Length > 2 || parts.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        public static void isHandleDecimalNCommaOnly(int dit,object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            {
                TextBox tb = sender as TextBox;
                int cursorPosLeft = tb.SelectionStart;
                int cursorPosRight = tb.SelectionStart + tb.SelectionLength;
                string result = tb.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb.Text.Substring(cursorPosRight);
                string[] parts = result.Split('.');
                if (parts.Length > 1)
                {
                    if (parts[1].Length > dit || parts.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        public static void isHandleDecimalOnly(int dit, object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b') && (e.KeyChar != '.') )
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsNumber(e.KeyChar) || e.KeyChar == '.')
            {
                #region
                if (sender is TextBox)
                {
                    TextBox tb = sender as TextBox;
                    int cursorPosLeft = tb.SelectionStart;
                    int cursorPosRight = tb.SelectionStart + tb.SelectionLength;
                    string result = tb.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb.Text.Substring(cursorPosRight);
                    string[] parts = result.Split('.');
                    if (parts.Length > 1)
                    {
                        if (parts[1].Length > dit || parts.Length > 2)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else if (sender is ToolStripTextBox)
                {
                    ToolStripTextBox tb = sender as ToolStripTextBox;
                    int cursorPosLeft = tb.SelectionStart;
                    int cursorPosRight = tb.SelectionStart + tb.SelectionLength;
                    string result = tb.Text.Substring(0, cursorPosLeft) + e.KeyChar + tb.Text.Substring(cursorPosRight);
                    string[] parts = result.Split('.');
                    if (parts.Length > 1)
                    {
                        if (parts[1].Length > dit || parts.Length > 2)
                        {
                            e.Handled = true;
                        }
                    }
                }
                #endregion
            }
        }

        public static void selectToCheck(CheckedListBox checkList,int selectedIndex)
        {
            try
            {
                for (int i = 0; i < checkList.Items.Count; i++)
                {
                    if (i == selectedIndex) checkList.SetItemChecked(i, true); else checkList.SetItemChecked(i, false);
                }
            }
            catch
            {
                throw;
            }
        }

        public static void ClearCheck(CheckedListBox checkList)
        {
            try
            {
                for (int i = 0; i < checkList.Items.Count; i++)
                {
                    checkList.SetItemChecked(i, false);
                }
            }
            catch
            {
                throw;
            }
        }

        public static void FindValueToChecked(CheckedListBox checkList, string valueText)
        {
            try
            {
                for (int i = 0; i < checkList.Items.Count; i++)
                {
                    if (checkList.Items[i].ToString().IndexOf(valueText) != -1)
                    {
                        checkList.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkList.SetItemChecked(i, false);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static void FindItemIsChecked(CheckedListBox checkList, ref string isItemCheck)
        {
            try
            {
                if (checkList.CheckedItems.Count > 0)
                {
                    foreach (string itm in checkList.CheckedItems)
                    {
                        isItemCheck = itm;
                        break;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public static void DataGridViewSetDisplayColumn(DataGridView DGV,string[] colNameDisplay)
        {
            try
            {
                if (colNameDisplay.Length > 0)
                {
                    int isSetCount = 0;

                    for (int i = 0; i < DGV.ColumnCount; i++)
                    {
                        if (isSetCount == colNameDisplay.Length) 
                            break;

                        string colName = DGV.Columns[i].Name.Trim();

                        foreach (string colNameDis in colNameDisplay)
                        {
                            if (colName == colNameDis)
                            {
                                int newIndex = Array.IndexOf(colNameDisplay, colNameDis);
                                DGV.Columns[colName].DisplayIndex = newIndex;
                                isSetCount++;
                                break;
                            }
                        }
                    }
                }
            }
            catch { throw; }
        }

        public static void DataGridViewSetDisplayColumn(DataGridView DGV, string[] colCapDisplay,string[] colCapReplace)
        {
            try
            {
                for (int i = 0; i < DGV.ColumnCount; i++)
                {
                    DGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    string oldHead = DGV.Columns[i].HeaderText;
                    for (int s = 0; s < colCapDisplay.Length; s++)
                    {
                        if (oldHead.IndexOf(colCapDisplay[s]) != -1)
                        {
                            DGV.Columns[i].HeaderText = colCapReplace[s];
                            break;
                        }
                    }
                }
            }
            catch { throw; }
        }

        public static void DataGridViewHideColumn(DataGridView DGV, string[] colNames)
        {
            try
            {
                for (int i = 0; i < colNames.Length; i++)
                {
                    int colIndex = serviceControl.getGridCellIndex(DGV, colNames[i]);
                    DGV.Columns[colIndex].Visible = false;
                }
            }
            catch { throw; }
        }

        public static void TextEditAutoComplete(TextBox control,string[] completeValues)
        {
            try
            {
                var source = new AutoCompleteStringCollection();
                source.AddRange(completeValues);

                if (control != null)
                {
                    control.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    control.AutoCompleteCustomSource = source;
                    control.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch { throw; }
        }
    }

    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }

    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
                (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the button cell.
        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,  
            // background, and disabled button for the cell.
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    PushButtonState.Disabled);

                // Draw the disabled button text. 
                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string)this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                // The button cell is enabled, so let the base class 
                // handle the painting.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }

    public class DataModelComboboxList
    {
        public string displayText { get; set; }
        public string valueText { get; set; }
    }
}

