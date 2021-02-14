using Model.Game;
using System;
using System.Collections.Generic;
using View;

namespace ConsoleView.Menu
{
    /// <summary>
    /// Класс консолького представления рекордов
    /// </summary>
    public class ConsoleViewRecords : ViewBase
    {

        /// <summary>
        /// Отступ
        /// </summary>
        private const int PADDING = 3;

        /// <summary>
        /// Ширина
        /// </summary>
        public const int WIDTH = 40;

        /// <summary>
        /// Высота
        /// </summary>
        public const int HEIGHT = 10;

        /// <summary>
        /// Список рекордов
        /// </summary>
        private List<Record> _records;

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
        public ConsoleViewRecords(List<Record> parRecordsList)
        {
            _records = parRecordsList;
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
        /// Отрисовка
        /// </summary>
        public override void Draw()
        {
            Console.Clear();
            Console.CursorLeft = X;
            Console.CursorTop = Y;
            Console.Write("╔════════════[   Records   ]═══════════╗");
            int recordId = 1;
            foreach (Record elRecord in _records)
            {
                Console.CursorLeft = X;
                Console.CursorTop++;
                Console.Write($"{recordId,PADDING}. {elRecord.Score,PADDING}");
                recordId++;
            }
            Console.CursorLeft = X;
            Console.CursorTop++;
            Console.Write("╚══════════════════════════════════════╝");
        }
    }
}
