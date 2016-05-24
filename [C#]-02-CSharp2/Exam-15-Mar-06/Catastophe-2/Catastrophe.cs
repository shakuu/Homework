
namespace Catastophe_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Catastrophe
    {
        // Stuff to look for
        static string[] Types = @"string, int, sbyte, byte, 
                                  short, ushort, uint, long,
                                  ulong, float, double, decimal, 
                                  bool, char, int?, sbyte?, byte?, 
                                  short?, ushort?, uint?, long?,
                                  ulong?, float?, double?, decimal?, 
                                  bool?, char?"
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
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

            while (RowCounter < rowsToRead)
            {
                // Step 1: Read Lines until 
                // a new method.
                var curLine = Console.ReadLine();
                ++RowCounter;

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
                            ParseMethod(curLine, MethodIndex);
                        }
                    }

                    curIndex = curLine.IndexOf(method, ++curIndex);
                }

                // Check for new Block of Code
                if (curLine.Trim() == "{")
                {
                    // Parse a new block of code
                    ParseBlock(MethodIndex, false);
                }
            }
        }

        // TODO: Parse Block of code
        static void ParseBlock(int Scope, bool isSkip)
        {

            while (RowCounter < rowsToRead)
            {
                var curLine = Console.ReadLine();
                ++RowCounter;

                var isChecked = false;

                // On curly brackets - start a new block
                // or return a block up.
                if (curLine.Trim() == "{") ParseBlock(Scope, isSkip);
                if (curLine.Trim() == "}") return;

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
                            ParseMethod(curLine, LoopIndex);
                            Scope = LoopIndex;
                            isChecked = true;
                            isSkip = false;
                        }
                    }

                    curIndex = curLine.IndexOf(loop, ++curIndex);
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
                            ParseMethod(curLine, ConditionIndex);
                            Scope = ConditionIndex;
                            isChecked = true;
                            isSkip = false;
                        }
                    }

                    curIndex = curLine.IndexOf(condition, ++curIndex);
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
                            Scope = SkipIndex;
                            isChecked = true;
                            isSkip = true;
                        }
                    }

                    curIndex = curLine.IndexOf(skip, ++curIndex);
                }

                // if none of the above, extract all variables
                // from the current row.
                if (!isChecked)
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

        }

        // Extract arguments
        static string ParseMethod(string curLine, int Scope)
        {
            // Get string between brackets 
            // ( declaring arguments )

            var openBracket = curLine.IndexOf("(") + 1;
            var closeBracket = curLine.LastIndexOf(")");
            var length = closeBracket - openBracket;

            var toReturn = curLine.Substring(openBracket, length);

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

            if (curLine[curIndex - 1] == ' ' &&
                curLine[curIndex + length] == ' ')
            {
                return true;
            }
            else return false;
        }
    }
}
