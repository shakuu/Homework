namespace School.Utils
{
    using System.Collections.Generic;

    using School.Exceptions;

    public static class IdGenerator
    {
        public static int GenerateUniqueIdInRange(IEnumerable<int> existingIds, int minimumValue, int maximumValue)
        {
            var output = minimumValue;

            foreach (var id in existingIds)
            {
                if (id == output)
                {
                    output++;
                }
                else
                {
                    return output;
                }
            }

            throw new ArgumentNotUniqueException();
        }
    }
}
