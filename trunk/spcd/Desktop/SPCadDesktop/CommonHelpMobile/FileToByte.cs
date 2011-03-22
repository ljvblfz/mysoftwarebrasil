using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CommonHelpMobile
{
   public class FileToByte
    {
        public byte[] ReadByteArrayFromFile(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
    }
}
