using Model.Menu;
using System;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace WindowsView.Menu
{
    /// <summary>
    /// Класс представления информации об игре в формах
    /// </summary>
    public class WindowsViewAbout : ViewBase
    {
        /// <summary>
        /// Форма с информацией об игре
        /// </summary>
        private Form _form = null;

        /// <summary>
        /// Надпись
        /// </summary>
        private Label _label = null;

        /// <summary>
        /// Кнопка 
        /// </summary>
        private Button Button { get; } = null;

        /// <summary>
        /// Конструктор класса представления информации о игре в формах
        /// </summary>
        public WindowsViewAbout()
        {
            _form = new Form();
            String text = About.AboutText;
            _label = new Label { Location = new Point(13, 13), AutoSize = true, Text = text, BackColor = Color.White };
            Button = new Button { Text = "Exit" };
            Button.Location = new Point(_form.ClientSize.Width / 2 - Button.Width / 2, _form.ClientSize.Height - 2 * Button.Height);
            Button.Click += (s, e) => { _form.Close(); };
            _form.Controls.Add(Button);
            _form.Controls.Add(_label);
        }

        /// <summary>
        /// Отобразить информацию на форме
        /// </summary>
        public override void Draw()
        {
            _form.Show();
        }
    }
}
