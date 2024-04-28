namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.bnsTextBoxNumber1 = new bannoiFramework.Controlls.bnsTextBoxNumber();
            this.bnsTextBoxDecimal1 = new bannoiFramework.Controlls.bnsTextBoxDecimal();
            this.dataGridList1 = new bannoiFramework.Controlls.DataGridList();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridList1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bnsTextBoxNumber1
            // 
            this.bnsTextBoxNumber1.bnsComma = true;
            this.bnsTextBoxNumber1.Location = new System.Drawing.Point(76, 143);
            this.bnsTextBoxNumber1.Name = "bnsTextBoxNumber1";
            this.bnsTextBoxNumber1.Size = new System.Drawing.Size(100, 20);
            this.bnsTextBoxNumber1.TabIndex = 1;
            this.bnsTextBoxNumber1.Text = "0";
            this.bnsTextBoxNumber1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bnsTextBoxDecimal1
            // 
            this.bnsTextBoxDecimal1.bnsComma = false;
            this.bnsTextBoxDecimal1.bnsDecimalDigit = 3;
            this.bnsTextBoxDecimal1.Location = new System.Drawing.Point(76, 94);
            this.bnsTextBoxDecimal1.Name = "bnsTextBoxDecimal1";
            this.bnsTextBoxDecimal1.Size = new System.Drawing.Size(100, 20);
            this.bnsTextBoxDecimal1.TabIndex = 0;
            this.bnsTextBoxDecimal1.Text = "0";
            this.bnsTextBoxDecimal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridList1
            // 
            this.dataGridList1.AllowUserToAddRows = false;
            this.dataGridList1.AllowUserToDeleteRows = false;
            this.dataGridList1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridList1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridList1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridList1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridList1.Location = new System.Drawing.Point(300, 36);
            this.dataGridList1.MultiSelect = false;
            this.dataGridList1.Name = "dataGridList1";
            this.dataGridList1.ReadOnly = true;
            this.dataGridList1.RowHeadersVisible = false;
            this.dataGridList1.RowTemplate.Height = 27;
            this.dataGridList1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridList1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridList1.Size = new System.Drawing.Size(526, 299);
            this.dataGridList1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 100);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 377);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridList1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bnsTextBoxNumber1);
            this.Controls.Add(this.bnsTextBoxDecimal1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridList1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private bannoiFramework.Controlls.bnsTextBoxDecimal bnsTextBoxDecimal1;
        private bannoiFramework.Controlls.bnsTextBoxNumber bnsTextBoxNumber1;
        private System.Windows.Forms.Button button1;
        private bannoiFramework.Controlls.DataGridList dataGridList1;
        private System.Windows.Forms.Button button2;

    }
}

