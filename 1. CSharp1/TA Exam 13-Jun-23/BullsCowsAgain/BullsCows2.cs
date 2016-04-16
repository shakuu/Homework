using System;
using System.Linq;

namespace BullsCowsAgain
{
    class BullsCows2
    {
        //create each digit will have a Bull/Cow flag
        public class Digits
        {
            public char Value;
            public bool isBull = false;
            public bool isCow = false;
            //get value from char
            public Digits(char cVal)
            {
                this.Value = cVal;
            }
            //get value from string
            public Digits(string cStr, int cPos)
            {
                this.Value = cStr[cPos];
            }
        }

        static void Main()
        {
            //get the secretNumber input
            string secretNumberInput = Console.ReadLine();
            //get req bulls and cows
            int inputBulls = int.Parse(Console.ReadLine());
            int inputCows = int.Parse(Console.ReadLine());
            //no zeroes
            string toGuess = "1111";
            //convert input to Digits Array
            Digits[] secretNumber = new Digits[secretNumberInput.Length];
            for (int i = 0; i < secretNumberInput.Length; i++)
            {
                secretNumber[i] = new Digits(secretNumberInput[i]);
            }
            //bulls/ cows Counters
            int currBulls; int currCows;
            // output no
            bool foundMatch = false;
            while (toGuess != "11111")
            {
                //reset Counters
                currBulls = 0;
                currCows = 0;
                //flag secret number to False
                foreach (Digits digit in secretNumber)
                {
                    digit.isBull = false;
                    digit.isCow = false;
                }
                //get the current number
                Digits[] currGuess = new Digits[toGuess.Length];
                for (int i = 0; i < toGuess.Length; i++)
                {
                    currGuess[i] = new Digits(toGuess[i]);
                }
                //check for bulls
                for (int i = 0; i < secretNumber.Length; i++)
                {
                    if (secretNumber[i].Value
                        == currGuess[i].Value)
                    {
                        currGuess[i].isBull = true;
                        secretNumber[i].isBull = true;
                        currBulls++;
                    }
                }
                //check for cows
                for (int secretIndex = 0;
                    secretIndex < secretNumber.Length; secretIndex++)
                {
                    for (int guessIndex = 0;
                        guessIndex < currGuess.Length; guessIndex++)
                    {
                        if (secretNumber[secretIndex].Value
                            == currGuess[guessIndex].Value
                            && secretNumber[secretIndex].isBull == false
                            && secretNumber[secretIndex].isCow == false
                            && currGuess[guessIndex].isBull == false
                            && currGuess[guessIndex].isCow == false)
                        {
                            secretNumber[secretIndex].isCow = true;
                            currGuess[guessIndex].isCow = true;
                            currCows++;
                        }
                    }
                }
                //Found a number ? 
                if (currBulls == inputBulls
                    && currCows == inputCows)
                {
                    Console.Write(toGuess + " ");
                    foundMatch = true;
                }
                //increment toGuess
                toGuess = (Convert.ToInt32(toGuess) + 1).ToString();
                while (toGuess.Contains('0'))
                {
                    toGuess = toGuess.Replace('0', '1');
                }
            }
            if ( !foundMatch)
            {
                Console.Write("No");
            }
        }
    }
}
