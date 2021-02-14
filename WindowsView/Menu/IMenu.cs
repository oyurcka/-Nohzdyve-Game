using System.Windows.Forms;

namespace WindowsView.Menu
{
    /// <summary>
    /// Интерфейс элементов меню
    /// </summary>
    public interface IMenu
    {
        /// <summary>
        /// Интерфейс метода родительского элемента управления
        /// </summary>
        /// <param name="parControl"></param>
        void SetParentControl(Control parControl);
    }
}
