using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mini4ki
{
    using Minesweeper.Models;

    public class minite
    {
        static void Main(string[] аргументи)
        {
            string komanda = string.Empty;
            char[,] poleto = create_igralno_pole();
            char[,] bombite = slojibombite();
            int broya4 = 0;
            bool grum = false;
            List<ScoreCard> shampion4eta = new List<ScoreCard>(6);
            int red = 0;
            int kolona = 0;
            bool flag = true;
            const int maks = 35;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintTheMinefield(poleto);
                    flag = false;
                }

                Console.Write("Daj red i kolona : ");
                komanda = Console.ReadLine().Trim();

                if (komanda.Length >= 3)
                {
                    if (int.TryParse(komanda[0].ToString(), out red) &&
                    int.TryParse(komanda[2].ToString(), out kolona) &&
                        red <= poleto.GetLength(0) && kolona <= poleto.GetLength(1))
                    {
                        komanda = "turn";
                    }
                }
                switch (komanda)
                {
                    case "top":
                        klasacia(shampion4eta);
                        break;
                    case "restart":
                        poleto = create_igralno_pole();
                        bombite = slojibombite();
                        PrintTheMinefield(poleto);
                        grum = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombite[red, kolona] != '*')
                        {
                            if (bombite[red, kolona] == '-')
                            {
                                tisinahod(poleto, bombite, red, kolona);// TODO:
                                broya4++;
                            }
                            if (maks == broya4)
                            {
                                flag2 = true;
                            }

                            PrintTheMinefield(poleto);

                        }
                        else
                        {
                            grum = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (grum)
                {
                    PrintTheMinefield(bombite);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", broya4);
                    string niknejm = Console.ReadLine();
                    ScoreCard t = new ScoreCard(niknejm, broya4);
                    if (shampion4eta.Count < 5)
                    {
                        shampion4eta.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < shampion4eta.Count; i++)
                        {
                            if (shampion4eta[i].Score < t.Score)
                            {
                                shampion4eta.Insert(i, t);
                                shampion4eta.RemoveAt(shampion4eta.Count - 1);
                                break;
                            }
                        }
                    }
                    shampion4eta.Sort((ScoreCard r1, ScoreCard r2) => r2.Name.CompareTo(r1.Name));
                    shampion4eta.Sort((ScoreCard r1, ScoreCard r2) => r2.Score.CompareTo(r1.Score));
                    klasacia(shampion4eta);

                    poleto = create_igralno_pole();
                    bombite = slojibombite();
                    broya4 = 0;
                    grum = false;
                    flag = true;
                }
                if (flag2)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintTheMinefield(bombite);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string imeee = Console.ReadLine();
                    ScoreCard to4kii = new ScoreCard(imeee, broya4);
                    shampion4eta.Add(to4kii);
                    klasacia(shampion4eta);
                    poleto = create_igralno_pole();
                    bombite = slojibombite();
                    broya4 = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (komanda != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void klasacia(List<ScoreCard> to4kii)
        {
            Console.WriteLine("\nTo4KI:");
            if (to4kii.Count > 0)
            {
                for (int i = 0; i < to4kii.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, to4kii[i].Name, to4kii[i].Score);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void tisinahod(char[,] POLE,
            char[,] BOMBI, int RED, int KOLONA)
        {
            char kolkoBombi = kolko(BOMBI, RED, KOLONA);
            BOMBI[RED, KOLONA] = kolkoBombi;
            POLE[RED, KOLONA] = kolkoBombi;
        }

        private static void PrintTheMinefield(char[,] board)
        {
            int RRR = board.GetLength(0);
            int KKK = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < RRR; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < KKK; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] create_igralno_pole()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] slojibombite()
        {
            int Редове = 5;
            int Колони = 10;
            char[,] игрално_поле = new char[Редове, Колони];

            for (int i = 0; i < Редове; i++)
            {
                for (int j = 0; j < Колони; j++)
                {
                    игрално_поле[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomeNumber = random.Next(50);
                if (!mines.Contains(randomeNumber))
                {
                    mines.Add(randomeNumber);
                }
            }

            foreach (int number in mines)
            {
                int kol = (number / Колони);
                int red = (number % Колони);
                if (red == 0 && number != 0)
                {
                    kol--;
                    red = Колони;
                }
                else
                {
                    red++;
                }
                игрално_поле[kol, red - 1] = '*';
            }

            return игрално_поле;
        }

        private static char kolko(char[,] mines, int row, int col)
        {
            int brojkata = 0;
            int reds = mines.GetLength(0);
            int kols = mines.GetLength(1);

            if (row - 1 >= 0)
            {
                if (mines[row - 1, col] == '*')
                {
                    brojkata++;
                }
            }
            if (row + 1 < reds)
            {
                if (mines[row + 1, col] == '*')
                {
                    brojkata++;
                }
            }
            if (col - 1 >= 0)
            {
                if (mines[row, col - 1] == '*')
                {
                    brojkata++;
                }
            }
            if (col + 1 < kols)
            {
                if (mines[row, col + 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (mines[row - 1, col - 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < kols))
            {
                if (mines[row - 1, col + 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((row + 1 < reds) && (col - 1 >= 0))
            {
                if (mines[row + 1, col - 1] == '*')
                {
                    brojkata++;
                }
            }
            if ((row + 1 < reds) && (col + 1 < kols))
            {
                if (mines[row + 1, col + 1] == '*')
                {
                    brojkata++;
                }
            }
            return char.Parse(brojkata.ToString());
        }
    }
}
