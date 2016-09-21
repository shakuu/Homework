using MatrixPath.Logic.Values.Contracts;

namespace MatrixPath.Logic.Values
{
    public class BasicCellValueSequence : ICellValueSequence
    {
        private int lastValue;

        public int GetNextCellValue()
        {
            return ++lastValue;
        }
    }
}
