using TaskManager.Database;
using TaskManager.WinForms;

namespace TaskManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //new DbAccess().RefreshDB();

            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}