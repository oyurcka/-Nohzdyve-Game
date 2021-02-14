using Model.Game;

namespace View.Game
{
    /// <summary>
    /// Представление игрового объекта
    /// </summary>
    public abstract class ViewGameObject : ViewBase
    {

        /// <summary>
        /// Игровой объект
        /// </summary>
        public GameObject GameObject { get; } = null;

        /// <summary>
        /// Констркутор класса, принимает и записывает в свойство игровой объект
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        public ViewGameObject(GameObject parGameObject)
        {
            GameObject = parGameObject;
        }
    }
}

