using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public Digits (char cVal)
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
            //no zeroes
            string toGuess = "1111";
            //convert input to Digits Array
            Digits[] secretNumber = new Digits[secretNumberInput.Length];
            for ( int i = 0; i< secretNumberInput.Length; i++)
            {
                secretNumber[i] = new Digits(secretNumberInput[i]);
            } 

            while (toGuess != "11111")
            {
                //flag secret number to False
                foreach(Digits digit in secretNumber)
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

                //increment toGuess
                toGuess = (Convert.ToInt32(toGuess) + 1).ToString();
                while (toGuess.Contains('0'))
                {
                    toGuess = toGuess.Replace('0', '1');
                }
            }
        }
    }
}
