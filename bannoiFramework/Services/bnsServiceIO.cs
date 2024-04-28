using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bannoiFramework.Services
{
    public partial class bnsServiceIO
    {
        public bnsServiceIO()
        {

        }

        public static void openFileByte(byte[] data, string filename)
        {
            try
            {
                var tempFolder = System.IO.Path.GetTempPath();
                filename = System.IO.Path.Combine(tempFolder, filename);
                System.IO.File.WriteAllBytes(filename, data);
                System.Diagnostics.Process.Start(filename);
            }
            catch { throw; }
        }

        public void getAllDrive(ListBox listBox,bool fixPosition)
        {
            try
            {
                string[] str = Directory.GetLogicalDrives();
                for (int i = 0; i < str.Length; i++)
                {
                    if (fixPosition)
                    {
                        listBox.Items.Add(str[i].Substring(0,1).ToUpper());
                    }
                    else
                    {
                        listBox.Items.Add(str[i].ToUpper());
                    }
                }
            }
            catch (IOException e) 
            { Console.WriteLine(e.ToString()); }
        }

        public string getWindowsDir()
        {
            string Res = "C";
            Res = Environment.GetEnvironmentVariable("windir", EnvironmentVariableTarget.Machine);
            return Res.ToUpper();
        }

        public string getSystemDrive()
        {
            string Res = "C";
            Res = Environment.GetEnvironmentVariable("windir", EnvironmentVariableTarget.Machine).Substring(0,1);
            return Res.ToUpper();
        }

        public void writeFile(string s, string filePath)
        {
            // create a writer and open the file
            TextWriter tw = new StreamWriter(filePath);

            // write a line of text to the file
            tw.WriteLine(s);

            // close the stream
            tw.Close();
        }

        public void writeLongFile(string s, string filePath)
        {
            // create a writer and open the file
            TextWriter tw = new StreamWriter(filePath);

            // write a line of text to the file
            tw.Write(s);

            // close the stream
            tw.Close();
        }

        public void writeFile(string s, string filePath,bool append)
        {
            // create a writer and open the file
            TextWriter tw = new StreamWriter(filePath,append);

            // write a line of text to the file
            tw.WriteLine(s);

            // close the stream
            tw.Close();
        }

        public string readFile(string filePath)
        {
            string Res = "";
            // create reader & open file
            TextReader tr = new StreamReader(filePath);

            // read a line of text
            //Console.WriteLine(tr.ReadLine());
            Res = tr.ReadLine(); ;
            // close the stream
            tr.Close();
            return Res;
        }

        public bool isDir(string dirName,bool appPath)
        {
            try
            {
                bool Res=true;
                string fullPath = dirName;
                if (appPath)
                {
                    fullPath = System.Windows.Forms.Application.StartupPath + @"\" + dirName;
                }
                if (!Directory.Exists(fullPath))
                {
                    try
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                    catch
                    {
                        Res = false;
                    }
                }
                return Res;
            }
            catch
            {
                throw;
            }
        }

        public string replaceFileName(string originalName)
        {
            string Res = originalName;
            string[] mark = {"/",@"\",":","*","?","''","<",">","|" };
            foreach (string remark in mark)
            {
                Res = Res.Replace(remark, "_");
            }
            return Res;
        }

        public static void killLockFile(string fileName)
        {
            Process tool = new Process();
            tool.StartInfo.FileName = "handle.exe";
            tool.StartInfo.Arguments = fileName;
            tool.StartInfo.UseShellExecute = false;
            tool.StartInfo.RedirectStandardOutput = true;
            tool.Start();
            tool.WaitForExit();
            string outputTool = tool.StandardOutput.ReadToEnd();

            string matchPattern = @"(?<=\s+pid:\s+)\b(\d+)\b(?=\s+)";
            foreach (Match match in Regex.Matches(outputTool, matchPattern))
            {
                Process.GetProcessById(int.Parse(match.Value)).Kill();
            }
        }

        public static byte[] StreamFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }

        public static int countFileInDirectory(string path,string pattern)
        {
            int Res = 0;
            try
            {
                if (Directory.Exists(path))
                {
                    string[] f = Directory.GetFiles(path);
                    foreach (string fName in f)
                    {
                        if (fName.IndexOf(pattern) != -1)
                        {
                            Res++;
                        }
                    }
                    f = null;
                }
            }
            catch
            {
                throw;
            }
            return Res;
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        public static double ConvertKilobytesToMegabytes(long kilobytes)
        {
            return kilobytes / 1024f;
        }

        public static byte[] FileToByteArray(string _FileName)
        {
            byte[] _Buffer = null;

            try
            {
                // Open file for reading
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // attach filestream to binary reader
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream);

                // get total byte length of the file
                long _TotalBytes = new System.IO.FileInfo(_FileName).Length;

                // read entire file into buffer
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);

                // close file reader
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            return _Buffer;
        }

        public static void clearFileInDir(string dirPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirPath);
                foreach (FileInfo file in dir.GetFiles())
                {
                    File.Delete(file.FullName);
                }
            }
            catch { throw; }
        }
    }

    public partial class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
          string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
          string key, string def, StringBuilder retVal,
          int size, string filePath);

        public IniFile(string INIPath)
        {
            path = INIPath;
        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
    }

    public partial class TransferFile
    {
        public TransferFile() { }

        public string WriteBinarFile(byte[] fs, string path, string fileName)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(fs);
                FileStream fileStream = new FileStream(path +
                fileName, FileMode.Create);
                memoryStream.WriteTo(fileStream);
                memoryStream.Close();
                fileStream.Close();
                fileStream = null;
                memoryStream = null;
                return "File has already uploaded successfully&#12290;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// getBinaryFile&#65306;Return array of byte which you specified&#12290;

        public byte[] ReadBinaryFile(string path, string fileName)
        {
            if (File.Exists(path + fileName))
            {
                try
                {
                    ///Open and read a file&#12290;
                    FileStream fileStream = File.OpenRead(path + fileName);
                    try
                    {
                        return ConvertStreamToByteBuffer(fileStream);
                    }
                    finally
                    {
                        fileStream.Close();
                        fileStream.Dispose();
                    }
                }
                catch 
                {
                    return new byte[0];
                }
            }
            else
            {
                return new byte[0];
            }
        }

        /// ConvertStreamToByteBuffer&#65306;Convert Stream To ByteBuffer&#12290;

        public byte[] ConvertStreamToByteBuffer(System.IO.Stream theStream)
        {
            int b1;
            System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
            while ((b1 = theStream.ReadByte()) != -1)
            {
                tempStream.WriteByte(((byte)b1));
            }
            return tempStream.ToArray();
        }
    }
}
