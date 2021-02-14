using Model.Menu;
using System.Collections.Generic;
using System.Linq;

namespace View.Menu
{
    /// <summary>
    /// Класс представления меню
    /// </summary>
    public abstract class ViewMenu : ViewBase
    {
        /// <summary>
        /// Поле меню
        /// </summary>
        private Model.Menu.Menu _menu = null;

        /// <summary>
        /// Коллекция представлений элементов меню по ключу
        /// </summary>
        private Dictionary<int, ViewMenuItem> _subMenu = null;

        /// <summary>
        /// Свойство возвращающее массив элементов меню
        /// </summary>
        protected ViewMenuItem[] Menu => _subMenu.Values.ToArray();

        /// <summary>
        /// Координата по горизонтали
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата по вертикали
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина меню
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Высота меню
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Возвращает представления элементов меню по id
        /// </summary>
        /// <param name="parId">id</param>
        /// <returns>Представление элемента меню</returns>
        public ViewMenuItem this[int parId]
        {
            get
            {
                return _subMenu[parId];
            }
        }

        /// <summary>
        /// Конструктор представления меню
        /// </summary>
        /// <param name="parSubMenuItem">Элемент подменю</param>
        public ViewMenu(Model.Menu.Menu parSubMenuItem)
        {
            _menu = parSubMenuItem;
            _subMenu = new Dictionary<int, ViewMenuItem>();
            foreach (MenuItem elMenuItem in parSubMenuItem.Items)
            {
                _subMenu.Add(elMenuItem.Id, CreateItem(elMenuItem));
            }
            _menu.NeedRedraw += NeedRedraw;
        }

        /// <summary>
        /// Перерисовывает содержимое меню
        /// </summary>
        protected abstract void NeedRedraw();

        /// <summary>
        /// Создает представление элемента меню
        /// </summary>
        /// <param name="parMenuItem">Элемент меню</param>
        /// <returns>Представление элемента меню</returns>
        protected abstract ViewMenuItem CreateItem(MenuItem parMenuItem);
    }
}
