using ControllerConsole.Menu;

namespace NohzdyveConsole
{
    /// <summary>
    /// Класс входа в приложение
    /// </summary>
    public class Runner
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ConsoleControllerMainMenu controller = ConsoleControllerMainMenu.GetInstance();
            controller.Start();
        }
    }
}
