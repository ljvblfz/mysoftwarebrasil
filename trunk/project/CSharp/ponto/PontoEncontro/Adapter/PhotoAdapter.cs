using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEncontro.Infrastructure.IO;
using PontoEncontro.Models;
using PontoEncontro.Domain;
using PontoEncontro.Infrastructure;

namespace PontoEncontro.Adapter
{
    /// <summary>
    ///  Adaptador de Foto
    /// </summary>
    public class PhotoAdapter
    {
        /// <summary>
        ///  Cria um regostropara foto e realiza o upload
        /// </summary>
        /// <param name="modelView">dados da view</param>
        /// <returns>verdadeiro ou falso para o registro gravado</returns>
        public static bool CreateFoto(PhotoModel modelView)
        {
            var membro = Aplication.GetUser<Membro>(typeof(Membro)) as Membro;
            var model = new Foto();
            var fotoFile = new Upload(modelView.nameFoto);
            model.pathFoto = fotoFile.ImagePath;
            model.nameFoto = fotoFile.ImageUpload();
            model.idMembro = membro.idMembro;
            new FotoRepository().Save(model);
            return model.idFoto != 0;
        }

        public static IList<Foto> List()
        {
            return new FotoRepository().ListAll();
        }
    }
}