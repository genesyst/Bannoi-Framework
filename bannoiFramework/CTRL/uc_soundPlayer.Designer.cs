namespace bannoiFramework.CTRL
{
    partial class uc_soundPlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_soundPlayer));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitBtn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.stopBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.stopBtn);
            this.panel1.Controls.Add(this.pauseBtn);
            this.panel1.Controls.Add(this.playBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 33);
            this.panel1.TabIndex = 2;
            // 
            // exitBtn
            // 
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitBtn.ImageIndex = 4;
            this.exitBtn.ImageList = this.imageList1;
            this.exitBtn.Location = new System.Drawing.Point(229, 0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(63, 29);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "ออก";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Play1Normal.png");
            this.imageList1.Images.SetKeyName(1, "PlayModeRepeatAllHot.ico");
            this.imageList1.Images.SetKeyName(2, "pause.ico");
            this.imageList1.Images.SetKeyName(3, "stop.ico");
            this.imageList1.Images.SetKeyName(4, "stop.ico");
            // 
            // stopBtn
            // 
            this.stopBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopBtn.ImageIndex = 3;
            this.stopBtn.ImageList = this.imageList1;
            this.stopBtn.Location = new System.Drawing.Point(125, 0);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(59, 29);
            this.stopBtn.TabIndex = 2;
            this.stopBtn.Text = "ปิด";
            this.stopBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pauseBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.pauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pauseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pauseBtn.ImageIndex = 2;
            this.pauseBtn.ImageList = this.imageList1;
            this.pauseBtn.Location = new System.Drawing.Point(60, 0);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(65, 29);
            this.pauseBtn.TabIndex = 1;
            this.pauseBtn.Text = "หยุด";
            this.pauseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.playBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.playBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playBtn.ImageIndex = 0;
            this.playBtn.ImageList = this.imageList1;
            this.playBtn.Location = new System.Drawing.Point(0, 0);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(60, 29);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "เล่น";
            this.playBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.playBtn.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(296, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uc_soundPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uc_soundPlayer";
            this.Size = new System.Drawing.Size(296, 103);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Button exitBtn;
        public System.Windows.Forms.Button stopBtn;
        public System.Windows.Forms.Button pauseBtn;
        public System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;



    }
}
