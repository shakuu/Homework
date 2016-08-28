using System.Text;

namespace Batman.Models
{
    public class SuperBatman
    {
        private const char EmptySpace = ' ';

        private int size;
        private char symbol;

        private int horizontalSize;
        private int horizontalMiddlePoint;

        private int verticalSize;
        private int topAndBottomSize;
        private int middleSize;

        private int distanceBetweenEyes;

        public SuperBatman(int size, char symbolToPrint)
        {
            this.size = size;
            this.symbol = symbolToPrint;

            this.CalculateBatmanDimensions(size);
        }

        public override string ToString()
        {
            var batmanBuilder = new StringBuilder();

            for (int row = 0; row < this.verticalSize; row++)
            {
                for (int column = 0; column < this.horizontalSize; column++)
                {
                    var isTopLeftPartOfBatman = this.CheckIfWritingTopLeftPartOfBatman(row, column);
                    var isTopRightPartOfBatman = this.CheckIfWritingTopRightPartOfBatman(row, column);
                    var isBateyes = this.CheckIfWritingBateyes(row, column);
                    var isMidlePart = this.ChackIfWritingMiddlePart(row, column);
                    var isBottomPart = this.CheckIfWritingBottomPart(row, column);

                    var shouldPrint = isTopLeftPartOfBatman ||
                        isTopRightPartOfBatman ||
                        isBottomPart ||
                        isMidlePart ||
                        isBateyes;

                    if (shouldPrint)
                    {
                        batmanBuilder.Append(this.symbol);
                    }
                    else
                    {
                        batmanBuilder.Append(SuperBatman.EmptySpace);
                    }
                }

                batmanBuilder.AppendLine();
            }

            return batmanBuilder.ToString();
        }

        private bool CheckIfWritingBottomPart(int row, int column)
        {
            var isBottomPart = row >= this.topAndBottomSize + this.middleSize &&
                column > this.size + (row - (this.topAndBottomSize + this.middleSize)) &&
                column < this.horizontalSize - 1 - this.size - (row - (this.topAndBottomSize + this.middleSize));

            return isBottomPart;
        }

        private bool ChackIfWritingMiddlePart(int row, int column)
        {
            var isMiddlePart = row >= this.topAndBottomSize &&
                row < this.topAndBottomSize + this.middleSize &&
                column >= (this.size - 1) / 2 &&
                column <= this.horizontalSize - ((this.size + 1) / 2);

            return isMiddlePart;
        }

        private bool CheckIfWritingBateyes(int row, int column)
        {
            var isBateyes = row == this.topAndBottomSize - 1 &&
                (column == this.horizontalMiddlePoint - 1 || column == this.horizontalMiddlePoint + 1);

            return isBateyes;
        }

        private bool CheckIfWritingTopRightPartOfBatman(int row, int column)
        {
            var isTopRightPartOfBatman = row < this.topAndBottomSize
                && column > (this.horizontalSize - 1 - this.size)
                && column <= this.horizontalSize - 1 - row;

            return isTopRightPartOfBatman;
        }

        private bool CheckIfWritingTopLeftPartOfBatman(int row, int column)
        {
            var isTopLeftPartOfBatman = row < this.topAndBottomSize &&
                column < this.size &&
                column >= row;

            return isTopLeftPartOfBatman;
        }

        private void CalculateBatmanDimensions(int size)
        {
            this.horizontalSize = size * 3;
            this.topAndBottomSize = (size - 1) / 2;
            this.middleSize = size / 3;

            this.verticalSize = (2 * this.topAndBottomSize) + this.middleSize;
            this.horizontalMiddlePoint = (this.horizontalSize - 1) / 2;

            this.distanceBetweenEyes = size / 7;
        }
    }
}