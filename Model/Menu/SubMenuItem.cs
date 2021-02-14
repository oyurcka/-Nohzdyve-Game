using System.Collections.Generic;
using System.Linq;

namespace Model.Menu

{
    /// <summary>
    /// Класс подменю
    /// </summary>
    public class SubMenuItem : MenuItem
    {
        /// <summary>
        /// Коллекция элементов меню по ключу
        /// </summary>
        private Dictionary<int, MenuItem> _items = new Dictionary<int, MenuItem>();

        /// <summary>
        /// Возвращает массив элементов меню
        /// </summary>
        public MenuItem[] Items
        {
            get
            {
                return _items.Values.ToArray();
            }
        }

        /// <summary>
        /// Возвращает элемент меню по заданному индексу
        /// </summary>
        /// <param name="parId">индекс элемента</param>
        /// <returns>элемент меню</returns>
        public MenuItem this[int parId]
        {
            get
            {
                return _items[parId];
            }
        }

        /// <summary>
        /// Конструктор класса подменю
        /// </summary>
        /// <param name="parId">Номер элемента меню</param>
        /// <param name="parName">Название элемента</param>
        public SubMenuItem(int parId, string parName) : base(parId, parName)
        {
        }

        /// <summary>
        /// Добавляет элемент в меню
        /// </summary>
        /// <param name="parMenuItem"></param>
        protected void AddItem(MenuItem parMenuItem)
        {
            _items.Add(parMenuItem.Id, parMenuItem);
        }
    }
}