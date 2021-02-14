namespace Model.Game
{
    /// <summary>
    /// Человечек
    /// </summary>
    public class Man : GameObject
    {
        /// <summary>
        /// Конструктор объекта человечка
        /// </summary>
        /// <param name="parX">Позиция объекта по горизонтали</param>
        /// <param name="parY">Позиция объекта по вертикали</param>
        /// <param name="parWidth">Ширина объекта</param>
        /// <param name="parHeight">Высота объекта</param>
        public Man(int parX, int parY, int parWidth, int parHeight) : base(parX, parY, parWidth, parHeight) { }
    }
}
