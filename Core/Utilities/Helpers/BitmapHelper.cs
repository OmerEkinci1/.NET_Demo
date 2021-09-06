using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public static class BitmapHelper
    {
        public static Bitmap Base64StringBitmap(string base64String)
        {
            Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }
    }
}
