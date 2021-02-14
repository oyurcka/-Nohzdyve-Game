using System.Collections.Generic;
using Controller;
using System.Windows.Forms;
using Model.Game;

namespace WindowsController
{
    /// <summary>
    /// Класс адаптера для обработки пользовательского ввода в формах
    /// </summary>
    public class WindowsAdapter : BaseAdapter
    {
        /// <summary>
        /// Коллекция игровых действий по коду нажатой клавиши
        /// </summary>
        private static Dictionary<Keys, GameAction> _keyToAction = null;

        /// <summary>
        /// Статический конструктор адаптера для инициализации коллекции игровых действий
        /// </summary>
        static WindowsAdapter()
        {
            _keyToAction = new Dictionary<Keys, GameAction>
            {
                [Keys.Left] = GameAction.Left,
                [Keys.Right] = GameAction.Right,
                [Keys.Escape] = GameAction.Escape
            };
        }

        /// <summary>
        /// Конструктор адаптера для обработки действий в формах
        /// </summary>
        /// <param name="parModel">Экземпляр игры</param>
        public WindowsAdapter(Model.Game.Game parModel) : base(parModel)
        {
        }

        /// <summary>
        /// Обработчик нажатия клавиш
        /// </summary>
        /// <param name="parKeyCode">Код нажатой клавиши</param>
        public void HandleInput(Keys parKeyCode)
        {
            if (_keyToAction.ContainsKey(parKeyCode))
            {
                GameModel.HandleAction(_keyToAction[parKeyCode]);
            }
        }
    }
}
