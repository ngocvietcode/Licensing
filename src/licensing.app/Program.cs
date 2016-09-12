using System;
using System.Globalization;
using System.Windows.Forms;
using Licensing.Client;

namespace Licensing.App
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GenLicenseForm());
        }
    }

  
}