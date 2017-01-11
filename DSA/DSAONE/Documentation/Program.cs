using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    class Program
    {
        private static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        private static Dictionary<char, int> costs;

        static void Main(string[] args)
        {
            costs = new Dictionary<char, int>();
            for (int i = 'a'; i <= 'z'; i++)
            {
                costs.Add((char)i, (int)i - 97);
            }

            var inputString = Console.ReadLine();
            var stringWithoutSpecial = new StringBuilder();

            foreach (var chr in inputString)
            {
                if (char.IsLetterOrDigit(chr))
                {
                    stringWithoutSpecial.Append(chr);
                }
            }

            var strABuilder = new StringBuilder();
            var strBBuilder = new StringBuilder();

            for (int i = 0; i < stringWithoutSpecial.Length / 2; i++)
            {
                strABuilder.Append(char.ToLower(stringWithoutSpecial[i]));
                strBBuilder.Append(char.ToLower(stringWithoutSpecial[stringWithoutSpecial.Length - i - 1]));
            }

            //var strO = stringWithoutSpecial.ToString();
            //var strA = strO.Substring(0, strO.Length / 2);
            //var startB = strO.Length % 2 == 0 ? strO.Length / 2 : strO.Length / 2 + 1;
            //var strBRev = strO.Substring(startB, strA.Length);

            //var strB = new StringBuilder();
            //for (int i = strBRev.Length - 1; i >= 0; i--)
            //{
            //    strB.Append(strBRev[i]);
            //}

            var res = LevenshteinDistance(strABuilder.ToString(), strBBuilder.ToString());
            Console.WriteLine(res);
        }

        private static int Again(StringBuilder s, StringBuilder t)
        {
            //function LevenshteinDistance(char s[1..m], char t[1..n]):

            var m = s.Length;
            var n = t.Length;
            // for all i and j, d[i,j] will hold the Levenshtein distance between
            // the first i characters of s and the first j characters of t
            // note that d has (m+1)*(n+1) values
            int[,] d = new int[s.Length, t.Length];

            // source prefixes can be transformed into empty string by
            // dropping all characters
            for (var i = 0; i < s.Length; i++)
                d[i, 0] = i;


            // target prefixes can be reached from empty source prefix
            // by inserting every character
            for (var j = 0; j < t.Length; j++)
                d[0, j] = j;


            for (var j = 0; j < n; j++)
                for (var i = 0; i < m; i++)
                {
                    var substitutionCost = s[i] == t[j] ? 0 : GetCost(s[i], t[j]);
                    d[i, j] = substitutionCost;
                    //:= minimum(d[i - 1, j] + 1,                   // deletion
                    //     d[i, j - 1] + 1,                   // insertion
                    //     d[i - 1, j - 1] + substitutionCost)  // substitution
                }

            return d[m - 1, n - 1];
        }

        private static int LevenshteinDistance(string s, string t)
        {
            // degenerate cases
            if (s == t) return 0;
            if (s.Length == 0) return t.Length;
            if (t.Length == 0) return s.Length;

            // create two work vectors of integer distances
            int[] v0 = new int[t.Length + 1];
            int[] v1 = new int[t.Length + 1];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
                v0[i] = i;

            for (int i = 0; i < s.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < t.Length; j++)
                {
                    var cost = s[i] == t[j] ? 0 : GetCost(s[i], t[j]);
                    //var cost = (s[i] == t[j]) ? 0 : 1;
                    v1[j + 1] = Math.Min(v1[j] + cost, Math.Min(v0[j + 1] + cost, v0[j] + cost));
                }

                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }

            return v1[t.Length];
        }

        private static int GetCost(char a, char b)
        {
            var aIndex = costs[a];
            var bIndex = costs[b];

            var pathA = Math.Abs(aIndex - bIndex);
            var pathB = Math.Min(aIndex, bIndex) + 26 - Math.Max(aIndex, bIndex);

            return Math.Min(pathA, pathB);
        }
    }
}
