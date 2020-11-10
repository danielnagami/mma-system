using System;
using System.Drawing;
using System.IO;
using System.Web;

namespace MMASystem.Services
{
    public class ImageHelper
    {
        public static void ValidateImage(Image fingerPrint)
        {
            if (fingerPrint == null)
                throw new Exception("Invalid image!");
        }

        public static byte[] ConvertUploadToByteArray(object fingerPrint)
        {
            HttpPostedFileBase[] postedFile = (HttpPostedFileBase[])fingerPrint;
            var br = new BinaryReader(postedFile[0].InputStream);
            return br.ReadBytes((Int32)postedFile[0].InputStream.Length);
        } 

        //public static byte[] GetByteArrayFromImage(Image fingerPrint)
        //{
        //    using (var target = new MemoryStream())
        //    {
        //        fingerPrint.CopyTo(target);
        //        return target.ToArray();
        //    }
        //}

        public static Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}