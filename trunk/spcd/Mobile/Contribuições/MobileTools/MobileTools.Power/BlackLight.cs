using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace MobileTools.Power
{
    public class BackLight
    {
        public BackLight()
        {

        }

        public int Timeout
        {
            get
            {
                PowerStatus power = new PowerStatus();
                if (power.PowerLineStatus == PowerLineStatus.Online)
                    return GetBacklightValue("ACTimeout");

                return GetBacklightValue("BatteryTimeout");
            }
        }

        public int Brightness
        {
            get
            {
                PowerStatus power = new PowerStatus();
                if (power.PowerLineStatus == PowerLineStatus.Online)
                    return GetBacklightValue("ACBrightness");

                return GetBacklightValue("Brightness");
            }
            set
            {
                PowerStatus power = new PowerStatus();
                if (power.PowerLineStatus == PowerLineStatus.Online)
                    SetBacklightValue("ACBrightness", value);
                else
                    SetBacklightValue("Brightness", value);

                RaiseBackLightChangeEvent();
            }
        }

        private void SetBacklightValue(string name, int v)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"ControlPanel\Backlight", true);
            if (key != null)
            {
                key.SetValue(name, v);
                key.Close();
            }
        }

        private int GetBacklightValue(string name)
        {
            object v = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\ControlPanel\Backlight", name, 0);
            if (v != null)
                return (int)v;

            return 0;
        }

        private static void RaiseBackLightChangeEvent()
        {
            IntPtr hBackLightEvent = CreateEvent(IntPtr.Zero, false, true, "BackLightChangeEvent");
            if (hBackLightEvent != IntPtr.Zero)
            {
                SetEvent(hBackLightEvent);
                CloseHandle(hBackLightEvent);
            }
        }

        enum EventFlags
        {
            PULSE = 1,
            RESET = 2,
            SET = 3
        }

        private static bool SetEvent(IntPtr hEvent)
        {
            return EventModify(hEvent, (int)EventFlags.SET);
        }

        [DllImport("coredll.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EventModify(IntPtr hEvent, [In, MarshalAs(UnmanagedType.U4)] int dEvent);

        [DllImport("coredll.Dll")]
        private static extern IntPtr CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, string lpName);

        [DllImport("coredll.Dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
    }
}
