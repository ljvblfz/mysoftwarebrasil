using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace CommonHelpMobile
{
    public class DeviceStateSleep
    {
        #region Não permite desligamento de tela do PDA

        /// <summary>
        /// This function resets a system timer that controls whether or not the
        /// device will automatically go into a suspended state.
        /// </summary>
        [DllImport("CoreDll.dll")]
        public static extern void SystemIdleTimerReset();

        private static int nDisableSleepCalls = 0;
        private static System.Threading.Timer preventSleepTimer = null;

        public static void DisableDeviceSleep()
        {
            nDisableSleepCalls++;
            if (nDisableSleepCalls == 1)
            {
                // start a 30-second periodic timer
                preventSleepTimer = new System.Threading.Timer(new TimerCallback(PokeDeviceToKeepAwake),
                    null, 0, 30 * 1000);
            }
        }

        public static void EnableDeviceSleep()
        {
            nDisableSleepCalls--;
            if (nDisableSleepCalls == 0)
            {
                if (preventSleepTimer != null)
                {
                    preventSleepTimer.Dispose();
                    preventSleepTimer = null;
                }
            }
        }

        private static void PokeDeviceToKeepAwake(object extra)
        {
            try
            {
                SystemIdleTimerReset();
            }
            catch (Exception)
            {

            }
        }

        #endregion
    }    
}
