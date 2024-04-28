namespace bannoiFramework.Dialogs
{
    partial class dlgMultiCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgMultiCode));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.bindingSource1 = new System.Windows.Forms.BindingSource();
            this.dataGridList1 = new bannoiFramework.Controlls.DataGridList();
            this.DEL = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bnsTextBox1 = new bannoiFramework.Controlls.bnsTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridList1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridList1);
            this.panel1.Controls.Add(this.bnsTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 316);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(327, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(55, 316);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 46);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "get-products-icon-large.png");
            // 
            // dataGridList1
            // 
            this.dataGridList1.AllowUserToAddRows = false;
            this.dataGridList1.AllowUserToDeleteRows = false;
            this.dataGridList1.AutoGenerateColumns = false;
            this.dataGridList1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridList1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridList1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridList1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridList1.ColumnHeadersVisible = false;
            this.dataGridList1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DEL,
            this.CODE});
            this.dataGridList1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridList1.DataSource = this.bindingSource1;
            this.dataGridList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridList1.Location = new System.Drawing.Point(0, 23);
            this.dataGridList1.MultiSelect = false;
            this.dataGridList1.Name = "dataGridList1";
            this.dataGridList1.ReadOnly = true;
            this.dataGridList1.RowHeadersVisible = false;
            this.dataGridList1.RowTemplate.Height = 27;
            this.dataGridList1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridList1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridList1.Size = new System.Drawing.Size(327, 293);
            this.dataGridList1.TabIndex = 1;
            this.dataGridList1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridList1_CellContentClick);
            // 
            // DEL
            // 
            this.DEL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "ลบ";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DEL.DefaultCellStyle = dataGridViewCellStyle2;
            this.DEL.HeaderText = "";
            this.DEL.Name = "DEL";
            this.DEL.ReadOnly = true;
            this.DEL.Width = 5;
            // 
            // CODE
            // 
            this.CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CODE.DataPropertyName = "CODE";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CODE.DefaultCellStyle = dataGridViewCellStyle3;
            this.CODE.HeaderText = "";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            // 
            // bnsTextBox1
            // 
            this.bnsTextBox1.bnsClearButton = true;
            this.bnsTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bnsTextBox1.Location = new System.Drawing.Point(0, 0);
            this.bnsTextBox1.Name = "bnsTextBox1";
            this.bnsTextBox1.Size = new System.Drawing.Size(327, 23);
            this.bnsTextBox1.TabIndex = 0;
            this.bnsTextBox1.WatermarkText = null;
            this.bnsTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bnsTextBox1_KeyDown);
            // 
            // dlgMultiCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 316);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dlgMultiCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgMultiCode";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Controlls.bnsTextBox bnsTextBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private Controlls.DataGridList dataGridList1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewButtonColumn DEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
    }
}