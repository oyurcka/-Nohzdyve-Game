using Model.Game;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using View;

namespace WindowsView.Menu
{
    /// <summary>
    /// Класс представления рекордов в формах
    /// </summary>
    public class ViewRecordsWindows : ViewBase
    {
        /// <summary>
        /// Отступ
        /// </summary>
        private const int PADDING = 5;

        /// <summary>
        /// Отступ по х
        /// </summary>
        private const int MARGIN_X = 4;

        /// <summary>
        /// Отступ по у
        /// </summary>
        private const int MARGIN_Y = 2;

        /// <summary>
        /// Список рекордов
        /// </summary>
        private List<Record> _records;

        /// <summary>
        /// Форма 
        /// </summary>
        private Form _form = null;

        /// <summary>
        /// Кнопка 
        /// </summary>
        protected Button Button { get; } = null;

        /// <summary>
        /// Текстовое поле
        /// </summary>
        protected TextBox TextBox { get; } = null;

        /// <summary>
        /// Конструктор класса представления рекордов в формах
        /// </summary>
        /// <param name="parRecordsList">Список рекордов</param>
        public ViewRecordsWindows(List<Record> parRecordsList)
        {
            _form = new Form();
            _records = parRecordsList;
            Button = new Button { Text = "Return" };
            Button.Location = new Point(_form.ClientSize.Width / 2 - Button.Width / 2, _form.ClientSize.Height - 2 * Button.Height);
            Button.Click += (s, e) => { _form.Close(); };
            TextBox = new TextBox
            {
                Multiline = true,
                Enabled = false,
            };
            _form.Controls.Add(Button);
            _form.Controls.Add(TextBox);
        }

        /// <summary>
        /// Масштабирование размера текстового поля к его содержимому
        /// </summary>
        /// <param name="parTextBox"></param>
        private void AutoSizeTextBox(TextBox parTextBox)
        {
            Size size = TextRenderer.MeasureText(parTextBox.Text, parTextBox.Font);
            parTextBox.ClientSize = new Size(size.Width + MARGIN_X, size.Height + MARGIN_Y);
        }

        /// <summary>
        /// Отобразить рекорды
        /// </summary>
        public override void Draw()
        {
            int recordId = 1;
            foreach (Record elRecord in _records)
            {
                TextBox.AppendText(Environment.NewLine + $"{recordId,PADDING}. {elRecord.Score,PADDING}");
            }
            TextBox.AppendText(Environment.NewLine);
            AutoSizeTextBox(TextBox);
            TextBox.Location = new Point(_form.ClientSize.Width / 2 - TextBox.Width / 2, PADDING);
            _form.Show();
        }
    }
}
