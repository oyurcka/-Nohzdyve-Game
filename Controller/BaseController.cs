namespace Controller
{
    /// <summary>
    /// Абстрактный класс контроллера
    /// </summary>
    public abstract class BaseController
    {
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        public BaseController()
        {
        }

        /// <summary>
        /// Метод для запуска контроллера
        /// </summary>
        public abstract void Start();
    }
}
