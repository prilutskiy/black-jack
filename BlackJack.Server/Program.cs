using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;

namespace BlackJack.Server
{
    static class WinAPI
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint RegisterWindowMessage(string lpString);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        public const uint HWND_BROADCAST = 0xFFFF;
        public const short SW_RESTORE = 9;
    }
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        public static uint BringToFrontMessage;
        [STAThread]
        private static void Main()
        {
            BringToFrontMessage = WinAPI.RegisterWindowMessage("MyAppBringToFront");
            bool createdMutex = false;

            using (Mutex oneApp = new Mutex(true, "MyAppMutex", out createdMutex))
            {
                if (createdMutex)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainWindow());
                }
                else
                {
                    WinAPI.PostMessage(
                      (IntPtr)WinAPI.HWND_BROADCAST,
                      BringToFrontMessage,
                      IntPtr.Zero,
                      IntPtr.Zero);
                }
            }
        }
    }
}