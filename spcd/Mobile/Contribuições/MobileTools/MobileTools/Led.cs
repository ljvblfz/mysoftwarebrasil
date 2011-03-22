﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace MobileTools
{
    public static class Led
    {
        [DllImport("coredll.dll", EntryPoint = "NLedGetDeviceInfo", SetLastError = true)]
        private static extern bool NLedGetDeviceCount(short nID, ref NLED_COUNT_INFO pOutput);
        [DllImport("coredll.dll", EntryPoint = "NLedGetDeviceInfo", SetLastError = true)]
        private static extern bool NLedGetDeviceSupports(short nID, ref NLED_SUPPORTS_INFO pOutput);
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool NLedSetDevice(short nID, ref NLED_SETTINGS_INFO pOutput);

        private const int NLED_COUNT_INFO_ID = 0;
        private const int NLED_SETTINGS_INFO_ID = 2;
        private const int NLED_SUPPORTS_INFO_ID = 1;

        /// <summary>
        /// Define o estado LED.
        /// </summary>
        /// <param name="led">Número do led.</param>
        /// <param name="newState">Estado do led.</param>
        public static void SetLedStatus(int led, LedState newState)
        {
            NLED_SETTINGS_INFO pOutput = new NLED_SETTINGS_INFO();
            pOutput.LedNum = led;
            pOutput.OffOnBlink = (int)newState;
            if (!NLedSetDevice(2, ref pOutput))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error(), "Error Initialising LED's");
            }
        }

        /// <summary>
        /// Quantidades de Leds.
        /// </summary>
        public static int Count
        {
            get
            {
                NLED_COUNT_INFO pOutput = new NLED_COUNT_INFO();
                if (!NLedGetDeviceCount(0, ref pOutput))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Error Initialising LED's");
                }
                return (int)pOutput.cLeds;
            }
        }

        // Nested Types
        public enum LedState
        {
            Off,
            On,
            Blink
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct NLED_COUNT_INFO
        {
            public uint cLeds;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct NLED_SETTINGS_INFO
        {
            public int LedNum;
            public int OffOnBlink;
            public int TotalCycleTime;
            public int OnTime;
            public int OffTime;
            public int MetaCycleOn;
            public int MetaCycleOff;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct NLED_SUPPORTS_INFO
        {
            public uint LedNum;
            public int lCycleAdjust;
            public bool fAdjustTotalCycleTime;
            public bool fAdjustOnTime;
            public bool fAdjustOffTime;
            public bool fMetaCycleOn;
            public bool fMetaCycleOff;
        }
    }

}
