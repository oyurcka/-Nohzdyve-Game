using Model.Game;
using System.Drawing;
using View.Game;

namespace WindowsView.Game
{
    /// <summary>
    /// Представление объектов игры в формах
    /// </summary>
    public class ViewGameObjectWindows : ViewGameObject
    {
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
        /// <param name="parGameObject">Игровой объект</param>
        /// <param name="parBufferedGraphics">Объект буферезированной графики</param>
        public ViewGameObjectWindows(GameObject parGameObject, BufferedGraphics parBufferedGraphics) : base(parGameObject)
        {
            _bufferedGraphics = parBufferedGraphics;
            SetImage();
        }

        /// <summary>
        /// Задать картинку
        /// </summary>
        private void SetImage()
        {
            if (GameObject is Man)
            {
                _picture = Properties.Resources.man;
                _picture = new Bitmap(_picture, new Size(20, 20));
            }
            else if (GameObject is Obstacle)
            {
                _picture = Properties.Resources.eye;
                _picture = new Bitmap(_picture, new Size(40, 20));
            }
        }

        /// <summary>
        /// Выводит объект на экран
        /// </summary>
        public override void Draw()
        {
            _bufferedGraphics.Graphics.DrawImage(_picture, GameObject.X, GameObject.Y);
        }
    }
}
