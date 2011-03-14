using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DeviceProject.Util;
using DeviceProject.referencia;
using DeviceProject.Sincronizacao;
using System.Text.RegularExpressions;

namespace DeviceProject.Config
{
    /// <summary>
    ///  Classe de controle da tela de configuração
    /// </summary>
    public partial class ConfiguracaoWeb : Form
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ConfiguracaoWeb()
        {
            InitializeComponent();
            LoadDadosWebService();
        }

        /// <summary>
        /// Salvar as configurações
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxServidor.Text))
            {
                MessageBox.Show("Servidor não informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (string.IsNullOrEmpty(tbxServico.Text))
            {
                MessageBox.Show("Serviço não informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            // Atualiza os valores de usuario e web server
            ConfiguracaoPDA.CurrentInstance.WebServiceAddress = UrlWebService();
            ConfiguracaoPDA.CurrentInstance.Username = userTextBox.Text;
            ConfiguracaoPDA.CurrentInstance.Servidor = tbxServidor.Text;
            ConfiguracaoPDA.CurrentInstance.Porta = tbxPorta.Text;
            ConfiguracaoPDA.CurrentInstance.Diretorio = tbxDiretorio.Text;
            ConfiguracaoPDA.CurrentInstance.Servico = tbxServico.Text;

            // Habilitar e desabilitar a sincronização automatica
            if (checkBox1.Checked)
                ConfiguracaoPDA.CurrentInstance.SincronizacaoAuto = "TRUE";
            else
                ConfiguracaoPDA.CurrentInstance.SincronizacaoAuto = "FALSE";


            ConfiguracaoPDA.CurrentInstance.Password = passwordTextBox.Text;

            // Salva as configurações no registro do PDA
            ConfiguracaoPDA.SaveCurrent();

            //// Mostra a mensagem informando que deve ser fechada.
            DialogResult r = MessageBox.Show("É necessário fechar o sistema para aplicar as alterações.\nDeseja fazer isso agora?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                Application.Exit();  
 
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// Fecha a aplicação
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        /// <summary>
        /// Faz um teste no web server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Variaveis de retorno das validaçoes
            bool testeWebSever = false;
            bool testeBD = false;

            // Intancia do web server
            //            Service1 _webService = new Service1();

            try
            {
                #region//**** VALIDACAO 1 VERIFICA SER A STRING DA URL ESTA NO FORMATO CORRETO****//

                // Valida o web server
                if (!DeviceProject.Util.ExtensionMethods.ValidaURL(UrlWebService(), 1))
                    DeviceProject.Util.ExtensionMethods.MsgError("O endereço do web service esta escrito errado.", "Erro");

                #endregion

                #region//**** VALIDACAO 2 VERIFICA CONEXÃO WEB SERVER****//

                // Valida o web server
                testeWebSever = DeviceProject.Util.ExtensionMethods.CheckConnected(UrlWebService());
                if (!testeWebSever)
                    DeviceProject.Util.ExtensionMethods.MsgError("Não foi possivel conectar ao web service.", "Erro");
                #endregion

                #region//**** VALIDACAO 3 VERIFICA CONEXÃO COM BANCO DE DADOS DO WEB SERVER ****//

                // Veirifica se o web server foi validado
                if (testeWebSever)
                {
                    // Verifica se o endereço do web server foi alterado
                    if (UrlWebService() != ConfiguracaoPDA.CurrentInstance.WebServiceAddress)
                        Sincronizar._webService.Url = UrlWebService();

                    // Altera o timeout do web server
                    Sincronizar._webService.Timeout = 10000;

                    // Realiza o teste com o banco do web sever
                    testeBD = Sincronizar._webService.teste();

                    // Verifica se houve a conecxão com o banco de dados
                    if (!testeBD)
                        DeviceProject.Util.ExtensionMethods.MsgError("Não foi possivel conectar ao banco de dados do webServer.", "Erro");
                }
                #endregion
            }
            catch (Exception ex)
            {
                DeviceProject.Util.ExtensionMethods.MsgError(ex.Message, "Erro");
            }

            // Verifica se todas as validações estão corretas
            if (testeBD && testeWebSever)
                DeviceProject.Util.ExtensionMethods.MsgInfomation("Teste finalizado com sucesso", "Ok");
        }

        //carrega os dados de web service e de usuario.
        public void LoadDadosWebService()
        {
            tbxServidor.Text = ConfiguracaoPDA.CurrentInstance.Servidor;
            tbxPorta.Text = ConfiguracaoPDA.CurrentInstance.Porta;
            tbxDiretorio.Text = ConfiguracaoPDA.CurrentInstance.Diretorio;
            tbxServico.Text = ConfiguracaoPDA.CurrentInstance.Servico;
            userTextBox.Text = ConfiguracaoPDA.CurrentInstance.Username;
            passwordTextBox.Text = ConfiguracaoPDA.CurrentInstance.Password;
            tbxIdPda.Text = ConfiguracaoPDA.GetDeviceID();

            // Carrega os dados de configuração
            if (ConfiguracaoPDA.CurrentInstance.SincronizacaoAuto == "TRUE")
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
        }

        //salva a url no registro
        public string UrlWebService()
        {
            string url = string.Empty;

            url = "http://";
            url += tbxServidor.Text.Trim();
            url += (string.IsNullOrEmpty(tbxPorta.Text)) ? "" : ":" + tbxPorta.Text.Trim();
            url += (string.IsNullOrEmpty(tbxDiretorio.Text)) ? "" : "/" + tbxDiretorio.Text.Trim();
            url += "/" + tbxServico.Text.Trim();

            return url;
        }
    }
}