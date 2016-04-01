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
            //VARIABLES
            string[] gameArea = new string[15];
            string playerRow = "";
            string playerCharacter = "(0)";

            int gameAreaWidth = 15;
            int playerPosition = 7;
            bool playerCollision = false;

            ConsoleKeyInfo playerInput = new ConsoleKeyInfo();

            //Generate PlayerRow
            playerRow = GeneratePlayerRow(playerPosition, gameAreaWidth, playerCharacter);
            //and GameArea
            for ( int i = 0; i< gameArea.Length; i++)
            { gameArea[i] = ""; }

            // Main Body
            do 
            {
                while (Console.KeyAvailable == false)
                {
                   //Handle Input
                   switch ( playerInput.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                if ( playerPosition>1)
                                { playerPosition--; }
                                playerInput= new ConsoleKeyInfo();
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (playerPosition < gameAreaWidth-playerCharacter.Length)
                                { playerPosition++; }
                                playerInput = new ConsoleKeyInfo();
                                break;
                            }
                        default: break;}
                    //END INPUT

                    //UPDATE PLAYER ROW
                    playerRow = GeneratePlayerRow(playerPosition, gameAreaWidth, playerCharacter);

                    //TEST
                    Console.Clear();
                    Console.WriteLine(playerRow);

                    Thread.Sleep(150);
                }

                playerInput = Console.ReadKey(true);
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
    }
}
