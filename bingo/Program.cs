using static bingo.Bingo;

namespace bingo;

class Program
{
    static void Main(string[] args)
    {
        Bingo bingo = new Bingo();
        bingo.WriteBingo();
        Thread.Sleep(1000);
        bingo.ChooseMode();
    }
}