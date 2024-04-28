namespace bannoiFramework.Dialogs
{
    partial class dlgBrows
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.findText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridList1 = new bannoiFramework.Controlls.DataGridList();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.findText);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 51);
            this.panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ค้นหาทุกส่วน"});
            this.comboBox1.Location = new System.Drawing.Point(0, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(379, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // findText
            // 
            this.findText.Dock = System.Windows.Forms.DockStyle.Top;
            this.findText.Location = new System.Drawing.Point(0, 0);
            this.findText.Name = "findText";
            this.findText.Size = new System.Drawing.Size(379, 23);
            this.findText.TabIndex = 2;
            this.findText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findText_KeyDown);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Image = global::bannoiFramework.Properties.Resources._001_38;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(379, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "ตกลง";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridList1
            // 
            this.dataGridList1.AllowUserToAddRows = false;
            this.dataGridList1.AllowUserToDeleteRows = false;
            this.dataGridList1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridList1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridList1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridList1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridList1.Location = new System.Drawing.Point(0, 51);
            this.dataGridList1.MultiSelect = false;
            this.dataGridList1.Name = "dataGridList1";
            this.dataGridList1.ReadOnly = true;
            this.dataGridList1.RowHeadersVisible = false;
            this.dataGridList1.RowTemplate.Height = 27;
            this.dataGridList1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridList1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridList1.Size = new System.Drawing.Size(431, 284);
            this.dataGridList1.TabIndex = 1;
            this.dataGridList1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridList1_CellContentClick);
            // 
            // dlgBrows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 335);
            this.Controls.Add(this.dataGridList1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dlgBrows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgBrows";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dlgBrows_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox findText;
        private System.Windows.Forms.Button button1;
        private Controlls.DataGridList dataGridList1;

    }
}