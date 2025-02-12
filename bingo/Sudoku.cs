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
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < card.GetLength(1); i++)
        {
            Console.Write(" ____");
        }
        Console.ResetColor();

        Console.WriteLine();

        for (int i = 0; i < card.GetLength(0); i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
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
                    Console.Write("   |");
                    continue;
                }
                
                Console.Write(" ");
                /* if (numbers.Contains(card[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                } */
                Console.Write(card[i, j]);
                
                Console.ResetColor();

                //TODO...
                if ((j + 1) % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
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
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write(" ----");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }

    private static void SudokuMechanics()
    {
        int[,] card = Create();
        Print(card);
    }

    public static void SudokuGame()
    {
        WriteSudoku();
        SudokuMechanics();
    }
}