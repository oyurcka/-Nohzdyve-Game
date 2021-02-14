using System.Collections.Generic;
using System.Windows.Forms;
using Model.Game;
using WindowsController.Menu;
using WindowsView.Game;

namespace WindowsController.Game
{
    /// <summary>
    /// Класс контроллера игры в формах
    /// </summary>
    public class WindowsControllerGame : Controller.Game.ControllerGame
    {
        /// <summary>
        /// Контроллер главного меню
        /// </summary>
        private WindowsControllerMainMenu _parentController = null;

        /// <summary>
        /// Адаптер для обработки пользовательского ввода
        /// </summary>
        private WindowsAdapter _inputAdapter { get; set; } = null;

        /// <summary>
        ///  Конструктор класса контроллера игры
        /// </summary>
        /// <param name="parControllerMainMenuWindows">Контроллер главного меню</param>
        public WindowsControllerGame(WindowsControllerMainMenu parControllerMainMenuWindows)
        {
            _parentController = parControllerMainMenuWindows;
            List<GameObject> GameObjects = new List<GameObject>() { new Man(200, 50, 20, 20), new Obstacle(200, 200, 40, 20) };
            ModelGame = new Model.Game.Game(GameObjects, 10);
            _inputAdapter = new WindowsAdapter(ModelGame);
            View = new WindowsViewGame(ModelGame);
            ModelGame.NeedRedraw += () => { View.NeedRedraw(); };
            ModelGame.ShowMenu += ShowMenu;
        }

        /// <summary>
        /// Вернуться в меню
        /// </summary>
        private void ShowMenu()
        {
            View.Close();
            _parentController.Restore();
        }

        /// <summary>
        /// Запустить контроллер
        /// </summary>
        public override void Start()
        {
            ModelGame.CreateGame();
            ModelGame.Play();
            ((WindowsViewGame)View).KeyDown += ControllerGameWindow_KeyDown;
        }

        /// <summary>
        /// Обработчик события нажатия на клавишу
        /// </summary>
        /// <param name="parE"></param>
        private void ControllerGameWindow_KeyDown(KeyEventArgs parE)
        {
            _inputAdapter.HandleInput(parE.KeyData);
        }
    }
}
