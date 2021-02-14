using Model.Game;
using System.Drawing;
using View.Game;

namespace WindowsView.Game
{
    /// <summary>
    /// Класс представления стен в формах 
    /// </summary>
    public class WindowsViewWalls : ViewWalls
    {
        /// <summary>
        /// Высота стен
        /// </summary>
        private const int WALLS_WIDTH = 5;

        /// <summary>
        /// Отступ
        /// </summary>
        private const int PADDING = 30;

        /// <summary>
        /// Изображение
        /// </summary>
        private Bitmap _picture;

        /// <summary>
        /// Объект для работы с графикой
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parWalls">Объект стен</param>
        /// <param name="parBufferedGraphics">Объект буферизированной графики</param>
        /// <param name="GameHeight">Высота игры</param>
        public WindowsViewWalls(Walls parWalls, BufferedGraphics parBufferedGraphics, int GameHeight) : base(parWalls)
        {
            _bufferedGraphics = parBufferedGraphics;
            GameHeight -= PADDING;
            Bitmap bmp = new Bitmap(WALLS_WIDTH, GameHeight);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, Walls.Width, GameHeight);
                graph.FillRectangle(Brushes.Black, ImageSize);
            }
            _picture = bmp;
        }

        /// <summary>
        /// Выводит объект на экран
        /// </summary>
        public override void Draw()
        {
            _bufferedGraphics.Graphics.DrawImage(_picture, Walls.X, 0);
        }
    }
}
