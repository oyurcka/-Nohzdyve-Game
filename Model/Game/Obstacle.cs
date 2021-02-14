namespace Model.Game
{
    /// <summary>
    /// Препятствие
    /// </summary>
    public class Obstacle : GameObject
    {
        /// <summary>
        /// Конструктор объекта препятствия
        /// </summary>
        /// <param name="parX">Позиция объекта по горизонтали</param>
        /// <param name="parY">Позиция объекта по вертикали</param>
        /// <param name="parWidth">Ширина</param>
        /// <param name="parHeight">Высота</param>
        public Obstacle(int parX, int parY, int parWidth, int parHeight) : base(parX, parY, parWidth, parHeight) { }
    }
}
