using static bingo.Bingo;

namespace bingo;

public class Loteria
{
    static void WriteLoteria()
    {
        string[] loteriaAscii =
        {
            "██       ██████  ████████ ███████ ██████  ██  █████  ",
            "██      ██    ██    ██    ██      ██   ██ ██ ██   ██ ",
            "██      ██    ██    ██    █████   ██████  ██ ███████ ",
            "██      ██    ██    ██    ██      ██   ██ ██ ██   ██ ",
            "███████  ██████     ██    ███████ ██   ██ ██ ██   ██ ",
        };

        foreach (string line in loteriaAscii)
        {
            Console.WriteLine(line);
        }
    }
    
    public static void ChooseFill(int[,] card)
    {
        Console.Write("Vyplnit karticku automaticky? (y/n) ");
        char ansFill = '.';
        while (ansFill != 'y' || ansFill == 'n')
        {
            string input = Console.ReadLine(); 
            if (input.Length == 1 && (input[0] == 'y' || input[0] == 'n'))
            {
                ansFill = input[0];
                break;
            }
            else
            {
                Console.WriteLine("Neplatne udaje, zadajte 'y' alebo 'n'.");
            }
        }
        
        if (ansFill == 'y')
        {
            Bingo.FillAuto(card);
        }
        else
        {
            Bingo.FillManual(card);
        }
    }

    static void LoteriaMechanichs()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = -1;
        }
        
        int[,] card = Bingo.Create();
        ChooseFill(card);
        Bingo.Print(card, numbers);
    }

    public static void LoteriaGame()
    {
        Bingo bingo = new Bingo();
        
        WriteLoteria();
        Console.WriteLine();
        Thread.Sleep(1000);
        LoteriaMechanichs();
        
    }
}