using System;

namespace ModifyBitv3
{
    class ModifyBitv3
    {
        static void Main(string[] args)
        {
            ulong numN = ulong.Parse(Console.ReadLine());
            int Pos = int.Parse(Console.ReadLine());
            int newVal = int.Parse(Console.ReadLine());

            ulong mask = (ulong)1 << Pos;
            ulong currVal = numN & mask;
            currVal >>= Pos;

            if ( (int)currVal != newVal)
            {
                Console.WriteLine((ulong)(numN ^ mask));
            }
            else
            { Console.WriteLine(numN); }
        }
    }
}
