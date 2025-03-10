namespace bingo;

public class Piskvorky
{
    private static void WritePiskvorky()
    {
        string[] loteriaAscii =
        [
            "██████  ██ ███████ ██   ██ ██    ██  ██████  ██████  ██   ██ ██    ██ ",
            "██   ██ ██ ██      ██  ██  ██    ██ ██    ██ ██   ██ ██  ██   ██  ██  ",
            "██████  ██ ███████ █████   ██    ██ ██    ██ ██████  █████     ████   ",
            "██      ██      ██ ██ ██    ██  ██  ██    ██ ██   ██ ██ ██      ██    ",
            "██      ██ ███████ ██   ██    ██     ██████  ██   ██ ██   ██    ██    "
        ];

        foreach (string line in loteriaAscii)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

    private static char ChooseMode()
    {
        Console.Write("Hrat proti pocitacu? (y/n) ");
        char ansFill = '.';
        while (ansFill != 'y' || ansFill == 'n' || ansFill != 'Y' || ansFill == 'N')
        {
            string input = Console.ReadLine(); 
            if (input.Length == 1 && (input[0] == 'y' || input[0] == 'n' || input[0] == 'Y' || input[0] == 'N'))
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
        return ansFill;
    }
    private static void ShowTable(char[,] arr, char user, char bot, bool isAuto)
        {
            if (isAuto)
            {
                Console.WriteLine("\nPouzivatel: " + user +"\nPocitac: " + bot);
            }
            else
            {
                Console.WriteLine("\nPouzivatel 1: " + user +"\nPouzivatel 2: " + bot);
            }
            

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write(" ___");
            }
            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(" " + arr[i, j] + " |");
                }

                if (arr.GetLength(0) % 3 == 0)
                {
                    Console.WriteLine();
                } 
                
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write(" ---");
                }
                Console.WriteLine();
            }
        }

        private static void TakeStepXAuto(char[,] arr, char user, char bot, int[] winCor, bool isAuto)
        {
            Random random = new Random();
            int a = -1;
            int b = -1;
            int c = -1;
            int d = -1;
            do
            {
                Console.Write("Zadajte koordinaty (od 1 do 3): ");

                try
                {
                    Console.Write("Zadajte cislo riadku (od 1 do 3): " +
                                  "\n(Cislovanie sa zacina hore) ");
                    do
                    {
                        a = int.Parse(Console.ReadLine()) - 1;
                        if (a < 0 || a >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (a < 0 || a >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                try
                {
                    Console.Write("Zadajte cislo stlpca (od 1 do 3): " +
                                  "\n(Cislovanie sa zacina na lavej strane) ");
                    do
                    {
                        b = int.Parse(Console.ReadLine()) - 1;
                        if (b < 0 || b >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (b < 0 || b >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                if (arr[a, b] != '.')
                {
                    Console.WriteLine("V zadanych koordinatoch uz je oznacene");
                }
                
            } while (arr[a, b] != '.');

            arr[a, b] = user;
            
            ShowTable(arr, user, bot, isAuto);
            if (CheckWin(arr, user, winCor))
            {
                return;
            }
            
            do
            {
                try
                {
                    do
                    {
                        c = random.Next(0, arr.GetLength(0) - 1);
                    } while (c < 0 || c >= 3);
                }
                catch
                {
                    continue;
                }
                
                try
                {
                    do
                    {
                        d = random.Next(0, arr.GetLength(1) - 1);
                    } while (d < 0 || d >= 3);
                }
                catch
                {
                    continue;
                }

                /* 
                if (arr[c, d] != '.')
                {
                    Console.WriteLine("V zadanych koordinatoch uz je oznacene");
                } */
            } while (arr[c, d] != '.');
            
            arr[c, d] = bot;
        }
        
        private static void TakeStepOAuto(char[,] arr, char user, char bot, int[] winCor, bool isAuto)
        {
            Random random = new Random();
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            
            do
            {
                try
                {
                    do
                    {
                        c = random.Next(0, arr.GetLength(0) - 1);
                    } while (c < 0 || c >= 3);
                }
                catch
                {
                    continue;
                }

                try
                {
                    do
                    {
                        d = random.Next(0, arr.GetLength(1) - 1);
                    } while (d < 0 || d >= 3);
                }
                catch
                {
                    
                    continue;
                }
                
            } while (arr[c, d] != '.');
            
            arr[c, d] = bot;
            if (CheckWin(arr, bot, winCor))
            {
                return;
            }
            ShowTable(arr, user, bot, isAuto);
            
            do
            {
                Console.Write("Zadajte koordinaty (od 1 do 3): ");
                try
                {
                    do
                    {
                        a = int.Parse(Console.ReadLine()) - 1;
                        if (a < 0 || a >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (a < 0 || a >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                try
                {
                    do
                    {
                        b = int.Parse(Console.ReadLine()) - 1;
                        if (b < 0 || b >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (b < 0 || b >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                if (arr[a, b] != '.')
                {
                    Console.WriteLine("V zadanych koordinatoch uz je oznacene");
                }
                
            } while (arr[a, b] != '.');

            arr[a, b] = user;
        }
        
        private static void TakeStepXManual(char[,] arr, char oneUser, char twoUser, int[] winCor, bool isAuto)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            do
            {
                Console.Write("Zadajte koordinaty (od 1 do 3): ");

                try
                {
                    do
                    {
                        a = int.Parse(Console.ReadLine()) - 1;
                        if (a < 0 || a >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (a < 0 || a >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                try
                {
                    do
                    {
                        b = int.Parse(Console.ReadLine()) - 1;
                        if (b < 0 || b >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (b < 0 || b >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                if (arr[a, b] != '.')
                {
                    Console.WriteLine("V zadanych koordinatoch uz je oznacene");
                }
                
            } while (arr[a, b] != '.');

            arr[a, b] = oneUser;
            
            ShowTable(arr, oneUser, twoUser, isAuto);
            if (CheckWin(arr, oneUser, winCor))
            {
                return;
            }
            
            do
            {
                Console.Write("Zadajte koordinaty (od 1 do 3): ");
                try
                {
                    do
                    {
                        c = int.Parse(Console.ReadLine()) - 1;
                        if (c < 0 || d >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (c < 0 || c >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }
                
                try
                {
                    do
                    {
                        d = int.Parse(Console.ReadLine()) - 1;
                        if (d < 0 || d >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (d < 0 || d >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                if (arr[c, d] != '.')
                {
                    Console.WriteLine("V zadanych koordinatoch uz je oznacene");
                }
            } while (arr[c, d] != '.');
            
            arr[c, d] = twoUser;
        }
        
        private static void TakeStepOManual(char[,] arr, char oneUser, char twoUser, int[] winCor, bool isAuto)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            
            do
            {
                Console.Write("Zadajte koordinaty (od 1 do 3): ");
                try
                {
                    do
                    {
                        c = int.Parse(Console.ReadLine()) - 1;
                        if (c < 0 || d >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (c < 0 || c >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                try
                {
                    do
                    {
                        d = int.Parse(Console.ReadLine()) - 1;
                        if (d < 0 || d >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (d < 0 || d >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                if (arr[c, d] != '.')
                {
                    Console.WriteLine("V zadanych koordinatoch uz je oznacene");
                }
            } while (arr[c, d] != '.');
            
            arr[c, d] = twoUser;
            if (CheckWin(arr, twoUser, winCor))
            {
                return;
            }
            ShowTable(arr, oneUser, twoUser, isAuto);
            
            do
            {
                Console.Write("Zadajte koordinaty (od 1 do 3): ");
                try
                {
                    do
                    {
                        a = int.Parse(Console.ReadLine()) - 1;
                        if (a < 0 || a >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (a < 0 || a >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                try
                {
                    do
                    {
                        b = int.Parse(Console.ReadLine()) - 1;
                        if (b < 0 || b >= 3)
                        {
                            Console.WriteLine("Koordinaty musia byt v rozmedzi od 1 do 3.");
                        }
                    } while (b < 0 || b >= 3);
                }
                catch
                {
                    Console.WriteLine("Nezadali ste cislo");
                    Console.Write("Zadajte koordinaty (od 1 do 3): ");
                    continue;
                }

                if (arr[a, b] != '.')
                {
                    Console.WriteLine("V zadanych koordinatoch uz je oznacene");
                }
                
            } while (arr[a, b] != '.');

            arr[a, b] = oneUser;
        }

        private static bool CheckWin(char[,] arr, char znak, int[] winCor)
        {
            bool win;
            // horizontal
            if (arr[0, 0] == znak && arr[0, 1] == znak && arr[0, 2] == znak)
            {
                winCor[0] = 0; winCor[1] = 0;
                winCor[2] = 0; winCor[3] = 1;
                winCor[4] = 0; winCor[5] = 2;
                win = true;
            } else if (arr[1, 0] == znak && arr[1, 1] == znak && arr[1, 2] == znak)
            {
                winCor[0] = 1; winCor[1] = 0;
                winCor[2] = 1; winCor[3] = 1;
                winCor[4] = 1; winCor[5] = 2;
                win = true;
            } else if (arr[2, 0] == znak && arr[2, 1] == znak && arr[2, 2] == znak)
            {
                winCor[0] = 2; winCor[1] = 0;
                winCor[2] = 2; winCor[3] = 1;
                winCor[4] = 2; winCor[5] = 2;
                win = true;
                // vertikalne
            } else if (arr[0, 0] == znak && arr[1, 0] == znak && arr[2, 0] == znak)
            {
                winCor[0] = 0; winCor[1] = 0;
                winCor[2] = 1; winCor[3] = 0;
                winCor[4] = 2; winCor[5] = 0;
                win = true;
            } else if (arr[0, 1] == znak && arr[1, 1] == znak && arr[2, 1] == znak)
            {
                winCor[0] = 0; winCor[1] = 1;
                winCor[2] = 1; winCor[3] = 1;
                winCor[4] = 2; winCor[5] = 1;
                win = true;
            } else if (arr[0, 2] == znak && arr[1, 2] == znak && arr[2, 2] == znak)
            {
                winCor[0] = 0; winCor[1] = 2;
                winCor[2] = 1; winCor[3] = 2;
                winCor[4] = 2; winCor[5] = 2;
                win = true;
                //diagonalne
            } else if (arr[0, 0] == znak && arr[1, 1] == znak && arr[2, 2] == znak)
            {
                winCor[0] = 0; winCor[1] = 0;
                winCor[2] = 1; winCor[3] = 1;
                winCor[4] = 2; winCor[5] = 2;
                win = true;
            } else if (arr[0, 2] == znak && arr[1, 1] == znak && arr[2, 0] == znak)
            {
                winCor[0] = 0; winCor[1] = 2;
                winCor[2] = 1; winCor[3] = 1;
                winCor[4] = 2; winCor[5] = 0;
                win = true;
            }
            else
            {
                win = false;
            }

            return win;
        }
        
        private static void ShowWinTable(char[,] arr, char user, char bot, int[] winCor)
        {
            Console.WriteLine("Pouzivatel: " + user +"\nPocitac: " + bot);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write(" ___");
            }
            Console.WriteLine();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if ((i == winCor[0] && j == winCor[1]) || (i == winCor[2] && j == winCor[3]) || (i == winCor[4] && j == winCor[5]))
                    {
                        Console.Write(" ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(arr[i, j]);
                        Console.ResetColor();
                        Console.Write(" |");
                    } else
                    {
                        Console.Write(" " + arr[i, j] + " |");
                    }
                }

                if (arr.GetLength(0) % 3 == 0)
                {
                    Console.WriteLine();
                } 
                
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    Console.Write(" ---");
                }
                Console.WriteLine();
            }
        }

        public static void PiskvorkyGame()
        {
            char[,] arr = new char[3, 3];
            
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = '.';
                }
            }
            
            bool win;
            int[] winCorUser = new int[6];
            int[] winCorBot = new int[6];
            bool isAuto = false;
            
            WritePiskvorky();
            if (ChooseMode() == 'y' || ChooseMode() == 'Y')
            {
                isAuto = true;
            }

            char user;
            char bot;
            
            do
            {
                Console.Write("Vyberte znak pre Pouzivatela 1 (x/o): ");
                user = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (user != 'o' && user != 'x');

            Console.ReadKey();
            
            bot = user == 'x' ? 'o' : 'x';

            double time = 0;
            do
            {
                time++;
                ShowTable(arr, user, bot, isAuto);
                if (user == 'x')
                {
                    if (isAuto)
                    {
                        TakeStepXAuto(arr, user, bot, winCorUser, isAuto);
                    }
                    else
                    {
                        TakeStepXManual(arr, user, bot, winCorUser, isAuto);
                    }
                }
                else
                {
                    if (isAuto)
                    {
                        TakeStepOAuto(arr, user, bot, winCorUser, isAuto);
                    }
                    else
                    {
                        TakeStepOManual(arr, user, bot, winCorUser, isAuto);
                    }
                }

                // check user win 
                win = CheckWin(arr, user, winCorUser);
                // check bot win
                if (CheckWin(arr, bot, winCorBot))
                {
                    Console.WriteLine("Vyhral Pocitac");
                    ShowWinTable(arr, user, bot, winCorBot);
                    break;
                }

                if (time > 3.9)
                {
                    time += 0.5;
                }

                if (time > 4.5)
                {
                    Console.WriteLine("Remiza!");
                    break;
                }
            } while (win != true);

            if (win)
            {
                ShowWinTable(arr, user, bot, winCorUser);
                Console.WriteLine("Vyhral Pouzivatel");
            }
        }    
}