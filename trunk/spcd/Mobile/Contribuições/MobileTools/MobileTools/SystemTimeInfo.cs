using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTools
{
    /// <summary>
    /// Gerencia o horário do sistema.
    /// </summary>
    public static class SystemTimeInfo
    {
        struct SYSTEMTIME
        {
            public void LoadDateTime(DateTime dateTime)
            {
                this.Year = (UInt16)dateTime.Year;
                this.Month = (UInt16)dateTime.Month;
                this.Day = (UInt16)dateTime.Day;
                this.Hour = (UInt16)dateTime.Hour;
                this.Minute = (UInt16)dateTime.Minute;
                this.Second = (UInt16)dateTime.Second;
                this.MilliSecond = (UInt16)dateTime.Millisecond;
            }
            public UInt16 Year;
            public UInt16 Month;
            public UInt16 DayOfWeek;
            public UInt16 Day;
            public UInt16 Hour;
            public UInt16 Minute;
            public UInt16 Second;
            public UInt16 MilliSecond;
        }

        [System.Runtime.InteropServices.DllImport("Coredll.dll", EntryPoint = "SetSystemTime")]
        private static extern bool SetSystemTime(ref SYSTEMTIME st);

        /// <summary>
        /// Atualiza o horário do sistema.
        /// </summary>
        /// <param name="time">Nome horário.</param>
        public static void UpdateSystemTime(DateTime time)
        {
            DateTime uTime = time.ToUniversalTime();
            SYSTEMTIME sysTime = new SYSTEMTIME();
            sysTime.LoadDateTime(uTime);
            bool worked = SetSystemTime(ref sysTime);
        }

    }
}
