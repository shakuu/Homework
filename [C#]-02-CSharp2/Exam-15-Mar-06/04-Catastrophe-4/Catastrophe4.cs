
namespace _04_Catastrophe_4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Catastrophe4
    {
        // 60/ 100
        // Stuff to look for
        // REMOE VAR
        static string[] Types = @"string, int, sbyte, byte, 
                                  short, ushort, uint, long,
                                  ulong, float, double, decimal, 
                                  bool, char, int?, sbyte?, byte?, 
                                  short?, ushort?, uint?, long?,
                                  ulong?, float?, double?, decimal?, 
                                  bool?, char?"
            .Split(new[] { ' ', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        static string[] Conditionals = "if, else"
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        static string[] Loops = "for, while, foreach"
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        static string[] Methods = "static"
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        static string[] Skips = "do, switch"
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        static string[] EndOfScope = "}, } while"
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        // Containers, counters and helpers
        static List<List<string>> ListContainer = new List<List<string>>();

        static List<string> MethodsContainer = new List<string>();
        static List<string> LoopsContainer = new List<string>();
        static List<string> ConditionalContainer = new List<string>();
        static List<string> SkipContainer = new List<string>();

        static int MethodIndex = 0;
        static int LoopIndex = 1;
        static int ConditionIndex = 2;
        static int SkipIndex = 3;

        static int RowCounter = 1;
        static int rowsToRead = 0;

        static void Main(string[] args)
        {
            // Ease of access
            ListContainer.Add(MethodsContainer);
            ListContainer.Add(LoopsContainer);
            ListContainer.Add(ConditionalContainer);
            ListContainer.Add(SkipContainer);

            rowsToRead = int.Parse(Console.ReadLine());

            ////////////////////////////////

            // Store previous scopes to revert to
            var prevScopes = new Stack<int>();

            var curScope = -1;
            var nextScope = -1;

            while (RowCounter < rowsToRead)
            {
                var curLine = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ', '(', ')' })
                    .ToArray();

                ++RowCounter;

                // On { -> New Scope
                if (curLine[0] == "{")
                {
                    prevScopes.Push(curScope);
                    curScope = nextScope;
                }

                if (curLine[0] == "}")
                {
                    curScope = prevScopes.Pop();
                }
                // On } -> Scope Up
                // Ananlyze line -> extract vars
                // return next scope
                nextScope = ParseRow(curLine, curScope);
                if (nextScope >= 0)
                {
                    GetVariables(curLine, nextScope);
                }
            }

            // Outpu
            PrintOutput();
        }

        // Get Scope
        static int ParseRow(string[] curLine, int curScope)
        {
            // Step 1: Get Scope if any
            // Method -> first word static
            foreach (var method in Methods)
            {
                if (curLine[0] == method)
                {
                    return MethodIndex;
                }
            }

            foreach (var loop in Loops)
            {
                if (curLine[0] == loop)
                {
                    return LoopIndex;
                }
            }

            foreach (var condition in Conditionals)
            {
                if (curLine[0] == condition)
                {
                    return ConditionIndex;
                }
            }

            foreach (var skip in Skips)
            {
                if (curLine[0] == skip)
                {
                    return SkipIndex;
                }
            }

            return curScope;
            // Step 2: Get vars if applicable
            // Write them into the new scope
        }

        // Get Variables
        static void GetVariables(string[] curLine, int curScope)
        {
            var isType = false;
            var isComma = false;

            var endofname = ",;";

            // Check for method or loop/ condition
            var startat = 0;

            if (curLine[0] == "static")
            {
                startat = 3;
            }

            // Find Variables
            for (int curElement = startat;
                     curElement < curLine.Length;
                     curElement++)
            {
                var curValue = curLine[curElement];

                if (curValue == "") continue;

                if (Types.Contains(curValue))
                {
                    isType = true;
                }
                else if (isType)
                {
                    if (curValue == "?")
                    {
                        continue;
                    }

                    // Check for array
                    if (!isArray(curValue))
                    {
                        var strLength = curValue.Length;

                        if (!char.IsLetter(curValue[curValue.Length - 1])) strLength--;

                        ListContainer[curScope].Add(curValue.Substring(0, strLength));
                    }

                    if (curValue[curValue.Length - 1] == ',')
                    {
                        isComma = true;
                    }

                    isType = false;
                }
                else if ((!isType && isComma))
                {
                    // Check for array
                    if (!isArray(curValue))
                    {
                        var strLength = curValue.Length;

                        if (!char.IsLetter(curValue[curValue.Length - 1])) strLength--;

                        ListContainer[curScope].Add(curValue.Substring(0, strLength));
                    }

                    if (curValue[curValue.Length - 1] == ',')
                    {
                        isComma = true;
                    }
                    else
                    {
                        isComma = false;
                    }
                }

            }
        }

        // check if declaring array
        static bool isArray(string Element)
        {
            var notAllowed = "[";

            foreach (var chr in Element)
            {
                if (notAllowed.Contains(chr))
                {
                    return true;
                }
            }

            return false;
        }

        // Print output.
        static void PrintOutput()
        {
            var Names = new string[]
            {
                "Methods",
                "Loops",
                "Conditional Statements",
            };

            var Format = new string[]
            {
                "{0} -> {1} -> {2}",
                "{0} -> None"
            };

            for (int i = 0; i < 3; i++)
            {
                if (ListContainer[i].Count() > 0)
                {
                    Console.WriteLine(
                        Format[0],
                        Names[i],
                        ListContainer[i].Count(),
                        string.Join(", ", ListContainer[i]));
                }
                else
                {
                    Console.WriteLine(Format[1], Names[i]);
                }
            }
        }
    }
}
