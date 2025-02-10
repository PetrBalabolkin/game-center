using static bingo.Bingo;
using static bingo.Loteria;
using Console = System.Console;

namespace bingo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        WriteName();
        ChooseGame();
    }

    static void WriteName()
    {
        string[] asciiArt = new string[]
        {
            " ██████   █████  ███    ███ ███████       ██████  ███████ ███    ██ ████████ ███████ ██████  ",
            "██       ██   ██ ████  ████ ██           ██    ██ ██      ████   ██    ██    ██      ██   ██ ",
            "██  ████ ███████ ██ ████ ██ █████        ██       █████   ██ ██  ██    ██    █████   ██████  ",
            "██    ██ ██   ██ ██  ██  ██ ██           ██    ██ ██      ██  ██ ██    ██    ██      ██   ██ ",
            " ██████  ██   ██ ██      ██ ███████       ██████  ███████ ██   ████    ██    ███████ ██   ██ ",
        };

        foreach (string line in asciiArt)
        {
            Console.WriteLine(line);
        }
    }
    
    static void ChooseGame()
    {
        Console.WriteLine();
        Console.WriteLine("Vyberte rezim hry:");
        Console.WriteLine("1 - Bingo");
        Console.WriteLine("2 - Loteria");
        // Console.WriteLine("3 - Piskvorky");
        // Console.WriteLine("4 - Sudoku");
        // Console.WriteLine("5 - Loteria");
        Console.WriteLine();

        int choice = 0;
        do
        {
            try
            {
                if (choice < 1 || choice > 4)
                {
                    Console.WriteLine("Vyberte rezim hry od 1 do 5:");
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
            // case 3: BingoCol(); break;
            // case 4: BingoDiagonal(); break;
            // case 5: Loteria(); break;
            // default: BingoFull(); break;
        }
    }
}