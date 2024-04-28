namespace bannoiFramework.Dialogs
{
    partial class dlgSoundPlayer
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
            this.uc_soundPlayer1 = new bannoiFramework.CTRL.uc_soundPlayer();
            this.SuspendLayout();
            // 
            // uc_soundPlayer1
            // 
            this.uc_soundPlayer1.BackColor = System.Drawing.Color.Black;
            this.uc_soundPlayer1.File = null;
            this.uc_soundPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.uc_soundPlayer1.ForeColor = System.Drawing.Color.White;
            this.uc_soundPlayer1.Location = new System.Drawing.Point(4, 4);
            this.uc_soundPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.uc_soundPlayer1.Name = "uc_soundPlayer1";
            this.uc_soundPlayer1.Size = new System.Drawing.Size(467, 145);
            this.uc_soundPlayer1.TabIndex = 0;
            // 
            // dlgSoundPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(476, 152);
            this.Controls.Add(this.uc_soundPlayer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dlgSoundPlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgSoundPlayer";
            this.ResumeLayout(false);

        }

        #endregion

        private CTRL.uc_soundPlayer uc_soundPlayer1;
    }
}