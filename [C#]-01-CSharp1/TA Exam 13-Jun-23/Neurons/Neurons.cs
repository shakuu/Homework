using System;
using System.Collections.Generic;
using System.Linq;

namespace Neurons
{
    class Neurons
    {
        static void Main()
        {
            //get strings
            List<string> Strings = new List<string>();
            long temp;
            while (true)
            {
                temp = long.Parse(Console.ReadLine());
                if (temp < 0)
                { break; }

                Strings.Add(Convert.ToString(temp, 2).PadLeft(32, '0'));
            }

            bool right = false;
            bool top = false;
            bool bot = false;
            //Identify Neurons and mark them
            for (int i = 0; i < Strings.Count; i++)
            {
                //if current row contains 1s
                if (Strings[i].Contains('1'))
                {
                    for (int pos = Strings[i].IndexOf("1"); pos < Strings[i].Length; pos++)
                    {
                        if (Strings[i][pos] == '0')
                        {
                            // reset bools
                            right = false;
                            top = false;
                            bot = false;
                            //check right
                            if (Strings[i].Substring(pos, Strings[i].Length - pos).Contains("1"))
                            { right = true; }
                            //check top
                            for (int row = Math.Max(0, i - 1); row >= 0; row--)
                            {
                                if (Strings[row][pos] == '1')
                                { top = true; }
                            }
                            for (int row = Math.Min(i + 1, Strings.Count); row < Strings.Count; row++)
                            {
                                if (Strings[row][pos] == '1')
                                { bot = true; }
                            }
                            // if all are true -> mark for replace 
                            if (top == true && right == true && bot == true)
                            {
                                Strings[i] = Strings[i].Insert(pos, "+");
                                Strings[i] = Strings[i].Remove(pos + 1, 1);
                            }
                        }
                    }
                }
            }
            //fill with correct symbols
            for(int i = 0; i<Strings.Count;i++)
            {
                Strings[i] = Strings[i].Replace('1', '0');
                Strings[i] = Strings[i].Replace('+', '1');

                Console.WriteLine(Convert.ToInt64(Strings[i], 2));
            }
        }
    }
}
