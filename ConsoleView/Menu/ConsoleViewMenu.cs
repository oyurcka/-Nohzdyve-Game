using System;
using System.Linq;

namespace ConsoleView.Menu
{
    /// <summary>
    /// Класс консольного представления меню
    /// </summary>
    public class ConsoleViewMenu : View.Menu.ViewMenu
    {
        /// <summary>
        /// Высота
        /// </summary>
        public static int HEIGHT = 30;

        /// <summary>
        /// Ширина
        /// </summary>
        public static int WIDTH = 60;

        /// <summary>
        /// Конструктор консольного представления меню
        /// </summary>
        /// <param name="parSubMenuItem">Меню</param>
        public ConsoleViewMenu(Model.Menu.Menu parSubMenuItem) : base(parSubMenuItem)
        {
            Init();
            Draw();
        }

        /// <summary>
        /// Создает представление элемента меню или подменю
        /// </summary>
        /// <param name="parMenuItem">Элемент меню</param>
        /// <returns>Представление элемента меню</returns>
        protected override View.Menu.ViewMenuItem CreateItem(Model.Menu.MenuItem parMenuItem)
        {
            if (parMenuItem is Model.Menu.SubMenuItem)
            {
                return new ConsoleViewSubMenuItem((Model.Menu.SubMenuItem)parMenuItem);
            }

            if (parMenuItem is Model.Menu.MenuItem)
            {
                return new ConsoleViewMenuItem(parMenuItem);
            }

            return null;
        }

        /// <summary>
        /// Статический метод изменения размера и шрифта для меню
        /// </summary>
        public static void Resize()
        {
            Console.SetWindowSize(WIDTH, HEIGHT);
            Console.SetBufferSize(WIDTH, HEIGHT);
            ConsoleHelper.ConsoleHelper.SetCurrentFont("Lucida Console", 14);
        }

        /// <summary>
        /// Инициализирует значения для отображения меню
        /// </summary>
        private void Init()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Resize();
            Console.CursorVisible = false;
            Console.Title = "Nohzdyve";
            View.Menu.ViewMenuItem[] menu = Menu;
            Height = menu.Length;
            Width = menu.Max(x => x.Width);
            X = Console.WindowWidth / 2 - Width / 2;
            Y = Console.WindowHeight / 2 - Height / 2;
            int y = Y;
            foreach (View.Menu.ViewMenuItem elMenuItemView in menu)
            {
                elMenuItemView.X = X;
                elMenuItemView.Y = y++;
            }
        }

        /// <summary>
        /// Перерисовывает содержимое
        /// </summary>
        protected override void NeedRedraw()
        {
            Draw();
        }

        /// <summary>
        /// Отрисовывает содержимое
        /// </summary>
        public override void Draw()
        {
            Console.Clear();
            foreach (View.Menu.ViewMenuItem elMenuItemView in Menu)
            {
                elMenuItemView.Draw();
            }
        }
    }
}
