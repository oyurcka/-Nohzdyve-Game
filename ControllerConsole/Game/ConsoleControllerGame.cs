using Controller.Game;
using Model.Game;
using System.Collections.Generic;

namespace ControllerConsole.Game
{
    /// <summary>
    /// Класс контроллера консольной игры
    /// </summary>
    public class ConsoleControllerGame : ControllerGame
    {

        /// <summary>
        /// Адаптер для обработки пользовательского ввода с консоли
        /// </summary>
        private InputAdapterConsole _inputAdapter { get; set; } = null;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ConsoleControllerGame()
        {
            List<GameObject> GameObjects = new List<GameObject>() { new Man(25, 5, 2, 2), new Obstacle(22, 90, 5, 2) };
            ModelGame = new Model.Game.Game(GameObjects, 1);
            View = new ConsoleView.Game.ConsoleViewGame(ModelGame);
            _inputAdapter = new InputAdapterConsole(ModelGame);
            ModelGame.NeedRedraw += () => { View.NeedRedraw(); };
            ModelGame.ShowMenu += () => { View.Close(); };
        }

        /// <summary>
        /// Запуск игрового контроллера
        /// </summary>
        public override void Start()
        {
            ModelGame.CreateGame();
            ModelGame.Play();

            do
            {
                View.Draw();
                _inputAdapter.HandleInput();
            } while (!ModelGame.NeedExit);
        }
    }
}
