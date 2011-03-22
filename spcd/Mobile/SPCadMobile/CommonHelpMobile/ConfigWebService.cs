using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CommonHelpMobile
{
    public class ConfigWebService
    {
        public string WebServiceCurrent{get; set;}
        public string LoginWebService { get; set; }
        public string SenhaWebService { get; set; }
        public string SerialDevice { get; set; }
        public string TimeOutWebService { get; set; }

        public ConfigWebService()
        {
            SetConfigAtual();
        }

        public void CreateKey()
        {
            // Cria uma referêcnia para a chave de registro 'Software'
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);

            //testa se existe as chaves no registro, se não, elas são criadas.
            rk = rk.OpenSubKey("SPCadWebService");           
            try
            {
                if (rk != null)
                {
                    return;
                }
                else
                {
                    rk = Registry.LocalMachine.OpenSubKey("Software", true);
                    rk.CreateSubKey("SPCadWebService").CreateSubKey("Parametro");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na leitura ou gravação no Registro: " + ex.Message);
            }
            finally
            {
                if(rk != null)rk.Close();
            }
        }

        /// <summary>
        /// Atualiza as propriedades com os dados de configuração do webservice.
        /// </summary>
        public void SetConfigAtual()
        {
            // Pega numero de série do equipamento
            SerialDevice = ConfigWebService.GetDeviceID();
            TimeOutWebService = "5";
            // Cria uma referêcnia para a chave de registro 'Software'
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);
            try
            {
                rk = rk.OpenSubKey("SPCadWebService");
                if(rk != null) rk = rk.OpenSubKey("Parametro");         
                if (rk == null) return; //se as chaves existirem o processo continua                
                if (rk.ValueCount == 0) return;

                rk = Registry.LocalMachine.OpenSubKey("Software", true);
                WebServiceCurrent = rk.OpenSubKey("SPCadWebService", true).OpenSubKey("Parametro", true).GetValue("WEBSERVICE").ToString();
                LoginWebService = rk.OpenSubKey("SPCadWebService", true).OpenSubKey("Parametro", true).GetValue("IDUSUARIO").ToString();
                SenhaWebService = rk.OpenSubKey("SPCadWebService", true).OpenSubKey("Parametro", true).GetValue("SENHA").ToString();
                TimeOutWebService = rk.OpenSubKey("SPCadWebService", true).OpenSubKey("Parametro", true).GetValue("TIMEOUT").ToString();
                
            }
            catch (NullReferenceException)
            {
               
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao consultar registro: " + erro.Message);
            }
            finally
            {
                if(rk != null)rk.Close();
            }
        }

        /// <summary>
        /// configura o webservice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetWebService(string webService, string usuario, string senha, string timeOut)
        {           
            // Cria uma referêcnia para a chave de registro 'Software'
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);

            try
            {
                if (timeOut.Trim() == "") timeOut = "5";

                // Realiza a inserção da chave no registro
                rk.OpenSubKey("SPCadWebService", true).OpenSubKey("Parametro", true).SetValue("WEBSERVICE", webService);
                rk.OpenSubKey("SPCadWebService", true).OpenSubKey("Parametro", true).SetValue("IDUSUARIO", usuario);
                rk.OpenSubKey("SPCadWebService", true).OpenSubKey("Parametro", true).SetValue("SENHA", senha);
                rk.OpenSubKey("SPCadWebService", true).OpenSubKey("Parametro", true).SetValue("TIMEOUT", timeOut);              
               
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir chave no registro: " + ex.Message);
            }
            finally
            {
                rk.Close();
            }            
        }

        [DllImport("coredll.dll")]
        private extern static int GetDeviceUniqueID([In, Out] byte[] appdata,
            int cbApplictionData, int dwDeviceIDVersion,
            [In, Out] byte[] deviceIDOuput, out uint pcbDeviceIDOutput);

        /// <summary>
        /// Retorna o identificador do dispositivo.
        /// </summary>
        /// <returns>O ID do dispositivo.</returns>
        public static string GetDeviceID()
        {
            // Retorna os bytes com o nome do aplicativo
            string appString = "SPCadVelp";
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
    }
}
