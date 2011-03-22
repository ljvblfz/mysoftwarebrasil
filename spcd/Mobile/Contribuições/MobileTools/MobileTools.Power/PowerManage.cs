using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MobileTools.Power
{
    [Flags]
    internal enum PowerStateFlags
    {

        Boot = 0x80000,
        CriticalOff = 0x40000,
        Idle = 0x100000,
        Off = 0x20000,
        On = 0x10000,
        PasswordProtected = 0x10000000,
        Reset = 0x800000,
        Suspend = 0x200000

    }

    /// <summary>
    /// 
    /// </summary>
    public class PowerManage
    {
        [DllImport("coredll.dll", SetLastError = true)]
        internal static extern int SetSystemPowerState(IntPtr psState, PowerStateFlags flags, uint Options);

        /// <summary>
        /// Define que o dispositivo deve ficar ligado.
        /// </summary>
        public static void SetOn()
        {

            int m = SetSystemPowerState(IntPtr.Zero, PowerStateFlags.On, 0x1000);

            if (m != 0)
            {
                throw new System.ComponentModel.Win32Exception(m);
            }

        }

    }
}
