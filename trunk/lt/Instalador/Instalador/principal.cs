using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Instalador
{
    public partial class principal : Form
    {
        private string dataBase = "GEFiscDB.sdf";
        private string passwordDataBase = "velp2009";
        private string executavel = "\\Program Files\\ltmobile\\LTmobile.exe";
        private string dirOrigem = "\\Program Files\\ltmobile\\Resources\\";
        private string dirDestino = "\\Program Files\\ltmobile\\";

        public principal()
        {
            InitializeComponent();
            lblDiretorio.Text = "Diretório de destino:\n" + dirDestino;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(executavel, "-fa");
            this.Close();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            //Thread updater = new Thread(new ThreadStart(animacaoBarra));
            //updater.Start();
            this.Copy();
            //updater.Abort();
        }

        public void Copy()
        {
            try
            {
                List<string> listaArquivo = getArquivos();

                if (listaArquivo.Count > 0)
                {
                    foreach(string itemArquivo in listaArquivo)
                    {
                        if (System.IO.Directory.Exists(dirOrigem) && System.IO.Directory.Exists(dirDestino))
                        {
                            System.IO.FileInfo a = new System.IO.FileInfo(dirOrigem + itemArquivo);
                            if (File.Exists(dirDestino + itemArquivo))
                                a.Delete();

                            if (File.Exists(dirOrigem + itemArquivo))
                            {
                                File.Copy(dirOrigem + itemArquivo, dirDestino + itemArquivo);
                                lblProgresso.Text = "Copiando o Arquivo :" + itemArquivo;
                            }

                            // Escreve na janela OutPut do VS.NET
                            System.Diagnostics.Debug.WriteLine("Copiando o Arquivo :" + itemArquivo);
                        }
                    }
                    lblProgresso.Text = "Copia concluida"; 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu um erro na aplicação detalhes :" + e.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            MessageBox.Show("Atualização do aplicativo concluida.", "INSTALAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        public List<string> getArquivos()
        {
            System.IO.DirectoryInfo a = new System.IO.DirectoryInfo(dirOrigem);
            List<string> listaArquivo = new List<string>();
            if (a.Exists)
            {
                foreach (System.IO.FileInfo b_loopVariable in a.GetFiles())
                {
                    listaArquivo.Add(b_loopVariable.Name);
                    // Escreve na janela OutPut do VS.NET
                    System.Diagnostics.Debug.WriteLine("Arquivo encontrado :" + b_loopVariable.Name);
                }
            }
            return listaArquivo;
        }

        public void animacaoBarra()
        {
            pbrArquivos.Value = 0;
            for (int i = 0; i <= 100; i++)
            {
                if (i < 100)
                    pbrArquivos.Value = i;
                else
                {
                    pbrArquivos.Value = i;
                    i = 0;
                }
            }
        }
    }
}