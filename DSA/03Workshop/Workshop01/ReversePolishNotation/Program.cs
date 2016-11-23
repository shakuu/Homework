using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Count; i++)
            {
                var nextElement = input[i];

                int parsed;
                var isParsed = int.TryParse(nextElement, out parsed);
                if (isParsed)
                {
                    stack.Push(parsed);
                }
                else
                {
                    var b = stack.Pop();
                    var a = stack.Pop();

                    // +, -, *, /) and bitwise (&, |, ^)
                    switch (nextElement)
                    {
                        case "+":
                            stack.Push(a + b);
                            break;
                        case "-":
                            stack.Push(a - b);
                            break;
                        case "*":
                            stack.Push(a * b);
                            break;
                        case "/":
                            stack.Push(a / b);
                            break;
                        case "&":
                            stack.Push(a & b);
                            break;
                        case "|":
                            stack.Push(a | b);
                            break;
                        case "^":
                            stack.Push(a ^ b);
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
