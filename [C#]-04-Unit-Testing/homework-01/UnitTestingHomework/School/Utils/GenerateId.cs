namespace School.Utils
{
    using System;
    using System.Threading;

    public class GenerateId
    {
        private int currentId;
        private int minimumValue;
        private int maximumValue;

        public GenerateId(int minimumValue, int maximumValue)
        {
            this.minimumValue = minimumValue;
            this.maximumValue = maximumValue;
            this.currentId = this.minimumValue - 1;
        }

        public int Generate()
        {
            // TODO:
            Interlocked.Increment(ref currentId);

            return currentId;
        }
    }
}
