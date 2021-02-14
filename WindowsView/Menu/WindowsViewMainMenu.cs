using System.Windows.Forms;

namespace WindowsView.Menu
{
    /// <summary>
    /// Класс представления главного меню в формах
    /// </summary>
    public class WindowsViewMainMenu : WindowsViewMenu
    {
        /// <summary>
        /// Форма главного меню
        /// </summary>
        private Form _form = null;

        /// <summary>
        /// Конструктор класса представления главного меню в формах
        /// </summary>
        /// <param name="parSubMenuItem">Элемент меню</param>
        public WindowsViewMainMenu(Model.Menu.Menu parSubMenuItem) : base(parSubMenuItem)
        {
            Draw();
        }

        /// <summary>
        /// Инициализация формы главного меню
        /// </summary>
        public void Init()
        {
            _form = new Form();
            _form.Text = "Nohzdyve";
            _form.WindowState = FormWindowState.Normal;
            _form.FormBorderStyle = FormBorderStyle.Fixed3D;
            SetParentControl(_form);
            Draw();
            Application.Run(_form);
        }

        /// <summary>
        /// Закрыть форму
        /// </summary>
        public void Close()
        {
            _form.Close();
        }

        /// <summary>
        /// Скрыть форму
        /// </summary>
        public void Hide()
        {
            _form.Hide();
        }

        /// <summary>
        /// Отобразить форму
        /// </summary>
        public void Restore()
        {
            _form.Show();
        }
    }
}
