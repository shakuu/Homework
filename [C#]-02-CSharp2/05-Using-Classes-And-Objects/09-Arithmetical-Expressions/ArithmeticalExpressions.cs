using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_Arithmetical_Expressions
{
    class ArithmeticalExpressions
    {
        // static Vars
        static List<string> OutputExpression = new List<string>();
        static List<string> OperatorStack = new List<string>();

        static string[] OperatorKey = "+ - * / %".Split(' ');

        static void Main()
        {
            // variables
            string toAdd = "";

            // input as string
            string InputExpression = Console.ReadLine()
                                            .ToLower();

            // iterate through the string
            for (int curElement = 0;
                curElement < InputExpression.Length;
                curElement++)
            {
                // reset
                toAdd = "";


                // if the current element is a digit
                // read the number
                if (InputExpression[curElement] >= '0' &&
                    InputExpression[curElement] <= '9')
                {
                    toAdd = ReadNumber(           // Read The Number
                              InputExpression,    //
                              curElement          //
                              );

                    OutputExpression.Add(toAdd);      // Add Numnber to output
                                                      //
                    curElement += toAdd.Length - 1;   // skip the length of the number

                    continue;
                }

                // If the cur element is a function
                if (char.IsLetter(InputExpression[curElement]))
                {
                    //TODO: Read Function
                    toAdd = ReadFunc(           // Read The Number
                              InputExpression,    //
                              curElement          //
                              );

                    OperatorStack.Add(toAdd);      // Add Numnber to output
                                                   //
                    curElement += toAdd.Length - 1;   // skip the length of the number

                    continue;
                }

                // Read Comma ( Func Argument separator )
                if (InputExpression[curElement] == ',')
                {
                    // TODO: Read Operators off the stack
                    // till opening parenthesis
                }

                // if current element is an operator 
                if (OperatorKey.Contains(
                        InputExpression[curElement].ToString()))
                {
                    ReadOperator(InputExpression[curElement].ToString());

                    continue;
                }

                // if Opening Parenthesis
                if (InputExpression[curElement] == '(')
                {
                    OperatorStack.Add(InputExpression[curElement].ToString());

                    continue;
                }

                // if closing Parenthesis
                if (InputExpression[curElement] == ')')
                {
                    ClosingParenthesis();
                    continue;
                }
            }
        }

        // Read A Number
        public static string ReadNumber
            (
                string InputExpression,
                int StartPosition
            )
        {
            string toReturn = "";

            for (int curElement = StartPosition;
                curElement < InputExpression.Length;
                curElement++)
            {
                if ((InputExpression[curElement] >= '0' &&      // if current element is
                     InputExpression[curElement] <= '9') ||     // a digit or a float DOT
                     InputExpression[curElement] == '.')        // add to the string
                {
                    toReturn += InputExpression[curElement];
                }                                               // else break
                else                                            // and return
                {
                    break;
                }
            }

            // Output
            return toReturn;
        }

        // Read An Operator
        public static void ReadOperator(string curOperator)
        {
            // if the stack is empty
            // add the new Operator and return
            if (OperatorStack.Count() == 0)
            {
                OperatorStack.Add(curOperator);
                return;
            }

            // iterate through OperatorStack
            // starting at the top ( end ) 
            for (int curElement = OperatorStack.Count() - 1;
                     curElement >= 0;
                     curElement--)
            {
                // Check Precedence 
                // by checking index in the Operator Key
                // index 0 1 -> + - , index 2-4 -> * / %
                if (Array.IndexOf(OperatorKey, curOperator) >= 2 &&
                    Array.IndexOf(OperatorKey, OperatorStack[curElement]) < 2)

                {
                    OperatorStack.Add(curOperator);
                    return;
                }
                else
                {
                    // TODO: If NOT Open Parenthesis 
                    if (OperatorStack[curElement] == "(")
                    {
                        OperatorStack.Add(curOperator);
                        return;
                    }
                    // TODO: If NOT a Function
                    if (char.IsLetter(OperatorStack[curElement][0]))
                    {
                        OperatorStack.Add(curOperator);
                        return;
                    }

                    OutputExpression.Add(OperatorStack[curElement]);
                    OperatorStack.RemoveAt(curElement);

                    if (OperatorStack.Count() == 0)     // case all previous
                    {                                   // operators are 
                        OperatorStack.Add(curOperator); // removed
                        return;                         //
                    }
                }
            }
        }

        // Read Closing Parenthesis ) 
        public static void ClosingParenthesis()
        {
            // TODO: Error Handling
            // 1. Empty Stack
            // 2. Opening Parenthesis NOT found


            // read Operators off the stack till 
            // the Opening Parenthsis ( 
            for (int curElement = OperatorStack.Count() - 1;
                     curElement >= 0;
                     curElement--)
            {
                if (OperatorStack[curElement] != "(")
                {
                    OutputExpression.Add(OperatorStack[curElement]);
                    OperatorStack.RemoveAt(curElement);

                    continue;
                }

                if (OperatorStack[curElement] == "(")
                {
                    OperatorStack.RemoveAt(curElement);
                    break;
                }
            }

            // TODO: If the next element in the stack is a FUNC
            // add the FUNC to the OutputExpression
            if (OperatorStack.Count() > 0)
            {
                if (char.IsLetter(OperatorStack[OperatorStack.Count() - 1][0]))
                {
                    OutputExpression.Add(
                        OperatorStack[OperatorStack.Count() - 1]
                        );

                    OperatorStack.RemoveAt(
                        OperatorStack.Count() - 1
                        );
                }
            }

            return;
        }

        // TODO: Read Function
        public static string ReadFunc(
                string InputExpression,
                int StartPosition
                )
        {
            string toReturn = "";

            for (int curLetter = StartPosition;
                     curLetter < InputExpression.Count();
                     curLetter++)
            {
                // if letter keep reading
                if (char.IsLetter(InputExpression[curLetter]))
                {
                    toReturn += InputExpression[curLetter];

                    continue;
                }
                else
                {
                    break;
                }
            }


            return toReturn;
        }

        // TODO: Read Comma
        public static void ReadComma()
        {
            // TODO: ERRORS
            // 1. Empty Stack
            // 2. No opening parenthesis found

            for (int curElement = OperatorStack.Count() - 1; 
                     curElement >= 0; 
                     curElement--)
            {
                // Add Operators to Output Expression
                // Until the next operator is (
                if (OperatorStack[curElement] != "(")
                {
                    OutputExpression.Add(OperatorStack[curElement]);
                    OperatorStack.RemoveAt(curElement);

                    continue;
                }

                // If next Operator is ( -> break
                if (OperatorStack[curElement] == "(")
                {
                    break;
                }
            }
            
            return;
        }
    }
}
