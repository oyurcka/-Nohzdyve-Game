using Controller;
using Model.Menu;
using WindowsView.Menu;

namespace WindowsController.Menu
{
    /// <summary>
    /// Класс контроллера информации об игре в формах
    /// </summary>
    public class WindowsControllerRecords : BaseController
    {
        /// <summary>
        /// Представление информации об игре в формах
        /// </summary>
        private ViewRecordsWindows _recordsView = null;

        /// <summary>
        /// Конструктор класса представления информации об игре в формах
        /// </summary>
        public WindowsControllerRecords()
        {
            Records records = new Records();
            _recordsView = new ViewRecordsWindows(records.RecordsList);
        }

        /// <summary>
        /// Запустить контроллер
        /// </summary>
        public override void Start()
        {
            _recordsView.Draw();
        }
    }
}
