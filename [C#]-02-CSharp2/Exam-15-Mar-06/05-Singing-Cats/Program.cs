
namespace _05_Singing_Cats
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Program
    {
        public class CustomCopare : IComparer
        {
            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(Object x, Object y)
            {
                int[] xarray = (int[])x;
                int[] yarray = (int[])y;

                return ((new CaseInsensitiveComparer()).Compare(xarray.Sum(), yarray.Sum()));
            }
        }

        static List<int[]> CatScripts = new List<int[]>();

        static int[][] Cats;
        static int[][] Songs;

        static int MinSongList = int.MaxValue;
        static bool isConcert = false;

        static void Main()
        {
            //var CatSays = "Mew!";
            var notWin = "No concert!";

            // Input
            var numberOfCats = Console.ReadLine()
                .Split()
                .Where(x => char.IsDigit(x[0]))
                .Select(byte.Parse)
                .ToArray()[0];

            var numberOfSongs = Console.ReadLine()
                .Split()
                .Where(x => char.IsDigit(x[0]))
                .Select(byte.Parse)
                .ToArray()[0];

            // Arrays to store input
            Cats = new int[numberOfCats][]
                .Select(x => x = new int[numberOfSongs])
                .ToArray();

            Songs = new int[numberOfSongs][]
                .Select(x => x = new int[numberOfCats])
                .ToArray();



            while (true)
            {
                // Cat X knows song Y
                // [0] cat, [1] song

                // Cat and Song count starts at ONE 
                var curInputLine = Console.ReadLine()
                        .Split()
                        .Where(x => char.IsDigit(x[0]))
                        .Select(byte.Parse)
                        .Select(x => x - 1)
                        .ToArray();

                if (curInputLine.Length == 0) break;

                // Cat X knows song Y
                Cats[curInputLine[0]][curInputLine[1]] = 1;

                // Song Y can be sung by Cat X
                Songs[curInputLine[1]][curInputLine[0]] = 1;
            }

            // Sort Songs by "popularity"
            var myCompare = new CustomCopare();

            Array.Sort(Cats, myCompare);

            

            // For each song the cat with least songs can sing
            for (int curSong = 0; curSong < Cats[0].Length; curSong++)
            {
                // helper variables
                var curSongList = new int[numberOfCats];
                var SongCounter = 0;

                // If the song is available check
                // against other cats.
                if (Cats[0][curSong] == 1)
                {
                    // Check
                    curSongList[0] = 1;

                    checkOtherCats(curSong, SongCounter, curSongList);

                    if (curSongList.Sum() == numberOfCats) isConcert = true;
                }
            }
            
            // Print Output
            if (isConcert) Console.WriteLine(MinSongList);
            else           Console.WriteLine(notWin);
        }

        // BACK UP VARIABLES 
        // WHEN CALLING RECURSIVELY
        static void checkOtherCats(
            int SongNumber,
            int counter,
            int[] curSongList)
        {
            // increment the song counter
            // with the new song.
            counter++;

            // Check Which Cats can sing this song
            // and mark them in the songlist.
            for (int curCat = 0; curCat < Cats.Length; curCat++)
            {
                if (Cats[curCat][SongNumber] == 1)
                {
                    curSongList[curCat] = 1;
                }
            }

            // Check if it's a concert or keep
            // looking for more songs.
            if (curSongList.Sum() == Cats.Length)
            {
                MinSongList = counter < MinSongList ?
                              counter : MinSongList;

                isConcert = true;

                return;
            }
            else
            {
                var nextCat = 0;

                // Find the next Cat and Song
                for (int cat = 0; cat < curSongList.Length; cat++)
                {
                    if (curSongList[cat] == 0)
                    {
                        nextCat = cat;
                        break;
                    }
                }

                // Check for each song this cat can sing.
                for (int song = 0; song < Cats[nextCat].Length; song++)
                {
                    if (Cats[nextCat][song] == 1 && 
                        song != SongNumber)
                    {
                        // Back Up current song list
                        // and counter.
                        var tempCounter = counter;

                        var tempSongList = new int[curSongList.Length];
                        curSongList.CopyTo(tempSongList, 0);

                        // Check against other cats
                        checkOtherCats(song, counter, curSongList);

                        // restore song list to where it was 
                        tempSongList.CopyTo(curSongList, 0);
                        counter = tempCounter;
                    }
                }
            }
            
            // Play with other cats! 
            return;
        }
    }
}
