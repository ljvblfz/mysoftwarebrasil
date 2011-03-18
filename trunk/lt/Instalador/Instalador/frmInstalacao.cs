using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Instalacao.Properties;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Data.SqlServerCe;

namespace Instalador
{
    public partial class frmInstalacao : Form
    {
        private string caminhoArquivo;
        private bool atualizacao;
        private string diretorioAplicacao = "ltmobile";
        private string executavel = "LTmobile.exe";
        private const string COPIA = "Instalador.Resources";
        private const string SQL = "Instalacao.Sql";

        public frmInstalacao(bool atualizacao)
        {
            InitializeComponent();

            // Inicia o diretório de destino, alterando a variável caminhoArquivo dentro do método
            RetornaDiretorio();
            lblDiretorio.Text = "Diretório de destino:\n" + caminhoArquivo;

            // Variável que armazena a informação do tipo de execução
            this.atualizacao = atualizacao;

            // Verifica se a execução é automática (atualização via WebService)
            if (atualizacao)
            {
                // Substitui a pergunta por uma mensagem
                lblPergunta.Text = "Iniciando atualização dos arquivos...";

                // Inicia a cópia
                menuItem1_Click(null, EventArgs.Empty);
            }
        }

        #region Classe de controle de arquivos

        private class Arquivo
        {
            public string Nome;
            public byte[] Dados;
        }

        #endregion

        #region Enumeração de tipos de arquivos

        /// <summary>
        /// Tipo de arquivo de resource.
        /// </summary>
        private enum TipoArquivo
        {
            Copia,
            Sql,
            Desconhecido
        }

        #endregion

        #region Métodos privados

        /// <summary>
        /// Retorna o número total de arquivos.
        /// </summary>
        /// <returns>O número total de arquivos.</returns>
        private int NumeroArquivos()
        {
            return ListaArquivos(TipoArquivo.Copia).Length + ListaArquivos(TipoArquivo.Sql).Length;
        }

        /// <summary>
        /// Recupera uma lista de arquivos do tipo desejado.
        /// </summary>
        /// <param name="tipo">O tipo de arquivo desejado.</param>
        /// <returns>Um array de Arquivo.</returns>
        private Arquivo[] ListaArquivos(TipoArquivo tipo)
        {
            // Retorna os arquivos que serão copiados
            string[] arquivos = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            // Cria a lista de retorno
            List<Arquivo> retorno = new List<Arquivo>();
            foreach (string a in arquivos)
            {
                // Verifica se é um arquivo que será copiado
                if (GetTipoArquivo(a) != tipo) continue;

                // Cria o objeto que representa o arquivo
                Arquivo arquivo = new Arquivo();
                arquivo.Nome = CaminhoArquivo(tipo, a);
                arquivo.Dados = DadosArquivo(a);

                // Adiciona à lista de retorno
                retorno.Add(arquivo);
            }

            // Retorna a lista
            return retorno.ToArray();
        }

        /// <summary>
        /// Indica se o arquivo deve ser copiado.
        /// </summary>
        /// <param name="resource">O nome do resource.</param>
        /// <returns>Verdadeiro se o arquivo for copiado.</returns>
        private TipoArquivo GetTipoArquivo(string resource)
        {
            if (resource.IndexOf(COPIA) == 0)
                return TipoArquivo.Copia;
            else if (resource.IndexOf(SQL) == 0)
                return TipoArquivo.Sql;

            return TipoArquivo.Desconhecido;
        }

        /// <summary>
        /// Retorna o nome do arquivo que será salvo.
        /// </summary>
        /// <param name="resource">O nome do resource.</param>
        /// <returns>Uma string com o caminho do arquivo.</returns>
        private string CaminhoArquivo(TipoArquivo tipo, string resource)
        {
            if (tipo == TipoArquivo.Desconhecido)
                throw new ArgumentException("Tipo de arquivo desconhecido.", "tipo");
            else if (tipo != TipoArquivo.Copia)
                return null;

            const string INICIO = "Instalacao.Resources.";
            string arquivo = resource.Substring(INICIO.Length);

            return caminhoArquivo + "\\" + arquivo;
        }

        /// <summary>
        /// Retorna o conteúdo de um arquivo.
        /// </summary>
        /// <param name="resource">O nome do resource que será lido.</param>
        /// <returns>Um vetor de bytes com os dados do arquivo.</returns>
        private byte[] DadosArquivo(string resource)
        {
            // Variável de retorno
            byte[] retorno;

            try
            {
                // Lê o arquivo
                using (Stream dados = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    retorno = new byte[(int)dados.Length];
                    dados.Read(retorno, 0, retorno.Length);
                }
            }
            catch
            {
                // Em caso de erro, retorno vazio
                retorno = new byte[0];
            }

            // Retorna o conteúdo do arquivo
            return retorno;
        }

        #endregion

        #region Métodos usados no thread secundário

        #region Delegates

        /// <summary>
        /// Delegate usado no método SetPropertyValue.
        /// </summary>
        /// <param name="control">O controle que será alterado.</param>
        /// <param name="propertyName">O nome da propriedade que será alterada.</param>
        /// <param name="value">O novo valor da propriedade.</param>
        private delegate void SetValueInvoke(Control control, string propertyName, object value);

        /// <summary>
        /// Delegate usado no método GetPropertyValue.
        /// </summary>
        /// <param name="control">O controle que será alterado.</param>
        /// <param name="propertyName">O nome da propriedade que será alterada.</param>
        private delegate object GetValueInvoke(Control control, string propertyName);

        /// <summary>
        /// Delegate usado no método InvokeMethod.
        /// </summary>
        /// <param name="control">O controle que será usaado para a invocação do método.</param>
        /// <param name="methodName">O nome do método.</param>
        /// <param name="parameters">Os parâmetros do método.</param>
        public delegate object MethodInvoke(Control control, string methodName, object[] parameters);

        #endregion

        #region Métodos básicos

        /// <summary>
        /// Altera o valor de uma propriedade do controle desejado.
        /// </summary>
        /// <param name="control">O controle que será alterado.</param>
        /// <param name="propertyName">O nome da propriedade que será alterada.</param>
        /// <param name="value">O novo valor da propriedade.</param>
        private void SetPropertyValue(Control control, string propertyName, object value)
        {
            if (control.InvokeRequired)
            {
                SetValueInvoke d = new SetValueInvoke(SetPropertyValue);
                control.Invoke(d, new object[] { control, propertyName, value });
            }
            else
                control.GetType().GetProperty(propertyName).SetValue(control, value, null);
        }

        /// <summary>
        /// Retorna o valor de uma propriedade do controle desejado.
        /// </summary>
        /// <param name="control">O controle que será alterado.</param>
        /// <param name="propertyName">O nome da propriedade que será alterada.</param>
        private object GetPropertyValue(Control control, string propertyName)
        {
            if (control.InvokeRequired)
            {
                GetValueInvoke d = new GetValueInvoke(GetPropertyValue);
                return control.Invoke(d, new object[] { control, propertyName });
            }
            else
                return control.GetType().GetProperty(propertyName).GetValue(control, null);
        }

        /// <summary>
        /// Retorna o valor de uma propriedade do controle desejado.
        /// </summary>
        /// <param name="control">O controle que será alterado.</param>
        /// <param name="propertyName">O nome da propriedade que será alterada.</param>
        private object GetPropertyValue(MenuItem control, string propertyName)
        {
            return control.GetType().GetProperties()[3].GetValue(control, null);
        }

        /// <summary>
        /// Invoca um método do controle desejado.
        /// </summary>
        /// <param name="control">O controle que será usado para a invocação do método.</param>
        /// <param name="methodName">O nome do método.</param>
        /// <param name="parameters">Os parâmetros do método.</param>
        /// <returns>O objeto contendo o retorno do método invocado.</returns>
        private object InvokeMethod(Menu control, string methodName, object[] parameters)
        {
            return control.MenuItems[0].GetType().GetMethod(methodName).Invoke(control, parameters);
        }
        
        /// <summary>
        /// Invoca um método do controle desejado.
        /// </summary>
        /// <param name="control">O controle que será usado para a invocação do método.</param>
        /// <param name="methodName">O nome do método.</param>
        /// <param name="parameters">Os parâmetros do método.</param>
        /// <returns>O objeto contendo o retorno do método invocado.</returns>
        private object InvokeMethod(Control control, string methodName, object[] parameters)
        {
            if (control.InvokeRequired)
            {
                MethodInvoke d = new MethodInvoke(InvokeMethod);
                return control.Invoke(d, new object[] { control, methodName, parameters });
            }
            else
                return control.GetType().GetMethod(methodName).Invoke(control, parameters);
        }

        #endregion

        /// <summary>
        /// Altera o texto do label de progresso.
        /// </summary>
        /// <param name="texto">O texto que será escrito no label.</param>
        private void AlterarTextoProgresso(string texto)
        {
            SetPropertyValue(lblProgresso, "Text", texto);
            Thread.Sleep(150);
        }

        /// <summary>
        /// Inicia os dados da barra de progresso.
        /// </summary>
        /// <param name="valorMaximo">O valor máximo permitido pela barra de progresso.</param>
        private void IniciarBarraProgresso(int valorMaximo)
        {
            SetPropertyValue(pbrArquivos, "Value", 0);
            SetPropertyValue(pbrArquivos, "Minimum", 0);
            SetPropertyValue(pbrArquivos, "Maximum", valorMaximo);
        }

        /// <summary>
        /// Soma o valor passado à barra de progresso.
        /// </summary>
        /// <param name="valor">O valor que será somado à barra de progresso.</param>
        private void SomaProgresso(int valor)
        {
            SetPropertyValue(pbrArquivos, "Value", ProgressoAtual() + valor);
        }

        /// <summary>
        /// Retorna o valor atual da barra de progresso.
        /// </summary>
        /// <returns>A propriedade Value da barra de progresso.</returns>
        private int ProgressoAtual()
        {
            return Convert.ToInt32(GetPropertyValue(pbrArquivos, "Value"));
        }

        /// <summary>
        /// Fecha o programa e executa o GeFiscMobile.
        /// </summary>
        private void FecharAtualizacao()
        {
            AlterarTextoProgresso("Atualização Concluida!!");
            AlterarTextoProgresso("Reinicie a aplicação!!");
            Thread.Sleep(500);

            //this.Close();

            /*Menu form = (Menu)GetPropertyValue(fo, "Parent");
            InvokeMethod(form, "Close", new object[] { });*/

            
            //System.Diagnostics.Process.Start(caminhoArquivo + "\\" + executavel, "-fa");*/
            Program.status = false;
        }

        #endregion

        #region Cópia dos arquivos

        /// <summary>
        /// Método de cópia dos arquivos.
        /// </summary>
        private void Copiar()
        {
            Program.status = true;
            try
            {
                // Inicia o label de progresso
                AlterarTextoProgresso("Recuperando lista de arquivos...");

                // Recupera a lista de arquivos que serão copiados
                Arquivo[] arquivos = ListaArquivos(TipoArquivo.Copia);

                // Inicia os objetos de progresso
                IniciarBarraProgresso(NumeroArquivos());

                // Copia os arquivos
                foreach (Arquivo a in arquivos)
                {
                    // Atualiza os objetos de progresso
                    SomaProgresso(1);
                    AlterarTextoProgresso("Copiando arquivo " + ProgressoAtual() + " de " + arquivos.Length.ToString() + "..." +
                        "\nArquivo: " + a.Nome);

                    // Sobrescreve o arquivo
                    if (File.Exists(a.Nome)) File.Delete(a.Nome);
                    using (FileStream f = File.Create(a.Nome))
                    {
                        f.Write(a.Dados, 0, a.Dados.Length);
                        f.Flush();
                    }
                }

                // Indica o fim do processo
                AlterarTextoProgresso("Arquivos copiados com sucesso!");

                // Espera 1,5 segundos antes de finalizar (tempo de leitura do sucesso)
                Thread.Sleep(1500);

                // Verifica se há execução de SQL e, caso haja, se a execução foi bem sucedida
                if (ExecutarSql())
                {
                    // Espera 1,5 segundos antes de finalizar (tempo de leitura do sucesso)
                    Thread.Sleep(1500);
                }
            }
            catch (Exception ex)
            {
                // Indica o erro
                AlterarTextoProgresso("Erro ao copiar: " + ex.Message);

                // Espera 3 segundos antes de finalizar (tempo de leitura do erro)
                Thread.Sleep(3000);
            }

            // Verifica se o processo foi automático
            if (atualizacao)
                FecharAtualizacao();
        }

        #endregion

        #region Execução de SQL

        /// <summary>
        /// Método de execução de SQL.
        /// </summary>
        /// <returns>Verdadeiro, se a mensagem final for de sucesso na operação.</returns>
        private bool ExecutarSql()
        {
            // Inicia o label de progresso
            AlterarTextoProgresso("Verificando se há alteração no banco de dados...");

            // Espera 0,5 segundo para que o usuário leia a mensagem
            Thread.Sleep(500);

            // Recupera a lista de arquivos que será executada
            Arquivo[] arquivos = ListaArquivos(TipoArquivo.Sql);

            // Verifica se há arquivos para execução
            if (arquivos.Length == 0)
            {
                // Inicia o label de progresso
                AlterarTextoProgresso("Não há alteração no banco de dados");

                // Indica que a exeução foi correta
                return true;
            }

            // Variável de controle de execução
            bool executou = false;

            // Altera o label de progresso
            AlterarTextoProgresso("Executando alterações no banco de dados...");

            try
            {
                // Cria a conexão com o banco de dados
                using (SqlCeConnection conexao = new SqlCeConnection("Data Source= \"" + caminhoArquivo + "\\GEFiscDB.sdf\"; password='velp2009'"))
                {
                    // Abrea a conexão
                    conexao.Open();

                    // Cria o comando de acesso ao banco de dados
                    using (SqlCeCommand comando = conexao.CreateCommand())
                    {
                        // Verifica todos os arquivos da lista de execução
                        foreach (Arquivo a in arquivos)
                        {
                            // Recupera os dados do arquivo
                            string dadosArquivo = Encoding.UTF8.GetString(a.Dados, 0, a.Dados.Length).Trim();

                            // Verifica se o arquivo possui texto
                            if (dadosArquivo.Length == 0)
                                continue;

                            // Indica a execução do código
                            executou = true;

                            // Separa as linhas do arquivo
                            string[] linhas = dadosArquivo.Split('\n');

                            // Executa os comandos de cada linha
                            foreach (string s in linhas)
                            {
                                // Linha que será executada
                                string executar = s.Trim();

                                // Verifica se a linha possui um comentário
                                if (executar.IndexOf("--") > -1)
                                {
                                    // Remove o comentário da linha
                                    if (executar.IndexOf("--") > 0)
                                        executar = executar.Substring(0, executar.IndexOf("--"));

                                    // Se a linha for um comentário, ignora-a
                                    else
                                        continue;
                                }

                                // Verifica se a linha está vazia
                                if (executar.Trim().Length == 0)
                                    continue;

                                // Executa a linha
                                comando.CommandText = executar.Trim();
                                comando.ExecuteNonQuery();
                            }

                            // Atualiza a barra de progresso
                            SomaProgresso(1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Inicia o label de progresso
                AlterarTextoProgresso("Erro na alteração do banco: " + ex.Message);

                // Espera 3 segundos para que a mensagem de erro seja lida
                Thread.Sleep(3000);

                // Indica que a execução foi falha
                return false;
            }

            if (!executou)
            {
                // Inicia o label de progresso
                AlterarTextoProgresso("Não há alteração no banco de dados");
            }
            else
            {
                // Inicia o label de progresso
                AlterarTextoProgresso("Banco de dados alterado com sucesso!");
            }

            // Indica que a exeução foi correta
            return true;
        }

        #endregion

        #region Métodos de retorno do diretório de cópia

        [System.Runtime.InteropServices.DllImport("Coredll.dll")]
        static extern int SHGetSpecialFolderPath(IntPtr hwndOwner, StringBuilder lpszPath, int nFolder, int fCreate);

        private const int CSIDL_PROGRAM_FILES = 0x0026;

        /// <summary>
        /// Cria a variável (caminhoArquivo) que retorna o diretório onde os arquivos serão copiados.
        /// </summary>
        private void RetornaDiretorio()
        {
            StringBuilder b = new StringBuilder(255);
            SHGetSpecialFolderPath(IntPtr.Zero, b, CSIDL_PROGRAM_FILES, 0);

            caminhoArquivo = b.ToString() + "\\" + diretorioAplicacao;
            if (!Directory.Exists(caminhoArquivo))
                Directory.CreateDirectory(caminhoArquivo);
        }

        #endregion

        private void frmInstalacao_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.F1))
            {
                // Soft Key 1
                // Not handled when menu is present.
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.F2))
            {
                // Soft Key 2
                // Not handled when menu is present.
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D1))
            {
                // 1
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D2))
            {
                // 2
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D3))
            {
                // 3
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D4))
            {
                // 4
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D5))
            {
                // 5
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D6))
            {
                // 6
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D7))
            {
                // 7
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D8))
            {
                // 8
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D9))
            {
                // 9
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.F8))
            {
                // *
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.D0))
            {
                // 0
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.F9))
            {
                // #
            }

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            // Verifica se a execução é automática (atualização via WebService)
            if (!atualizacao || (atualizacao && !Program.status))
            {
                // Inicia a cópia assíncrona
                Thread copiar = new Thread(new ThreadStart(Copiar));
                copiar.Start();
                Program.status = true;
            }
            else
            {
                MessageBox.Show("Execução é automática reinicie a aplicação.");
            }
        }
        
        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (!Program.status)
            {
                this.Close();
                System.Diagnostics.Process.Start(caminhoArquivo + "\\" + executavel, "-fa");
            }
            else
            {
                MessageBox.Show("Aguarde o fim da atualização.");
            }
        }

        //Fecha a aplicacao
        private void CloseApp()
        {
            this.Close();
        }
    }
}