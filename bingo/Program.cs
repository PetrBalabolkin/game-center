using Console = System.Console;

namespace bingo;

class Program
{
    static void Main()
    {
        Console.WriteLine();
        WriteName();
        Thread.Sleep(1000);
        ChooseGame();
    }

    private static void WriteName()
    {
        string[] asciiArt =
        [
            " ██████   █████  ███    ███ ███████       ██████  ███████ ███    ██ ████████ ███████ ██████ ",
            "██       ██   ██ ████  ████ ██           ██    ██ ██      ████   ██    ██    ██      ██   ██",
            "██  ████ ███████ ██ ████ ██ █████        ██       █████   ██ ██  ██    ██    █████   ██████ ",
            "██    ██ ██   ██ ██  ██  ██ ██           ██    ██ ██      ██  ██ ██    ██    ██      ██   ██",
            " ██████  ██   ██ ██      ██ ███████       ██████  ███████ ██   ████    ██    ███████ ██   ██"
        ];

        foreach (string line in asciiArt)
        {
            Console.WriteLine(line);
        }
    }
    
    private static void ChooseGame()
    {
        Console.WriteLine();
        Console.WriteLine("Vyberte rezim hry:");
        Console.WriteLine("1 - Bingo");
        Console.WriteLine("2 - Loteria");
        Console.WriteLine("3 - Piskvorky");
        Console.WriteLine("4 - Sudoku");
        Console.WriteLine();

        int choice = 0;
        do
        {
            try
            {
                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("Vyberte rezim hry od 1 do 4:");
                }
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Zadali ste nespravnu hodnotu");
            }
        } while (choice < 1 || choice > 5);
        
        switch (choice)
        {
            case 1: Bingo.BingoGame(); break;
            case 2: Loteria.LoteriaGame(); break;
            case 3: Piskvorky.PiskvorkyGame(); break;
            case 4: Sudoku.SudokuGame(); break;
            default: Bingo.BingoGame(); break;
        }
    }
}