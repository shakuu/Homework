
namespace _04_CATastrophe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Catastrophe
    {
        static int RowsRead = 0;

        static string[] PrimitiveDataTypes = "sbyte, byte, short, ushort, int, uint, long, ulong, float, double, decimal, bool, char, string"
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        // only methods are static by definition
        // therefore no variables outside of methods
        static string[] ConditionalStatements = "if, else"
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        static string[] Loops = "while, for, foreach"
            .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        static string MethodIdendtifier = "static";

        static List<List<string>> ListsContainer = new List<List<string>>();

        static List<string> conditionVars = new List<string>();
        static List<string> methodVars = new List<string>();
        static List<string> loopVars = new List<string>();


        static void Main()
        {

            ListsContainer.Add(methodVars);
            ListsContainer.Add(conditionVars);
            ListsContainer.Add(loopVars);

            // Input
            var numberOfRows = int.Parse(Console.ReadLine());

            for (RowsRead = 0; RowsRead < numberOfRows; RowsRead++)
            {
                var currentRowOfCode = Console.ReadLine().Trim();

                if (currentRowOfCode.Contains(MethodIdendtifier))
                {
                    //CheckCurrentLineForVariables(currentRowOfCode);
                    // NEED A SEPARATE METHOD FOR READING VARS OUT OF METHODs
                    CheckCurrentLineForVariables(GetArgsInBrackets(currentRowOfCode), 0);
                    ParseText(0);
                }
            }
        }

        static void ParseText(int AddToContainerIndex)
        {
            // Recursively parse each block of code 

            while (true)
            {
                var curLine = Console.ReadLine().Trim();
                RowsRead++;

                var isChecked = false;

                // Break on End of current block of code
                if (curLine == "}")
                {
                    break;
                }

                if (curLine.Contains("{") || curLine == "")
                {
                    // no need to check
                    continue;
                }
                // Check for Condition
                foreach (var condition in ConditionalStatements)
                {
                    if (curLine.Contains(condition))
                    {
                        CheckCurrentLineForVariables(curLine, 1);
                        isChecked = true;
                        ParseText(1);
                        break;
                    }

                }

                // Check for loops.
                foreach (var loop in Loops)
                {
                    if (curLine.Contains(loop))
                    {
                        CheckCurrentLineForVariables(curLine, 2);
                        isChecked = true;
                        ParseText(2);
                        break;
                    }
                }

                // If it's not a new block of code
                // check for newly declared variables
                if (!isChecked)
                {
                    CheckCurrentLineForVariables(curLine, AddToContainerIndex);
                }
            }
        }

        // Method Row, Extract Arguments between brackets
        static string GetArgsInBrackets(string curLine)
        {
            var firstOpenBrackets = curLine.IndexOf("(");
            var lastCloseBrackets = curLine.LastIndexOf(")");

            return curLine.Substring(firstOpenBrackets, lastCloseBrackets - firstOpenBrackets + 1);
        }

        static void CheckCurrentLineForVariables(string curLine, int AddToContainerIndex)
        {
            foreach (var type in PrimitiveDataTypes)
            {
                var indextOfCurType = curLine.IndexOf(type);

                while (indextOfCurType >= 0)
                {
                    // find the name 
                    var curVarName = ParseVarName(curLine.Substring(indextOfCurType), type);

                    // TODO: CASE EMPTY ( found an array)
                    if (curVarName != string.Empty)
                    {
                        ListsContainer[AddToContainerIndex].Add(curVarName);

                        //// add to each list
                        //if (isMethod)
                        //{
                        //    methodVars.Add(curVarName);
                        //}

                        //if (isCondition)
                        //{
                        //    conditionVars.Add(curVarName);
                        //}

                        //if (isLoop)
                        //{
                        //    loopVars.Add(curVarName);
                        //}
                    }

                    indextOfCurType = curLine.IndexOf(type, ++indextOfCurType);
                }
            }
        }

        // TODO: CASE ARRAY - return empty
        static string ParseVarName(string LineOfCode, string DataType)
        {
            var separators = " [=;,)".ToCharArray();

            var curPosition = LineOfCode.IndexOf(DataType) + DataType.Length + 1;

            if (LineOfCode[curPosition - 1] == '?')
            {
                curPosition++;
            }
            else if (LineOfCode[curPosition - 1] != ' ')
            {
                return string.Empty;
            }

            var varName = new StringBuilder();

            while (true)
            {
                varName.Append(LineOfCode[curPosition]);
                curPosition++;

                if (separators.Contains(LineOfCode[curPosition]))
                {
                    break;
                }
            }

            return varName.ToString();
        }
    }
}
