using System.Windows.Forms;
using View.Menu;

namespace WindowsView.Menu
{
    /// <summary>
    /// Класс представления пункта меню в формах
    /// </summary>
    public class WindowsViewMenuItem : ViewMenuItem, IMenu
    {
        /// <summary>
        /// Кнопка пункта меню
        /// </summary>
        protected Button Button { get; } = null;

        /// <summary>
        /// Делегат, передающий индекс выбранного пункта меню
        /// </summary>
        /// <param name="parId"></param>
        public delegate void dEnter(int parId);

        /// <summary>
        /// Событие, происходящее при выборе пункта меню
        /// </summary>
        public event dEnter Enter = null;

        /// <summary>
        /// Конструктор класса представления элемента меню в формах
        /// </summary>
        /// <param name="parItem">Элемент меню</param>
        public WindowsViewMenuItem(Model.Menu.MenuItem parItem) : base(parItem)
        {
            Button = new Button();
            Button.Text = parItem.Name;
            Button.Click += (s, e) => { Enter?.Invoke(Item.Id); };
            Height = Button.Height;
            Width = Button.Width;
        }

        /// <summary>
        /// Задать родительский элемент управления
        /// </summary>
        /// <param name="parControl">Элемент управления</param>
        public void SetParentControl(Control parControl)
        {
            if (!parControl.Controls.Contains(Button))
                parControl.Controls.Add(Button);
        }

        /// <summary>
        /// Отобразить содержимое
        /// </summary>
        public override void Draw()
        {
            Button.Left = X + 5;
            Button.Top = Y;
        }
    }
}
