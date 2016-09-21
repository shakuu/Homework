using MatrixPath.Logic.Values.Contracts;

namespace MatrixPath.Logic.Values
{
    public class BasicCellValueSequence : ICellValueSequence
    {
        private int lastValue;

        public int GetNextCellValue()
        {
            if (this.lastValue == int.MaxValue)
            {
                this.lastValue = 0;
            }

            return ++this.lastValue;
        }
    }
}
