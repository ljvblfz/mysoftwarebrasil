using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MobileTools
{
    public static class Utils
    {
        /// <summary>
        /// Formata o texto passado com quebra de linhas de acordo com o número máximo de caracteres por linha.
        /// </summary>
        /// <param name="text">Texto a ser formatado.</param>
        /// <param name="maxLengthPerLine">Número máximo de caracteres por linha.</param>
        /// <returns>Texto formatado.</returns>
        public static string FormatText(string text, int maxLengthPerLine)
        {
            string tempString = text;
            string workString = "";
            StringBuilder outputstring = new StringBuilder();
            int sp_pos = 0;
            int sp_pos1 = 0;
            int sp_pos2 = 0;
            int sp_pos3 = 0;
            bool bNeeded = false; // Variável que indica se a necessidade de quebra de linha

            if (tempString.Length > maxLengthPerLine)
            {
                while (tempString.Length > 0)
                {
                    //Verifica se existe mais letras a serem tratadas
                    if (tempString.Length <= maxLengthPerLine)
                    {
                        outputstring.Append(tempString);
                        break;
                    }
                    // Busca a próxima letra
                    workString = tempString.Substring(0, maxLengthPerLine);

                    // Procura indicadores que simbolizam quebra de linha
                    sp_pos1 = workString.LastIndexOf(" ");
                    sp_pos2 = workString.LastIndexOf(";");
                    sp_pos3 = workString.IndexOf("\r\n");

                    bNeeded = true;
                    if (sp_pos3 > 0)
                    {
                        // Encontrou uma quebra de linha
                        sp_pos = sp_pos3;
                        bNeeded = false;
                    }
                    else
                    {
                        // Verifica se encontrou um ; e se não existe nenhum espaço
                        // em branco depois dele
                        if ((sp_pos2 > 0) && (sp_pos2 > sp_pos1))
                        {
                            sp_pos = sp_pos2;
                        }
                        // Verifica se encontrou um espaço em branco
                        else if (sp_pos1 > 0)
                        {
                            sp_pos = sp_pos1;
                        }
                        else
                        {
                            // Não encontrou nenhum separa para quebra de linha
                            sp_pos = 0;
                        }
                    }

                    if (sp_pos > 0)
                    {
                        outputstring.Append(tempString.Substring(0, sp_pos + 1));
                        if (bNeeded) outputstring.Append("\r\n");
                        tempString = tempString.Substring((sp_pos + 1), tempString.Length - (sp_pos + 1));
                    }
                    else
                    {
                        outputstring.Append(tempString.Substring(0, maxLengthPerLine - 1));
                        if (bNeeded) outputstring.Append("\r\n");
                        tempString = tempString.Substring(maxLengthPerLine, tempString.Length - maxLengthPerLine);
                    }
                    
                }
            }
            return outputstring.ToString();
        }

        /*public static bool IsDecimalNumber(string text, char key)
        {
            char separador = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            int valueKey = (int)key;
            // Verifica se foi digita algum número do topo do teclado
            if (valueKey < 48 || valueKey > 57)
            {
                if (text != null && key == separador && text.IndexOf(separador) != -1)
                    // O que foi digitado não é um número
                    return false;
                else
                    return false;       
            }

            return true;
        }*/

        public static bool IsNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            for (int i = 0; i < value.Length; i++)
                if (!IsNumber(value[i]))
                    return false;

            return true;
        }

        /// <summary>
        /// Verifica se o caracter é um número.
        /// </summary>
        /// <param name="keyChar"></param>
        /// <returns></returns>
        public static bool IsNumber(char keyChar)
        {
            int valueKey = (int)keyChar;
            return (valueKey >= 48 && valueKey <= 57);
        }
        
        /// <summary>
        /// Verifica se o código informado é um número.
        /// </summary>
        /// <param name="keyCode"></param>
        /// <returns></returns>
        public static bool IsNumber(Keys keyCode)
        {
            // Verifica se foi digita algum número do topo do teclado
            if (keyCode < Keys.D0 || keyCode > Keys.D9)
            {
                // Verifica se foi digitado algum número do keypad
                if (keyCode < Keys.NumPad0 || keyCode > Keys.NumPad9)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Verifica se o caracter informado é um separador decimal.
        /// </summary>
        /// <param name="keyChar"></param>
        /// <returns></returns>
        public static bool IsCurrencyDecimalSeparator(char keyChar)
        {
            return (keyChar == Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator));
        }

        /// <summary>
        /// Criptografa a string recebida
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String criptografada</returns>
        public static string HashMD5(string value)
        {
            System.Security.Cryptography.HashAlgorithm hash = System.Security.Cryptography.MD5.Create();
            StringBuilder str = new StringBuilder();
            byte[] result = hash.ComputeHash(Encoding.Convert(UnicodeEncoding.Unicode, UnicodeEncoding.ASCII, new UnicodeEncoding().GetBytes(value)));
            foreach (byte b in result)
                str.Append(string.Format("{0:X2}", b));

            return str.ToString();
        }

        /// <summary>
        /// Recupera um string com a relação dos bits contidos no número inteiro.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string GetBits(int val)
        {
            string result = "";

            int p = 0;

            for (int i = 0; i < sizeof(int); i++)
            {
                int v2 = val >> (i * 8) & 0xff;

                for (int j = 0; j < 8; j++)
                {
                    p = (int)Math.Pow(2, j);
                    result += (v2 & p) != 0 ? "1" : "0";
                }

                result += " ";
            }

            return result;
        }

        /// <summary>
        /// Verifica se o texto informado contem algum separador decimal.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsContainCurrencyDecimalSeparator(string text)
        {
            return (text != null && text.IndexOf(Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator)) != -1);
        }

        /// <summary>
        /// Converte o texto para um valor decimal.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(string text)
        {
            string num = text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator, ".");

            return Convert.ToDecimal(num);
        }

        /// <summary>
        /// Converto o valor decimal para uma string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ConvertToString(decimal value)
        {
            return value.ToString().Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);
        }

        /// <summary>
        /// Aloca um espaço de memória.
        /// </summary>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        public static IntPtr LocalAlloc(int byteCount)
        {
            IntPtr ptr = Win32.LocalAlloc(Win32.LMEM_ZEROINIT, byteCount);
            if (ptr == IntPtr.Zero)
            {
                throw new OutOfMemoryException();
            }

            return ptr;
        }

        public static void LocalFree(IntPtr hMem)
        {
            IntPtr ptr = Win32.LocalFree(hMem);
            if (ptr != IntPtr.Zero)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Mante o dispositivo ligado.
        /// </summary>
        public static void StayConnected()
        {
            Win32.SetSystemPowerState(null, Win32.POWER_STATE_ON, Win32.POWER_FORCE);
        }

        /// <summary>
        /// Executa uma HardReset no dispositivo.
        /// </summary>
        public static void HardReset()
        {
            int IOCTL_HAL_REBOOT = 0x101003C;
            int bytesReturned = 0;
            Win32.SetCleanRebootFlag();
            Win32.KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, IntPtr.Zero, 0, ref bytesReturned);
        }
    }

    internal class Win32
    {
        public const int LMEM_ZEROINIT = 0x40;
        [System.Runtime.InteropServices.DllImport("coredll.dll", EntryPoint = "#33", SetLastError = true)]
        public static extern IntPtr LocalAlloc(int flags, int byteCount);

        [System.Runtime.InteropServices.DllImport("coredll.dll", EntryPoint = "#36", SetLastError = true)]
        public static extern IntPtr LocalFree(IntPtr hMem);

        public const int POWER_STATE_ON = 0x0010000;
        public const int POWER_STATE_OFF = 0x0020000; 
        public const int POWER_STATE_SUSPEND = 0x00200000;
        public const int POWER_FORCE = 0x00001000;

        [System.Runtime.InteropServices.DllImport("coredll.dll", EntryPoint = "SetSystemPowerState", SetLastError = true)] 
        public static extern int SetSystemPowerState(string psState , int StateFlags , int Options );

        [DllImport("Coredll.dll")]
        public extern static int KernelIoControl(
          int dwIoControlCode,
          IntPtr lpInBuf,
          int nInBufSize,
          IntPtr lpOutBuf,
          int nOutBufSize,
          ref int lpBytesReturned
        );

        [DllImport("Coredll.dll")]
        public extern static void SetCleanRebootFlag();
    }
}
