using System.Collections.Generic;

using Newtonsoft.Json;
using System.IO;
using Model.Game;

namespace Model.Menu
{
    /// <summary>
    /// Статический класс для записи и чтения рекордов с помощью JSON файла
    /// </summary>
    public static class ScoreRecorder
    {
        /// <summary>
        /// Путь к файлу с рекордами
        /// </summary>
        private static readonly string _path = Path.Combine(Directory.GetCurrentDirectory(), "records.json");

        /// <summary>
        /// Блокировочный объект для потоков
        /// </summary>
        private static object _locker = new object();

        /// <summary>
        /// Статический конструктор, создающий файл в случае его отстутствия, и инициализирующий его начальными значениями
        /// </summary>
        static ScoreRecorder()
        {
            if (!File.Exists(_path))
            {
                StreamWriter file = File.CreateText(_path);
                file.Close();

                string jsonListOfRecords = File.ReadAllText(_path);
                if (jsonListOfRecords == "")
                {
                    jsonListOfRecords = "[]";
                    File.WriteAllText(_path, jsonListOfRecords);
                }
            }
        }

        /// <summary>
        /// Добавляет новый рекорд в файл, сортирует по количеству очков
        /// </summary>
        /// <param name="parRecord">Рекорд</param>
        public static void AddRecord(Record parRecord)
        {
            List<Record> records = GetRecords();

            records.Add(parRecord);

            records.Sort((rec1, rec2) => (rec2.Score - rec1.Score));

            if (records.Count == 11)
            {
                records.RemoveAt(records.Count - 1);
            }

            string jsonRecords = JsonConvert.SerializeObject(records.ToArray());
            lock (_locker)
            {
                File.WriteAllText(_path, jsonRecords);
            }
        }

        /// <summary>
        /// Получает список структур рекордов
        /// </summary>
        /// <returns>Список рекордов</returns>
        public static List<Record> GetRecords()
        {
            string jsonListOfRecords = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<List<Record>>(jsonListOfRecords);
        }
    }
}


