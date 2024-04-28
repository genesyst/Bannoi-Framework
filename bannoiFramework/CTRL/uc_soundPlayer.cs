using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;
using System.Runtime.InteropServices;
using WMPLib;

namespace bannoiFramework.CTRL
{
    public partial class uc_soundPlayer : UserControl
    {
        #region members
        private FileInfo file;

        public FileInfo File
        {
            get { return file; }
            set { file = value; }
        }

        public string MediaDuration
        {
            get { return this.Player.currentMedia.durationString; }
        }

        private WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        

        #endregion

        public uc_soundPlayer()
        {
            InitializeComponent();

            try
            {
                this.playBtn.Enabled = true;
                this.stopBtn.Enabled = false;
                this.pauseBtn.Enabled = false;
            }
            catch { throw; }
        }

        public void setPlay()
        {
            try
            {
                if (this.file == null) return;

                Player.URL = this.file.FullName;
                this.label2.Text = this.Player.URL;
                this.timer1.Enabled = true;

            }
            catch { throw; }
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, WMPLib.WMPPlayState e)
        {
            //media player control's playstate change event handler
            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                timer1.Start();
            }
            else if (Player.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if (Player.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
            }

        }

        private void PlayFile(String url)
        {
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = url;
            Player.controls.play();
            this.playBtn.Enabled = false;
            this.pauseBtn.Enabled = true;
            this.stopBtn.Enabled = true;
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                //this.Close();
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            //this.Close();
        }

        public void stopBtn_Click(object sender, EventArgs e)
        {
            this.Player.controls.stop();
            this.playBtn.Enabled = true;
            this.pauseBtn.Enabled = false;
            ((Button)sender).Enabled = false;
            this.timer1.Enabled = false;
        }

        public void pauseBtn_Click(object sender, EventArgs e)
        {
            this.Player.controls.pause();
            this.playBtn.Enabled = true;
            this.stopBtn.Enabled = false;
            ((Button)sender).Enabled = false;
            this.timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.label1.Text = "[" + this.Player.controls.currentPositionString + "|" +
                    this.Player.currentMedia.durationString + "]" + this.Player.status;

            }
            catch { throw; }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.stopBtn_Click(sender, e);
        }
    }
}
