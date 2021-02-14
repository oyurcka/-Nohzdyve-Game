namespace Model.Menu
{
    /// <summary>
    /// Класс элемента меню
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Делегат, вызываемый при выборе элемента
        /// </summary>
        public delegate void dSelected();

        /// <summary>
        /// Событие при выбора элемента
        /// </summary>
        public event dSelected Selected = null;

        /// <summary>
        /// Перечисление возможных состояний элемента
        /// </summary>
        public enum States : int
        {
            /// <summary>
            /// Нормальное
            /// </summary>
            Normal,

            /// <summary>
            /// Выделенное
            /// </summary>
            Focused,

            /// <summary>
            /// Выбранное
            /// </summary>
            Selected
        }

        /// <summary>
        /// Текущее состояние элемента
        /// </summary>
        private States _state = States.Normal;

        /// <summary>
        /// Название элемента
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Свойство для задания и получения текущего состояния элемента
        /// </summary>
        public States State
        {
            get { return _state; }
            set
            {
                _state = value;
                if (_state == States.Selected)
                {
                    Selected?.Invoke();
                }
            }
        }

        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Конструктор класса, задаёт идентификатор и название элемента
        /// </summary>
        /// <param name="parId">Идентификатор элемента</param>
        /// <param name="parName">Название элемента</param>
        public MenuItem(int parId, string parName)
        {
            Id = parId;
            State = States.Normal;
            Name = parName;
        }
    }
}
