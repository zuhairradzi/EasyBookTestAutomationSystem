using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EBTestGUI
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AttachConsole(ATTACH_PARENT_PROCESS);

            Application.EnableVisualStyles();
            Console.WriteLine("Test");
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
           // Application.Run(new Form1());
            Application.Exit();
        }
    }
}
