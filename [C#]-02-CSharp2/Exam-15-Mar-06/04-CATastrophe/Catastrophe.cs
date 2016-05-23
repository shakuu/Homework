
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

        static string[] PrimitiveDataTypes = "sbyte ,byte ,short ,ushort ,int ,uint ,long ,ulong ,float ,double ,decimal ,bool ,char ,string ,int? "
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        // only methods are static by definition
        // therefore no variables outside of methods
        static string[] ConditionalStatements = "if ,else "
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        static string[] Loops = "while ,for ,foreach "
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        static string[] toSkip = "do ,switch "
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        static string MethodIdendtifier = "static ";

        static List<List<string>> ListsContainer = new List<List<string>>();

        static List<string> conditionVars = new List<string>();
        static List<string> methodVars = new List<string>();
        static List<string> loopVars = new List<string>();
        static List<string> SkipVars = new List<string>();

        static int numberOfRows;

        static void Main()
        {
            // MAIN SKIPPED BLOCKS -> Switch - DO WHile, additional curly brackets
            //  EMTPY READ , to skip the curly brackets

            ListsContainer.Add(methodVars);
            ListsContainer.Add(loopVars);
            ListsContainer.Add(conditionVars);
            ListsContainer.Add(SkipVars);

            var modifiers = "public, private, internal, protected"
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            // Input
            numberOfRows = int.Parse(Console.ReadLine());

            for (RowsRead = 0; RowsRead < numberOfRows; RowsRead++)
            {
                var currentRowOfCode = Console.ReadLine();

                var isMethod = false;

                if (currentRowOfCode.Contains(MethodIdendtifier))
                {
                    isMethod = true;

                    foreach (var mod in modifiers)
                    {
                        if (currentRowOfCode.Contains(mod))
                        {
                            isMethod = false;
                        }
                    }

                    //CheckCurrentLineForVariables(currentRowOfCode);
                    // NEED A SEPARATE METHOD FOR READING VARS OUT OF METHODs
                    if (isMethod)
                    {
                        CheckCurrentLineForVariables(GetArgsInBrackets(currentRowOfCode), 0);
                        ParseText(0);
                    }
                }
            }

            // Output
            if (methodVars.Count() > 0)
            {
                Console.WriteLine("Methods -> {0} -> {1}",
                methodVars.Count(), string.Join(", ", methodVars));
            }
            else
            {
                Console.WriteLine("Methods -> None");
            }

            if (loopVars.Count > 0)
            {
                Console.WriteLine("Loops -> {0} -> {1}",
                loopVars.Count(), string.Join(", ", loopVars));
            }
            else
            {
                Console.WriteLine("Loops -> None");
            }

            if (conditionVars.Count() > 0)
            {
                Console.WriteLine("Conditional Statements -> {0} -> {1}",
                conditionVars.Count(), string.Join(", ", conditionVars));
            }
            else
            {
                Console.WriteLine("Conditional Statements -> None");
            }
        }

        static void ParseText(int AddToContainerIndex)
        {
            // Recursively parse each block of code 

            while (true)
            {
                if (RowsRead == numberOfRows - 1)
                {
                    break;
                }

                var curLine = Console.ReadLine();
                RowsRead++;

                var isChecked = false;

                // Break on End of current block of code
                if (curLine.Trim() == "}" || curLine.Contains("} while") )
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
                        CheckCurrentLineForVariables(curLine, 2);
                        isChecked = true;
                        ParseText(2);
                        break;
                    }

                }
                
                // Check for loops.
                foreach (var loop in Loops)
                {
                    if (curLine.Contains(loop))
                    {
                        CheckCurrentLineForVariables(curLine, 1);
                        isChecked = true;
                        ParseText(1);
                        break;
                    }
                }

                Check for skips.
                foreach (var skip in toSkip)
                    {
                        if (curLine.Contains(skip))
                        {
                            isChecked = true;
                            ParseText(3);
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

            var curPosition = LineOfCode.IndexOf(DataType) + DataType.Length;

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
