using Game2048.ViewModel;

namespace Game2048.Model
{
    public class GameBoard : MainVM
    {
        public readonly int boardSize = 4;

        public readonly int winValue = 2048;

        public int[,]? board;

        public int score;

        public int[,]? Board { get => board; set => Set(ref board, value, nameof(Board)); }
        
        public int Score { get => score; set => Set(ref score, value, nameof(Score)); }
    }
}