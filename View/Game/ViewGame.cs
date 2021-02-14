using System.Collections.Generic;
using Model.Game;

namespace View.Game
{
    /// <summary>
    /// Общий класс вывода игры на экран
    /// </summary>
    public abstract class ViewGame : ViewBase
    {

        /// <summary>
        /// Блокировочный объект для потоков
        /// </summary>
        private static object _locker = new object();

        /// <summary>
        /// Модель игры
        /// </summary>
        private Model.Game.Game _model = null;

        /// <summary>
        /// Ширина игры
        /// </summary>
        public int GameWidth { get; protected set; }

        /// <summary>
        /// Высота игры
        /// </summary>
        public int GameHeight { get; protected set; }

        /// <summary>
        /// Список игровых объектов
        /// </summary>
        protected List<ViewGameObject> ViewGameObjects;

        /// <summary>
        /// Игровое представление стен слева
        /// </summary>
        protected ViewWalls ViewLeftWalls { get; set; } = null;

        /// <summary>
        /// Игровое представление стен справа
        /// </summary>
        protected ViewWalls ViewRightWalls { get; set; } = null;

        /// <summary>
        /// Блокировочный объект для потоков
        /// </summary>
        protected static object Locker { get => _locker; set => _locker = value; }

        /// <summary>
        /// Модель игры
        /// </summary>
        public Model.Game.Game ModelGame { get => _model; set => _model = value; }

        /// <summary>
        /// Конструктор представления, принимает объект игры
        /// </summary>
        /// <param name="parModel"></param>
        public ViewGame(Model.Game.Game parModel)
        {
            ModelGame = parModel;
            ViewGameObjects = new List<ViewGameObject>();
            GameWidth = ModelGame.Width;
            GameHeight = ModelGame.Height;
            Init();
            foreach (GameObject elGameObject in ModelGame.GameObjects)
            {
                ViewGameObjects.Add(CreateItem(elGameObject));
            }
            ViewLeftWalls = CreateWallsView(ModelGame.LeftWalls);
            ViewRightWalls = CreateWallsView(ModelGame.RightWalls);
        }

        /// <summary>
        /// Инициализирует параметры представления
        /// </summary>
        protected abstract void Init();

        /// <summary>
        /// Перерисовывает игру
        /// </summary>
        public abstract void NeedRedraw();

        /// <summary>
        /// Создает представление игрового объекта
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        /// <returns>Представление игрового объекта</returns>
        protected abstract ViewGameObject CreateItem(GameObject parGameObject);

        /// <summary>
        /// Создать представление стен
        /// </summary>
        /// <param name="parHouses">Объект стен</param>
        /// <returns>Представление объекта стен</returns>
        public abstract ViewWalls CreateWallsView(Walls parHouses);

        /// <summary>
        /// Закрыть представление
        /// </summary>
        public abstract void Close();
    }
}