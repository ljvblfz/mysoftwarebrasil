using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Axis.Infrastructure.IO
{
    /// <summary>
    /// Classe de manipulação de imagem
    /// </summary>
    public class Image
    {
        /// <summary>
        ///  Retorna a imagem em base64
        /// </summary>
        /// <param name="path">string caminho da imgem</param>
        /// <returns>string imagem em base64</returns>
        public static string GetBase64Image(string path)
        {
            if (new FileInfo(path).Exists)
            {
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[(int)fileStream.Length];
                fileStream.Read(data, 0, data.Length);
                return Convert.ToBase64String(data);
            }
            else
                return String.Empty;
        }

        /// <summary>
        ///  Exclusão logica da imagem
        /// </summary>
        /// <param name="fileName">caminho da imagem</param>
        public static bool DeleteImage(string fileName)
        {
            try
            {
                var file = new FileInfo(fileName);
                file.Delete();
                return true;
            }
            catch (IOException ex)
            {
                if (ex.InnerException != null)
                    throw new Exception(ex.InnerException.Message, ex);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        ///  Converte o caminho fisico para caminho virtual
        /// </summary>
        /// <param name="physicalFilePath">caminho fisico</param>
        /// <returns>caminho virtual</returns>
        public static string GetVirtualPath(string physicalFilePath)
        {
            return physicalFilePath
                        .Replace(HttpRuntime.AppDomainAppPath, "/")
                        .Replace(Path.DirectorySeparatorChar, '/');
        }
    }
}
