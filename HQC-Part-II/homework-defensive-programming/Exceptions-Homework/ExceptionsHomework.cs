using System;
using System.Collections.Generic;
using System.Text;

using Exceptions_Homework.PrimeChecker;
using Exceptions_Homework.Utils;

public class ExceptionsHomework
{
    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        var extractEndingParameters = GetExtractEndingParameters();
        foreach (var pair in extractEndingParameters)
        {
            try
            {
                var message = ExtractEnding(pair.Key, pair.Value);
                Console.WriteLine(message);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid parameters {0} {1}", pair.Key, pair.Value);
            }
        }

        try
        {
            Console.WriteLine(CheckForPrimes());
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Could not instantiate PrimeChecker.");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }

    public static string CheckForPrimes()
    {
        var primeCheckerLogger = new Logger();
        var primeChecker = new PrimeChecker(primeCheckerLogger);

        var primeCandidates = GetPrimeCandidatesCollection();
        foreach (var candidate in primeCandidates)
        {
            primeChecker.CheckPrime(candidate);
        }

        return primeCheckerLogger.ToString();
    }

    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("arr");
        }

        if (arr.Length <= startIndex)
        {
            throw new IndexOutOfRangeException("startIndex");
        }

        if (arr.Length < startIndex + count)
        {
            throw new IndexOutOfRangeException("count");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        StringBuilder result = new StringBuilder();

        var startIndex = Math.Max(0, str.Length - count);
        for (int i = startIndex; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    private static IEnumerable<int> GetPrimeCandidatesCollection()
    {
        var candidates = new List<int>() { 23, 33 };
        return candidates;
    }

    private static IDictionary<string, int> GetExtractEndingParameters()
    {
        var extractEndingParameters = new Dictionary<string, int>()
        {
            { "I love C#", 2 },
            { "Nakov", 4 },
            { "beer", 4 },
            { "Hi", 100 }
        };

        return extractEndingParameters;
    }
}
