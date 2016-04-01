using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//https://msdn.microsoft.com/en-us/library/system.console.keyavailable%28v=VS.100%29.aspx
//Waiting For Input

namespace FallingRocksv2
{
    class FalllingRocks
    {
        static void Main()
        {
            //CONSOLE
            Console.SetWindowSize(42, 24);
            Console.SetBufferSize(42, 24);
            Console.Title = "Falling Rocks";
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            
            //VARIABLES
            string[] gameArea = new string[18];
            string playerRow = "";
            string playerCharacter = "(0)";

            int gameAreaWidth = 42;
            int playerPosition = (gameAreaWidth / 2);
            int playerScore = 0;
            bool playerCollision = false;

            ConsoleKeyInfo playerInput = new ConsoleKeyInfo();

            //Generate PlayerRow
            playerRow = GeneratePlayerRow(playerPosition, gameAreaWidth, playerCharacter);
            //and GameArea
            for (int i = 0; i < gameArea.Length; i++)
            {
                for (int p = 0; p < gameAreaWidth; p++)
                { gameArea[i] += " "; }
            }

            // Main Body
            do
            {
                while (Console.KeyAvailable == false)
                {
                    //Handle Input
                    switch (playerInput.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                if (playerPosition > 0)
                                { playerPosition--; }
                                playerInput = new ConsoleKeyInfo();
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (playerPosition < gameAreaWidth - playerCharacter.Length)
                                { playerPosition++; }
                                playerInput = new ConsoleKeyInfo();
                                break;
                            }
                        default: break;
                    }
                    //END INPUT

                    //UPDATE PLAYER ROW
                    playerRow = GeneratePlayerRow(playerPosition, gameAreaWidth, playerCharacter);
                    //CheckCollision
                    playerCollision = CheckCollision(playerPosition, gameArea[gameArea.Length - 1]);
                    //Shift Game Area down
                    gameArea = ShiftGameArea(gameArea);
                    //GenerateNewTopRow
                    gameArea[0] = GenerateNewGameRow(gameAreaWidth);
                    playerScore++;

                    //TEST
                    Console.Clear();
                    for (int i = 0; i < gameArea.Length; i++)
                    { Console.WriteLine(gameArea[i]); }
                    Console.WriteLine(playerRow);
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(" SCORE: {0, 4:D4}", playerScore);

                    Thread.Sleep(175);
                }

                playerInput = Console.ReadKey(true);
                //Pause Button
                if ( playerInput.Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("         Press ENTER to continue");
                    Console.ReadLine();
                }
            } while (playerInput.Key != ConsoleKey.X);


        }

        static string GeneratePlayerRow(int playerPos, int areaWidth, string Character)
        {
            string currentRow = "";

            for (int i = 0; i < areaWidth; i++)
            {
                if (i == playerPos)
                { currentRow += Character; }
                else
                { currentRow += " "; }
            }

            return currentRow;
        }

        static bool CheckCollision(int playerPos, string gameBottomRow)
        {
            bool collision = false;

            for (int i = playerPos; i < playerPos + 2; i++)
            {
                if (gameBottomRow.ElementAt(i).ToString() != " ")
                {
                    collision = true;
                    Console.WriteLine("   Press ENTER to try again! ESC to Exit");
                    ConsoleKeyInfo continueKey = Console.ReadKey(true);
                    switch (continueKey.Key)
                    {
                        case ConsoleKey.Enter:
                            FallingRocksv2.FalllingRocks.Main();
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        default:
                            FallingRocksv2.FalllingRocks.Main();
                            break;}
                    
                }
            }

            return collision;
        }

        static string[] ShiftGameArea(string[] CurrentGameArea)
        {

            for (int i = CurrentGameArea.Length - 1; i > 0; i--)
            {
                CurrentGameArea[i] = CurrentGameArea[i - 1];
            }

            return CurrentGameArea;
        }

        static string GenerateNewGameRow(int AreaWidth)
        {
            Random randomRock = new Random();

            string possibleRocks = "^@*&+%$#!.;-";
            string newRow = "";
            //generate rock positions
            int[] posRocks = new int[randomRock.Next(0, 3)];
            for (int i = 0; i < posRocks.Length; i++)
            { posRocks[i] = randomRock.Next(1, AreaWidth); }


            bool rockPrint = false;
            for (int i = 0; i < AreaWidth+1; i++)
            {
                for (int p = 0; p < posRocks.Length; p++)
                {
                    if (posRocks[p] == i)
                    {
                        rockPrint = true;
                        newRow = newRow + possibleRocks.ElementAt
                            (randomRock.Next(1, possibleRocks.Length)).ToString();
                    }
                 }
                if (rockPrint!=true)
                {
                    newRow = newRow + " ";
                }
                rockPrint = false;
            }

            return newRow;
        }
    }
}
