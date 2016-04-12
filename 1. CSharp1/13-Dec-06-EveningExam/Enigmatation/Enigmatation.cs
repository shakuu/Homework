using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//1+2+3+(4+5+6)+7+8+9
namespace Enigmatation
{
    class Enigmatation
    {
        static void Main()
        {
            string inputString = Console.ReadLine();

            string currResult = "";
            int currStringIndex = 0;
            int currStringLength = 0;

            while (inputString.Contains("(") 
                && inputString.Contains(")"))
            {
                currResult = "";

                currStringIndex = inputString.IndexOf("(");
                currStringLength = inputString.IndexOf(")")
                     - inputString.IndexOf("(") + 1;

                currResult = Solve(inputString.Substring(
                    currStringIndex, currStringLength));

                inputString = inputString.Remove
                    (currStringIndex, currStringLength);
                inputString = inputString.Insert
                    (currStringIndex, currResult);
                
            }

            //test
            Console.WriteLine(inputString);
 
        }

        public static string Solve(string currString)
        {
            //REMOVE BRACKETS
            currString = currString.Remove(0, 1);
            currString = currString.Remove(currString.Length - 1, 1);

            double result = 0;
            string[] splitSeparators = new string[] 
            { "+", "-", "%", "*", "(", ")" };
            string[] Numbers = currString.Split(splitSeparators,
                StringSplitOptions.RemoveEmptyEntries);
            string[] Operators = currString.Split(Numbers, 
                StringSplitOptions.RemoveEmptyEntries);

            result = Convert.ToDouble(Numbers[0]);

            for(int i = 1; i< Numbers.Length;i++)
            {
                switch(Operators[i-1])
                {
                    case "+":
                        result += Convert.ToDouble(Numbers[i]);
                        break;
                    case "-":
                        result -= Convert.ToDouble(Numbers[i]);
                        break;
                    case "%":
                        result %= Convert.ToDouble(Numbers[i]);
                        break;
                    case "*":
                        result *= Convert.ToDouble(Numbers[i]);
                        break;
                }

            }
            return result.ToString();
        }
    }
}
