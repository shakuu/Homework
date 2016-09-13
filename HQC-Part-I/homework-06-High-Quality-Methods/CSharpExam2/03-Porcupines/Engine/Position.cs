using _03_Porcupines.Engine.Contracts;

namespace _03_Porcupines.Engine
{
    public class Position : IPosition
    {
        private int row;
        private int column;

        public Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            set
            {
                this.column = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        public static IPosition CreatePosition(int row, int column)
        {
            return new Position(row, column);
        }

        public IPosition Add(IPosition delta)
        {
            var row = this.Row + delta.Row;
            var column = this.Column + delta.Column;
            var result = new Position(row, column);

            return result;
        }

        public IPosition Subtract(IPosition delta)
        {
            var row = this.Row - delta.Row;
            var column = this.Column - delta.Column;
            var result = new Position(row, column);

            return result;
        }

        public IPosition Clone()
        {
            var clonedPostion = new Position(this.Row, this.Column);
            return clonedPostion;
        }
    }
}
