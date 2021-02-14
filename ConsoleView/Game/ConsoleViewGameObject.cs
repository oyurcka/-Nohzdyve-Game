using Model.Game;
using System;
using View.Game;

namespace ConsoleView.Game
{
    /// <summary>
    ///  Класс представления игрового объекта в консоли 
    /// </summary>
    public class ViewGameObjectConsole : ViewGameObject
    {

        /// <summary>
        /// Отображаемый символ сверху
        /// </summary>
        private String _topSymbol { get; set; }

        /// <summary>
        /// Отображаемый символ снизу
        /// </summary>
        private String _bottomSymbol { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parGameObject"></param>
        public ViewGameObjectConsole(GameObject parGameObject) : base(parGameObject)
        {
            SetSymbol();
        }

        /// <summary>
        /// Задать символ для отображения
        /// </summary>
        private void SetSymbol()
        {
            if (GameObject is Man)
            {
                _topSymbol = "00";
                _bottomSymbol = "/\\";
            }
            else if (GameObject is Obstacle)
            {
                _topSymbol = "00000";
                _bottomSymbol = "00000";
            }
        }

        /// <summary>
        /// Выводит объект на экран
        /// </summary>
        public override void Draw()
        {
            FastOutput.FastOutput.Write(_topSymbol, GameObject.X, GameObject.Y - 1, ConsoleColor.White);
            FastOutput.FastOutput.Write(_bottomSymbol, GameObject.X, GameObject.Y, ConsoleColor.White);
        }
    }
}
