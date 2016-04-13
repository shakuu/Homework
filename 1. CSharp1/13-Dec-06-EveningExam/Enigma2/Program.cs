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
            string inputString1 = Console.ReadLine();

            string currResult = "";
            int currStringIndex = 0;
            int currStringLength = 0;
            double total = 0;
            // test get different strings 
            string[] testStrings = inputString1.Split('=');
            //foreach(string str in testStrings)
            //{
            //    Console.WriteLine(str);
            //}
            // return;
            //end test

            //get string up to first = 
            //if (inputString.Contains("="))
            //{
            //    inputString = inputString.Substring(0,
            //        inputString.IndexOf("="));
            //}
            string inputString = "";
            foreach (string str in testStrings)
            {

                inputString = str;

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

                if (inputString != "")
                {
                    currResult = Solve(inputString);
                    total += double.Parse(currResult);
                }
            }
            //test
            Console.WriteLine("{0,0:F3}", double.Parse(currResult));

        }

        public static string Solve(string currString)
        {
            //REMOVE BRACKETS
            if (currString.Contains("("))
            {
                currString = currString.Remove(0, 1);
                currString = currString.Remove(currString.Length - 1, 1);
            }

            double result = 0;
            string[] splitSeparators = new string[]
            { "+", "-", "%", "*", "(", ")" };
            string[] Numbers = currString.Split(splitSeparators,
                StringSplitOptions.RemoveEmptyEntries);
            string[] Operators = currString.Split(Numbers,
                StringSplitOptions.RemoveEmptyEntries);

            int operatorMod = 1;
            result = double.Parse(Numbers[0]);
            if (currString.Substring(0, 1) == "-")
            {
                result = -result;
                operatorMod = 0;
            }

            for (int i = 1; i < Numbers.Length; i++)
            {
                switch (Operators[i - operatorMod])
                {
                    case "+":
                        result += double.Parse(Numbers[i]);
                        break;
                    case "+-":
                        result -= double.Parse(Numbers[i]);
                        break;
                    case "-":
                        result -= double.Parse(Numbers[i]);
                        break;
                    case "--":
                        result += double.Parse(Numbers[i]);
                        break;
                    case "%":
                        result %= double.Parse(Numbers[i]);
                        break;
                    case "*":
                        result *= double.Parse(Numbers[i]);
                        break;
                    case "*-":
                        result *= -(double.Parse(Numbers[i]));
                        break;
                    case "%-":
                        result %= -(double.Parse(Numbers[i]));
                        if (result < 0) { result = Math.Abs(result); }
                        break;
                }

            }
            return result.ToString();
        }
    }
}
