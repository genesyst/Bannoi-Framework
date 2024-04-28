using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreAudioApi;
using System.Runtime.InteropServices;
using NAudio.Wave;
using System.Threading;

namespace bannoiFramework.Services
{
    public enum mediaType{mtSound,mtVideo}
    public enum mediaPlay { mpPlay, mpPause, mpStop }

    public class bnsServiceMedia
    {
        #region members
        private FileInfo mediaFile;

        public FileInfo MediaFile
        {
            get { return mediaFile; }
            set { mediaFile = value; }
        }

        public string MediaDuration
        {
            get { return this.Player.currentMedia.durationString; }
        }

        //use mediaPlayer
        private WMPLib.WindowsMediaPlayer Player;
        //use Naudio lib
        private Mp3FileReader mp3Player;
        private WaveOut mp3PlayerController = new WaveOut();

        private mediaType mediaType;
        private double mediaPosition;

        private int positionSec=0;

        public int PositionSec
        {
            get { return positionSec; }
            set { positionSec = value; }
        }

        private float volume=(float)1.0;

        public int Volume
        {
            set {
                switch (value)
                {
                    case 1: this.volume = (float)0.1; break;
                    case 2: this.volume = (float)0.2; break;
                    case 3: this.volume = (float)0.3; break;
                    case 4: this.volume = (float)0.4; break;
                    case 5: this.volume = (float)0.5; break;
                    case 6: this.volume = (float)0.6; break;
                    case 7: this.volume = (float)0.7; break;
                    case 8: this.volume = (float)0.8; break;
                    case 9: this.volume = (float)0.9; break;
                    case 10: this.volume = (float)1.0; break;
                    default:
                        this.volume = (float)0.0; break;
                }
            }
        }

        #endregion

        public bnsServiceMedia(string mediaURL)
        {
            this.mediaFile = new FileInfo(mediaURL);
        }

        public bool isMediaExist()
        {
            return this.mediaFile.Exists;
        }

        public void nAudioMP3Player()
        {
            try
            {
                this.mp3Player = new Mp3FileReader(this.mediaFile.FullName);
                TimeSpan posTime = new TimeSpan(0, 0, this.positionSec);
                this.mp3Player.CurrentTime = posTime;
                this.mp3PlayerController.Volume = this.volume;
                this.mp3PlayerController.Init(this.mp3Player);
                this.mp3PlayerController.Play();
            }
            catch { throw; }
        }

        public void mp3MediaPlay(mediaType type,int positionValue )
        {
            try
            {
                this.mediaType = type;
                switch (this.mediaType)
                {
                    case mediaType.mtSound:
                        this.positionSec = positionValue;
                        this.nAudioMP3Player();
                        break;
                }
            }
            catch { throw; }
        }

        public void wmpMediaPlay(mediaType type)
        {
            try
            {
                this.mediaType=type;
                switch (this.mediaType)
                {
                    case mediaType.mtSound:
                        this.PlayFile(this.mediaFile.FullName);
                        break;
                }
            }
            catch { throw; }
        }

        public void mp3MediaStop(bool distroy)
        {
            try
            {
                switch (this.mediaType)
                {
                    case mediaType.mtSound:
                        this.mp3PlayerController.Stop();
                        this.positionSec = 0;

                        if (distroy)
                        {
                            this.mp3Player.Dispose();
                            this.mp3Player = null;
                        }
                        break;
                }

                this.mediaFile = null;
            }
            catch { throw; }
        }

        public void wmpMediaStop()
        {
            try
            {
                switch (this.mediaType)
                {
                    case mediaType.mtSound:
                        this.Player.controls.stop();
                        break;
                }

                this.mediaFile = null;
            }
            catch { throw; }
        }

        public void mp3MediaPause(int pauseSecValue)
        {
            try
            {
                switch (this.mediaType)
                {
                    case mediaType.mtSound:
                        if (this.mp3PlayerController.PlaybackState == PlaybackState.Playing)
                        {
                            this.mp3PlayerController.Pause();
                            if (pauseSecValue > -1)
                                this.positionSec = pauseSecValue;
                        }
                        break;
                }
            }
            catch { throw; }
        }

        public void wmpMediaPause()
        {
            try
            {
                switch (this.mediaType)
                {
                    case mediaType.mtSound:
                        this.mediaPosition = this.Player.controls.currentPosition;
                        this.Player.controls.pause();
                        break;
                }
            }
            catch { throw; }
        }

        public void wmpMediaPlay()
        {
            try
            {
                switch (this.mediaType)
                {
                    case mediaType.mtSound:
                        this.Player.controls.play();
                        break;
                }
            }
            catch { throw; }
        }

        private void PlayFile(String url)
        {
            if (this.Player == null)
                this.Player = new WMPLib.WindowsMediaPlayer();

            Player.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError += new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = url;

            this.Player.controls.currentPosition = this.mediaPosition;
            Player.controls.play();
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
        }

        private void Player_PlayStateChange(int NewState)
        {
            //media player control's playstate change event handler
            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                
            }
            else if (Player.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                
            }
            else if (Player.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                
            }
        }

        public mediaPlay controlStatus()
        {
            Services.mediaPlay Res=Services.mediaPlay.mpStop;
            //media player control's playstate change event handler
            if (Player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Res= Services.mediaPlay.mpPlay;
            }
            else if (Player.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                Res= Services.mediaPlay.mpPause;
            }
            else if (Player.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                Res= Services.mediaPlay.mpStop;
            }
            return Res;
        }

        public bool mp3PlayerIsDisponse()
        {
            if (this.mp3Player == null)
                return true;
            else
                return false;
        }
    }

    public class bnsServiceMediaControl
    {
        [DllImport("winmm.dll")]
        private static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        private bool microphoneIsMute=true;

        public bool MicrophoneIsMute
        {
            get { return microphoneIsMute; }
            set { 
                microphoneIsMute = value;
                if (microphoneIsMute)
                {
                    new WindowsMicrophoneMuteLibrary.WindowsMicMute().MuteMic();
                }
                else
                {
                    new WindowsMicrophoneMuteLibrary.WindowsMicMute().UnMuteMic();
                }
            }
        }

        public bnsServiceMediaControl()
        {

        }

        public static int GetApplicationVolume()
        {
            uint CurrVol = 0;
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            int volume = CalcVol / (ushort.MaxValue / 10);
            return volume;
        }

        public static void SetApplicationVolume(int volume) //Volume from 0 to 10
        {
            int NewVolume = ((ushort.MaxValue / 10) * volume);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }
    }

    public class bnsServiceMediaConverter
    {
        #region members class
        private FileInfo mediaFile;

        public FileInfo MediaFile
        {
            get { return mediaFile; }
            set { mediaFile = value; }
        }
        #endregion

        public bnsServiceMediaConverter(string mediaFilePath)
        {
            try
            {
                if (File.Exists(mediaFilePath))
                {
                    this.mediaFile = new FileInfo(mediaFilePath);
                }
            }
            catch { throw; }
        }

        public static void ConvertToMP3(string sourceFilename, string targetFilename)
        {
            using (var reader = new NAudio.Wave.AudioFileReader(sourceFilename))
            using (var writer = new NAudio.Lame.LameMP3FileWriter(targetFilename, reader.WaveFormat, NAudio.Lame.LAMEPreset.STANDARD))
            {
                reader.CopyTo(writer);
            }
        }

        public void ConvertToMP3(string outPutPath)
        {
            try
            {
                bnsServiceMediaConverter.ConvertToMP3(this.mediaFile.FullName, outPutPath);
            }
            catch { throw; }
        }

        public void ConvertToMP3()
        {
            bnsServiceMediaConverter.ConvertToMP3(this.mediaFile.FullName, 
                this.mediaFile.DirectoryName+"\\"+this.mediaFile.Name.Substring(
                0,this.mediaFile.Name.Length-this.mediaFile.Extension.Length)+".mp3");
        }
    }
}
