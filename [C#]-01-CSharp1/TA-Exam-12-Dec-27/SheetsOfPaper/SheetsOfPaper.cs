using System;
using System.Collections.Generic;

namespace SheetsOfPaper
{
    class SheetsOfPaper
    {
        class SheetSizes
        {
            public int Value;
            public string Name;
            public bool isUsed = false;

            public SheetSizes(int PowerOf2, int cName)
            {
                this.Value = (int)Math.Pow(2, PowerOf2);
                this.Name = "A" + cName.ToString();
            }
        }
        static void Main()
        {
            //Asya needs this  many sheets of A10
            int AsyaNeeds = int.Parse(Console.ReadLine());

            //construct Sheets
            List<SheetSizes> availableSheets = new List<SheetSizes>();
            for (int i = 0, p=10; i <= 10; i++, p--)
            {
                availableSheets.Add(new SheetSizes(i, p));
            }
            //check
            for (int i =10; i>=0; i--)
            {
                if (AsyaNeeds >= availableSheets[i].Value)
                {
                    AsyaNeeds -= availableSheets[i].Value;
                    availableSheets[i].isUsed = true;
                }
            }

            //output sheet.name NOT used
            for (int i =10; i>=0; i--)
            {
                if (!availableSheets[i].isUsed)
                {
                    Console.WriteLine(availableSheets[i].Name);
                }
            }
        }
    }
}
