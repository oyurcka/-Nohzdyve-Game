using Model.Game;
using System;
using View.Game;

namespace ConsoleView.Game
{
    /// <summary>
    /// Класс представления стен в консоли 
    /// </summary>
    public class ConsoleViewWalls : ViewWalls
    {
        /// <summary>
        /// Отступ
        /// </summary>
        private const int PADDING = 3;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parWalls">Объект стен</param>
        public ConsoleViewWalls(Walls parWalls) : base(parWalls)
        {

        }

        /// <summary>
        /// Выводит объект на экран
        /// </summary>
        public override void Draw()
        {
            for (int i = PADDING; i < Console.WindowHeight - 3; i++)
                FastOutput.FastOutput.Write("|", Walls.X, i, ConsoleColor.Green);
        }
    }
}
