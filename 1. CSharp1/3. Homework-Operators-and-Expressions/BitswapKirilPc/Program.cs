using System;
class BitSwap
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        int firstPos = int.Parse(Console.ReadLine());
        int secondPos = int.Parse(Console.ReadLine());
        if (firstPos > secondPos)
        {
            int holder = firstPos;
            firstPos = secondPos;
            secondPos = holder;
        }
        int bitNum = int.Parse(Console.ReadLine());
        long maskLenth = (long)Math.Pow(2, bitNum) - 1;

        long firstMask = maskLenth << firstPos;
        long secondMask = maskLenth << secondPos;
        long firstBlankMask = ~(maskLenth << firstPos);
        long secondBlankMask = ~(maskLenth << secondPos);


        firstMask = firstMask & number;
        secondMask = secondMask & number;

        number = firstBlankMask & number;
        number = secondBlankMask & number;

        number = (firstMask << (secondPos - firstPos)) | number;
        number = (secondMask >> (secondPos - firstPos)) | number;
        Console.WriteLine(number);

    }
}