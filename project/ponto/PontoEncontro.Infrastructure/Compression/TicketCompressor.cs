using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace PontoEncontro.Infrastructure.Compression
{
    public class TicketCompressor : StringCompressor
	{
        public override string Compress(string uncompressedString)
		{
			string[] arrModules = uncompressedString.Split('|');

			int pos = 0;

			string oldModuleName = arrModules[pos].Split('.')[0];

			for (pos = 1; pos < arrModules.Length; pos++)
			{
				string newModuleName = arrModules[pos].Split('.')[0];

				if (oldModuleName == newModuleName)
					arrModules[pos] = arrModules[pos].Replace(oldModuleName + ".", ",");
				else
				{
					arrModules[pos] = "|" + arrModules[pos];
					oldModuleName = newModuleName;
				}
			}

			string compressedString = base.Compress(string.Join(string.Empty, arrModules));

			return compressedString;
		}

        public override string Decompress(string compressedString)
		{
            compressedString = base.Decompress(compressedString);

			string[] arrModules = compressedString.Split('|');

			for (int pos = 0; pos < arrModules.Length; pos++)
			{
				string moduleName = arrModules[pos].Split('.')[0];
				arrModules[pos] = arrModules[pos].Replace(",", "|" + moduleName + ".");
			}

			return string.Join("|", arrModules); 
		}
	}
}
