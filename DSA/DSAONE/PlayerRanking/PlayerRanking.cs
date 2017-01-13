using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    public class Player
    {
        // add PLAYER_NAME PLAYER_TYPE PLAYER_AGE PLAYER_POSITION
        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public int Position { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Player;
            if (other == null)
            {
                return false;
            }

            var nameE = this.Name == other.Name;
            var typeR = this.Type == other.Type;
            var ageE = this.Age == other.Age;
            var positionE = this.Position == other.Position;

            return nameE && typeR && ageE && positionE;
        }

        public override int GetHashCode()
        {
            var hash = 199;

            unchecked
            {
                hash = hash * 257 + this.Name.GetHashCode();
                hash = hash * 257 + this.Type.GetHashCode();
                hash = hash * 257 + this.Age.GetHashCode();
                hash = hash * 257 + this.Position.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }

    public class ReversIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }

    public class PlayerComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            // toLower -> 60 / 100
            var nameCompare = x.Name.CompareTo(y.Name);
            if (nameCompare != 0)
            {
                return nameCompare;
            }
            else
            {
                return y.Age - x.Age;
            }
        }
    }

    public class ReverseStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x.CompareTo(y);
        }
    }

    public class PlayerRanking
    {
        private static Dictionary<string, SortedSet<Player>> StoredPlayersByType = new Dictionary<string, SortedSet<Player>>();
        //private static List<Player> PlayersByPosition = new List<Player>();

        private static BigList<Player> PlayersByPosition = new BigList<Player>();


        public static void Main()
        {
            //var test = new Wintellect.PowerCollections.

            PlayersByPosition.Add(new Player("zer", "o", 99, 5));

            var engineIsRunning = true;
            while (engineIsRunning)
            {
                var nextCommandWords = Console.ReadLine().Split(' ');

                switch (nextCommandWords[0].ToLower())
                {
                    case "ranklist":
                        PlayerRanking.HandleRanklistCommand(nextCommandWords);
                        break;
                    case "find":
                        PlayerRanking.HandleFindCommand(nextCommandWords);
                        break;
                    case "add":
                        PlayerRanking.HandleAddCommand(nextCommandWords);
                        break;
                    case "end":
                        engineIsRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        // ranklist START END
        private static void HandleRanklistCommand(string[] commandWords)
        {
            var startIndex = int.Parse(commandWords[1]);
            var endIndex = int.Parse(commandWords[2]);

            var result = new StringBuilder();
            //1. Stamat(40); 2. Ivan(20); 3. Stamat(22); 4. Pesho(25); 5. Georgi(30)
            for (int playerIndex = startIndex; playerIndex <= endIndex; playerIndex++)
            {
                result.AppendFormat("{0}. ", playerIndex);
                result.Append(PlayerRanking.PlayersByPosition[playerIndex]);
                result.Append("; ");
            }

            result.Length = result.Length - 2;
            Console.WriteLine(result.ToString());
        }

        private static void HandleFindCommand(string[] commandWords)
        {
            var result = new StringBuilder();
            result.AppendFormat("Type {0}: ", commandWords[1]);

            // Type PLAYER_TYPE: 
            var nameExists = PlayerRanking.StoredPlayersByType.ContainsKey(commandWords[1]);
            if (!nameExists)
            {
                Console.WriteLine(result.ToString());
                return;
            }


            var count = 0;
            //Type Aggressive: Ivan(20); Stamat(40); Stamat(22)
            foreach (var player in PlayerRanking.StoredPlayersByType[commandWords[1]])
            {
                result.Append(player.ToString());
                result.Append("; ");
                count++;

                if (count == 5)
                {
                    break;
                }
            }

            result.Length = result.Length - 2;
            Console.WriteLine(result.ToString());
        }

        private static void HandleAddCommand(string[] commandWords)
        {
            // add PLAYER_NAME PLAYER_TYPE PLAYER_AGE PLAYER_POSITION
            var positionValue = int.Parse(commandWords[4]);
            var newPlayer = new Player(commandWords[1], commandWords[2], int.Parse(commandWords[3]), positionValue);

            var typeExists = PlayerRanking.StoredPlayersByType.ContainsKey(commandWords[2]);
            if (!typeExists)
            {
                StoredPlayersByType.Add(commandWords[2], new SortedSet<Player>(new PlayerComparer()));
            }

            if (StoredPlayersByType[commandWords[2]].Contains(newPlayer))
            {
                return;
            }

            StoredPlayersByType[commandWords[2]].Add(newPlayer);

            if (positionValue > PlayersByPosition.Count)
            {
                PlayersByPosition.Add(newPlayer);
            }
            else
            {
                PlayersByPosition.Insert(positionValue, newPlayer);
            }

            //Added player Ivan to position 1
            Console.WriteLine("Added player {0} to position {1}", newPlayer.Name, newPlayer.Position);
        }
    }
}
