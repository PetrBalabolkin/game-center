﻿namespace bingo;

class Program
{
    static void Main(string[] args)
    {
        /* WriteBingo();
        Console.WriteLine();

        // vytvorenie pola
        int[,] card = Create();

        // naplnenie pola
        Console.Write("Vyplnit karticku automaticky? (y/n) ");
        char ansFill = '.';
        try
        {
            ansFill = Convert.ToChar(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Vyplnit karticku automaticky? (y/n) ");
        }

        if (ansFill == 'y')
        {
            FillAuto(card);
        }
        else
        {
            FillManual(card);
        }

        Print(card);

        // hra s krokami
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = -1;
        }

        int counter = 0;

        bool win = false;
        do
        {
            Step(numbers, counter);
            win = CheckWinFull(card, numbers, counter);
        } while (win == false);

        if (win)
        {
            Console.WriteLine("Vyhral si");
        } */
        
        WriteBingo();
        Thread.Sleep(1000);
        ChooseMode();
    }

    static void WriteBingo()
    {
        string[] bingoAscii =
        {
            "███████  ██ ███    ██  ██████   ██████  ",
            "██    ██ ██ ████   ██ ██       ██    ██ ",
            "███████  ██ ██ ██  ██ ██   ███ ██    ██ ",
            "██    ██ ██ ██  ██ ██ ██    ██ ██    ██ ",
            "███████  ██ ██   ████  ██████   ██████  "
        };

        foreach (string line in bingoAscii)
        {
            Console.WriteLine(line);
        }
    }
    
    static void ChooseMode()
    {
        Console.WriteLine();
        Console.WriteLine("Vyberte rezim hry:");
        Console.WriteLine("1 - Bingo Full");
        Console.WriteLine("2 - Bingo Row");
        Console.WriteLine("3 - Bingo Column");
        Console.WriteLine("4 - Bingo Diagonal");
        Console.WriteLine("5 - Loteria");
        Console.WriteLine();

        int choice = 0;
        try
        {
            choice = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Zadali ste nespravnu hodnotu");
        }

        switch (choice)
        {
            case 1: BingoFull(); break;
            case 2: BingoRow(); break;
            case 3: BingoCol(); break;
            case 4: BingoDiagonal(); break;
            case 5: Loteria(); break;
            default: BingoFull(); break;
        }
    }

    static void ChooseFill(int[,] card)
    {
        Console.Write("Vyplnit karticku automaticky? (y/n) ");
        char ansFill = '.';
        try
        {
            ansFill = Convert.ToChar(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Vyplnit karticku automaticky? (y/n) ");
        }

        if (ansFill == 'y')
        {
            FillAuto(card);
        }
        else
        {
            FillManual(card);
        }
    }

    static int[,] Create()
    {
        int cardHeight = 0;
        int cardWidth = 0;

        Console.WriteLine("Zadajte vysku a dlzku hernej karticky: \n(Rozmery rozdelte stlacenim klavesy 'Enter')");
        try
        {
            cardHeight = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Nezadali ste cislo");
        }

        try
        {
            cardWidth = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Nezadali ste cislo");
        }

        int[,] card = new int[cardHeight, cardWidth];

        return card;
    }

    static void Print(int[,] card, int[] numbers)
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

                // neviem, ci by som toto mal nechat
                /* if (card[i, j] == 0)
                {
                    Console.Write("   |");
                    continue;
                } */
                Console.Write(" ");
                if (numbers.Contains(card[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
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

    static void FillAuto(int[,] card)
    {
        Random random = new Random();

        for (int i = 0; i < card.GetLength(1); i++)
        {
            for (int j = 0; j < card.GetLength(0); j++)
            {
                /*
                int rndNum = random.Next(0, 10);
                if (rndNum == 1 || rndNum == 5)
                {
                    continue;
                }
                */
                int rndNum = 0;
                do
                {
                    rndNum = random.Next((i * 10), ((i + 1) * 10));
                } while (Contains(card, rndNum));

                card[j, i] = rndNum;
            }
        }
    }

    static void FillManual(int[,] card)
    {
        for (int i = 0; i < card.GetLength(1); i++)
        {
            for (int j = 0; j < card.GetLength(0); j++)
            {
                int rndNum = 0;
                int counter = 0;
                Console.Write("Zadajte hodnotu od " + (i * 10) + " do " + ((i + 1) * 10) + ": ");
                do
                {
                    if (counter > 0)
                    {
                        Console.WriteLine();
                        Console.Write("Zadana hodnotu uz je v listku. \nZadajte hodnotu znova: ");
                    }

                    try
                    {
                        int count = 0;
                        do
                        {
                            if (count > 0)
                            {
                                Console.WriteLine();
                                Console.Write("Zadajte hodnotu znovu: ");
                            }

                            rndNum = int.Parse(Console.ReadLine());
                            count++;
                        } while ((rndNum < (i * 10)) || (rndNum > ((i + 1) * 10)));
                    }
                    catch
                    {
                        Console.WriteLine("Nezadali ste cislo");
                    }

                    counter++;
                } while (Contains(card, rndNum));

                card[j, i] = rndNum;
            }
        }
    }

    static int Step(int[] numbers, int counter)
    {
        Random random = new Random();

        int stepNum = 0;

        do
        {
            stepNum = random.Next(0, 100);
        } while (numbers.Contains(stepNum));
        
        Console.WriteLine("Vypadlo cislo: " + stepNum);

        numbers[counter] = stepNum;
        counter++;
        
        return counter;
    }

    static bool CheckWinFull(int[,] card, int[] numbers, int counter)
    {
        bool[] numsWon = new bool[counter];
        int counterWon = 0;

        for (int i = 0; i < card.GetLength(1); i++)
        {
            for (int j = 0; j < card.GetLength(0); j++)
            {
                int numsInd = 0;
                for (int k = 0; k < numsWon.Length; k++)
                {
                    if (numbers[k] == -1)
                    {
                        return false;
                    }

                    if (card[j, i] == numbers[k])
                    {
                        numsWon[numsInd] = true;
                    }
                    numsInd++;
                }
            }
        }

        for (int i = 0; i < numsWon.Length; i++)
        {
            if (numsWon[i])
            {
                counterWon++;
            }
        }

        if (counterWon == (card.GetLength(0) * card.GetLength(1)))
        {
            return true;
        }
        
        return false;
    }

    static bool CheckWinRow(int[,] card, int[] numbers)
    {
        for (int i = 0; i < card.GetLength(0); i++)
        {
            for (int j = 0; j < card.GetLength(1); j++)
            {
                bool[] numsWon = new bool[card.GetLength(0)];
                int numsInd = 0;
                
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (numbers[k] == -1)
                    {
                        break;
                    }

                    if (card[i, j] == numbers[k])
                    {
                        numsWon[numsInd] = true;
                    }
                    numsInd++;
                }

                if (numsWon.All(n => n))
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool CheckWinCol(int[,] card, int[] numbers)
    {
        for (int i = 0; i < card.GetLength(1); i++)
        {
            for (int j = 0; j < card.GetLength(0); j++)
            {
                bool[] numsWon = new bool[card.GetLength(1)];
                int numsInd = 0;
                
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (numbers[k] == -1)
                    {
                        break;
                    }

                    if (card[j, i] == numbers[k])
                    {
                        numsWon[numsInd] = true;
                    }
                    numsInd++;
                }

                if (numsWon.All(n => n))
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool ChcekWinDiagonalRight(int[,] card, int[] numbers)
    {
        bool[] numsWon = new bool[card.GetLength(0)];
        
        for (int i = 0; i < card.GetLength(0); i++)
        {
            int numsInd = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] == -1)
                {
                    break;
                }
                
                if (card[i, i] == numbers[j])
                {
                    numsWon[numsInd] = true;
                    break;
                }
            }
        }
        
        if (numsWon.All(n => n))
        {
            return true;
        }
        
        return false;
    }
    
    static bool ChcekWinDiagonalLeft(int[,] card, int[] numbers)
    {
        bool[] numsWon = new bool[card.GetLength(0)];
        
        for (int i = (card.GetLength(0) - 1); i >= 0; i--)
        {
            int numsInd = 0;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] == -1)
                {
                    break;
                }
                
                if (card[i, i] == numbers[j])
                {
                    numsWon[numsInd] = true;
                    break;
                }
            }
        }
        
        if (numsWon.All(n => n))
        {
            return true;
        }
        
        return false;
    }

    static bool Contains(int[,] arr, int num)
    {
        for (int i = 0; i < arr.GetLength(1); i++)
        {
            for (int j = 0; j < arr.GetLength(0); j++)
            {
                if (arr[j, i] == num)
                {
                    return true;
                }
            }
        }
        return false;
    }

    static void BingoFull()
    {
        bool win = false;
        
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = -1;
        }

        int counter = 0;
        
        int[,] card = Create();
        ChooseFill(card);
        Print(card, numbers);

        do
        {
            Step(numbers, counter);
            Print(card, numbers);
            win = CheckWinFull(card, numbers, counter);
        } while (win != true);

        if (win)
        {
            Console.WriteLine("Vyhral si!");
        }
    }

    static void BingoRow()
    {
        bool win = false;
        
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = -1;
        }

        int counter = 0;
        
        int[,] card = Create();
        ChooseFill(card);

        do
        {
            Step(numbers, counter);
            win = CheckWinRow(card, numbers);
        } while (win != true);

        if (win)
        {
            Console.WriteLine("Vyhral si!");
        }
    }

    static void BingoCol()
    {
        bool win = false;
        
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = -1;
        }

        int counter = 0;
        
        int[,] card = Create();
        ChooseFill(card);

        do
        {
            Step(numbers, counter);
            win = CheckWinCol(card, numbers);
        } while (win != true);

        if (win)
        {
            Console.WriteLine("Vyhral si!");
        }
    }

    static void BingoDiagonal()
    {
        bool win = false;
        
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = -1;
        }

        int counter = 0;
        
        int[,] card = Create();
        ChooseFill(card);

        do
        {
            Step(numbers, counter);
            win = ChcekWinDiagonalRight(card, numbers);
            if (win)
            {
                continue;
            }
            win = ChcekWinDiagonalLeft(card, numbers);
        } while (win != true);

        if (win)
        {
            Console.WriteLine("Vyhral si!");
        }
    }

    static void Loteria()
    {
        
    }
}