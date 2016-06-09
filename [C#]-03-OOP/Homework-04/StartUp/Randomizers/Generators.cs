
namespace StartUp.Randomizers
{
    using System;
    using System.Text;

    internal static class Generators
    {
        internal static string GenerateName(Random random)
        {
            const string consonants = "bcdfghjklmnpqrstvwxyz";
            const string vowels = "aeiou";

            int consonantsLength = consonants.Length;
            int vowelsLength = vowels.Length;

            var output = new StringBuilder();

            var length = random.Next(3, 8);
            var letter = 0;
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                {
                    letter = consonants[random.Next(0, consonants.Length)];
                }
                else
                {
                    letter = vowels[random.Next(0, vowels.Length)];
                }

                output.Append((char)letter);
            }

            output[0] = char.ToUpper(output[0]);

            return output.ToString();
        }
        
        internal static double GenerateGrade(Random random)
        {
            var format = "{0}.{1}";

            var whoGrade = random.Next(2, 6);
            var decGrade = random.Next(0, 99);

            var grade = string.Format(format, whoGrade, decGrade);

            return double.Parse(grade);
        }
    }
}
