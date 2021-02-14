using Model.Game;
using System;
using System.Drawing;
using View.Game;
using System.Windows.Forms;

namespace WindowsView.Game
{
    /// <summary>
    /// Класс представления игры в формах 
    /// </summary>
    public class WindowsViewGame : ViewGame
    {
        /// <summary>
        /// Рамзер одной игровой точки
        /// </summary>
        private const int COEFFICIENT = 10;

        /// <summary>
        /// Форма игры
        /// </summary>
        private Form _form = null;

        /// <summary>
        /// Объект двойной буферизации
        /// </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary>
        /// Объект для рисования на иображении
        /// </summary>
        public Graphics _graphics = null;

        /// <summary>
        /// Надпись
        /// </summary>
        private Label _label;

        /// <summary>
        /// Делегат для отслеживания нажатия клавиши
        /// </summary>
        /// <param name="parE">Нажатая клавиша</param>
        public delegate void DKeyDown(KeyEventArgs parE);

        /// <summary>
        /// Событие нажатия клавиши
        /// </summary>
        public event DKeyDown KeyDown;

        /// <summary>
        /// Конструктор класса представления игры в формах
        /// </summary>
        /// <param name="parModel">Экземпляр игры</param>
        public WindowsViewGame(Model.Game.Game parModel) : base(parModel)
        {
        }

        /// <summary>
        /// Инициализация свойств представления и формы
        /// </summary>
        protected override void Init()
        {
            _form = new Form();
            _form.Size = new Size(GameWidth * COEFFICIENT, GameHeight * COEFFICIENT);
            _form.ControlBox = false;
            _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_form.CreateGraphics(), _form.ClientRectangle);
            _form.KeyDown += _form_KeyDown;
            _form.FormClosing += _form_Closing;
            _label = new Label { Location = new Point(13, 13), AutoSize = true, Text = "Score", BackColor = Color.White };
            _form.Controls.Add(_label);
            _form.Show();
        }

        /// <summary>
        ///  Обработчик события закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ModelGame.Stop();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _form_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(e);
        }

        /// <summary>
        /// Определяет и задает сообщение для отображения на форме
        /// </summary>
        private void SetInfoMessage()
        {
            String result;
            if (ModelGame.GameOver)
            {
                result = "Game over";
            }
            else
            {
                result = $"Score: {ModelGame.Score}";
            }
            _label.BeginInvoke((MethodInvoker)(() => this._label.Text = result));
        }

        /// <summary>
        /// Отображает содержимое игры на форме
        /// </summary>
        public override void Draw()
        {
            lock (Locker)
            {
                SetInfoMessage();
                _bufferedGraphics.Graphics.Clear(Color.White);
                foreach (ViewGameObject elGameObjectView in ViewGameObjects)
                {
                    elGameObjectView.Draw();
                }
                ViewLeftWalls.Draw();
                ViewRightWalls.Draw();
                _bufferedGraphics.Render();
                System.Threading.Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Закрывает форму
        /// </summary>
        public override void Close()
        {
            _form.Close();
        }

        /// <summary>
        /// Перерисовывает содержимое игры
        /// </summary>
        public override void NeedRedraw()
        {
            Draw();
        }

        /// <summary>
        /// Создать представление игрового объекта
        /// </summary>
        /// <param name="parGameObject">Игровой объект</param>
        /// <returns>Представление игрового объекта</returns>
        protected override ViewGameObject CreateItem(GameObject parGameObject)
        {
            return new ViewGameObjectWindows(parGameObject, _bufferedGraphics);
        }

        /// <summary>
        /// Создание представления стен
        /// </summary>
        /// <param name="parWalls">Объект стен</param>
        /// <returns>Представление объекта стен</returns>
        public override ViewWalls CreateWallsView(Walls parWalls)
        {
            return new WindowsViewWalls(parWalls, _bufferedGraphics, GameHeight * COEFFICIENT);
        }
    }
}
