using Model.Game;

namespace View.Game
{
    /// <summary>
    /// Абстрактный класс представления стен
    /// </summary>
    public abstract class ViewWalls : ViewBase
    {
        /// <summary>
        /// Стены
        /// </summary>
        protected Model.Game.Walls Walls { get; } = null;

        /// <summary>
        /// Конструктор представления стен
        /// </summary>
        /// <param name="parWalls">Объект стен</param>
        public ViewWalls(Walls parWalls)
        {
            Walls = parWalls;
        }
    }
}
