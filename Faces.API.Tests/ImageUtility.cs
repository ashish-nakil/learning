using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Faces.API.Tests
{
    public class ImageUtility
    {

        public byte[] FromImageToBytes(string imagePath)
        {
            MemoryStream memoryStream = new MemoryStream();

            using (FileStream stream = new FileStream(@"C:\Ashish\Learnings\Sample Project\LearnApp\LearnApp\Faces.API.Tests\" + imagePath, FileMode.Open))
            {
                stream.CopyTo(memoryStream);
            }

            return memoryStream.ToArray();
        }


        public void FromBytesToImage(byte[] imageBytes, string fileName)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                Image img = Image.FromStream(ms);
                img.Save(fileName + ".jpg", ImageFormat.Jpeg);
            }
        }



    }
}
