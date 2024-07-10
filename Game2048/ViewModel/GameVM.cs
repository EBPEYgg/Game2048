using Game2048.Model;
using Microsoft.VisualBasic;
using System;
using System.Windows;

namespace Game2048.ViewModel
{
    public class GameVM : MainVM
    {
        /// <summary>
        /// Инициализация игровой доски.
        /// </summary>
        private GameBoard gameBoard;

        /// <summary>
        /// Инициализация генератора чисел.
        /// </summary>
        private Random random;

        /// <summary>
        /// Возвращает значения доски.
        /// </summary>
        public int[,] Board
        {
            get => gameBoard.board;
            private set => Set(ref gameBoard.board, value);
        }

        /// <summary>
        /// Возвращает счет игры.
        /// </summary>
        public int Score
        { 
            get => gameBoard.score; 
            private set => Set(ref gameBoard.score, value);
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
            for (int row = 0; row < gameBoard.BoardSize; row++)
            {
                for (int column = 0; column < gameBoard.BoardSize; column++)
                {
                    if (gameBoard.board[row, column] == gameBoard.WinValue)
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
            for (int row = 0; row < gameBoard.BoardSize; row++)
            {
                for (int column = 0; column < gameBoard.BoardSize; column++)
                {
                    if (gameBoard.board[row, column] == 0)
                    {
                        return false;
                    }
                }
            }

            for (int row = 0; row < gameBoard.BoardSize; row++)
            {
                for (int column = 0; column < gameBoard.BoardSize; column++)
                {
                    int value = gameBoard.board[row, column];

                    if (row > 0 && gameBoard.board[row - 1, column] == value)
                    {
                        return false;
                    }

                    if (row < gameBoard.BoardSize - 1 && gameBoard.board[row + 1, column] == value)
                    {
                        return false;
                    }

                    if (column > 0 && gameBoard.board[row, column - 1] == value)
                    {
                        return false;
                    }

                    if (column < gameBoard.BoardSize - 1 && gameBoard.board[row, column + 1] == value)
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
            Board = new int[gameBoard.BoardSize, gameBoard.BoardSize];
            Score = 0;
            GenerateRandomNumber();
            GenerateRandomNumber();
            Update();
        }

        /// <summary>
        /// Метод, который генерирует ячейку на доске.
        /// </summary>
        private void GenerateRandomNumber()
        {
            int row, col;

            do
            {
                row = random.Next(gameBoard.BoardSize);
                col = random.Next(gameBoard.BoardSize);
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

        /// <summary>
        /// Метод, отвечающий за сдвиг влево.
        /// </summary>
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

        /// <summary>
        /// Метод, отвечающий за сдвиг вверх.
        /// </summary>
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

        /// <summary>
        /// Метод, отвечающий за сдвиг вправо.
        /// </summary>
        public void ShiftRight()
        {
            bool shifted = false;
            for (int i = 0; i < gameBoard.board.GetLength(0); i++)
            {
                int index = gameBoard.board.GetLength(1) - 1;
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

        /// <summary>
        /// Метод, отвечающий за сдвиг вниз.
        /// </summary>
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

        /// <summary>
        /// Метод, который проверяет состояние игры.
        /// </summary>
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

        /// <summary>
        /// Метод, который добавляет результат пользователя в таблицу лидеров.
        /// </summary>
        private void AddToStatistics()
        {
            string name;

            name = Interaction.InputBox
                ("Чтобы занести себя в статистику,\nвведите ваше имя: ", "Ввод имени", "");
            if (!string.IsNullOrEmpty(name))
            {
                Statistics.Add(name, Score.ToString());
            }
        }
    }
}