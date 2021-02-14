namespace Model.Game
{
    /// <summary>
    /// Структура для хранения информации об игровой сессии
    /// </summary>
    public struct Record
    {
        /// <summary>
        /// Счёт игры
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Конструктор, заполняющий структуру 
        /// </summary>
        /// <param name="parScore">Счёт игры</param>
        public Record(int parScore)
        {
            Score = parScore;
        }
    }
}
