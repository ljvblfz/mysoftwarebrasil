using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace LTmobile
{
    public class ConfigWebService
    {
        public string WebServiceCurrent { get; set; }
        public string LoginWebService { get; set; }
        public string SenhaWebService { get; set; }
        public string IntervaloWebService { get; set; }
        public string QuantidadeWebService { get; set; }
        public static bool LigarGpsWebService { get; set; }
        public static string FormatoLeitura { get; set; }
        
        public ConfigWebService()
        {
            SetConfigAtual();
        }

        /// <summary>
        /// Cria chave de registro
        /// </summary>
        public void CreateKey()
        {
            // Cria uma referêcnia para a chave de registro 'Software'
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);

            //testa se existe as chaves no registro, se não, elas são criadas.
            rk = rk.OpenSubKey("LTmobileWebService");
            try
            {
                if (rk != null)
                {
                    return;
                }
                else
                {
                    rk = Registry.LocalMachine.OpenSubKey("Software", true);
                    rk.CreateSubKey("LTmobileWebService").CreateSubKey("Parametro");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na leitura ou gravação no Registro: " + ex.Message);
            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }

        /// <summary>
        /// configura o webservice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetWebService(string webService, string usuario, string senha, string intervalo, string quantidade, bool ligarGps)
        {
            // Cria uma referêcnia para a chave de registro 'Software'
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);

            try
            {
               // if (timeOut.Trim() == "") timeOut = "5";

                // Realiza a inserção da chave no registro
                rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).SetValue("WEBSERVICE", webService);
                rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).SetValue("IDUSUARIO", usuario);
                rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).SetValue("SENHA", senha);
                rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).SetValue("INTERVALO", intervalo);
                rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).SetValue("QUANTIDADE", quantidade);
                rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).SetValue("LIGARGPS", ligarGps);
                

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

        public void setFormatoLeitura(string FormatoLeitura)
        {
            // Cria uma referêcnia para a chave de registro 'Software'
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);

            try
            {
                // if (timeOut.Trim() == "") timeOut = "5";

                // Realiza a inserção da chave no registro
                rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).SetValue("FormatoLeitura", FormatoLeitura);               


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

        private static void ConvertToBoolean(string value)
        {
            try
            {
                Console.WriteLine("Converted '{0}' to {1}.", value,
                                  Convert.ToBoolean(value));
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Boolean.", value);
            }
        }



        /// <summary>
        /// Atualiza as propriedades com os dados de configuração do webservice.
        /// </summary>
        public void SetConfigAtual()
        {
            // Pega numero de série do equipamento
           /* SerialDevice = ConfigWebService.GetDeviceID();
            TimeOutWebService = "5";*/
            // Cria uma referêcnia para a chave de registro 'Software'
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);
            try
            {
                rk = rk.OpenSubKey("LTmobileWebService");
                if (rk != null) rk = rk.OpenSubKey("Parametro");
                if (rk == null) return; //se as chaves existirem o processo continua                
                if (rk.ValueCount == 0) return;

                rk = Registry.LocalMachine.OpenSubKey("Software", true);
                WebServiceCurrent = rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("WEBSERVICE").ToString();
                LoginWebService = rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("IDUSUARIO").ToString();
                SenhaWebService = rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("SENHA").ToString();
                IntervaloWebService = rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("INTERVALO").ToString();
                QuantidadeWebService = rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("QUANTIDADE").ToString();
                LigarGpsWebService = Convert.ToBoolean(rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("LIGARGPS").ToString());
                FormatoLeitura = rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("FormatoLeitura").ToString();

                if (string.IsNullOrEmpty(FormatoLeitura))
                {
                    FormatoLeitura = "direita";
                }
                
                

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
                if (rk != null) rk.Close();
            }
        }

        public void SetFormatoLeituraAtual()
        {
            // Pega numero de série do equipamento
            /* SerialDevice = ConfigWebService.GetDeviceID();
             TimeOutWebService = "5";*/
            // Cria uma referêcnia para a chave de registro 'Software'
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("Software", true);
            try
            {
                rk = rk.OpenSubKey("LTmobileWebService");
                if (rk != null) rk = rk.OpenSubKey("Parametro");
                if (rk == null) return; //se as chaves existirem o processo continua                
                if (rk.ValueCount == 0) return;

                rk = Registry.LocalMachine.OpenSubKey("Software", true);
                FormatoLeitura = rk.OpenSubKey("LTmobileWebService", true).OpenSubKey("Parametro", true).GetValue("FormatoLeitura").ToString();
                



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
                if (rk != null) rk.Close();
            }
        }
    }
}

