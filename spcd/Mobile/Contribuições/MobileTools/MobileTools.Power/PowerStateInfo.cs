using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTools.Power
{
    /// <summary>
    /// Possíveis valores que o estado pode assumir.
    /// </summary>
    public enum PowerState
    {
        Unspecified = -1,
        /// <summary>
        /// Esse é o estado que o dispositivo está ligado e funcionando.
        /// </summary>
        FullPower = 0, 
        /// <summary>
        /// Esse é o estado que o dispositivo é totalmente funcional porém com
        /// menor pontência e desempenho que o estado <see cref="PowerStateValue.FullPower"/>.
        /// </summary>
        PowerSavings, 
        /// <summary>
        /// Esse é o estado em que o dispositivo é parcialmente alimentado.
        /// </summary>
        Standby,
        SleepMode, 
        /// <summary>
        /// Esse é o estado que o dipositivo não está ligado.
        /// </summary>
        PowerOff
    }

    /// <summary>
    /// Representa as informações dos dispositivo no estado.
    /// </summary>
    public class PowerStateInfo
    {
        #region Variáveis Locais

        private string _name;
        private PowerState _value;
        private DevicePowerState _devicePowerState;

        #endregion

        #region Propriedades

        /// <summary>
        /// Nome do dispositivo.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Valor que assume.
        /// </summary>
        public PowerState Value
        {
            get { return _value; }
            set
            {
                _devicePowerState.SetPowerStateInfoValue(this, value);
                _value = value;
            }
        }

        /// <summary>
        /// Estado de energia relacinado.
        /// </summary>
        public DevicePowerState DevicePowerState
        {
            get { return _devicePowerState; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor interno.
        /// </summary>
        /// <param name="name">Nome do dispositivo.</param>
        /// <param name="value">Valor do estado.</param>
        /// <param name="devicePowerState">Estado de energia relacionado.</param>
        internal PowerStateInfo(string name, PowerState value, DevicePowerState devicePowerState)
        {
            _name = name;
            _value = value;
            _devicePowerState = devicePowerState;
        }

        #endregion

        #region Métodos Públicos

        public override string ToString()
        {
            return _name + " : " + _value.ToString();
        }

        #endregion
    }
}
