using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MobileTools.Text
{
    public class Base128
    {
        /// <summary>
        /// Códifica os dados do buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] Encode(byte[] buffer)
        {
            byte[] outBuffer = null;

            int inlen = buffer.Length;

            using (Stream str = new MemoryStream())
            {
                int bOut = 0;
                int pIn = 0;

                while (inlen > 0)
                {
                    // Armazena o restantes do bits que ficaram sobrando na conversão
                    int rest = 0;
                    // Mascara do bits que ficaram sobrando
                    int bitmask = 0;

                    for (int i = 0; 7 > i && inlen > 0; ++i, --inlen)
                    {
                        bOut = 0; // Novo byte para salva os bits

                        bitmask |= (1 << (7 - i));  // Mascara de bits para recuperar o resto
                        bOut = (((int)buffer[pIn]) << i);     // Recupera somente os bits que encaixam no atual byte
                        bOut &= ~(1 << 7);          // Define os 7bits
                        bOut |= rest;               // Junta com os bits que sobraram
                        rest = (bitmask & ((int)buffer[pIn])) >> (7 - i); // Recupera o restante do bits com base na mascara

                        // Salva o novo byte
                        str.WriteByte((byte)bOut);
                        pIn++;
                    }
                    // n+1 byte
                    // Salva os bits que sobraram
                    str.WriteByte((byte)rest);
                }

                // Instancia o buffer de saída
                outBuffer = new byte[str.Length];
                str.Seek(0, SeekOrigin.Begin);
                str.Read(outBuffer, 0, outBuffer.Length);
            }

            return outBuffer;
        }

        /// <summary>
        /// Decodifica os dados do buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static byte[] Decode(byte[] buffer)
        {
            int inlen = buffer.Length;
            byte[] outBuffer = null;

            using (Stream str = new MemoryStream())
            {
                int bOut = 0;
                int pIn = 0;

                while (inlen > 0)
                {
                    // Mascara do bits que ficaram faltando
                    int bitmask = 0;
                    for (int i = 0; 7 > i && inlen > 1; ++i, --inlen)
                    {
                        bOut = 0;                           // Novo byte para salva os bits
                        if (buffer[pIn] > 127) return null; // Verifica se o byte é válido
                        bitmask |= (1 << i);
                        bOut = ((int)buffer[pIn]) >> i;
                        pIn++;
                        bOut |= ((((int)buffer[pIn]) & bitmask) << (7 - i));

                        str.WriteByte((byte)bOut);
                    }
                    --inlen;
                    pIn++;
                }

                outBuffer = new byte[str.Length];
                str.Seek(0, SeekOrigin.Begin);
                str.Read(outBuffer, 0, outBuffer.Length);
            }

            return outBuffer;
        }

    }
}
