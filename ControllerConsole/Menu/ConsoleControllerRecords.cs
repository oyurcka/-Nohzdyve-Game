using ConsoleView.Menu;
using Controller;
using Model.Menu;
using System;

namespace ControllerConsole.Menu
{
    /// <summary>
    /// Класс контроллера рекордов консольной версии
    /// </summary>
    public class ConsoleControllerRecords : BaseController
    {
        /// <summary>
        /// Представление информации об игре
        /// </summary>
        private ConsoleViewRecords _recordsView = null;

        /// <summary>
        /// Необходимость закрытия окна
        /// </summary>
        private bool NeedExit { get; set; }

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public ConsoleControllerRecords()
        {
            Records records = new Records();
            _recordsView = new ConsoleViewRecords(records.RecordsList);
            _recordsView.Draw();
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
                        _recordsView.Draw();
                        break;
                }
            } while (!NeedExit);
        }
    }
}
