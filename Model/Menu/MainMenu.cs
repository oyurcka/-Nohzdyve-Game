namespace Model.Menu
{
    /// <summary>
    /// Класс, представляющий главное меню
    /// </summary>
    public class MainMenu : Menu
    {
        /// <summary>
        /// Перечисление элементов главного меню
        /// </summary>
        public enum MenuItemId : int
        {
            /// <summary>
            /// Новая игра
            /// </summary>
            NewGame,

            /// <summary>
            /// Рекорды
            /// </summary>
            Records,

            /// <summary>
            /// Об игре
            /// </summary>
            About,

            /// <summary>
            /// Выход
            /// </summary>
            Exit
        }

        /// <summary>
        /// Конструктор главного меню, заполняет меню элементами
        /// </summary>
        public MainMenu() : base("Nohzdyve")
        {
            AddItem(new MenuItem((int)MenuItemId.NewGame, "Новая игра") { State = States.Focused });
            AddItem(new MenuItem((int)MenuItemId.Records, "Рекорды"));
            AddItem(new MenuItem((int)MenuItemId.About, "Об игре"));
            AddItem(new MenuItem((int)MenuItemId.Exit, "Выход"));
            FocusedItemIndex = 0;
        }
    }
}
