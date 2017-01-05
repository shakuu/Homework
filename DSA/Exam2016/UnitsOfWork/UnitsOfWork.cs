using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsOfWork
{
    public class GameUnitAttackComparer : IComparer<GameUnit>
    {
        public int Compare(GameUnit x, GameUnit y)
        {
            return y.Attack - x.Attack;
        }
    }

    public class IntReverseComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

    public class UnitsOfWork
    {
        private const string EndCommand = "end";
        private const string AddCommand = "add";
        private const string RemoveCommand = "remove";
        private const string FindCommand = "find";
        private const string PowerCommand = "power";

        private static Dictionary<string, GameUnit> unitsDictionaryByUniqueName;
        private static SortedDictionary<int, HashSet<GameUnit>> unitsDictionaryByAttack;

        public static void Main()
        {
            unitsDictionaryByUniqueName = new Dictionary<string, GameUnit>();
            unitsDictionaryByAttack = new SortedDictionary<int, HashSet<GameUnit>>(new IntReverseComparer());

            var engineIsRunning = true;
            while (engineIsRunning)
            {
                var nextCommandWords = Console.ReadLine().Split(' ');

                switch (nextCommandWords[0])
                {
                    case UnitsOfWork.EndCommand:
                        engineIsRunning = false;
                        break;
                    case UnitsOfWork.AddCommand:
                        UnitsOfWork.HandleAddCommand(nextCommandWords);
                        break;
                    case UnitsOfWork.RemoveCommand:
                        UnitsOfWork.HandleRemoveCommand(nextCommandWords);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void HandleAddCommand(string[] commandWords)
        {
            var unitExists = UnitsOfWork.unitsDictionaryByUniqueName.ContainsKey(commandWords[1]);
            if (unitExists)
            {
                // FAIL: Spiderman already exists!
                Console.WriteLine("FAIL: {0} already exists!", commandWords[1]);
            }
            else
            {
                var commandWordsAttackValue = int.Parse(commandWords[3]);
                var newUnit = new GameUnit(commandWords[1], commandWords[2], commandWordsAttackValue);

                UnitsOfWork.unitsDictionaryByUniqueName.Add(newUnit.Name, newUnit);

                if (!UnitsOfWork.unitsDictionaryByAttack.ContainsKey(commandWordsAttackValue))
                {
                    UnitsOfWork.unitsDictionaryByAttack.Add(commandWordsAttackValue, new HashSet<GameUnit>());
                }

                // Save names only ? 
                unitsDictionaryByAttack[commandWordsAttackValue].Add(newUnit);

                // SUCCESS: TheMightyThor added!
                Console.WriteLine("SUCCESS: {0} added", newUnit.Name);
            }
        }

        private static void HandleRemoveCommand(string[] commandWords)
        {
            var unitExists = UnitsOfWork.unitsDictionaryByUniqueName.ContainsKey(commandWords[1]);
            if (!unitExists)
            {
                Console.WriteLine("FAIL: {0} could not be found!", commandWords[1]);
            }
            else
            {
                var unit = UnitsOfWork.unitsDictionaryByUniqueName[commandWords[1]];

                UnitsOfWork.unitsDictionaryByAttack[unit.Attack].RemoveWhere(x => x.Name == unit.Name);
                UnitsOfWork.unitsDictionaryByUniqueName.Remove(commandWords[1]);

                Console.WriteLine("SUCCESS: {0} removed!", unit.Name);
            }
        }
    }
}
