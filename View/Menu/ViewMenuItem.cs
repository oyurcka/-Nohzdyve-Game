using Model.Menu;

namespace View.Menu
{
    /// <summary>
    /// Представление элемента меню
    /// </summary>
    public abstract class ViewMenuItem : ViewBase
    {
        /// <summary>
        /// Элемент меню
        /// </summary>
        protected MenuItem Item { get; } = null;

        /// <summary>
        /// Координата по горизонтали
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата по вертикали
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Ширина элемента
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Высота элемента
        /// </summary>
        public int Height { get; protected set; }

        /// <summary>
        /// Конструктор представления элемента меню
        /// </summary>
        /// <param name="parItem">Элемент меню</param>
        public ViewMenuItem(MenuItem parItem)
        {
            Item = parItem;
        }
    }
}
