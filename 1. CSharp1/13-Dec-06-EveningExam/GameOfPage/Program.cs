using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//111  000 010
//111  010 010
//111  000 100
//cookie - crumb - broken cookie

namespace GameOfPage
{
    class Program
    {
        static void Main()
        {
            //declare vars
            float pricePerCookie = 1.79f; //$1.79  
            int iBoughtCookies = 0;
            string PageSays;
            int PageSaysRow;
            int PageSaysCol;
            string myReply;

            //create a cookie tray
            List<char[]> cookieTray = new List<char[]>();
            for (int i = 0; i < 16; i++)
            {
                cookieTray.Add(Console.ReadLine().ToCharArray());
            }


            while (true)
            {
                //clear vars
                myReply = "";

                //get input
                PageSays = Console.ReadLine().ToLower();
                PageSaysRow = int.Parse(Console.ReadLine());
                PageSaysCol = int.Parse(Console.ReadLine());

                switch (PageSays)
                {
                    case "paypal":
                        Console.WriteLine("${0}", iBoughtCookies * pricePerCookie);
                        return;
                    case "what is":
                        myReply = WhatIsInTheTray(PageSaysRow, PageSaysCol);
                        break;
                    case "buy":
                        myReply = BuyACookie(PageSaysRow, PageSaysCol);
                        break;
                    default:
                        myReply = "";
                        break;
                }
                Console.WriteLine(myReply);
            }
        }

        public static string CheckTheTray(int currRow, int currCol, bool toBuy )
        {
            string currReply = "";

            return currReply;
        }

        public static string WhatIsInTheTray(int currRow, int currCol)
        {
            string currReply = "";

            return currReply;
        }

        public static string BuyACookie (int currRow, int currCol)
        {
            string currReply = "";

            return currReply;
        }
    }
}
