using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Web.Hosting;
using PontoEncontro.Infrastructure;

namespace PontoEncontro.Infrastructure.IO
{
    /// <summary>
    ///  Classe de upload de arquivos
    /// </summary>
    public class Upload
    {
        /// <summary>
        ///  Nome do diretorio
        /// </summary>
        private readonly string StoragePath;

        /// <summary>
        ///  Nome do diretorio de imagens
        /// </summary>
        public readonly string ImagePath;

        /// <summary>
        /// Arquivo postado
        /// </summary>
        private HttpPostedFileBase file;

        /// <summary>
        ///  Construtor
        /// </summary>
        public Upload()
        {
            this.StoragePath = HostingEnvironment.IsHosted
                            ? HostingEnvironment.MapPath("~/Upload/") ?? ""
                            : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");

            this.ImagePath = Path.Combine(StoragePath,"Image", Aplication.GetUserName());
        }

        /// <summary>
        ///  Construtor
        /// </summary>
        /// <param name="file"></param>
        public Upload(HttpPostedFileBase file)
        : this(){
            this.file = file;
        }

        /// <summary>
        ///  Realiza o upload de um arquivo imagem
        /// </summary>
        /// <returns>nome do arquivo gravado</returns>
        public string ImageUpload()
        {
            if (this.file != null)
                return this.Save(this.file, this.ImagePath);
            return null;
        }

        /// <summary>
        ///  Salva o arquivo no diretorio especifico
        /// </summary>
        /// <param name="postedFile">objeto do arquivo postado</param>
        /// <param name="destiny">diretorio secundario de destino</param>
        /// <returns>nome do arquivo gravado</returns>
        private string Save(HttpPostedFileBase postedFile, string destiny)
        {
            var fileName = Guid.NewGuid().ToString() + "." + Path.GetExtension(postedFile.FileName);
            postedFile.SaveAs(Path.Combine(destiny, fileName));
            return fileName;
        }
    }
}
