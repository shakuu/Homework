using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scopes
{
    class Program
    {
        static string[] primitiveDataTypes = new string[] { "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong", "float", "double", "decimal", "bool", "char", "string" };

        static List<string> methodVariables = new List<string>();

        static List<string> conditionalStatementsVariables = new List<string>();

        static List<string> loopsVariables = new List<string>();

        static bool CheckValidityOfToken(string token, int beforeIndex, int afterIndex)
        {
            if (beforeIndex < 0 && afterIndex >= token.Length)
            {
                return true;
            }

            if (beforeIndex < 0 && (!char.IsLetter(token[afterIndex]) || token[afterIndex] == '?' || token[afterIndex] == ','))
            {
                return true;
            }

            if (afterIndex >= token.Length && (!char.IsLetter(token[beforeIndex]) || token[beforeIndex] == '('))
            {
                return true;
            }

            if ((!char.IsLetter(token[beforeIndex]) || token[beforeIndex] == '(') && (!char.IsLetter(token[afterIndex]) || token[afterIndex] == '?' || token[afterIndex] == ','))
            {
                return true;
            }

            return false;
        }

        static string CalculateLatestScope(string currentToken)
        {
            var forKeyWordIndex = currentToken.IndexOf("for");
            if (forKeyWordIndex > -1 && currentToken.IndexOf("foreach") < 0 && CheckValidityOfToken(currentToken, forKeyWordIndex - 1, forKeyWordIndex + 3))
            {
                return "Loop";
            }

            var whileKeyWordIndex = currentToken.IndexOf("while");
            if (whileKeyWordIndex > -1 && CheckValidityOfToken(currentToken, whileKeyWordIndex - 1, whileKeyWordIndex + 5))
            {
                return "Loop";
            }

            var foreachKeyWordIndex = currentToken.IndexOf("foreach");
            if (foreachKeyWordIndex > -1 && CheckValidityOfToken(currentToken, foreachKeyWordIndex - 1, foreachKeyWordIndex + 7))
            {
                return "Loop";
            }

            var ifKeyWordIndex = currentToken.IndexOf("if");
            if (ifKeyWordIndex > -1 && CheckValidityOfToken(currentToken, ifKeyWordIndex - 1, ifKeyWordIndex + 2))
            {
                return "Conditional Statement";
            }

            var elseKeyWordIndex = currentToken.IndexOf("else");
            if (elseKeyWordIndex > -1 && CheckValidityOfToken(currentToken, elseKeyWordIndex - 1, elseKeyWordIndex + 4))
            {
                return "Conditional Statement";
            }

            return null;
        }

        static void AddFoundVariable(string variable, string scope)
        {
            switch (scope)
            {
                case "Loop": loopsVariables.Add(variable); return;
                case "Conditional Statement": conditionalStatementsVariables.Add(variable); return;
                default: methodVariables.Add(variable); return;
            }
        }

        static bool CheckSpecialCases(char symbol)
        {
            if ((symbol != '>' && symbol != ')' && symbol != '(' && symbol != '[' && symbol != '.') || symbol == '?')
            {
                return true;
            }

            return false;
        }

        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            int openBrackets = 0;
            bool doNotAddScope = false;

            List<string> scopes = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                var currentLineTokens = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < currentLineTokens.Length; j++)
                {
                    var currentToken = currentLineTokens[j];
                    if (currentToken == "namespace")
                    {
                        openBrackets--;
                    }

                    if (currentToken.IndexOf("{") > -1)
                    {
                        openBrackets++;
                        if (openBrackets == 1 || openBrackets == 2)
                        {
                            scopes.Add("Method");
                        }
                        else
                        {
                            if (doNotAddScope)
                            {
                                doNotAddScope = false;
                            }
                            else
                            {
                                scopes.Add(string.Empty);
                            }
                        }
                    }

                    if (currentToken.IndexOf("}") > -1)
                    {
                        openBrackets--;
                        scopes.RemoveAt(scopes.Count - 1);
                    }

                    var checkForNewLatestScope = CalculateLatestScope(currentToken);
                    if (!string.IsNullOrEmpty(checkForNewLatestScope))
                    {
                        scopes.Add(checkForNewLatestScope);
                        doNotAddScope = true;
                    }

                    foreach (var dataType in primitiveDataTypes)
                    {
                        var indexOfDataType = currentToken.IndexOf(dataType);
                        if (indexOfDataType > -1 && CheckValidityOfToken(currentToken, indexOfDataType - 1, indexOfDataType + dataType.Length))
                        {
                            if (j + 1 < currentLineTokens.Length)
                            {
                                var nextTokenFirstSymbol = currentLineTokens[j + 1][0];

                                if (indexOfDataType + dataType.Length < currentToken.Length)
                                {
                                    if (!CheckSpecialCases(currentToken[indexOfDataType + dataType.Length]))
                                    {
                                        continue;
                                    }
                                }

                                if (j - 1 >= 0)
                                {
                                    if (currentLineTokens[j - 1] == "static")
                                    {
                                        continue;
                                    }
                                }

                                if (CheckSpecialCases(nextTokenFirstSymbol))
                                {
                                    string variableName;
                                    if (nextTokenFirstSymbol != '?')
                                    {
                                        variableName = currentLineTokens[j + 1];
                                    }
                                    else
                                    {
                                        variableName = currentLineTokens[j + 2];
                                    }

                                    for (int k = 0; k < variableName.Length; k++)
                                    {
                                        if (!char.IsLetter(variableName[k]))
                                        {
                                            variableName = variableName.Substring(0, k);
                                        }
                                    }

                                    for (int index = scopes.Count - 1; index >= 0; index--)
                                    {
                                        if (scopes[index] != string.Empty)
                                        {
                                            if (!string.IsNullOrWhiteSpace(variableName))
                                            {
                                                AddFoundVariable(variableName, scopes[index]);
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.Write("Methods -> ");
            Console.WriteLine(methodVariables.Count > 0 ? methodVariables.Count + " -> " + string.Join(", ", methodVariables) : "None");
            Console.Write("Loops -> ");
            Console.WriteLine(loopsVariables.Count > 0 ? loopsVariables.Count + " -> " + string.Join(", ", loopsVariables) : "None");
            Console.Write("Conditional Statements -> ");
            Console.WriteLine(conditionalStatementsVariables.Count > 0 ? conditionalStatementsVariables.Count + " -> " + string.Join(", ", conditionalStatementsVariables) : "None");
        }
    }
}
