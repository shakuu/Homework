using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusScore
{
    class BonusScore
    {
        static void Main(string[] args)
        {
            int Score = int.Parse(Console.ReadLine());

            if (Score >= 1 && Score <= 3)
            { Console.WriteLine(Score * 10); }
            else if (Score >= 4 && Score <= 6)
            { Console.WriteLine(Score * 100); }
            else if (Score >= 7 && Score <= 9)
            { Console.WriteLine(Score * 1000); }
            else { Console.WriteLine("invalid score"); }
        }
    }
}
