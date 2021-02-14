using Model.Menu;
using System.Collections.Generic;

namespace View.Menu
{
    /// <summary>
    /// Класс представления подменю
    /// </summary>
    public abstract class ViewSubMenuItem : ViewMenuItem
    {
        /// <summary>
        /// Список представлений элементов подменю
        /// </summary>
        private List<ViewMenuItem> _items = new List<ViewMenuItem>();

        /// <summary>
        /// Конструктор представления подменю
        /// </summary>
        /// <param name="parSubMenuItem">Элемент подменю</param>
        public ViewSubMenuItem(SubMenuItem parSubMenuItem)
          : base(parSubMenuItem)
        {
        }

        /// <summary>
        /// Добавляет представление элемента подменю
        /// </summary>
        /// <param name="parMenuItemView"></param>
        protected void AddItem(ViewMenuItem parMenuItemView)
        {
            _items.Add(parMenuItemView);
        }
    }
}
