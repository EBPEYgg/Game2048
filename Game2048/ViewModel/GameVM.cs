using Game2048.ViewModel;
using Game2048.Model;
using System;
using System.Windows;

namespace Game2048.ViewModel
{
    public class GameVM : MainVM
    {
        private GameBoard gameBoard;

        private Random random;

        /// <summary>
        /// Возвращает доску в игре.
        /// </summary>
        public int[,] Board
        {
            get => gameBoard.board;
            private set => Set(ref gameBoard.board, value, nameof(Board));
        }

        /// <summary>
        /// Возвращает очки в игре.
        /// </summary>
        public int Score
        { 
            get => gameBoard.score; 
            private set => Set(ref gameBoard.score, value, nameof(Score));
        }

        /// <summary>
        /// Команда, которая возвращает игрока в меню игры.
        /// </summary>
        public NavigationCommand NavigateToMenuPage
        {
            get => new(NavigateToPage, new Uri("View/Pages/MenuPage.xaml", UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Команда, которая отвечает за сдвиг влево.
        /// </summary>
        public RelayCommand ShiftLeftCommand
        {
            get => new(ShiftLeft);
        }

        /// <summary>
        /// Команда, которая отвечает за сдвиг вверх.
        /// </summary>
        public RelayCommand ShiftUpCommand
        {
            get => new(ShiftUp);
        }

        /// <summary>
        /// Команда, которая отвечает за сдвиг вправо.
        /// </summary>
        public RelayCommand ShiftRightCommand
        {
            get => new(ShiftRight);
        }

        /// <summary>
        /// Команда, которая отвечает за сдвиг вниз.
        /// </summary>
        public RelayCommand ShiftBottomCommand
        {
            get => new(ShiftBottom);
        }

        /// <summary>
        /// Команда, которая сбрасывает доску игры.
        /// </summary>
        public RelayCommand ResetCommand
        {
            get => new(Reset);
        }

        /// <summary>
        /// Конструктор класса <see cref="GameVM"/>.
        /// </summary>
        public GameVM()
        {
            gameBoard = new GameBoard();
            random = new Random();

            Reset();
        }

        /// <summary>
        /// Метод, который проверяет, выиграл ли игрок.
        /// </summary>
        /// <returns>True, если выиграл, иначе false.</returns>
        public bool IsPlayerWin()
        {
            for (int row = 0; row < gameBoard.boardSize; row++)
            {
                for (int column = 0; column < gameBoard.boardSize; column++)
                {
                    if (gameBoard.board[row, column] == gameBoard.winValue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Метод, который проверяет, проиграл ли игрок.
        /// </summary>
        /// <returns>True, если проиграл, иначе false.</returns>
        public bool IsPlayerLosing()
        {
            for (int row = 0; row < gameBoard.boardSize; row++)
            {
                for (int column = 0; column < gameBoard.boardSize; column++)
                {
                    if (gameBoard.board[row, column] == 0)
                    {
                        return false;
                    }
                }
            }

            for (int row = 0; row < gameBoard.boardSize; row++)
            {
                for (int column = 0; column < gameBoard.boardSize; column++)
                {
                    int value = gameBoard.board[row, column];

                    if (row > 0 && gameBoard.board[row - 1, column] == value)
                    {
                        return false;
                    }

                    if (row < gameBoard.boardSize - 1 && gameBoard.board[row + 1, column] == value)
                    {
                        return false;
                    }

                    if (column > 0 && gameBoard.board[row, column - 1] == value)
                    {
                        return false;
                    }

                    if (column < gameBoard.boardSize - 1 && gameBoard.board[row, column + 1] == value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Метод, который сбрасывает доску и очки в игре.
        /// </summary>
        private void Reset()
        {
            Board = new int[gameBoard.boardSize, gameBoard.boardSize];
            Score = 0;
            GenerateRandomNumber();
            GenerateRandomNumber();
            Update();
        }

        private void GenerateRandomNumber()
        {
            int row, col;

            do
            {
                row = random.Next(gameBoard.boardSize);
                col = random.Next(gameBoard.boardSize);
            }
            while (gameBoard.board[row, col] != 0);

            gameBoard.board[row, col] = random.Next(100) < 90 ? 2 : 4;
        }

        /// <summary>
        /// Метод, который обновляет доску и очки в игре.
        /// </summary>
        private void Update()
        {
            Board = gameBoard.Board;
            Score = gameBoard.Score;
        }

        public void ShiftLeft()
        {
            bool shifted = false;
            for (int i = 0; i < gameBoard.board.GetLength(0); i++)
            {
                int index = 0;
                for (int j = 0; j < gameBoard.board.GetLength(1); j++)
                {
                    if (gameBoard.board[i, j] != 0)
                    {
                        if (index > 0 && gameBoard.board[i, index - 1] == gameBoard.board[i, j])
                        {
                            gameBoard.board[i, index - 1] *= 2;
                            gameBoard.board[i, j] = 0;
                            shifted = true;
                            gameBoard.score += gameBoard.board[i, index - 1];
                        }

                        else
                        {
                            if (j != index)
                            {
                                gameBoard.board[i, index] = gameBoard.board[i, j];
                                gameBoard.board[i, j] = 0;
                                shifted = true;
                            }
                            index++;
                        }
                    }
                }
            }

            if (shifted)
            {
                GenerateRandomNumber();
                CheckGameState();
            }
        }

        public void ShiftUp()
        {
            bool shifted = false;
            for (int j = 0; j < gameBoard.board.GetLength(1); j++)
            {
                int index = 0;  
                for (int i = 0; i < gameBoard.board.GetLength(0); i++)
                {
                    if (gameBoard.board[i, j] != 0)
                    {
                        if (index > 0 && gameBoard.board[index - 1, j] == gameBoard.board[i, j])
                        {
                            gameBoard.board[index - 1, j] *= 2;
                            gameBoard.board[i, j] = 0;
                            shifted = true;
                            gameBoard.score += gameBoard.board[index - 1, j];
                        }

                        else
                        {
                            if (i != index)
                            {
                                gameBoard.board[index, j] = gameBoard.board[i, j];
                                gameBoard.board[i, j] = 0;
                                shifted = true;
                            }
                            index++;
                        }
                    }
                }
            }

            if (shifted)
            {
                GenerateRandomNumber();
                CheckGameState();
            }
        }

        public void ShiftRight()
        {
            bool shifted = false;
            for (int i = 0; i < gameBoard.board.GetLength(0); i++)
            {
                int index = 0;
                for (int j = gameBoard.board.GetLength(1) - 1; j >= 0; j--)
                {
                    if (gameBoard.board[i, j] != 0)
                    {
                        if (index < gameBoard.board.GetLength(1) - 1 && 
                            gameBoard.board[i, index + 1] == gameBoard.board[i, j])
                        {
                            gameBoard.board[i, index + 1] *= 2;
                            gameBoard.board[i, j] = 0;
                            shifted = true;
                            gameBoard.score += gameBoard.board[i, index + 1];
                        }

                        else
                        {
                            if (j != index)
                            {
                                gameBoard.board[i, index] = gameBoard.board[i, j];
                                gameBoard.board[i, j] = 0;
                                shifted = true;
                            }
                            index--;
                        }
                    }
                }
            }

            if (shifted)
            {
                GenerateRandomNumber();
                CheckGameState();
            }
        }

        public void ShiftBottom()
        {
            bool shifted = false;
            for (int j = 0; j < gameBoard.board.GetLength(1); j++)
            {
                int index = gameBoard.board.GetLength(0) - 1;
                for (int i = gameBoard.board.GetLength(0) - 1; i >= 0; i--)
                {
                    if (gameBoard.board[i, j] != 0)
                    {
                        if (index < gameBoard.board.GetLength(0) - 1 && 
                            gameBoard.board[index + 1, j] == gameBoard.board[i, j])
                        {
                            gameBoard.board[index + 1, j] *= 2;
                            gameBoard.board[i, j] = 0;
                            shifted = true;
                            gameBoard.score += gameBoard.board[index + 1, j];
                        }

                        else
                        {
                            if (i != index)
                            {
                                gameBoard.board[index, j] = gameBoard.board[i, j];
                                gameBoard.board[i, j] = 0;
                                shifted = true;
                            }
                            index--;
                        }
                    }
                }
            }

            if (shifted)
            {
                GenerateRandomNumber();
                CheckGameState();
            }
        }

        private void CheckGameState()
        {
            Update();
            if (IsPlayerLosing())
            {
                MessageBoxResult result = MessageBox.Show("Вы проиграли :(", "Конец");
                Reset();
            }

            else if (IsPlayerWin())
            {
                MessageBoxResult result = MessageBox.Show("Вы выиграли!", "Конец");
                AddToStatistics();
                Reset();
            }
        }

        private void AddToStatistics()
        {
            string name;

            do
            {
                name = Microsoft.VisualBasic.Interaction.InputBox
                    ("Введите ваше имя: ", "Ввод имени", "");
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show(
                        "Имя не может быть пустым. ", 
                        "Ошибка ввода", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
            }
            while (string.IsNullOrEmpty(name));

            //Statistics.Add(name, Score.ToString());
        }
    }
}