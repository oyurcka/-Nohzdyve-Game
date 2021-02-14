namespace Controller.Menu

{
    /// <summary>
    /// Базовый класс контроллера меню
    /// </summary>
    public abstract class ControllerMenu : BaseController
    {
        /// <summary>
        /// Объект меню
        /// </summary>
        protected Model.Menu.Menu Menu { get; set; } = null;
    }
}
