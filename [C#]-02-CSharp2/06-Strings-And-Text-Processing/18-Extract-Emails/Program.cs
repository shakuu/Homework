using System;
using System.Text.RegularExpressions;

namespace _18_Extract_Emails
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            // Step 1: Create a Pattern
            var emailPattern = @"([\w\d.]+@[\w\d.]+\.[\w\d.]+)";
            // Step 2: Create a Regex with the Pattern
            var emailRegex = new Regex(emailPattern);
            //Step 3: Find Match OR MatchES for all results
            var extractEmails = emailRegex.Matches(input);

            foreach (var email in extractEmails)
            {
                Console.WriteLine(email.ToString());
            }
        }
    }
}
