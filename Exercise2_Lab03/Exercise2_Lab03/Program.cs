using System;
using System.Windows.Forms;

namespace Exercise2_Lab03
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Cấu hình cho .NET 6.0+
            ApplicationConfiguration.Initialize();
            Application.Run(new Dashboard());
        }
    }
}
