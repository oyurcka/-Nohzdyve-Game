using System.Collections.Generic;
using Model.Game;

namespace Model.Menu
{
    /// <summary>
    /// Класс для меню с рекордами
    /// </summary>
    public class Records
    {
        public List<Record> RecordsList { get; set; }

        /// <summary>
        /// Конструктор класса, заполняет меню рекордами
        /// </summary>
        public Records()
        {
            RecordsList = ScoreRecorder.GetRecords();
        }
    }
}

