namespace bannoiFramework.CTRL
{
    partial class uc_sideTools
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addnewBTN = new System.Windows.Forms.ToolStripButton();
            this.editBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.delBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveBTN,
            this.toolStripSeparator1,
            this.addnewBTN,
            this.editBTN,
            this.toolStripSeparator2,
            this.cancelBTN,
            this.toolStripSeparator3,
            this.delBTN});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(72, 248);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveBTN
            // 
            this.saveBTN.Enabled = false;
            this.saveBTN.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.saveBTN.Image = global::bannoiFramework.Properties.Resources._001_06;
            this.saveBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveBTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(69, 28);
            this.saveBTN.Text = "บันทึก";
            this.saveBTN.Click+=saveBTN_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(69, 6);
            // 
            // addnewBTN
            // 
            this.addnewBTN.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.addnewBTN.Image = global::bannoiFramework.Properties.Resources._001_01;
            this.addnewBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addnewBTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addnewBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addnewBTN.Name = "addnewBTN";
            this.addnewBTN.Size = new System.Drawing.Size(69, 28);
            this.addnewBTN.Text = "เพิ่ม";
            this.addnewBTN.Click += addnewBTN_Click;
            // 
            // editBTN
            // 
            this.editBTN.Enabled = false;
            this.editBTN.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.editBTN.Image = global::bannoiFramework.Properties.Resources._001_08;
            this.editBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editBTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editBTN.Name = "editBTN";
            this.editBTN.Size = new System.Drawing.Size(69, 28);
            this.editBTN.Text = "แก้ไข";
            this.editBTN.Click+=editBTN_Click;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(69, 6);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Enabled = false;
            this.cancelBTN.Image = global::bannoiFramework.Properties.Resources._001_02;
            this.cancelBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancelBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(69, 28);
            this.cancelBTN.Text = "ยกเลิก";
            this.cancelBTN.Click+=cancelBTN_Click;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(69, 6);
            // 
            // delBTN
            // 
            this.delBTN.Enabled = false;
            this.delBTN.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.delBTN.Image = global::bannoiFramework.Properties.Resources._001_05;
            this.delBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delBTN.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.delBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delBTN.Name = "delBTN";
            this.delBTN.Size = new System.Drawing.Size(69, 28);
            this.delBTN.Text = "ลบ";
            this.delBTN.Click+=delBTN_Click;
            // 
            // uc_sideTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Name = "uc_sideTools";
            this.Size = new System.Drawing.Size(172, 248);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton saveBTN;
        public System.Windows.Forms.ToolStripButton addnewBTN;
        public System.Windows.Forms.ToolStripButton editBTN;
        public System.Windows.Forms.ToolStripButton cancelBTN;
        public System.Windows.Forms.ToolStripButton delBTN;
    }
}
