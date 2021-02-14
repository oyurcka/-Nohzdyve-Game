namespace Controller
{
    /// <summary>
    /// Абстрактный класс реализации шаблона "Адаптер"
    /// </summary>
    public abstract class BaseAdapter
    {
        /// <summary>
        /// Игровой объект, который необходимо адаптировать под консольную и формовую версии игры
        /// </summary>
        protected Model.Game.Game GameModel { get; set; } = null;

        /// <summary>
        /// Конструктор класса. Принимает игровой объект, методы которого будут вызываться адаптерами
        /// </summary>
        /// <param name="parModel">Игровой объект</param>
        public BaseAdapter(Model.Game.Game parModel)
        {
            GameModel = parModel;
        }
    }
}
