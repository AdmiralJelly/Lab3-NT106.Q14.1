using System;
using System.Windows.Forms;

namespace Exercise3_Lab03
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // For .NET 6.0+
            ApplicationConfiguration.Initialize();
            Application.Run(new Dashboard());
        }
    }
}
