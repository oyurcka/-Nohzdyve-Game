using System;
using System.Windows.Forms;
using WindowsController.Menu;

namespace WindowsNohzdyve
{
    /// <summary>
    /// Класс входа в приложение
    /// </summary>
    static class Runner
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowsControllerMainMenu controller = WindowsControllerMainMenu.GetInstance();
            controller.Start();
        }
    }
}
