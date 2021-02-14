using System.Windows;

namespace Model.Game

{
    /// <summary>
    /// Игровой объект
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// Положение объекта на поле
        /// </summary>
        private int _coordinateX;

        /// <summary>
        /// Положение объекта на поле
        /// </summary>
        private int _coordinateY;

        /// <summary>
        /// Прямоугольник для проверки на столкновение
        /// </summary>
        private Rect _rect;

        /// <summary>
        /// Координата X
        /// </summary>
        public int X { get { return _coordinateX; } set { _coordinateX = value; } }

        /// <summary>
        /// Координата Y
        /// </summary>
        public int Y { get { return _coordinateY; } set { _coordinateY = value; } }

        /// <summary>
        /// Ширина
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        public int Height { get; set; }


        /// <summary>
        /// Прямоугольник для проверки на столкновение
        /// </summary>
        public Rect Rect
        {
            get { _rect.X = _coordinateX + 1; _rect.Y = _coordinateY + 1; return _rect; }
            private set { _rect = value; }
        }

        /// <summary>
        /// Проверка на доступность для отрисовки 
        /// </summary>
        /// <param name="parHeight">Высота</param>
        /// <returns></returns>
        public bool IsAvailableToDraw(int parHeight)
        {
            if ((this.Y > 0) && (this.Y < parHeight - 1))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="parX">Позиция объекта по горизонтали</param>
        /// <param name="parY">Позиция объекта по вертикали</param>
        /// <param name="parWidth">Ширина</param>
        /// <param name="parHeight">Высота</param>
        public GameObject(int parX, int parY, int parWidth, int parHeight)
        {
            _coordinateX = parX;
            _coordinateY = parY;
            Width = parWidth;
            Height = parHeight;
            _rect = new Rect(parX, parY, parWidth, parHeight);
        }
    }
}
