namespace bannoiFramework.Controlls
{
    partial class bnsPanel
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.Turquoise;
            this.headerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(200, 27);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Header Label";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bnsPanel
            // 
            this.Controls.Add(this.headerLabel);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
    }
}
