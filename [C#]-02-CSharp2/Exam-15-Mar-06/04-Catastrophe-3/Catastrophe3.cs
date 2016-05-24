
namespace Catastophe_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Catastrophe3
    {
        // Stuff to look for
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

        static int RowCounter = 0;
        static int rowsToRead = 0;

        static void Main()
        {
            // Ease of access
            ListContainer.Add(MethodsContainer);
            ListContainer.Add(LoopsContainer);
            ListContainer.Add(ConditionalContainer);
            ListContainer.Add(SkipContainer);

            rowsToRead = int.Parse(Console.ReadLine());

            var Scope = -1;

            while (RowCounter < rowsToRead)
            {
                // Step 1: Read Lines until 
                // a new method.
                var curLine = Console.ReadLine();
                ++RowCounter;

                if (curLine == "") continue;

                // Check for method
                foreach (var method in Methods)
                {
                    var curIndex = curLine.IndexOf(method);

                    while (curIndex >= 0)
                    {
                        // Check if the current string
                        // is a separarte statement.
                        if (isWord(curLine, method, curIndex))
                        {
                            // Parse the text
                            Scope = MethodIndex;
                        }

                        curIndex = curLine.IndexOf(method, ++curIndex);
                    }
                }

                // Check for Loops
                foreach (var loop in Loops)
                {
                    var curIndex = curLine.IndexOf(loop);

                    while (curIndex >= 0)
                    {
                        // Check if the current string
                        // is a separarte statement.
                        if (isWord(curLine, loop, curIndex))
                        {
                            // Parse the text
                            Scope = LoopIndex;
                        }

                        curIndex = curLine.IndexOf(loop, ++curIndex);
                    }
                }

                // Check for Conditionals
                foreach (var condition in Conditionals)
                {
                    var curIndex = curLine.IndexOf(condition);

                    while (curIndex >= 0)
                    {
                        // Check if the current string
                        // is a separarte statement.
                        if (isWord(curLine, condition, curIndex))
                        {
                            // Parse the text
                            Scope = ConditionIndex;
                        }

                        curIndex = curLine.IndexOf(condition, ++curIndex);
                    }
                }


                // Check for Skips
                foreach (var skip in Skips)
                {
                    var curIndex = curLine.IndexOf(skip);

                    while (curIndex >= 0)
                    {
                        // Check if the current string
                        // is a separarte statement.
                        if (isWord(curLine, skip, curIndex))
                        {
                            // Parse
                            Scope = SkipIndex;
                        }

                        curIndex = curLine.IndexOf(skip, ++curIndex);
                    }
                }

                // Parse the current line 
                // and add to to current scope.
            }

            // Output
            PrintOutput();
        }

        // TODO: Parse Block of code
        static void ParseBlock(int Scope, bool isSkip)
        {
            var nextScope = 0;

            while (RowCounter < rowsToRead)
            {
                var curLine = Console.ReadLine();
                ++RowCounter;

                // skip on empty.
                if (curLine == "") continue;

                var isChecked = false;

                // On curly brackets - start a new block
                // or return a block up.
                if (curLine.Trim() == "{") { ParseBlock(nextScope, isSkip); continue; }
                if (curLine.Trim() == "}") return;


                

                // if none of the above, extract all variables
                // from the current row.
                if (!isChecked && !isSkip)
                {
                    ExtractVars(curLine, Scope);
                }
            }

        }

        // TODO:
        // Extract declared variables 
        // and add them to the appropriate scope.
        static void ExtractVars(string curLine, int Scope)
        {
            foreach (var type in Types)
            {
                var curIndex = curLine.IndexOf(type);

                while (curIndex >= 0)
                {
                    if (isWord(curLine, type, curIndex))
                    {
                        // Extract name
                        var toAdd = ExtractName(curLine, curIndex);
                        // Add to List
                        ListContainer[Scope].Add(toAdd);
                    }

                    curIndex = curLine.IndexOf(type, ++curIndex);
                }
            }
        }

        // Extract Name
        static string ExtractName(string curLine, int curIndex)
        {
            var toCheck = string.Format("^{0}$", curLine.Substring(curIndex));

            var name = new StringBuilder();

            var separators = " $=,".ToCharArray();

            var write = false;

            foreach (var symbol in toCheck)
            {
                if (!write && symbol == ' ')
                {
                    write = true;
                }
                else if (write && separators.Contains(symbol))
                {
                    break;
                }
                else if (write)
                {
                    name.Append(symbol);
                }
            }

            return name.ToString();
        }

        // Extract arguments
        static string ParseMethod(string curLine, int Scope)
        {
            // Get string between brackets 
            // ( declaring arguments )

            var openBracket = curLine.IndexOf("(");
            var closeBracket = curLine.LastIndexOf(")");
            var length = closeBracket - (openBracket + 1);

            if (openBracket < 0 && closeBracket < 0) return "";

            var toReturn = curLine.Substring(openBracket + 1, length);

            return toReturn;
        }

        // Helper Method to check if a statement is
        // a separate word.
        static bool isWord(string curLine,
                           string toFind,
                           int curIndex)
        {
            // To avoid exception checks
            var toCheck = string.Format("^{0}$", curLine);
            var length = toFind.Length;

            if ((toCheck[curIndex] == ' ' || toCheck[curIndex] == '^') &&
                (toCheck[curIndex + length + 1] == ' ' || toCheck[curIndex + length + 1] == '$'))
            {
                return true;
            }

            if (toCheck == string.Format("^{0}$", curLine.Substring(curIndex, length)))
            {
                return true;
            }

            else return false;
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
