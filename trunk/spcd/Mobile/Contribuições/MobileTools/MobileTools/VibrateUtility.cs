using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MobileTools
{
    /// <summary>
    /// Representa um utilitário que gerencia a vibração do dispositivo.
    /// </summary>
    public class VibrateUtility
    {
        // Fields
        internal const int DBGDRIVERSTAT = 0x1802;
        internal const int GETPOWERMANAGEMENT = 0x1804;
        internal const int GETVFRAMELEN = 0x1801;
        internal const int GETVFRAMEPHYSICAL = 0x1800;
        internal const int QUERYESCSUPPORT = 8;
        internal const int SETPOWERMANAGEMENT = 0x1803;

        // Methods
        [DllImport("aygshell.dll", SetLastError = true)]
        internal static extern int VibrateGetDeviceCaps(VibrationCapabilities caps);
        [DllImport("aygshell.dll", EntryPoint = "Vibrate", SetLastError = true)]
        internal static extern int VibratePlay(int cvn, IntPtr rgvn, uint fRepeat, uint dwTimeout);
        [DllImport("aygshell.dll", SetLastError = true)]
        internal static extern int VibrateStop();

        // Nested Types
        internal enum VideoPowerState
        {
            Off = 4,
            On = 1,
            StandBy = 2,
            Suspend = 3
        }

        public static int GetDeviceCaps(VibrationCapabilities caps)
        {
            return VibrateGetDeviceCaps(caps);
        }

        /// <summary>
        /// Inicializa a vibração do dispositivo.
        /// </summary>
        /// <returns></returns>
        public static bool Play()
        {
            if (VibratePlay(0, IntPtr.Zero, uint.MaxValue, uint.MaxValue) != 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Paraliza a vibração do dispositivo.
        /// </summary>
        /// <returns></returns>
        public static bool Stop()
        {
            if (VibrateStop() != 0)
            {
                return false;
            }
            return true;
        }

        // Nested Types
        public enum VibrationCapabilities
        {
            Amplitude,
            Frequency
        }

    }
}
