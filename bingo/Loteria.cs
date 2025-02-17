namespace bingo;

public class Loteria
{
    private static void WriteLoteria()
    {
        Console.Clear();
        string[] loteriaAscii =
        [
            "██       ██████  ████████ ███████ ██████  ██  █████ ",
            "██      ██    ██    ██    ██      ██   ██ ██ ██   ██",
            "██      ██    ██    ██    █████   ██████  ██ ███████",
            "██      ██    ██    ██    ██      ██   ██ ██ ██   ██",
            "███████  ██████     ██    ███████ ██   ██ ██ ██   ██"
        ];

        foreach (string line in loteriaAscii)
        {
            Console.WriteLine(line);
        }
    }

    private static void ChooseWriteRules()
    {
        Console.WriteLine();
        Console.Write("Vypisat pravidla? (y/n) ");
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
                ansFill = '.';
                Console.WriteLine("Neplatne udaje, zadajte 'y' alebo 'n'.");
            }
        }
        
        if (ansFill == 'y')
        {
            WriteRules();
        }
    }

    private static void WriteRules()
    {
        Console.WriteLine("1. V hre Loteria dostavate karticku (3 x 9), na ktorej musite vyznacit 8 cisel.");
        Console.WriteLine("2. Nasledne budu vypadat cisla. Absolutne nahodne a neovplyvnene organizatorom sutaze.");
        Console.WriteLine("3. Cim skor vypadnu vami vyznacene cisla, tym viac penazi ziskkate.");
        Console.WriteLine("4. Ked prve 8 cisel budu take iste ako vyznacene, vyhravate JackPot. \n   Suma bude stanovena kazdy raz ina");
        Console.WriteLine("5. Cena jedneho listka je 10 eur.");
        Console.WriteLine("6. Na zaciatku hry mate 50 eur. Hru mozete skoncit hocikedy a ziskat peniaze. " +
                          "\n   Avsak ked miniete vsetky peniaze na listky a vas kredit bude menej ako 10 eur nedostanete nic");
    }

    private static int[,] Create()
    {
        int[,] card = new int[3, 9];
        return card;
    }

    private static void FillAuto(int[,] card)
    {
        Random random = new Random();
        for (int i = 0; i < card.GetLength(0); i++)
        {
            for (int j = 0; j < card.GetLength(1); j++)
            {
                card[i, j] = -1;
            }
        }
        
        for (int i = 0; i < card.GetLength(1); i++)
        {
            for (int j = 0; j < card.GetLength(0); j++)
            {
                int rndNum = random.Next(0, 10);
                if (rndNum == 1 || rndNum == 5)
                {
                    continue;
                }
                
                int fillNum;
                do
                {
                    fillNum = random.Next((i * 10), ((i + 1) * 10));
                } while (Bingo.Contains(card, fillNum));

                card[j, i] = fillNum;
            }
        }
    }

    private static int[] ChooseNumbers(int[,] card, int[] numbersAuto)
    {
        int[] numbers = new int[8];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = -1;
        }

        Console.WriteLine("Zadajte 8 cisel:");
        for (int i = 0; i < numbers.Length; i++)
        {
            int count = 0;
            int tempNum = 0;
            do
            {
                if (count > 0)
                {
                    Console.WriteLine("Zadajte cislo, ktore je v listku");
                }

                int c = 0;
                
                Console.Write("Vyberte si cislo: ");
                try
                {
                    do
                    {
                        if (c > 0)
                        {
                            Console.WriteLine("Zadane cislo uz bolo zadane");
                        }
                        tempNum = Convert.ToInt32(Console.ReadLine());
                        c++;
                    } while (numbers.Contains(tempNum));
                }
                catch
                {
                    Console.WriteLine("Zadali ste neplatnu hodnotu");
                }
                count++;
            } while (!Bingo.Contains(card, tempNum));
            numbers[i] = tempNum;
            Print(card, numbersAuto, numbers);
        }
        return numbers;
    }
    
    private static void Print(int[,] card, int[] numbers, int[] chosenNumbers)
    {
        for (int i = 0; i < card.GetLength(1); i++)
        {
            Console.Write(" ____");
        }

        Console.WriteLine();

        for (int i = 0; i < card.GetLength(0); i++)
        {
            Console.Write("|");
            for (int j = 0; j < card.GetLength(1); j++)
            {
                if (card[i, j] < 10)
                {
                    Console.Write(" ");
                }
                
                if (card[i, j] == -1)
                {
                    Console.Write("   |");
                    continue;
                }
                Console.Write(" ");
                
                if (numbers.Contains(card[i, j]) && chosenNumbers.Contains(card[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else if (numbers.Contains(card[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (chosenNumbers.Contains(card[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(card[i, j]);
                
                Console.ResetColor();
                
                Console.Write(" |");
            }

            if (card.GetLength(0) % card.GetLength(0) == 0)
            {
                Console.WriteLine();
            }

            for (int j = 0; j < card.GetLength(1); j++)
            {
                Console.Write(" ----");
            }

            Console.WriteLine();
        }
    }
    
    private static int Step(int[] numbers, int counter)
    {
        Random random = new Random();

        int stepNum;

        do
        {
            stepNum = random.Next(0, 91);
        } while (numbers.Contains(stepNum));
        
        Console.WriteLine("Vypadlo cislo: " + stepNum);

        numbers[counter] = stepNum;
        counter++;
        
        return counter;
    }

    private static int ChooseJackpot()
    {
        Random random = new Random();
        int jackpot = random.Next(1000, 10000);

        return jackpot;
    }
    
    // Keby sme chceli zvysit sancu vyhry
    /*
    private static double ChooseBudget()
    {
        Random random = new Random();
        double budget = random.Next(1000, 2000);
        
        return budget;
    } */
    
    private static int Economy(int winMoney, int counter, bool win, int jackpot, int budget)
    {
        if (counter == 8 && win)
        {
            winMoney = jackpot;
            Console.WriteLine("Vyhrali ste jackpot v rozmere " + jackpot + " eur");
        }

        if (win)
        {
            if (winMoney > 0)
            {
                winMoney = budget - (counter * 10);
            }
        }

        if (!win)
        {
            Console.WriteLine("Mohli ste vyhrat " + (budget - (counter * 10)) + " eur");
        }
        
        return winMoney;
    }

    private static bool CheckWin(int[] numbers, int[] chosenNumbers)
    {
        bool[] findenNumbers = new bool[chosenNumbers.Length];

        for (int i = 0; i < chosenNumbers.Length; i++)
        {
            if (numbers.Contains(chosenNumbers[i]))
            {
                findenNumbers[i] = true;
            }
        }
        
        if (findenNumbers.All(n => n))
        {
            return true;
        }
        
        return false;
    }

    public static bool ChooseContinue()
    {
        char contChar = '.';
        
        Console.WriteLine("Chcete pokracovat? (y/n)");
        while (contChar != 'y' || contChar == 'n')
        {
            string input = Console.ReadLine();
            if (input.Length == 1 && (input[0] == 'y' || input[0] == 'n'))
            {
                contChar = input[0];
                break;
            }
            else
            {
                contChar = '.';
                Console.WriteLine("Neplatne udaje, zadajte 'y' alebo 'n'.");
            }
        }

        if (contChar == 'y')
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void LoteriaMechanichs()
    {
        bool cont;
        int money = 10;
        
        do
        {
            int counter = 0;
            int winMoney = 0;
            bool win;
            int jackpot = ChooseJackpot();
            int budget = 750;
            
            int[] numbers = new int[100];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = -1;
            }
            
            int[,] card = Create();
            FillAuto(card);
            int[] chosenNumbers = new int[8];
            Print(card, numbers, chosenNumbers);
        
            chosenNumbers = ChooseNumbers(card, numbers);
            Print(card, numbers, chosenNumbers);

            money -= 10;
            
            do
            {
                Thread.Sleep(1000);
                counter = Step(numbers, counter);
                Print(card, numbers, chosenNumbers);
                win = CheckWin(numbers, chosenNumbers);
                winMoney = Economy(winMoney, counter, win, jackpot, budget);
            } while (!win);

            if (win)
            {
                Console.WriteLine("Vyhral si a konkretne " + winMoney + " eur");
            }
            money += winMoney;

            if (money > 0)
            {
                Console.WriteLine("Vas kredit: " + money + " eur");
                Console.WriteLine("Cena hry: 10 eur");
                cont = ChooseContinue();
            }
            else
            {
                cont = false;
            }
            
        } while (cont);
    }

    public static void LoteriaGame()
    {
        WriteLoteria();
        ChooseWriteRules();
        LoteriaMechanichs();
    }
}