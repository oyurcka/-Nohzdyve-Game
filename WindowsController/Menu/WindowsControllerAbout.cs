using Controller;
using WindowsView.Menu;

namespace WindowsController.Menu
{
    /// <summary>
    /// Класс контроллера информации об игре в формах
    /// </summary>
    public class WindowsControllerAbout : BaseController
    {
        /// <summary>
        /// Представление информации об игре в формах
        /// </summary>
        private WindowsViewAbout _aboutView = null;

        /// <summary>
        /// Конструктор класса представления информации об игре
        /// </summary>
        public WindowsControllerAbout()
        {
            _aboutView = new WindowsViewAbout();
        }

        /// <summary>
        /// Запустить контроллер
        /// </summary>
        public override void Start()
        {
            _aboutView.Draw();
        }
    }
}
