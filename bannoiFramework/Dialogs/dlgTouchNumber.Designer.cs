namespace bannoiFramework.Dialogs
{
    partial class dlgTouchNumber
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
            this.uc_touchNumber1 = new bannoiFramework.CTRL.uc_touchNumber();
            this.SuspendLayout();
            // 
            // uc_touchNumber1
            // 
            this.uc_touchNumber1.AutoSize = true;
            this.uc_touchNumber1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_touchNumber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.uc_touchNumber1.Location = new System.Drawing.Point(0, 0);
            this.uc_touchNumber1.Margin = new System.Windows.Forms.Padding(4);
            this.uc_touchNumber1.Name = "uc_touchNumber1";
            this.uc_touchNumber1.ResultTxt = null;
            this.uc_touchNumber1.Size = new System.Drawing.Size(196, 241);
            this.uc_touchNumber1.TabIndex = 0;
            // 
            // dlgTouchNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 241);
            this.Controls.Add(this.uc_touchNumber1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "dlgTouchNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Keyboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CTRL.uc_touchNumber uc_touchNumber1;
    }
}