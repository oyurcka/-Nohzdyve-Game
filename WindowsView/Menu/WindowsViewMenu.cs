using Model.Menu;
using System;
using System.Linq;
using System.Windows.Forms;
using View.Menu;

namespace WindowsView.Menu
{
    /// <summary>
    /// Класс представления меню в формах
    /// </summary>
    public class WindowsViewMenu : ViewMenu, IMenu
    {
        /// <summary>
        /// Группа элементов меню
        /// </summary>
        private GroupBox _groupBox = null;

        /// <summary>
        /// Конструктор класса представления меню в формах
        /// </summary>
        /// <param name="parSubMenuItem">Элемент меню</param>
        public WindowsViewMenu(Model.Menu.Menu parSubMenuItem) : base(parSubMenuItem)
        {
            _groupBox = new GroupBox();
            Draw();
        }

        /// <summary>
        /// Отобразить содержимое меню
        /// </summary>
        public override void Draw()
        {
            foreach (ViewMenuItem elViewMenuItem in Menu)
            {
                elViewMenuItem.Draw();
            }
        }

        /// <summary>
        /// Задать родительский элемент управления
        /// </summary>
        /// <param name="parControl">Элемент управления</param>
        public void SetParentControl(Control parControl)
        {
            parControl.Controls.Add(_groupBox);
            Init(parControl);
            parControl.SizeChanged += ParControl_SizeChanged;
        }

        /// <summary>
        /// Обработчик события изменения размера родительского элемента управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParControl_SizeChanged(object sender, EventArgs e)
        {
            Init((Control)sender);
        }

        /// <summary>
        /// Инициализация представления
        /// </summary>
        /// <param name="parControl">Роительский элемент управления</param>
        private void Init(Control parControl)
        {
            ViewMenuItem[] menu = Menu;
            foreach (ViewMenuItem elViewMenuItem in menu)
            {
                ((IMenu)elViewMenuItem).SetParentControl(_groupBox);
            }
            Height = menu.Sum((x) => x.Height) + 20;
            Width = menu.Max((x) => x.Width) + 20;
            int y = 10;
            foreach (ViewMenuItem elViewMenuItem in menu)
            {
                elViewMenuItem.X = 5;
                elViewMenuItem.Y = y;

                y += elViewMenuItem.Height + 2;
            }
            _groupBox.Width = Width;
            _groupBox.Height = Height;
            _groupBox.Left = parControl.ClientSize.Width / 2 - Width / 2;
            _groupBox.Top = parControl.ClientSize.Height / 2 - Height / 2;
        }

        /// <summary>
        /// Создает представление элемента меню
        /// </summary>
        /// <param name="parMenuItem">Элемент меню</param>
        /// <returns>Представление элемента меню</returns>
        protected override ViewMenuItem CreateItem(Model.Menu.MenuItem parMenuItem)
        {
            if (parMenuItem is SubMenuItem)
                return new ViewSubMenuItemWindows((SubMenuItem)parMenuItem);
            else if (parMenuItem is Model.Menu.MenuItem)
                return new WindowsViewMenuItem(parMenuItem);
            return null;
        }

        /// <summary>
        /// Перерисовывает сожержимое
        /// </summary>
        protected override void NeedRedraw()
        {
            Draw();
        }
    }
}
