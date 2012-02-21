using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PontoEncontro.Infrastructure.IO;
using PontoEncontro.Models;
using PontoEncontro.Domain;
using PontoEncontro.Infrastructure;
using System.IO;

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
            model.legendaFoto = modelView.legendaFoto;
            model.pathFoto = fotoFile.ImagePath;
            model.nameFoto = fotoFile.ImageUpload();
            model.idMembro = membro.idMembro;
            new FotoRepository().Save(model);
            return model.idFoto != 0;
        }

        /// <summary>
        ///  Retorna todas as fotos
        /// </summary>
        /// <returns></returns>
        public static IList<Foto> List()
        {
            var membro = Aplication.GetUser<Membro>(typeof(Membro)) as Membro;
            return new FotoRepository().ListFoto(membro.idMembro);
        }

        /// <summary>
        ///  Excluir a imagem
        /// </summary>
        /// <param name="nameFoto">nome da imagem</param>
        /// <returns>true se a imagem foi excluida</returns>
        public static bool DeleteFoto(string nameFoto)
        {
            var repository = new FotoRepository();
            var foto = repository.GetFoto(nameFoto);

            return repository.Delete(foto) 
                    && 
                   Image.DeleteImage(Path.Combine(foto.pathFoto, foto.nameFoto));
        }

    }
}