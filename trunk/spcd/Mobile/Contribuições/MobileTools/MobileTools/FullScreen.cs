using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MobileTools
{
    [Flags()]
    public enum FullScreenFlags : int
    {
        SwHide = 0,
        ShowTaskbar = 0x1,
        HideTaskbar = 0x2,
        ShowSipButton = 0x4,
        HideSipButton = 0x8,
        SwRestore = 9,
        ShowStartIcon = 0x10,
        HideStartIcon = 0x20

    }

    public enum SetWindowPosZOrder : int
    {
        HWND_TOP = 0,
        HWND_BOTTOM = 1,
        HWND_TOPMOST = -1,
        HWND_NOTOPMOST = -2,
        HWND_MESSAGE = -3
    }

    public enum SetWindowPosFlag : int
    {
        SWP_NOSIZE = 0x1,
        SWP_NOMOVE = 0x2,
        SWP_NOZORDER = 0x4,
        SWP_NOREDRAW = 0x8,
        SWP_NOACTIVATE = 0x10,
        SWP_FRAMECHANGED = 0x20,
        SWP_SHOWWINDOW = 0x40,
        SWP_HIDEWINDOW = 0x80,
        SWP_NOCOPYBITS = 0x100,
        SWP_NOOWNERZORDER = 0x200,
        SWP_NOSENDCHANGING = 0x400,
        SWP_DRAWFRAME = SWP_FRAMECHANGED,
        SWP_NOREPOSITION = SWP_NOOWNERZORDER,
        SWP_DEFERERASE = 0x2000,
        SWP_ASYNCWINDOWPOS = 0x4000
    }

    public static class FullScreen
    {
        #region Win32 API Calls

        /// <summary>
        /// The GetCapture function retrieves a handle to the window 
        /// </summary>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        private static extern IntPtr GetCapture();

        /// <summary>
        /// The SetCapture function sets the mouse capture to
        /// the specified window belonging to the current thread
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        private static extern IntPtr SetCapture(IntPtr hWnd);

        /// <summary>
        /// This function can be used to take over certain areas of the screen
        ///  It is used to modify the taskbar, Input Panel button,
        /// or Start menu icon.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [DllImport("aygshell.dll", SetLastError = true)]
        private static extern bool SHFullScreen(IntPtr hwnd, int state);

        /// <summary>
        /// The function retrieves the handle to the top-level 
        /// window whose class name and window name match 
        /// the specified strings. This function does not search child windows.
        /// </summary>
        /// <param name="lpClass"></param>
        /// <param name="lpWindow"></param>
        /// <returns></returns>
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr FindWindowW(string lpClass, string
        lpWindow);

        /// <summary>
        /// changes the position and dimensions of the specified window
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="l"></param>
        /// <param name="repaint"></param>
        /// <returns></returns>
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr MoveWindow(IntPtr hwnd, int x, int y, int
        w, int l, int repaint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="wFlags"></param>
        /// <returns></returns>
        [DllImport("Coredll.dll")]
        private static extern int SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        #endregion

        #region General Methods

        /// <summary>
        /// Coloca a janela no topo.
        /// </summary>
        /// <param name="hwnd"></param>
        public static void SetWindowOnTop(IntPtr hwnd)
        {
            SetWindowPos(hwnd, (int)SetWindowPosZOrder.HWND_TOP, 0, 0, 0, 0, (int)(SetWindowPosFlag.SWP_NOSIZE & SetWindowPosFlag.SWP_NOMOVE));
        }

        /// <summary>
        /// Coloca a janela no topo.
        /// </summary>
        /// <param name="frm"></param>
        public static void SetWindowOnTop(Form frm)
        {
            SetWindowOnTop(GetHWnd(frm));
        }

        /// <summary>
        /// obtain the window handle of a .Net window or control
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static IntPtr GetHWnd(Control c)
        {
            IntPtr hOldWnd = GetCapture();
            c.Capture = true;
            IntPtr hWnd = GetCapture();
            c.Capture = false;
            SetCapture(hOldWnd);
            return hWnd;

        }

        public static void StartFullScreen(IntPtr handle)
        {
            IntPtr iptr = handle;
            SHFullScreen(iptr, (int)FullScreenFlags.HideStartIcon);

            //detect taskbar height
            int taskbarHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;

            // move the viewing window north taskbar height to get rid of the command 
            //bar 
            if (!PlatformDetection.IsPocketPC() && PlatformDetection.IsSmartphone())
                MoveWindow(iptr, 0, -taskbarHeight, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height + taskbarHeight, 1);
            else
                MoveWindow(iptr, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 1);
        }

        public static void StartFullScreen(Control control)
        {
            StartFullScreen(GetHWnd(control));
        }

        /// <summary>
        /// Set Full Screen Mode
        /// </summary>
        /// <param name="form"></param>
        public static void StartFullScreen(Form form)
        {
            form.WindowState = FormWindowState.Normal;

            IntPtr iptr = form.Handle;
            StartFullScreen(iptr);
        }

        /// <summary>
        /// Move o form na tela.
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveForm(Form frm, int x, int y)
        {
            IntPtr hWnd = GetHWnd(frm);
            MoveWindow(hWnd, x, y, frm.Width, frm.Height, 1);
        }
        
        /// <summary>
        /// Redimenciona o form.
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void ResizeForm(Form frm, int x, int y, int width, int height)
        {
            IntPtr hWnd = GetHWnd(frm);
            MoveWindow(hWnd, x, y, width, height, 1);
        }

        /// <summary>
        /// Stop Full Screen Mode
        /// </summary>
        /// <param name="form"></param>
        public static void StopFullScreen(Form form)
        {
            //if windows ce return window and taskbar to his original place
            //if (!PlatformDetection.IsPocketPC())
            //{
            IntPtr iptr = form.Handle;

            SHFullScreen(iptr, (int)FullScreenFlags.ShowStartIcon);

            //detect taskbar height
            int taskbarHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;

            if (!PlatformDetection.IsPocketPC())
                MoveWindow(iptr, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - taskbarHeight, 1);
            else
                MoveWindow(iptr, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, 1);

                //IntPtr iptrTB = FindWindowW("HHTaskBar", null);
                //MoveWindow(iptrTB, 0, Screen.PrimaryScreen.Bounds.Height - taskbarHeight, Screen.PrimaryScreen.Bounds.Width, taskbarHeight, 1);

            //}

        }

        public static void HiddenTaskBar()
        {
            //detect taskbar height
            int taskbarHeight = HeightTaskBar();

            // move the task bar south taskbar height so that its not visible anylonger 
            IntPtr iptrTB = FindWindowW("HHTaskBar", null);

            if (!PlatformDetection.IsPocketPC())
                MoveWindow(iptrTB, 0, Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width, taskbarHeight, 1);
            else
                MoveWindow(iptrTB, 0, 0, 0, taskbarHeight, 1);
        }

        public static void ShowTaskBar()
        {
            //detect taskbar height
            int taskbarHeight = HeightTaskBar();

            IntPtr iptrTB = FindWindowW("HHTaskBar", null);

            if (!PlatformDetection.IsPocketPC())
                MoveWindow(iptrTB, 0, Screen.PrimaryScreen.Bounds.Height - taskbarHeight, Screen.PrimaryScreen.Bounds.Width, taskbarHeight, 1);
            else
                MoveWindow(iptrTB, 0, 0, Screen.PrimaryScreen.Bounds.Width, taskbarHeight, 1);
        }

        /// <summary>
        /// Recupera altura da barra de tarefas.
        /// </summary>
        /// <returns></returns>
        public static int HeightTaskBar()
        {
            return Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
        }

        #endregion
    }

}
