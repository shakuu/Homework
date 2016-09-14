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
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));


        CheckForPrimes();

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

    public static void CheckForPrimes()
    {
        var primeCheckerLogger = new Logger();
        var primeChecker = new PrimeChecker(primeCheckerLogger);

        var primeCandidates = GetPrimeCandidatesCollection();
        foreach (var candidate in primeCandidates)
        {
            primeChecker.CheckPrime(candidate);
        }

        Console.WriteLine(primeCheckerLogger.ToString());
    }

    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
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
}
