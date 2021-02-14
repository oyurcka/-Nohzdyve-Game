using Model.Menu;
using System.Windows.Forms;
using View.Menu;

namespace WindowsView.Menu
{
    /// <summary>
    /// Класс представления подменю в формах
    /// </summary>
    public class ViewSubMenuItemWindows : ViewMenuItem
    {
        /// <summary>
        /// Кнопка подменю
        /// </summary>
        protected Button Button { get; } = null;

        /// <summary>
        /// Конструктор класса представления подменю в формах
        /// </summary>
        /// <param name="parSubMenuItem">Подменю</param>
        public ViewSubMenuItemWindows(SubMenuItem parSubMenuItem) : base(parSubMenuItem)
        {
            Button = new Button();
            Button.Text = parSubMenuItem.Name;
        }

        /// <summary>
        /// Задает родительский элемент управления
        /// </summary>
        /// <param name="parControl">Элемент управления</param>
        public void SetParentControl(Control parControl)
        {
            parControl.Controls.Add(Button);
        }

        /// <summary>
        /// Отображает представление
        /// </summary>
        public override void Draw()
        {
            Button.Left = X;
            Button.Top = Y;
        }
    }
}
