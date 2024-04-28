namespace bannoiFramework.Dialogs
{
    partial class dlgCash
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.uc_cash1 = new bannoiFramework.CTRL.uc_cash();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 270);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 40);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(370, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "ตกลง";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(370, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "ยกเลิก";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // uc_cash1
            // 
            this.uc_cash1.CashFormat = null;
            this.uc_cash1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_cash1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.uc_cash1.IsDecimalCash = false;
            this.uc_cash1.Location = new System.Drawing.Point(0, 0);
            this.uc_cash1.Margin = new System.Windows.Forms.Padding(4);
            this.uc_cash1.Name = "uc_cash1";
            this.uc_cash1.Size = new System.Drawing.Size(513, 270);
            this.uc_cash1.TabIndex = 0;
            // 
            // dlgCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 310);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uc_cash1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dlgCash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgCash";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CTRL.uc_cash uc_cash1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}