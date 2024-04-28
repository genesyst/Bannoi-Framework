
namespace bannoiFramework.Controlls
{
    partial class bnsTextBoxLookUp
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
            components = new System.ComponentModel.Container();
            //this
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            //Lookup button
            ButtonLookup = new System.Windows.Forms.Button();
            ButtonLookup.Parent = this;
            ButtonLookup.Width = 25;
            ButtonLookup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ButtonLookup.BackColor = System.Drawing.Color.AliceBlue;
            ButtonLookup.Cursor = System.Windows.Forms.Cursors.Hand;
            ButtonLookup.Dock = System.Windows.Forms.DockStyle.Right;
            ButtonLookup.Text = "";
            ButtonLookup.Image = global::bannoiFramework.Properties.Resources._001_38;
            ButtonLookup.Click += OnLookup_Click;
            this.Controls.Add(ButtonLookup);
        }

        private System.Windows.Forms.Button ButtonLookup;

        #endregion
    }
}
