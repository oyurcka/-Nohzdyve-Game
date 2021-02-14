using Controller.Menu;
using WindowsView.Menu;
using WindowsController.Game;

namespace WindowsController.Menu
{
    /// <summary>
    /// Класс контроллера главного меню в формах
    /// </summary>
    public class WindowsControllerMainMenu : ControllerMenu
    {

        /// <summary>
        /// Экземпляр контроллера
        /// </summary>
        private static WindowsControllerMainMenu _instance;

        /// <summary>
        /// Представление главного меню
        /// </summary>
        private WindowsViewMainMenu _viewMenu = null;

        /// <summary>
        /// Конструктор класса представления главного меню в формах
        /// </summary>
        public WindowsControllerMainMenu()
        {
            Menu = new Model.Menu.MainMenu();
            _viewMenu = new WindowsViewMainMenu(Menu);

            Menu[(int)Model.Menu.MainMenu.MenuItemId.NewGame].Selected += NewGame;
            Menu[(int)Model.Menu.MainMenu.MenuItemId.About].Selected += ShowAbout;
            Menu[(int)Model.Menu.MainMenu.MenuItemId.Records].Selected += ShowRecords;
            Menu[(int)Model.Menu.MainMenu.MenuItemId.Exit].Selected += () => { _viewMenu.Close(); };

            foreach (Model.Menu.MenuItem elItem in Menu.Items)
            {
                ((WindowsViewMenuItem)_viewMenu[elItem.Id]).Enter += (id) => { Menu.FocusItemById(id); Menu.SelectFocusedItem(); };
            }
        }

        /// <summary>
        /// Новая игра
        /// </summary>
        private void NewGame()
        {
            WindowsControllerGame gameController = new WindowsControllerGame(this);
            _viewMenu.Hide();
            gameController.Start();
        }

        /// <summary>
        /// Запустить контроллер рекордов
        /// </summary>
        private void ShowRecords()
        {
            new WindowsControllerRecords().Start();
        }

        /// <summary>
        /// Запустить контроллер информации об игре
        /// </summary>
        private void ShowAbout()
        {
            new WindowsControllerAbout().Start();
        }

        /// <summary>
        /// Показать форму
        /// </summary>
        public void Restore()
        {
            _viewMenu.Restore();
        }

        /// <summary>
        /// Запустить контроллер
        /// </summary>
        public override void Start()
        {
            _viewMenu.Init();
        }

        /// <summary>
        /// Создание и возврат экземпляра контроллера
        /// </summary>
        /// <returns>Экземпляр контроллера</returns>
        public static WindowsControllerMainMenu GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WindowsControllerMainMenu();
            }
            return _instance;
        }
    }
}
