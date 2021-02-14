namespace Model.Game
{
    public class Walls
    {
        /// <summary>
        /// Положение объекта на поле
        /// </summary>
        private int _coordinateX;

        /// <summary>
        /// Координата X
        /// </summary>
        public int X { get { return _coordinateX; } set { _coordinateX = value; } }

        /// <summary>
        /// Ширина
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="parX">Позиция объекта по X</param>
        /// <param name="parWidth">Ширина</param>
        public Walls(int parX, int parWidth)
        {
            _coordinateX = parX;
            Width = parWidth;
        }
    }
}
