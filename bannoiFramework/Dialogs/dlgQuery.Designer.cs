namespace bannoiFramework.Dialogs
{
    partial class dlgQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgQuery));
            this.uc_Query1 = new bannoiFramework.CTRL.uc_Query();
            this.SuspendLayout();
            // 
            // uc_Query1
            // 
            this.uc_Query1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_Query1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.uc_Query1.Location = new System.Drawing.Point(0, 0);
            this.uc_Query1.Margin = new System.Windows.Forms.Padding(4);
            this.uc_Query1.Name = "uc_Query1";
            this.uc_Query1.Size = new System.Drawing.Size(683, 319);
            this.uc_Query1.TabIndex = 0;
            // 
            // dlgQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 319);
            this.Controls.Add(this.uc_Query1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Query";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CTRL.uc_Query uc_Query1;
    }
}