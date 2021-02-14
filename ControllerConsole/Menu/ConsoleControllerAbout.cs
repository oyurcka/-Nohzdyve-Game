using ConsoleView.Menu;
using Controller;
using System;

namespace ControllerConsole.Menu
{
    /// <summary>
    /// Контроллер информации об игре
    /// </summary>
    public class ConsoleControllerAbout : BaseController
    {
        /// <summary>
        /// Представление информации об игре
        /// </summary>
        private ConsoleViewAbout _aboutView = new ConsoleViewAbout();

        /// <summary>
        /// Необходимость закрытия окна
        /// </summary>
        private bool NeedExit { get; set; }

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public ConsoleControllerAbout()
        {
            _aboutView.Draw();
        }

        /// <summary>
        /// Запуск контроллера с ожиданием пользовательского ввода
        /// </summary>
        public override void Start()
        {
            do
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        NeedExit = true;
                        break;
                    default:
                        _aboutView.Draw();
                        break;
                }
            } while (!NeedExit);
        }
    }
}
