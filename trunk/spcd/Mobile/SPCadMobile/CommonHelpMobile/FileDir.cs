using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CommonHelpMobile
{
    /// <summary>
    ///  Classe responsavel pela manipulação de arquivos e diretorios
    ///  <autor>Alexis Moura</autor>
    /// </summary>
    public class FileDir
    {
        /// <summary>
        ///  Metodo responsavel por retornar todos os arquivos de um diretorio
        /// </summary>
        /// <example>
        ///     FileInfo[] retorno = FileDir.OpenDir("ProgramFiles\\Aplicao\\")
        ///     if(retorno != null)
        ///         if(retorno.lenght > 0)
        ///         {
        ///         ....
        /// </example>
        /// <param name="path">string caminho do arquivo</param>
        /// <returns>FileInfo[] array de files</returns>
        public static FileInfo[] OpenDir(string path)
        {
            FileInfo[] files;

            // Verifica se o diretorio foi informado
            if (!String.IsNullOrEmpty(path))
            {
                try
                {
                    // retorna todos os arquivos do diretorio
                    DirectoryInfo dir = new DirectoryInfo(path);
                    files = dir.GetFiles();
                }
                catch (Exception ex)
                {
                    string stackTrace = "Classe FileDir().OpenDir: \n" + ex.StackTrace;
                    throw ex;
                }
            }
            else
                throw new Exception("Classe FileDir().OpenDir: Caminho do diretorio não informado.");

            return files;
        }
    }
}
