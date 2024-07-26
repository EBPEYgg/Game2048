using CommunityToolkit.Mvvm.ComponentModel;

namespace Game2048.Model
{
    public partial class GameBoard : ObservableObject
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
        [ObservableProperty]
        public int[,]? board;

        /// <summary>
        /// Счет.
        /// </summary>
        [ObservableProperty]
        public int score;
    }
}