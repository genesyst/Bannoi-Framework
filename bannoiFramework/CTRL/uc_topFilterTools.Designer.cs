namespace bannoiFramework.CTRL
{
    partial class uc_topFilterTools
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
            this.findTxt = new System.Windows.Forms.ToolStripTextBox();
            this.findBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addnewBTN = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findTxt,
            this.findBTN,
            this.toolStripSeparator1,
            this.refreshBTN,
            this.toolStripSeparator2,
            this.addnewBTN});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(536, 32);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // findTxt
            // 
            this.findTxt.Name = "findTxt";
            this.findTxt.Size = new System.Drawing.Size(300, 32);
            this.findTxt.TextChanged+=findTxt_TextChanged;
            this.findTxt.KeyDown+=findTxt_KeyDown;
            // 
            // findBTN
            // 
            this.findBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findBTN.Image = global::bannoiFramework.Properties.Resources.find_icon;
            this.findBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findBTN.Name = "findBTN";
            this.findBTN.Size = new System.Drawing.Size(29, 29);
            this.findBTN.Text = "ค้นหา";
            this.findBTN.Click+=findBTN_Click;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // refreshBTN
            // 
            this.refreshBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshBTN.Image = global::bannoiFramework.Properties.Resources._001_39;
            this.refreshBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshBTN.Name = "refreshBTN";
            this.refreshBTN.Size = new System.Drawing.Size(29, 29);
            this.refreshBTN.Text = "Refresh";
            this.refreshBTN.Click+=refreshBTN_Click;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // addnewBTN
            // 
            this.addnewBTN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addnewBTN.Image = global::bannoiFramework.Properties.Resources._001_01;
            this.addnewBTN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addnewBTN.Name = "addnewBTN";
            this.addnewBTN.Size = new System.Drawing.Size(29, 29);
            this.addnewBTN.Text = "เพิ่ม";
            this.addnewBTN.Click+=addnewBTN_Click;
            // 
            // uc_topFilterTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_topFilterTools";
            this.Size = new System.Drawing.Size(536, 100);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton addnewBTN;
        public System.Windows.Forms.ToolStripButton findBTN;
        public System.Windows.Forms.ToolStripButton refreshBTN;
        public System.Windows.Forms.ToolStripTextBox findTxt;
    }
}
