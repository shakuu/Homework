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
            if (x.Attack != y.Attack)
            {
                return y.Attack - x.Attack;
            }
            else
            {
                return -x.Name.CompareTo(y.Name);
            }
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
        private static Dictionary<string, SortedSet<GameUnit>> unitsDictionaryByUnitType;
        private static SortedSet<GameUnit> unitsByAttack;

        public static void Main()
        {
            unitsDictionaryByUniqueName = new Dictionary<string, GameUnit>();
            unitsDictionaryByUnitType = new Dictionary<string, SortedSet<GameUnit>>();
            unitsByAttack = new SortedSet<GameUnit>();

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
                    case UnitsOfWork.FindCommand:
                        UnitsOfWork.HandleFindCommand(nextCommandWords);
                        break;
                    case UnitsOfWork.PowerCommand:
                        UnitsOfWork.HandlePowerCommand(nextCommandWords);
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

                if (!UnitsOfWork.unitsDictionaryByUnitType.ContainsKey(commandWords[2]))
                {
                    UnitsOfWork.unitsDictionaryByUnitType.Add(commandWords[2], new SortedSet<GameUnit>());
                }

                // Save names only ? 
                UnitsOfWork.unitsDictionaryByUnitType[commandWords[2]].Add(newUnit);

                UnitsOfWork.unitsByAttack.Add(newUnit);

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

                UnitsOfWork.unitsDictionaryByUnitType[unit.Type].RemoveWhere(x => x.Name == unit.Name);
                UnitsOfWork.unitsByAttack.RemoveWhere(x => x.Name == unit.Name);
                UnitsOfWork.unitsDictionaryByUniqueName.Remove(commandWords[1]);

                Console.WriteLine("SUCCESS: {0} removed!", unit.Name);
            }
        }

        // find UNIT_TYPE – finds the top 10 units, first ordered by attack in descending order and then by their name in ascending order
        // Print the results in the following format 
        // "RESULT: UNIT, UNIT, UNIT" where UNIT should be printed in the format 
        // "UNIT_NAME[UNIT_TYPE](UNIT_ATTACK)". If no units are found just print 
        // "RESULT: " (ending with one space)
        private static void HandleFindCommand(string[] commandWords)
        {
            var result = new StringBuilder();
            result.Append("RESULT: ");

            var typeExists = UnitsOfWork.unitsDictionaryByUnitType.ContainsKey(commandWords[1]);
            if (!typeExists)
            {
                Console.WriteLine(result);
            }
            else
            {
                var units = UnitsOfWork.unitsDictionaryByUnitType[commandWords[1]];
                var availableUnitsCount = units.Count;
                var unitsCount = 0;

                foreach (var unit in units)
                {
                    result.Append(unit.ToString());
                    unitsCount++;

                    if (unitsCount == 10 || unitsCount == availableUnitsCount)
                    {
                        break;
                    }
                    else
                    {
                        result.Append(", ");
                    }
                }

                if (result[result.Length - 1] == ' ')
                {
                    result[result.Length - 2] = ' ';
                }

                Console.WriteLine(result.ToString().Trim());
            }
        }

        private static void HandlePowerCommand(string[] commandWords)
        {
            var unitsToPrintCount = int.Parse(commandWords[1]);

            var result = new StringBuilder();
            result.Append("RESULT: ");

            var unitsCount = 0;
            foreach (var unit in UnitsOfWork.unitsByAttack)
            {
                if (unitsCount < unitsToPrintCount)
                {
                    if (unitsCount != 0)
                    {
                        result.Append(", ");
                    }

                    result.Append(unit.ToString());
                    unitsCount++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
}
