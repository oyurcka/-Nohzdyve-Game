using Model.Game;
using Model.Menu;
using System;
using View.Game;

namespace ConsoleView.Game
{
    /// <summary>
    /// Консольное представление игры
    /// </summary>
    public class ConsoleViewGame : ViewGame
    {
        /// <summary>
        ///  Конструктор консольного представления игры
        /// </summary>
        /// <param name="parModel">Объект модели</param>
        public ConsoleViewGame(Model.Game.Game parModel) : base(parModel)
        {
        }

        /// <summary>
        /// Инициализация представления игры 
        /// </summary>
        protected override void Init()
        {
            ConsoleHelper.ConsoleHelper.SetCurrentFont("Lucida Console", 14);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(GameWidth, GameHeight);
            Console.SetBufferSize(GameWidth, GameHeight);
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Отобразить содержимое игры
        /// </summary>
        public override void Draw()
        {
            lock (Locker)
            {
                FastOutput.FastOutput.Clear();
                foreach (ViewGameObject elViewGameObject in ViewGameObjects)
                {
                    if (elViewGameObject.GameObject.IsAvailableToDraw(GameHeight))
                        elViewGameObject.Draw();
                }
                ViewLeftWalls.Draw();
                ViewRightWalls.Draw();
                if (ModelGame.GameOver)
                {
                    FastOutput.FastOutput.Write("GameOver", 20, 10, ConsoleColor.Red);
                }
                FastOutput.FastOutput.Write(ModelGame.Score.ToString(), 5, 5, ConsoleColor.Green);
                FastOutput.FastOutput.PrintOnConsole();
            }
        }

        /// <summary>
        /// Перерисовать содержимое игры
        /// </summary>
        public override void NeedRedraw()
        {
            Draw();
        }

        /// <summary>
        /// Создать консольное представление игрового объекта
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        /// <returns>Консольное представление игрового объекта</returns>

        protected override ViewGameObject CreateItem(GameObject parGameObject)
        {
            return new ViewGameObjectConsole(parGameObject);
        }

        /// <summary>
        /// Создать консольное представление стен
        /// </summary>
        /// <param name="parWalls">Объект стен</param>
        /// <returns></returns>
        public override ViewWalls CreateWallsView(Walls parWalls)
        {
            return new ConsoleViewWalls(parWalls);
        }

        /// <summary>
        /// Закрывает представление
        /// </summary>
        public override void Close()
        {
            Menu.ConsoleViewMenu.Resize();
        }
    }
}
