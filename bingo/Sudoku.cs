namespace bingo;

public class Sudoku
{
    private static void WriteSudoku()
    {
        string[] sudokuAscii =
        {
            "███████ ██    ██ ███████   ██████  ██   ██ ██    ██ ",
            "██      ██    ██ ██    ██ ██    ██ ██  ██  ██    ██ ",
            "███████ ██    ██ ██    ██ ██    ██ █████   ██    ██ ",
            "     ██ ██    ██ ██    ██ ██    ██ ██ ██   ██    ██ ",
            "███████  ██████  ███████   ██████  ██   ██  ██████  ",
        };
        
        foreach (string line in sudokuAscii)
        {
            Console.WriteLine(line);
        }
    }
    
    private static int[,] Create()
    {
        int[,] card = new int[9, 9];
        for (int i = 0; i < card.GetLength(0); i++)
        {
            for (int j = 0; j < card.GetLength(1); j++)
            {
                card[i, j] = 0;
            }
        }
        
        return card;
    }
    
    private static void Print(int[,] card)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < card.GetLength(1); i++)
        {
            Console.Write(" ____");
        }
        Console.ResetColor();

        Console.WriteLine();

        for (int i = 0; i < card.GetLength(0); i++)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("|");
            Console.ResetColor();
            for (int j = 0; j < card.GetLength(1); j++)
            {
                if (card[i, j] < 10)
                {
                    Console.Write(" ");
                }
                
                if (card[i, j] == 0)
                {
                    if ((j + 1) % 3 == 0 )
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write("   |");
                    Console.ResetColor();
                    continue;
                }
                
                Console.Write(" ");
                /* if (numbers.Contains(card[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                } */
                Console.Write(card[i, j]);
                
                Console.ResetColor();
                
                if ((j + 1) % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(" |");
                Console.ResetColor();
            }

            if (card.GetLength(0) % card.GetLength(0) == 0)
            {
                Console.WriteLine();
            }

            for (int j = 0; j < card.GetLength(1); j++)
            {
                if ((i + 1) % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(" ----");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }

    // TODO... debug fillovania
    private static void FillCard(int[,] card)
    {
        Random random = new Random();

        for (int i = 0; i < card.GetLength(0); i++)
        {
            for (int j = 0; j < card.GetLength(1); j++)
            {
                int fillNum = 0;
                do
                {
                    fillNum = random.Next(1, 10);
                } while (ContainsRow(card, i, fillNum) || ContainsCol(card, j, fillNum) || ContainsSquare(card, fillNum, i, j));

                card[i, j] = fillNum;
            }
        }
    }
    
    private static void FillUserCard(int[,] card, int[,] filledCard)
    {
        Random random = new Random();
        int complexity = -1;
        do
        {
            try
            {
                if (complexity < 0 || complexity > 10)
                {
                    Console.WriteLine("Zadajte mieru zlozitosti: " +
                                      "\n(1 - najlahsie, 10 - najtazsie)");
                }
                complexity = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Zadali ste neplatne udaje: ");
            }
        } while (complexity < 0 || complexity > 10);

        for (int i = 0; i < card.GetLength(0); i++)
        {
            for (int j = 0; j < card.GetLength(1); j++)
            {
                int rndNum = random.Next(0, 12 - complexity);
                if (rndNum == 1 || rndNum == 2 || rndNum == 3)
                {
                    continue;
                }

                card[i, j] = filledCard[i, j];
            }
        }
    }

    private static bool ContainsRow(int[,] card, int row, int num)
    {
        for (int i = 0; i < card.GetLength(1); i++)
        {
            if (card[row, i] == num)
            {
                return true;
            }
        }
        return false;
    }
    
    private static bool ContainsCol(int[,] card, int col, int num)
    {
        for (int i = 0; i < card.GetLength(0); i++)
        {
            if (card[i, col] == num)
            {
                return true;
            }
        }
        return false;
    }

    private static bool ContainsSquare(int[,] card, int num, int row, int col)
    {
        if (row == 1 || row == 4 || row == 7)
        {
            row -= 1;
        } else if (row == 2 || row == 5 || row == 8)
        {
            row -= 2;
        }
        
        if (col == 1 || col == 4 || col == 7)
        {
            col -= 1;
        } else if (col == 2 || col == 5 || col == 8)
        {
            col -= 2;
        }
        
        for (int i = row; i < (row + 3); i++)
        {
            for (int j = col; j < (col + 3); j++)
            {
                if (card[i, j] == num)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private static void SudokuMechanics()
    {
        int[,] card = Create();
        int[,] filledCard = Create();
        Print(card);
        //FillCard(filledCard);
        SolveSudoku(filledCard);
        FillUserCard(card, filledCard);
        Print(card);
    }

    public static void SudokuGame()
    {
        WriteSudoku();
        SudokuMechanics();
    }
    
    // ChatGPT code
    private static bool SolveSudoku(int[,] board)
    {
        // Ищем первую пустую ячейку (обозначенную 0)
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (board[row, col] == 0)
                {
                    // Создаем список чисел от 1 до 9 и перемешиваем его для случайности
                    List<int> numbers = Enumerable.Range(1, 9).ToList();
                    numbers = numbers.OrderBy(x => Guid.NewGuid()).ToList();

                    foreach (int num in numbers)
                    {
                        if (IsValid(board, row, col, num))
                        {
                            board[row, col] = num;

                            if (SolveSudoku(board))
                                return true;

                            // Откат: сбрасываем значение ячейки, если дальнейшее заполнение не удалось
                            board[row, col] = 0;
                        }
                    }
                    // Если ни одно число не подошло, возвращаем false для отката
                    return false;
                }
            }
        }
        // Если пустых ячеек нет, судоку заполнено корректно
        return true;
    }

    private static bool IsValid(int[,] board, int row, int col, int num)
    {
        // Проверяем строку
        for (int j = 0; j < board.GetLength(1); j++)
        {
            if (board[row, j] == num)
                return false;
        }

        // Проверяем столбец
        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (board[i, col] == num)
                return false;
        }

        // Определяем границы 3x3 квадрата
        int startRow = row - row % 3;
        int startCol = col - col % 3;

        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                if (board[i, j] == num)
                    return false;
            }
        }
        return true;
    }
}