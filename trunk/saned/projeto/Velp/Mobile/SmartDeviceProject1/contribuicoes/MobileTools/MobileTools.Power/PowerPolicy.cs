using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MobileTools.Power
{
    /// <summary>
    /// Representa o controle da política de controle de enercia do dispositivo.
    /// </summary>
    public class PowerPolicy
    {
        #region Win32

        private enum PPNMessage
        {
            PPN_REEVALUATESTATE = 1,
            PPN_POWERCHANGE = 2,
            PPN_UNATTENDEDMODE = 3,
            PPN_SUSPENDKEYPRESSED = 4,
            PPN_POWERBUTTONPRESSED = 4,
            PPN_SUSPENDKEYRELEASED = 5,
            PPN_APPBUTTONPRESSED = 6,
        }

        [DllImport("CoreDLL")]
        private static extern int PowerPolicyNotify(PPNMessage dwMessage, int option);

        #endregion

        #region Métodos Público

        /// <summary>
        /// Habilita para a aplicação trabalhar em modo autônomo.
        /// Essa opção possibilita que a aplicação continue rodando 
        /// mesmo com o dispositivo em modo suspenso.
        /// </summary>
        public static void EnableUnattendedMode()
        {
            PowerPolicyNotify(PPNMessage.PPN_UNATTENDEDMODE, 1);
        }

        /// <summary>
        /// Desabilita o modo autônomo da aplicação.
        /// </summary>
        public static void DisableUnattendedMode()
        {
            PowerPolicyNotify(PPNMessage.PPN_UNATTENDEDMODE, 0);
        }

        #endregion
    }
}
