using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LTmobile.Sincronizacao;
using System.Windows.Forms;
using System.Threading;

namespace LTmobile
{
    public static class AtualizaVersao
    {
        /// <summary>
        /// Caminho da aplicação
        /// </summary>
        public static string caminhoLocal = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName)+"\\Resources\\";

        /// <summary>
        /// Sincronização
        /// </summary>
        public static WS_ltMobile webService = new WS_ltMobile();

        /// <summary>
        ///  Nome do aplicativo
        /// </summary>
        public static string aplicativo = "Instalador.exe";

        /// <summary>
        ///  Usuario corrente TODO: NÃO IMPLEMENTADA
        /// </summary>
        public static int usuario = 0;

        /// <summary>
        ///  Atualiza a aplicação
        /// </summary>
        public static void Atualizar()
        {  
            webService.Url = new ConfigWebService().WebServiceCurrent;
           // webService.Url = "http://192.168.1.106:4204/WS_ltMobile.asmx";
            long[] tamanhoArquivo;
            string caminhoAtualizacao = caminhoLocal + aplicativo;
            int cont = 0;
        tentativa:
            try
            {
                // Altera a barra de progresso
                tamanhoArquivo = webService.GetLastVersionFileLength(usuario, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }
            catch(Exception e)
            {
                if (cont < 4)
                {
                    cont++;
                    goto tentativa;
                }
                else
                    throw e;
            }

            if (tamanhoArquivo != null)
            {
                try
                {
                    if (!Directory.Exists(caminhoLocal))
                    {
                        DirectoryInfo dir = new DirectoryInfo(caminhoLocal);
                        dir.Create();
                    }
                    
                    // Recupera e salva o arquivo de atualização
                    using (FileStream f = File.Create(caminhoAtualizacao))
                    {
                        byte[] temp;
                        int partNumber = 0;
                        while (true)
                        {
                            cont = 0;
                        tentativaArquivo:
                            try
                            {
                                temp = webService.GetLastVersionFile(usuario, System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), partNumber++);
                                if ((temp == null) || (temp.Length == 0))
                                {
                                    f.Close();
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (cont < 4)
                                {
                                    cont++;
                                    goto tentativaArquivo;
                                }
                                else
                                    throw ex;
                            }
                            f.Write(temp, 0, temp.Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                MessageBox.Show("Existe uma nova versão disponivel para atualização.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
