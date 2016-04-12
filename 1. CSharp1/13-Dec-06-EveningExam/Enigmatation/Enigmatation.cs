using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//1+2+3+(4+5+6)+7+8+9
namespace Enigmatation
{
    class Enigmatation
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string currResult = "";
            int currStringIndex = 0;
            int currStringLength = 0;

            //remove =
            List<string> InputStrings = new List<string>();
            while (input.Contains("="))
            {
                InputStrings.Add(input.Substring(0,
                    input.IndexOf("=")));
                input = input.Remove(0, input.IndexOf("=")+1);
            }

            string currString;
            string overallResult = "0";
            foreach (string inputString in InputStrings)
            {
                currString = inputString;
                while (currString.Contains("(")
                    && currString.Contains(")"))
                {
                    currResult = "";

                    currStringIndex = inputString.IndexOf("(");
                    currStringLength = inputString.IndexOf(")")
                         - inputString.IndexOf("(") + 1;

                    currResult = Solve(currString.Substring(
                        currStringIndex, currStringLength));

                    currString = currString.Remove
                        (currStringIndex, currStringLength);
                    currString = currString.Insert
                        (currStringIndex, currResult);

                    //resolve +-
                    if (currString.Contains("+-"))
                    {
                        currString = currString.Remove
                            (currString.IndexOf("+-"), 1);
                    }
                    //resolve --
                    if (currString.Contains("--"))
                    {
                        currString = currString.Insert
                            (currString.IndexOf("--"), "+");
                        currString = inputString.Remove
                            (currString.IndexOf("--"), 2);
                    }

                }

                overallResult = (Convert.ToDouble( Solve(currString)) 
                    + Convert.ToDouble(overallResult)).ToString();
            }
            //test
            Console.WriteLine("{0,0:F3}", double.Parse(overallResult));

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
                    case "-":
                        result -= double.Parse(Numbers[i]);
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
