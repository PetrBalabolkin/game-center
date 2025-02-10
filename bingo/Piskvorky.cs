namespace bingo;

public class Piskvorky
{
    static void WritePiskvorky()
    {
        string[] loteriaAscii =
        {
            "██████  ██ ███████ ██   ██ ██    ██  ██████  ██████  ██   ██ ██    ██ ",
            "██   ██ ██ ██      ██  ██  ██    ██ ██    ██ ██   ██ ██  ██   ██  ██  ",
            "██████  ██ ███████ █████   ██    ██ ██    ██ ██████  █████     ████   ",
            "██      ██      ██ ██ ██    ██  ██  ██    ██ ██   ██ ██ ██      ██    ",
            "██      ██ ███████ ██   ██    ██     ██████  ██   ██ ██   ██    ██    ",
        };

        foreach (string line in loteriaAscii)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }

    static char ChooseMode()
    {
        Console.Write("Hrat proti pocitacu? (y/n) ");
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
        return ansFill;
    }
    static void ShowTable(char[,] arr, char user, char bot)
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

        static void TakeStepXAuto(char[,] arr, char user, char bot, int[] winCor)
        {
            Random random = new Random();
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
                            continue;
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
                            continue;
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
            
            ShowTable(arr, user, bot);
            if (CheckWin(arr, user, winCor))
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
                        c = random.Next(0, arr.GetLength(0) - 1);
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
                        d = random.Next(0, arr.GetLength(1) - 1);
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
            
            arr[c, d] = bot;
        }
        
        static void TakeStepOAuto(char[,] arr, char user, char bot, int[] winCor)
        {
            Random random = new Random();
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
                        c = random.Next(0, arr.GetLength(0) - 1);
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
                        d = random.Next(0, arr.GetLength(1) - 1);
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
            
            arr[c, d] = bot;
            if (CheckWin(arr, bot, winCor))
            {
                return;
            }
            ShowTable(arr, user, bot);
            
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
        
        static void TakeStepXManual(char[,] arr, char oneUser, char twoUser, int[] winCor)
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
                            continue;
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
                            continue;
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
            
            ShowTable(arr, oneUser, twoUser);
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
                            continue;
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
                            continue;
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
        
        static void TakeStepOManual(char[,] arr, char oneUser, char twoUser, int[] winCor)
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
                            continue;
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
                            continue;
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
            ShowTable(arr, oneUser, twoUser);
            
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
                            continue;
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
                            continue;
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

        static bool CheckWin(char[,] arr, char znak, int[] winCor)
        {
            bool win = false;
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
        
        static void ShowWinTable(char[,] arr, char user, char bot, int[] winCor)
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
                        Console.ForegroundColor = ConsoleColor.White;
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
            
            bool win = false;
            int[] winCorUser = new int[6];
            int[] winCorBot = new int[6];
            
            // Console.WriteLine("Piskvorky");
            
            WritePiskvorky();
            char isAuto = ChooseMode();

            char user = '.';
            char bot = '.';
            
            do
            {
                Console.Write("Vyberte znak pre Pouzivatela 1 (x/o): ");
                user = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (user != 'o' && user != 'x');
            
            if (user == 'x')
            {
                bot = 'o';
            }
            else
            {
                bot = 'x';
            }

            double time = 0;
            do
            {
                time++;
                ShowTable(arr, user, bot);
                if (user == 'x')
                {
                    if (isAuto == 'y')
                    {
                        TakeStepXAuto(arr, user, bot, winCorUser);
                    }
                    else
                    {
                        TakeStepXManual(arr, user, bot, winCorUser);
                    }
                }
                else
                {
                    if (isAuto == 'y')
                    {
                        TakeStepOAuto(arr, user, bot, winCorUser);
                    }
                    else
                    {
                        TakeStepOManual(arr, user, bot, winCorUser);
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