using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Game2048.Model.Services
{
    /// <summary>
    /// Класс, описывающий сериализацию и десериализацию данных.
    /// </summary>
    public class StatisticsSerializer
    {
        /// <summary>
        /// Путь к файлу по умолчанию.
        /// </summary>
        private static readonly string _filePath = Path.Combine(Environment.GetFolderPath
            (Environment.SpecialFolder.MyDocuments), "Game2048", "Statistics.json");

        /// <summary>
        /// Метод для сохранения объекта игрока в файл.
        /// </summary>
        /// <param name="player">Экземпляр класса <see cref="Player"/>.</param>
        public static void SavePlayer(ObservableCollection<Player> player)
        {
            if (!Directory.Exists(_filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
            }

            var json = JsonConvert.SerializeObject(player);
            File.WriteAllText(_filePath, json);
        }

        /// <summary>
        /// Метод для загрузки объекта игрока из файла.
        /// </summary>
        /// <returns>Экземпляр класса <see cref="Player"/>.</returns>
        public static ObservableCollection<Player> LoadPlayer()
        {
            if (!File.Exists(_filePath))
            {
                return new ObservableCollection<Player>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<ObservableCollection<Player>>(json);
        }
    }
}