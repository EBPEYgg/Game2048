namespace Game2048.Model
{
    /// <summary>
    /// Класс, описывающий игрока.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество очков игрока.
        /// </summary>
        public string Score { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Player"/>.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="score">Количество очков.</param>
        public Player(string name, string score)
        {
            Name = name;
            Score = score;
        }
    }
}