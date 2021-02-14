using Controller.Menu;
using ControllerConsole.Game;
using System;

namespace ControllerConsole.Menu
{
    /// <summary>
    /// Класс контроллера главного меню
    /// </summary>
    public class ConsoleControllerMainMenu : ControllerMenu
    {
        /// <summary>
        /// Экземпляр контроллера
        /// </summary>
        private static ConsoleControllerMainMenu _instance;

        /// <summary>
        /// Представление главного меню
        /// </summary>
        private ConsoleView.Menu.ConsoleViewMenu _menuView = null;

        /// <summary>
        /// Необходимость закрытия окна
        /// </summary>
        private bool _needExit = false;

        /// <summary>
        /// Контроллер главного меню устанавливает обработчики событий для пунктов меню
        /// </summary>
        public ConsoleControllerMainMenu()
        {
            Menu = new Model.Menu.MainMenu();
            _menuView = new ConsoleView.Menu.ConsoleViewMenu(Menu);

            Menu[(int)Model.Menu.MainMenu.MenuItemId.NewGame].Selected += NewGame;
            Menu[(int)Model.Menu.MainMenu.MenuItemId.Records].Selected += ShowRecords;
            Menu[(int)Model.Menu.MainMenu.MenuItemId.About].Selected += ShowAbout;
            Menu[(int)Model.Menu.MainMenu.MenuItemId.Exit].Selected += () => { _needExit = true; };
        }

        /// <summary>
        /// Запуск контроллера игры
        /// </summary>
        private void NewGame()
        {
            ConsoleControllerGame gameController = new ConsoleControllerGame();
            gameController.Start();
        }

        /// <summary>
        /// Показать рекорды
        /// </summary>
        private void ShowRecords()
        {
            ConsoleControllerRecords recordsController = new ConsoleControllerRecords();
            recordsController.Start();
        }

        /// <summary>
        /// Показать информацию об игре
        /// </summary>
        private void ShowAbout()
        {
            ConsoleControllerAbout aboutController = new ConsoleControllerAbout();
            aboutController.Start();
        }

        /// <summary>
        /// Запуск контроллера и ожидания ввода пользователя
        /// </summary>
        public override void Start()
        {
            do
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        Menu.FocusPrevious();
                        break;
                    case ConsoleKey.DownArrow:
                        Menu.FocusNext();
                        break;
                    case ConsoleKey.Enter:
                        Menu.SelectFocusedItem();
                        break;
                    case ConsoleKey.Escape:
                        _needExit = true;
                        break;
                    default:
                        _menuView.Draw();
                        break;
                }

            } while (!_needExit);

        }

        /// <summary>
        /// Создание экземпляра контроллера
        /// </summary>
        /// <returns>instance контроллера</returns>
        public static ConsoleControllerMainMenu GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConsoleControllerMainMenu();
            }
            return _instance;
        }
    }
}
