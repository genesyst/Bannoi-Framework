using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Dialogs
{
    public partial class dlgSoundPlayer : Form
    {
        public dlgSoundPlayer()
        {
            InitializeComponent();
        }

        public dlgSoundPlayer(FileInfo fileinfo)
        {
            InitializeComponent();

            #region implement
            this.uc_soundPlayer1.File = fileinfo;
            this.uc_soundPlayer1.playBtn.Click += playBtn_Click;
            this.uc_soundPlayer1.exitBtn.Click += exitBtn_Click;
            this.uc_soundPlayer1.setPlay();
            #endregion

        }

        void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void playBtn_Click(object sender, EventArgs e)
        {
            this.uc_soundPlayer1.setPlay();
        }
    }
}
