using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace MobileTools.Power
{
    public class DevicePowerState
    {
        #region Constantes

        /// <summary>
        /// Endereço onde o estão os dados do estados no registro.
        /// </summary>
        private const string BASE_POWER_HIVE = @"System\CurrentControlSet\Control\Power\State";

        private const int POWER_NAME = 1;
        private const int POWER_FORCE = 0x00001000;

        #endregion

        #region Variáveis Locais

        private string _name;
        private List<PowerStateInfo> _statesInfo = new List<PowerStateInfo>();

        private Regex _targetRegistryValue = new Regex("(DEFAULT)|(^.*:$)", RegexOptions.IgnoreCase);

        #endregion

        #region Propriedades

        /// <summary>
        /// Nome do estado.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Lista as informações dos estados relacionados.
        /// </summary>
        public IList<PowerStateInfo> StatesInfo
        {
            get { return _statesInfo; }
        }

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor interno.
        /// </summary>
        /// <param name="name">Nome do estado de energia.</param>
        internal DevicePowerState(string name)
        {
            _name = name;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Atualiza as informações do estado.
        /// </summary>
        public void Refresh()
        {
            // Recupera a chave do registro relacionada com o estado
            RegistryKey stateInformationKey = Registry.LocalMachine.OpenSubKey(String.Format(@"{0}\{1}", BASE_POWER_HIVE, _name));

            // Recupera os dados dos estados dos dispositivos
            string[] valueList = stateInformationKey.GetValueNames();

            _statesInfo.Clear();

            for (int i = 0; i < valueList.Length; ++i)
            {
                // Recupera o valor
                string currentValue = valueList[i];
                // Verifica se o valor se enquadra no padrão esperado
                if (_targetRegistryValue.IsMatch(currentValue))
                {
                    _statesInfo.Add(new PowerStateInfo(valueList[i], (PowerState)(int)stateInformationKey.GetValue(currentValue), this));
                }
            }
        }

        /// <summary>
        /// Recupera os possíveis estados de energia do PDA.
        /// </summary>
        /// <returns></returns>
        public static DevicePowerState[] PowerStates()
        {
            RegistryKey powerStateKey = Registry.LocalMachine.OpenSubKey(BASE_POWER_HIVE);
            string[] states = powerStateKey.GetSubKeyNames();

            DevicePowerState[] dps = new DevicePowerState[states.Length];

            for (int i = 0; i < states.Length; i++)
            {
                dps[i] = new DevicePowerState(states[i]);
                dps[i].Refresh();
            }

            return dps;
        }

        /// <summary>
        /// Recupera as lista de todos os hardwares ativos no PDA.
        /// </summary>
        /// <returns></returns>
        public static string[] DevicesName()
        {
            // Recupera os nomes de todos as sub chaves que ser referem a um hardware ativo do dispositivo
            RegistryKey driverKeyRoot = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Drivers\\Active");
            string[] keyName = driverKeyRoot.GetSubKeyNames();

            // Nós vamos salvar essa informação para uma lista
            List<string> deviceNameList = new List<string>();

            for (int i = 0; i < keyName.Length; ++i)
            {
                // Recupera o nome do hardware e adiciona lista
                RegistryKey currentKey = driverKeyRoot.OpenSubKey(keyName[i]);
                string deviceName = currentKey.GetValue("Name") as string;
                if (deviceName != null)
                    deviceNameList.Add(deviceName);
            }

            return deviceNameList.ToArray();
        }

        /// <summary>
        /// Recupera o estado do dispositivo.
        /// </summary>
        /// <param name="device">Nome do dispositivo.</param>
        /// <returns></returns>
        public static PowerState GetPowerState(string device)
        {
            PowerState state = PowerState.Unspecified;
            
            // Recupera o estado do dispositivo
            int result = GetDevicePower(device, POWER_NAME | POWER_FORCE, ref state);

            if (result != 0)
                return PowerState.Unspecified;
            else
                return state;
        }

        /// <summary>
        /// Define o estado do dispositivo.
        /// </summary>
        /// <param name="device">Nome do dispositivo.</param>
        /// <param name="state">Estado que ele deve assumir.</param>
        /// <returns>True caso a operação tenha sido efetuada com sucesso.</returns>
        public static bool SetDevicePower(string device, PowerState state)
        {
            return (SetDevicePower(device, POWER_NAME | POWER_FORCE, state) == 0);
        }

        public override string ToString()
        {
            return _name;
        }

        #endregion

        #region Métodos Internos

        /// <summary>
        /// Define o valor para o estado do dispositivo.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="value"></param>
        internal void SetPowerStateInfoValue(PowerStateInfo info, PowerState value)
        {
            // Recupera a chave do registro relacionada com o estado
            RegistryKey stateInformationKey = Registry.LocalMachine.OpenSubKey(String.Format(@"{0}\{1}", BASE_POWER_HIVE, _name));

            stateInformationKey.SetValue(info.Name, (int)value);
        }

        #endregion

        #region API

        [DllImport("coredll.dll")]
        private static extern int GetDevicePower(string pvDevice, int dwDeviceFlags, ref PowerState state);

        [DllImport("coredll.dll")]
        private static extern int SetDevicePower(string pvDevice, int dwDeviceFlags, PowerState DeviceState);

        #endregion
    }
}
