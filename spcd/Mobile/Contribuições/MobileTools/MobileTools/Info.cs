using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MobileTools
{
    public static class Info
    {
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool KernelIoControl(int dwIoControlCode, byte[] inBuf, int inBufSize, byte[] outBuf, int outBufSize, ref int bytesReturned);

        private static Int32 FILE_DEVICE_HAL = 0x00000101;
        private static Int32 FILE_ANY_ACCESS = 0x0;
        private static Int32 METHOD_BUFFERED = 0x0;

        private static Int32 IOCTL_HAL_GET_DEVICEID =
            ((FILE_DEVICE_HAL) << 16) | ((FILE_ANY_ACCESS) << 14) |
            ((21) << 2) | (METHOD_BUFFERED);

        /*
        [DllImport("coredll.dll")]
        private extern static int GetDeviceUniqueID([In, Out] byte[] appdata,
            int cbApplictionData, int dwDeviceIDVersion,
            [In, Out] byte[] deviceIDOuput, out uint pcbDeviceIDOutput);

        /// <summary>
        /// Retorna o identificador do dispositivo.
        /// </summary>
        /// <param name="applicationName">O nome da aplicação que vai receber o identificador.</param>
        /// <returns>O ID do dispositivo.</returns>
        public static string GetDeviceID(string applicationName)
        {
            // Cria um buffer com os bytes do nome do aplicativo
            byte[] appData = new byte[applicationName.Length];
            for (int count = 0; count < applicationName.Length; count++)
                appData[count] = (byte)applicationName[count];

            // Variáveis auxiliares
            int appDataSize = appData.Length;
            byte[] deviceOutput = new byte[20];
            uint sizeOut = 20;

            // Chama a função GetDeviceUniqueID
            GetDeviceUniqueID(appData, appDataSize, 1, deviceOutput, out sizeOut);

            // Retorna o identificador do dispositivo
            return Convert.ToBase64String(deviceOutput);
        }
        */

        /// <summary>
        /// Retorna o identificador do dispositivo.
        /// </summary>
        /// <returns>O ID do dispositivo.</returns>
        public static string GetDeviceID()
        {
            byte[] OutputBuffer = new byte[256];
            Int32 OutputBufferSize, BytesReturned;
            OutputBufferSize = OutputBuffer.Length;
            BytesReturned = 0;

            // Call KernelIoControl passing the previously defined
            // IOCTL_HAL_GET_DEVICEID parameter
            // We don’t need to pass any input buffers to this call
            // so InputBuffer and InputBufferSize are set to their null
            // values
            bool retVal = KernelIoControl(IOCTL_HAL_GET_DEVICEID, null, 0, OutputBuffer,
                OutputBufferSize, ref BytesReturned);

            // If the request failed, exit the method now
            if (retVal == false)
                return null;

            // Examine the OutputBuffer byte array to find the start of the 
            // Preset ID and Platform ID, as well as the size of the
            // PlatformID. 
            // PresetIDOffset – The number of bytes the preset ID is offset
            //                  from the beginning of the structure
            // PlatformIDOffset - The number of bytes the platform ID is
            //                    offset from the beginning of the structure
            // PlatformIDSize - The number of bytes used to store the
            //                  platform ID
            // Use BitConverter.ToInt32() to convert from byte[] to int
            Int32 PresetIDOffset = BitConverter.ToInt32(OutputBuffer, 4);
            Int32 PlatformIDOffset = BitConverter.ToInt32(OutputBuffer, 0xc);
            Int32 PlatformIDSize = BitConverter.ToInt32(OutputBuffer, 0x10);

            // Creates a buffer with the significative bytes
            byte[] returnBuffer = new byte[10 + PlatformIDSize];
            Buffer.BlockCopy(OutputBuffer, PresetIDOffset, returnBuffer, 0, 10);
            Buffer.BlockCopy(OutputBuffer, PlatformIDOffset, returnBuffer, 10, PlatformIDSize);

            // Return the buffer as a base 64 string
            return Convert.ToBase64String(returnBuffer);
        }
    }
}
