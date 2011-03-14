using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MobileTools.Power
{
    public class PowerRequirement : IDisposable
    {
        /// <summary>
        /// Instância do requerimento.
        /// </summary>
        private IntPtr _handle = IntPtr.Zero;
        /// <summary>
        /// Nome do dipositivo que foi feito o requerimento.
        /// </summary>
        private string _device;
        /// <summary>
        /// Estado de energia do dispositivo.
        /// </summary>
        private PowerState _power;

        /// <summary>
        /// Inicializa um requerimento de energia para o dispositivo.
        /// </summary>
        /// <param name="device">Nome de dispositivo.</param>
        /// <param name="power">Estado de energia.</param>
        public PowerRequirement(string device, PowerState power)
        {
            if (string.IsNullOrEmpty(device))
                throw new ArgumentNullException("device");

            _device = device;
            _power = power;

            _handle = SetPowerRequirement(_device, _power, 1, IntPtr.Zero, 0);
        }

        ~PowerRequirement()
        {
            Dispose(false);
        }

        /// <summary>
        /// Estado de energia do dispositivo.
        /// </summary>
        public PowerState PowerState
        {
            get
            {
                return _power;
            }
            set
            {
                if (_power != value)
                {
                    // Libera o atual estado
                    ReleasePowerRequirement();
                    _power = value;
                    // Define o novo estado
                    _handle = SetPowerRequirement(_device, _power, 1, IntPtr.Zero, 0);
                }
            }
        }

        /// <summary>
        /// Libera o requerimento.
        /// </summary>
        private void ReleasePowerRequirement()
        {
            if (_handle != IntPtr.Zero)
                ReleasePowerRequirement(_handle);

            _handle = IntPtr.Zero;
        }

        /// <summary>
        /// Libera a instância do objeto.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            ReleasePowerRequirement();

            if (disposing)
                GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera a instância do objeto.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        [DllImport("coredll.dll")]
        private static extern IntPtr SetPowerRequirement(string pvDevice, PowerState DeviceState, int DeviceFlags, IntPtr pvSystemState, int StateFlags);

        [DllImport("coredll.Dll")]
        private static extern int ReleasePowerRequirement(IntPtr hPowerReq);
    }
}
