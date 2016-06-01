
namespace _05_3_in_1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        // Task 1
        private static List<int> blackjack = new List<int>();
        // Task 2
        private static List<int> cakes = new List<int>();
        private static int friends;
        // Task 3
        private static int[] gold;
        private static int[] have;
        private static int[] goal;
        private static int[] need;
        private static int[] extra;

        static void Input()
        {
            //blackjack = Console.ReadLine()
            //    .Trim()
            //    .Split(new[] { ' ', ',' },
            //        StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            //cakes = Console.ReadLine()
            //    .Trim()
            //    .Split(new[] { ' ', ',' },
            //        StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToList();

            //friends = int.Parse(Console.ReadLine());

            // G1 S1 B1 G2 S2 B2
            // 1 - available, 2-target
            gold = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        // Working
        static void BlackJackIndexOf()
        {
            for (int hand = 21; hand >= 0; hand--)
            {
                var curHandIndex = blackjack.IndexOf(hand);

                if (curHandIndex >= 0)
                {
                    var unique = blackjack.IndexOf(hand, curHandIndex + 1) >= 0 ? false : true;

                    if (unique)
                    {
                        Console.WriteLine(curHandIndex);
                        return;
                    }
                }
            }

            // if no unique hand's been found
            Console.WriteLine("-1");
        }
        // Working
        static void EatCake()
        {
            var myCakes = 0;

            cakes.Sort();

            for (int cake = cakes.Count - 1; cake >= 0; cake -= (friends + 1))
            {
                myCakes += cakes[cake];
            }

            Console.WriteLine(myCakes);
        }

        static void GoldExchange()
        {
            BuildGoldStacks();

            var OperationsCounter = 0;

            // bronze
            if (need[2] > 0)
            {
                if (extra[1] > 0)
                {
                    var needSilver = need[2] / 9 + 1;

                    if (extra[1] >= needSilver)
                    {
                        extra[1] -= needSilver;
                        OperationsCounter += needSilver;
                    }
                    else
                    {
                        need[1] += needSilver - extra[1];
                        OperationsCounter += extra[1];
                    }

                    
                }
            }

        }
        static void BuildGoldStacks()
        {
            have = new int[3]
           {
                gold[0],
                gold[1],
                gold[2]
           };

            goal = new int[3]
            {
                gold[3],
                gold[4],
                gold[5]
            };

            need = new int[3];
            extra = new int[3];

            for (int i = 0; i < 3; i++)
            {
                need[i] = goal[i] - have[i] > 0 ?
                          goal[i] - have[i] : 0;

                extra[i] = have[i] - goal[i] > 0 ?
                           have[i] - goal[i] : 0;
            }
        }

        static void Main()
        {
            Input();
            //BlackJackIndexOf();
            //EatCake();
        }
    }
}
