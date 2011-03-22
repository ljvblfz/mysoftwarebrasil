using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;

namespace CommonHelpMobile
{
    public static class TaskBarHelper
    {
        const int SW_HIDE = 0;
        const int SW_SHOW = 1;
        const string cTaskBarClassName = "HHTaskBar";
        [DllImport("coredll.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("coredll.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("coredll.dll")]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        static void _Enable(bool bEnable)
        {
            IntPtr hWnd = FindWindow(cTaskBarClassName, null);

            if (hWnd == IntPtr.Zero)
                return; ShowWindow(hWnd, bEnable ? SW_SHOW : SW_HIDE);

            EnableWindow(hWnd, bEnable);
        }

        public static void Show()
        {
            _Enable(true);
        }

        public static void Hide()
        {
            _Enable(false);
        }
    }
}
