using System;
using System.Linq;

namespace Balls
{
    public class Balls
    {
        public static void Main()
        {
            var possibleTakeList = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => -x).ToArray();
            var possibleBallsCount = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var possibleTakeCount = possibleTakeList.Length;

            var firstPlayerWins = 0;
            for (int ballCount = possibleBallsCount[0]; ballCount <= possibleBallsCount[1]; ballCount++)
            {
                var currentGameBallsCount = ballCount;

                var currentTakeIndex = 0;
                var isFirstPlayersTurn = true;
                while (true)
                {
                    var maximumPossibleTake = possibleTakeList[currentTakeIndex];
                    while (maximumPossibleTake > currentGameBallsCount)
                    {
                        currentTakeIndex++;
                        maximumPossibleTake = possibleTakeList[currentTakeIndex];
                    }

                    if (currentGameBallsCount - maximumPossibleTake == 1 && currentTakeIndex < possibleTakeCount - 1)
                    {
                        currentTakeIndex++;
                        maximumPossibleTake = possibleTakeList[currentTakeIndex];
                    }

                    currentGameBallsCount -= maximumPossibleTake;
                    if (currentGameBallsCount == 0)
                    {
                        if (isFirstPlayersTurn)
                        {
                            firstPlayerWins++;
                        }

                        break;
                    }

                    isFirstPlayersTurn = !isFirstPlayersTurn;
                }
            }

            Console.WriteLine(firstPlayerWins);
        }
    }
}
