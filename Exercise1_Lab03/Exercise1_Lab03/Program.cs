using Exercise1_Lab03;
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
            ApplicationConfiguration.Initialize();
            Application.Run(new Dashboard());
        }
    }
}
