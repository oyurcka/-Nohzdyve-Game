using View.Game;

namespace Controller.Game
{
    /// <summary>
    /// Абстрактный класс контроллера игры
    /// </summary>
    public abstract class ControllerGame : BaseController
    {
        /// <summary>
        /// Объект представления игры
        /// </summary>
        protected ViewGame View { get; set; } = null;

        /// <summary>
        /// Модель игры
        /// </summary>
        protected Model.Game.Game ModelGame { get; set; } = null;
    }
}
