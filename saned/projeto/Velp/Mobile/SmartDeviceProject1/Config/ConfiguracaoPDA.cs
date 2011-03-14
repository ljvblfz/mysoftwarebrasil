using Microsoft.Win32;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DeviceProject.Config
{
    /// <summary>
    ///  Classe de configuração da aplicação
    /// </summary>
    public class ConfiguracaoPDA
    {       
        
        #region Variáveis Locais

        private string _webServiceAddress = string.Empty;

        private string _username = string.Empty;

        private string _password = string.Empty;

        #endregion

        #region Propriedades

        public string Servidor { get; set; }
        public string Porta { get; set; }
        public string Diretorio { get; set; }
        public string Servico { get; set; }
        public string SincronizacaoAuto { get; set; }

        /// <summary>
        /// Endereço do WebService.
        /// </summary>
        public string WebServiceAddress
        {
            get { return _webServiceAddress; }
            set { _webServiceAddress = value; }
        }

        /// <summary>
        /// Usuário de acesso no WebService.
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// Senha de acesso do WebService.
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        #endregion

        #region Construtores

        /// <summary>
        /// Define um construtor privado.
        /// </summary>
        private ConfiguracaoPDA()
        {

        }

        #endregion

        #region Variáveis Estáticas

        /// <summary>
        /// Instancia do elemento geral de configuração.
        /// </summary>
        private static ConfiguracaoPDA _current;

        #endregion

        #region Métodos Estáticos

        /// <summary>
        /// Configurações atuais
        /// </summary>
        public static ConfiguracaoPDA CurrentInstance
        {
            get
            {
                if (_current == null)
                    RefreshCurrent();

                return _current;
            }

            set
            {
                _current = value;
            }
        }

        /// <summary>
        /// Atualiza as informações da atual configuração.
        /// </summary>
        public static void RefreshCurrent()
        {
            _current = new ConfiguracaoPDA();

            RegistryKey pRegSoftware = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            RegistryKey reg = pRegSoftware.OpenSubKey("SANED", true);

            // Verifica se os dados de configuração ainda não foram carregados
            if (reg == null)
            {
                // Cria a chave onde serão armazenados os dados da aplicação
                reg = pRegSoftware.CreateSubKey("SANED");
                //reg.SetValue("WebServiceAddress", "http://200.220.157.141:9086/Service1.asmx");
                reg.SetValue("WebServiceAddress", "http://192.168.1.106:8080/Service1.asmx");
                reg.SetValue("Username", "19");
                reg.SetValue("Password", "");
                reg.SetValue("Sincronizacao_auto", "TRUE");
            }
            else
            {
                _current.WebServiceAddress = reg.GetValue("WebServiceAddress", "").ToString();
                _current.Username = reg.GetValue("Username", "").ToString();
                _current.Password = reg.GetValue("Password", "").ToString();
                _current.Servidor = reg.GetValue("Servidor", "").ToString();
                _current.Porta = reg.GetValue("Porta", "").ToString();
                _current.Diretorio = reg.GetValue("Diretorio", "").ToString();
                _current.Servico = reg.GetValue("Servico", "").ToString();
                _current.SincronizacaoAuto = reg.GetValue("Sincronizacao_auto", "").ToString();
            }
        }

        /// <summary>
        /// Salva o arquivo de configuração.
        /// </summary>
        /// <exception cref="Exception">Quando ocorre algum erro ao salvar o arquivo de configuração.</exception>
        public static void SaveCurrent()
        {
            if (_current == null) return;

            RegistryKey pRegSoftware = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            RegistryKey reg = pRegSoftware.OpenSubKey("SANED", true);

            if (reg == null)
                reg = pRegSoftware.CreateSubKey("SANED");

            reg.SetValue("WebServiceAddress", _current.WebServiceAddress);
            reg.SetValue("Username", (_current.Username == null ? "" : _current.Username));
            reg.SetValue("Password", (_current.Password == null ? "" : _current.Password));
            reg.SetValue("Servidor", _current.Servidor);
            reg.SetValue("Porta", (string.IsNullOrEmpty(_current.Username)) ? "" : _current.Porta);
            reg.SetValue("Diretorio", (string.IsNullOrEmpty(_current.Diretorio)) ? "" : _current.Diretorio);
            reg.SetValue("Servico", (_current.Servico == null ? "" : _current.Servico));
            reg.SetValue("Sincronizacao_auto", (_current.SincronizacaoAuto == null ? "" : _current.SincronizacaoAuto));
        }

        [DllImport("coredll.dll")]
        private extern static int GetDeviceUniqueID([In, Out] byte[] appdata, int cbApplictionData, int dwDeviceIDVersion, [In, Out] byte[] deviceIDOuput, out uint pcbDeviceIDOutput);

        /// <summary>
        /// Retorna o identificador do dispositivo.
        /// </summary>
        /// <returns>O ID do dispositivo.</returns>
        public static string GetDeviceID()
        {
            // Retorna os bytes com o nome do aplicativo
            string appString = "SanedVelp";
            byte[] appData = new byte[appString.Length];
            for (int count = 0; count < appString.Length; count++)
                appData[count] = (byte)appString[count];

            // Variáveis auxiliares
            int appDataSize = appData.Length;
            byte[] deviceOutput = new byte[20];
            uint sizeOut = 20;

            // Retorna o identificador do dispositivo
            GetDeviceUniqueID(appData, appDataSize, 1, deviceOutput, out sizeOut);
            return Convert.ToBase64String(deviceOutput);
        }

        #endregion

    }
}
