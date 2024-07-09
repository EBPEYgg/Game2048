using Game2048.ViewModel;

namespace Game2048.Model
{
    public class GameBoard : MainVM
    {
        /// <summary>
        /// Размер доски.
        /// </summary>
        public readonly int BoardSize = 4;

        /// <summary>
        /// Количество очков для выигрыша.
        /// </summary>
        public readonly int WinValue = 2048;

        /// <summary>
        /// Значения ячеек на доске.
        /// </summary>
        public int[,]? board;

        /// <summary>
        /// Счет.
        /// </summary>
        public int score;

        /// <summary>
        /// Возвращает и задает значения ячеек на доске.
        /// </summary>
        public int[,]? Board { get => board; set => Set(ref board, value); }
        
        /// <summary>
        /// Возвращает и задает счет.
        /// </summary>
        public int Score { get => score; set => Set(ref score, value); }
    }
}