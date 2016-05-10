using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

            // https://en.wikipedia.org/wiki/Shunting-yard_algorithm
            // Shunting Yard Algorithm
            // Step 1: Read the expression
            // iterate through the string
            for (int curElement = 0;
                curElement < InputExpression.Length;
                curElement++)
            {
                // avoid unnecessary checks down 
                // if the current char is empty space
                if (InputExpression[curElement] == ' ')
                {
                    continue;
                }

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
                    ReadComma();

                    continue;
                }

                // if current element is an operator 
                if (OperatorKey.Contains(
                        InputExpression[curElement].ToString()))
                {
                    // Is it a negative number ? 
                    if (InputExpression[curElement] == '-' &&
                        char.IsDigit(InputExpression[curElement + 1]))
                    {
                        toAdd = ReadNumber(           // Read The Number
                              InputExpression,        // after the MINUS
                              curElement + 1           //
                              );

                        toAdd = "-" + toAdd;          // Add the Minus 

                        OutputExpression.Add(toAdd);      // Add Numnber to output
                                                          //
                        curElement += toAdd.Length - 1;   // skip the length of the number

                        continue;
                    }
                    else // read an operator
                    {
                        ReadOperator(InputExpression[curElement].ToString());

                        continue;
                    }
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

            // Read any remaining Operators off the OperatorStack
            // Add them at the end of the OutputExpression
            FlushOperatorStack();

            //////////////////////////////////
            // Step 2: Evaluate the expression
            for (int curElement = 0;
                     curElement < OutputExpression.Count();
                     curElement++)
            {
                // If Operator
                if (OperatorKey.Contains(
                        OutputExpression[curElement].ToString()))
                {
                    curElement = EvaluateOperator(curElement); // returning the index of 
                                                               // the next element to check
                    continue;
                }

                // If Func
                if (char.IsLetter(OutputExpression[curElement][0]))
                {
                    // TODO: Evaluate Function
                    curElement = EvaluateFunction(curElement); // returning the index of 
                                                               // the next element to check
                    continue;
                }
            }

            // ouput
            Console.WriteLine(double.Parse(OutputExpression[0]).ToString("F2"));
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

        // Read Comma
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

        // Read Remaining Operators
        public static void FlushOperatorStack()
        {
            for (int curElement = OperatorStack.Count() - 1;
                     curElement >= 0;
                     curElement--)
            {
                OutputExpression.Add(OperatorStack[curElement]);
                OperatorStack.RemoveAt(curElement); // -> not necesary to remove them at this point
            }

            return;
        }

        // Eva;uate Operator
        public static int EvaluateOperator(int OperatorIndex)
        {
            // TODO: Possible Errors

            // Operator Key -> + - * / %
            if (Array.IndexOf( // Index 0 -> Add
                        OperatorKey,
                        OutputExpression[OperatorIndex].ToString()
                        )
                        == 0)
            {
                // Add the two preceeding elements
                OutputExpression[OperatorIndex - 2] =
                        ((double.Parse(OutputExpression[OperatorIndex - 2])) +
                         (double.Parse(OutputExpression[OperatorIndex - 1])))
                        .ToString();

                // remove the unnecessaty Elements
                OutputExpression.RemoveAt(OperatorIndex);
                OutputExpression.RemoveAt(OperatorIndex - 1);

                return OperatorIndex - 2;
            }

            if (Array.IndexOf( // Index 1 -> Subtract
                        OperatorKey,
                        OutputExpression[OperatorIndex].ToString()
                        )
                        == 1)
            {
                // Add the two preceeding elements
                OutputExpression[OperatorIndex - 2] =
                        ((double.Parse(OutputExpression[OperatorIndex - 2])) -
                         (double.Parse(OutputExpression[OperatorIndex - 1])))
                        .ToString();

                // remove the unnecessaty Elements
                OutputExpression.RemoveAt(OperatorIndex);
                OutputExpression.RemoveAt(OperatorIndex - 1);

                return OperatorIndex - 2;
            }

            if (Array.IndexOf( // Index 2 -> Multiply
                        OperatorKey,
                        OutputExpression[OperatorIndex].ToString()
                        )
                        == 2)
            {
                // Add the two preceeding elements
                OutputExpression[OperatorIndex - 2] =
                        ((double.Parse(OutputExpression[OperatorIndex - 2])) *
                         (double.Parse(OutputExpression[OperatorIndex - 1])))
                        .ToString();

                // remove the unnecessaty Elements
                OutputExpression.RemoveAt(OperatorIndex);
                OutputExpression.RemoveAt(OperatorIndex - 1);

                return OperatorIndex - 2;
            }

            if (Array.IndexOf( // Index 3 -> Divide
                        OperatorKey,
                        OutputExpression[OperatorIndex].ToString()
                        )
                        == 3)
            {
                // Add the two preceeding elements
                OutputExpression[OperatorIndex - 2] =
                        ((double.Parse(OutputExpression[OperatorIndex - 2])) /
                         (double.Parse(OutputExpression[OperatorIndex - 1])))
                        .ToString();

                // remove the unnecessaty Elements
                OutputExpression.RemoveAt(OperatorIndex);
                OutputExpression.RemoveAt(OperatorIndex - 1);

                return OperatorIndex - 2;
            }

            if (Array.IndexOf( // Index 4 -> Mod
                        OperatorKey,
                        OutputExpression[OperatorIndex].ToString()
                        )
                        == 4)
            {
                // Add the two preceeding elements
                OutputExpression[OperatorIndex - 2] =
                        ((double.Parse(OutputExpression[OperatorIndex - 2])) %
                         (double.Parse(OutputExpression[OperatorIndex - 1])))
                        .ToString();

                // remove the unnecessaty Elements
                OutputExpression.RemoveAt(OperatorIndex);
                OutputExpression.RemoveAt(OperatorIndex - 1);

                return OperatorIndex - 2;
            }

            return OperatorIndex;
        }

        // Evaluate Function // TODO: More than 2 arguments
        public static int EvaluateFunction(int OperatorIndex)
        {
            //http://stackoverflow.com/questions/540066/calling-a-function-from-a-string-in-c-sharp
            // TODO: Methods with more than 2 arguments

            // Step 1: Format STring
            // TODO: LN = LOG
            OutputExpression[OperatorIndex] = OutputExpression[OperatorIndex][0]
                                              .ToString()
                                              .ToUpper() +
                                              OutputExpression[OperatorIndex];

            OutputExpression[OperatorIndex] = OutputExpression[OperatorIndex].Remove(1, 1);

            // ln -> Log
            if (OutputExpression[OperatorIndex] == "Ln")
            {
                OutputExpression[OperatorIndex] = "Log";
            }

            // Step 2: Get method info
            var argsToPass = 0;

            MethodInfo curMethod = typeof(Math)
                                   .GetMethod(
                                       OutputExpression[OperatorIndex],
                                       new Type[] 
                                       {
                                           typeof(double)
                                       });
            
            if (curMethod != null)
            {
                // moethod taking 1 argument found
                argsToPass = 1;
            }
            else
            {
                // search for a method taking 2 arguments
                curMethod = typeof(Math)
                            .GetMethod(
                                OutputExpression[OperatorIndex],
                                new Type[] 
                                {
                                    typeof(double),
                                    typeof(double)
                                });

                // method taking 2 argumetns
                argsToPass = 2;

                // TODO: methods with more than 2 args
            }

            // curMethod.CustomAttributes -> number of arguments to pass
            // includes optional arguments for overloads, not working
            if (argsToPass == 1)
            {
                // call method
                OutputExpression[OperatorIndex - 1] = (curMethod.Invoke(
                                                          typeof(Math),
                                                          new object[]
                                                          {
                                                              double.Parse(OutputExpression[OperatorIndex - 1])
                                                          }
                                                      ))
                                                      .ToString();

                // remove extra elements
                OutputExpression.RemoveAt(OperatorIndex);

                return OperatorIndex - 1;
            }

            if (argsToPass == 2)
            {
                // call method
                OutputExpression[OperatorIndex - 2] = (curMethod.Invoke(
                                                          typeof(Math),
                                                          new object[]
                                                          {
                                                              double.Parse(OutputExpression[OperatorIndex - 2]),
                                                              double.Parse(OutputExpression[OperatorIndex - 1])
                                                          }
                                                      ))
                                                      .ToString();

                // remove extra elements
                OutputExpression.RemoveAt(OperatorIndex);
                OutputExpression.RemoveAt(OperatorIndex - 1);

                return OperatorIndex - 2;
            }

            // return next index to check -1 
            // ( for will increment it prior to next check )
            // if no method was found -> return current index
            return OperatorIndex;
        }
    }
}
