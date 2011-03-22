using System;
using System.Collections.Generic;
using System.Text;

namespace CommonHelpMobile
{
    public class InfoFiles
    {
        //Define o caminho padrão de arquivamento de fotos.
        public static string PathDefaultFiles{ get; set;}
     
        /// <summary>
        /// Cria ou recupera o caminho padrão de arquivamento de fotos.
        /// </summary>
        /// <returns></returns>
        public static string GetPathFoto()
        {

            // Verifica se o caminha ainda não foi recuperado
            if (PathDefaultFiles == null)
            {
                // Define o nome da pasta onde serão salvas as fotos
                PathDefaultFiles = GetLocalPath() + "\\TempFotos\\";

                // Verifica se a pasta existe
                if (!System.IO.Directory.Exists(PathDefaultFiles))
                {
                    // Cria a pasta
                    System.IO.Directory.CreateDirectory(PathDefaultFiles);
                }
            }
            
            return PathDefaultFiles;
        }

        /// <summary>
        /// localiza a pasta padrao do sistema.
        /// </summary>
        /// <returns></returns>
        public static string GetLocalPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        }        
    }
}
