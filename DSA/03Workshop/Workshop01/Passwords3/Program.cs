using System;

namespace Passwords3
{
    public class Program
    {
        static string possibleCharacters = "1234567890";
        static int currentIteration = 0;
        static char[] currentPassword;

        public static void Main()
        {
            var passwordLength = int.Parse(Console.ReadLine());
            var sequence = Console.ReadLine();
            var targetIteration = int.Parse(Console.ReadLine());
            currentPassword = new char[passwordLength];

            GeneratePassword(sequence, passwordLength, 0, 9, targetIteration);
            for (int i = 0; i < 9; i++)
            {
                GeneratePassword(sequence, passwordLength, 0, i, targetIteration);
            }

            Console.WriteLine(string.Join("", currentPassword));
        }

        private static void GeneratePassword(string sequence, int passwordLength, int currentLength, int currentPosition, int targetIteration)
        {
            if (currentIteration == targetIteration)
            {
                return;
            }

            currentPassword[currentLength] = possibleCharacters[currentPosition];

            if (currentLength == passwordLength - 1)
            {
                Program.currentIteration++;
                return;
            }

            var nextInstruction = sequence[currentLength];
            if (nextInstruction == '=')
            {
                Program.GeneratePassword(sequence, passwordLength, currentLength + 1, currentPosition, targetIteration);
            }
            else if (nextInstruction == '<')
            {
                for (int nextPosition = 0; nextPosition < currentPosition; nextPosition++)
                {
                    Program.GeneratePassword(sequence, passwordLength, currentLength + 1, nextPosition, targetIteration);
                }
            }
            else if (nextInstruction == '>')
            {
                if (currentPosition != 9)
                {
                    Program.GeneratePassword(sequence, passwordLength, currentLength + 1, 9, targetIteration);
                }

                for (int nextPosition = currentPosition + 1; nextPosition < 9; nextPosition++)
                {
                    Program.GeneratePassword(sequence, passwordLength, currentLength + 1, nextPosition, targetIteration);
                }
            }
        }
    }
}
