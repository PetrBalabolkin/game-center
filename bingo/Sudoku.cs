namespace bingo;

public class Sudoku
{
    private static void WriteSudoku()
    {
        string[] sudokuAscii =
        [
            "███████ ██    ██ ███████   ██████  ██   ██ ██    ██ ",
            "██      ██    ██ ██    ██ ██    ██ ██  ██  ██    ██ ",
            "███████ ██    ██ ██    ██ ██    ██ █████   ██    ██ ",
            "     ██ ██    ██ ██    ██ ██    ██ ██ ██   ██    ██ ",
            "███████  ██████  ███████   ██████  ██   ██  ██████  "
        ];
        
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
    
    private static bool IsValid(int[,] board, int row, int col, int num)
    {
        for (int j = 0; j < board.GetLength(1); j++)
        {
            if (board[row, j] == num)
                return false;
        }
        
        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (board[i, col] == num)
                return false;
        }
        
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
    
    private static bool FillCard(int[,] card)
    {
        for (int row = 0; row < card.GetLength(0); row++)
        {
            for (int col = 0; col < card.GetLength(1); col++)
            {
                if (card[row, col] == 0)
                {
                    List<int> nums = Enumerable.Range(1, 9).ToList();
                    nums = nums.OrderBy(_ => Guid.NewGuid()).ToList();

                    foreach (int num in nums)
                    {
                        if (IsValid(card, row, col, num))
                        {
                            card[row, col] = num;
                            
                            if (FillCard(card))
                            {
                                return true;
                            }
                        
                            card[row, col] = 0;
                        }
                    }
                    return false;
                }
            }
        }
        return true;
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

    private static void SudokuMechanics()
    {
        int[,] card = Create();
        int[,] filledCard = Create();
        Print(card);
        FillCard(filledCard);
        // SolveSudoku(filledCard);
        FillUserCard(card, filledCard);
        Print(card);
    }

    public static void SudokuGame()
    {
        WriteSudoku();
        SudokuMechanics();
    }
}