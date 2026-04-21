using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Globalization;

namespace HCIProjekat1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(""); 
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}