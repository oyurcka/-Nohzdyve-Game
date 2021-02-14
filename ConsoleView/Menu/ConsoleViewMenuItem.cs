using System;
using System.Collections.Generic;

namespace ConsoleView.Menu
{
    /// <summary>
    /// Класс консольного представления элемента меню
    /// </summary>
    public class ConsoleViewMenuItem : View.Menu.ViewMenuItem
    {
        /// <summary>
        /// Высота
        /// </summary>
        public const int HEIGHT = 1;

        /// <summary>
        /// Коллекция цветов элементов меню по их состоянию
        /// </summary>
        protected static Dictionary<Model.Menu.MenuItem.States, ConsoleColor> ColorByState { get; private set; }

        /// <summary>
        /// Статический конструктор для инициализации коллекции цветов элементов меню
        /// </summary>
        static ConsoleViewMenuItem()
        {
            ColorByState = new Dictionary<Model.Menu.MenuItem.States, ConsoleColor>
            {
                [Model.Menu.MenuItem.States.Focused] = ConsoleColor.Yellow,
                [Model.Menu.MenuItem.States.Normal] = ConsoleColor.Red,
                [Model.Menu.MenuItem.States.Selected] = ConsoleColor.Green
            };
        }

        /// <summary>
        /// Конструктор консольного представления элемента меню
        /// </summary>
        /// <param name="parItem">Элемент меню</param>
        public ConsoleViewMenuItem(Model.Menu.MenuItem parItem) : base(parItem)
        {
            Height = HEIGHT;
            Width = parItem.Name.Length;
        }

        /// <summary>
        /// Отрисовка элемента
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
