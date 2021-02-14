using System;
using System.Collections.Generic;

namespace ConsoleView.Menu
{
    /// <summary>
    /// Класс представления подменю в консоли
    /// </summary>
    public class ConsoleViewSubMenuItem : View.Menu.ViewSubMenuItem
    {
        /// <summary>
        /// Высота
        /// </summary>
        public int HEIGHT = 1;

        /// <summary>
        /// Коллекция цветов элементов меню по их состоянию
        /// </summary>
        protected static Dictionary<Model.Menu.MenuItem.States, ConsoleColor> ColorByState { get; private set; }

        /// <summary>
        /// Статический конструктор для инициализации коллекции цветов элементов меню
        /// </summary>
        static ConsoleViewSubMenuItem()
        {
            ColorByState = new Dictionary<Model.Menu.MenuItem.States, ConsoleColor>
            {
                [Model.Menu.MenuItem.States.Focused] = ConsoleColor.Yellow,
                [Model.Menu.MenuItem.States.Normal] = ConsoleColor.Red,
                [Model.Menu.MenuItem.States.Selected] = ConsoleColor.Green
            };
        }

        /// <summary>
        /// Конструктор консольного представления подменю
        /// </summary>
        /// <param name="parSubItem">Подменю</param>
        public ConsoleViewSubMenuItem(Model.Menu.SubMenuItem parSubItem) : base(parSubItem)
        {
            Height = HEIGHT;
            Width = parSubItem.Name.Length + 2;
        }

        /// <summary>
        /// Отрисовывает подменю
        /// </summary>
        public override void Draw()
        {
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            ConsoleColor savColor = Console.ForegroundColor;
            Console.ForegroundColor = ColorByState[Item.State];
            Console.Write(Item.Name);
            Console.ForegroundColor = savColor;
        }
    }
}
