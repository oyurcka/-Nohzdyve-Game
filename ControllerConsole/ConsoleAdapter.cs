using System;
using System.Collections.Generic;
using Controller;
using Model.Game;

namespace ControllerConsole
{
    /// <summary>
    /// Класс - адаптер для обработки пользовательского ввода с консоли
    /// </summary>
    public class InputAdapterConsole : BaseAdapter
    {
        /// <summary>
        /// Коллекция игровых действий по ключам клавиш в консоли
        /// </summary>
        private static Dictionary<ConsoleKey, GameAction> _keyToAction = null;

        /// <summary>
        /// Статический конструктор, инициализирующий коллекцию игровых действий
        /// </summary>
        static InputAdapterConsole()
        {
            _keyToAction = new Dictionary<ConsoleKey, GameAction>
            {
                [ConsoleKey.LeftArrow] = GameAction.Left,
                [ConsoleKey.RightArrow] = GameAction.Right,
                [ConsoleKey.Escape] = GameAction.Escape
            };
        }

        /// <summary>
        /// Конструктор адаптера
        /// </summary>
        /// <param name="parModel">Экземпляр игры</param>
        public InputAdapterConsole(Model.Game.Game parModel) : base(parModel)
        {
        }

        /// <summary>
        /// Обрабатывает пользовательский ввод в игре
        /// </summary>
        public void HandleInput()
        {
            ConsoleKey key = Console.ReadKey().Key;

            if (_keyToAction.ContainsKey(key))
            {
                GameModel.HandleAction(_keyToAction[key]);
            }
        }
    }
}
