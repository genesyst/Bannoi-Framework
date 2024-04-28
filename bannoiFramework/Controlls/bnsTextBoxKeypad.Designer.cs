namespace bannoiFramework.Controlls
{
    partial class bnsTextBoxKeypad
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
            this.keypadIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.keypadIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // keypadIcon
            // 
            this.keypadIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.keypadIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.keypadIcon.Image = global::bannoiFramework.Properties.Resources.plainicon_com_49797_256px_a2f;
            this.keypadIcon.Location = new System.Drawing.Point(61, 0);
            this.keypadIcon.Name = "keypadIcon";
            this.keypadIcon.Size = new System.Drawing.Size(35, 34);
            this.keypadIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.keypadIcon.TabIndex = 0;
            this.keypadIcon.TabStop = false;
            this.keypadIcon.Click += new System.EventHandler(this.bnsKeyPad_Click);
            // 
            // bnsTextBoxKeypad
            // 
            this.Controls.Add(this.keypadIcon);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            ((System.ComponentModel.ISupportInitialize)(this.keypadIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox keypadIcon;
    }
}
