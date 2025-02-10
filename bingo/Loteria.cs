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
            "██      ██    ██    ██    ██      ██  ██  ██ ██   ██ ",
            "███████  ██████     ██    ███████ ██   ██ ██ ██   ██ ",
        };

        foreach (string line in loteriaAscii)
        {
            Console.WriteLine(line);
        }
    }

    public static void LoteriaGame()
    {
        Bingo bingo = new Bingo();
        
        WriteLoteria();
        Thread.Sleep(1000);
        int[,] card = Bingo.Create();
        Bingo.ChooseFill(card);
    }

}