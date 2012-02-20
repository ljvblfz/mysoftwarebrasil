using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PontoEncontro.Infrastructure.IO
{
    public class Image //: System.Net.Mime.MediaTypeNames.Image
    {
        public static string GetBase64Image(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[(int)fileStream.Length];
            fileStream.Read(data, 0, data.Length);

            return Convert.ToBase64String(data);
        } 
    }
}
