using System;
using System.Collections.Generic;
using System.Linq;

using _02_Kitty.Engine.Contracts;

namespace _02_Kitty.Engine
{
    public class JumpSequenceGenerator : ISequenceGenerator
    {
        public IEnumerable<int> GenerateSequenceOfPostions(string sequence, int pathSize)
        {
            var nextPosition = 0;
            var jumpSequence = new List<int>();
            jumpSequence.Add(nextPosition);

            var jumpLengths = this.ParseJumpLengthsInput(sequence);
            foreach (var jumpLength in jumpLengths)
            {
                nextPosition = (nextPosition + jumpLength) % pathSize;
                while (nextPosition < 0)
                {
                    nextPosition += pathSize;
                }

                jumpSequence.Add(nextPosition);
            }

            return jumpSequence;
        }

        private IEnumerable<int> ParseJumpLengthsInput(string sequence)
        {
            var listOfJumpLengths = sequence
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            return listOfJumpLengths;
        }
    }
}
