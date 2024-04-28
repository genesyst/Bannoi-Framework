namespace bannoiFramework.Forms
{
    partial class frmEntry
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uc_topFilterTools1 = new bannoiFramework.CTRL.uc_topFilterTools();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uc_sideTools1 = new bannoiFramework.CTRL.uc_sideTools();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(835, 338);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uc_topFilterTools1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(827, 309);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "รายการ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uc_topFilterTools1
            // 
            this.uc_topFilterTools1.AutoSize = true;
            this.uc_topFilterTools1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_topFilterTools1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.uc_topFilterTools1.Location = new System.Drawing.Point(3, 3);
            this.uc_topFilterTools1.Margin = new System.Windows.Forms.Padding(4);
            this.uc_topFilterTools1.Name = "uc_topFilterTools1";
            this.uc_topFilterTools1.Size = new System.Drawing.Size(821, 32);
            this.uc_topFilterTools1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.uc_sideTools1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(827, 309);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "รายละเอียด";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(75, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 303);
            this.panel1.TabIndex = 1;
            // 
            // uc_sideTools1
            // 
            this.uc_sideTools1.AutoSize = true;
            this.uc_sideTools1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uc_sideTools1.Location = new System.Drawing.Point(3, 3);
            this.uc_sideTools1.Margin = new System.Windows.Forms.Padding(4);
            this.uc_sideTools1.Name = "uc_sideTools1";
            this.uc_sideTools1.Size = new System.Drawing.Size(72, 303);
            this.uc_sideTools1.TabIndex = 0;
            // 
            // frmEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 338);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEntry";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEntry_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl1;
        public CTRL.uc_topFilterTools uc_topFilterTools1;
        public System.Windows.Forms.Panel panel1;
        public CTRL.uc_sideTools uc_sideTools1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
    }
}