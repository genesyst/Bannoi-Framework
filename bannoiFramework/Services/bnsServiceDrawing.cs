using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bannoiFramework.Services
{
    public partial class bnsServiceDrawing
    {
        public bnsServiceDrawing()
        {

        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(imageIn, typeof(byte[]));
            return xByte;
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Image fileToImage(string fileName)
        {
            try
            {
                byte[] fileByte = bnsServiceIO.FileToByteArray(fileName);
                if (fileByte.Length > 0)
                    return bnsServiceDrawing.byteArrayToImage(fileByte);
                else
                    return null;
            }
            catch { throw; }
        }
    }
}
