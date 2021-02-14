using Model.Menu;
using System;
using View;

namespace ConsoleView.Menu
{
    /// <summary>
    /// Класс консолького представления информации об игре
    /// </summary>
    public class ConsoleViewAbout : ViewBase
    {
        /// <summary>
        /// Ширина
        /// </summary>
        public const int WIDTH = 50;

        /// <summary>
        /// Высота
        /// </summary>
        public const int HEIGHT = 7;

        /// <summary>
        /// Координата X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ConsoleViewAbout()
        {
            Init();
            Draw();
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        public void Init()
        {
            X = Console.BufferWidth / 2 - WIDTH / 2;
            Y = Console.BufferHeight / 2 - HEIGHT / 2;
        }

        /// <summary>
        /// Отрисовка информации об игре
        /// </summary>
        public override void Draw()
        {
            String text = About.AboutText;

            Console.Clear();
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            Console.Write("╔══════════════════[   About   ]═════════════════╗");
            Console.CursorLeft = X;
            Console.CursorTop++;
            Console.Write("  " + text);
            Console.CursorLeft = X;
            Console.CursorTop++;
            Console.Write("╚════════════════════════════════════════════════╝");
        }
    }
}
