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
                    var isTopLeftSection = this.CheckIfWritingTopLeftSection(row, column);
                    var isTopRightSection = this.CheckIfWritingTopRightSection(row, column);
                    var isBateyes = this.CheckIfWritingBateyes(row, column);
                    var isMidleSection = this.ChackIfWritingMiddleSection(row, column);
                    var isBottomSection = this.CheckIfWritingBottomSection(row, column);

                    var shouldPrint = isTopLeftSection ||
                        isTopRightSection ||
                        isBottomSection ||
                        isMidleSection ||
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

        private bool CheckIfWritingBottomSection(int row, int column)
        {
            var bottomSectionStartRowNumber = this.topAndBottomSize + this.middleSize;

            var isCorrectRow = row >= bottomSectionStartRowNumber;

            var columnConstraintLeft = this.size + (row - bottomSectionStartRowNumber);
            var columnConstraintRight = this.horizontalSize - 1 - this.size - (row - bottomSectionStartRowNumber);
            var isColumnWithinConstraintsLeftSide = column > columnConstraintLeft;
            var isColumnWithinConstraintsRightSide = column < columnConstraintRight;
            var isCorrectColumn = isColumnWithinConstraintsLeftSide && isColumnWithinConstraintsRightSide;

            var isBottomPart = isCorrectRow && isCorrectColumn;

            return isBottomPart;
        }

        private bool ChackIfWritingMiddleSection(int row, int column)
        {
            var rowConstraintTop = this.topAndBottomSize;
            var rowConstraintBottom = this.topAndBottomSize + this.middleSize;
            var isRowWithinConstraintsTop = row >= rowConstraintTop;
            var isRowWithinConstraintsBottom = row < rowConstraintBottom;
            var isCorrectRow = isRowWithinConstraintsTop && isRowWithinConstraintsBottom;

            var columnConstraintLeft = (this.size - 1) / 2;
            var columnConstraintRight = this.horizontalSize - ((this.size + 1) / 2);
            var isColumnWithinConstraintLeft = column >= columnConstraintLeft;
            var isColumnWithinConstraintRight = column <= columnConstraintRight;
            var isCorrectColumn = isColumnWithinConstraintLeft && isColumnWithinConstraintRight;

            var isMiddlePart = isCorrectRow && isCorrectColumn;

            return isMiddlePart;
        }

        private bool CheckIfWritingBateyes(int row, int column)
        {
            var isCorrectRow = row == this.topAndBottomSize - 1;

            var isCorrectColumnLeft = column == this.horizontalMiddlePoint - 1;
            var isCorrectColumnRight = column == this.horizontalMiddlePoint + 1;
            var isCorrectColumn = isCorrectColumnLeft || isCorrectColumnRight;

            var isBateyes = isCorrectRow && isCorrectColumn;

            return isBateyes;
        }

        private bool CheckIfWritingTopRightSection(int row, int column)
        {
            var isCorrectRow = row < this.topAndBottomSize;

            var columnLeftConstraint = this.horizontalSize - 1 - this.size;
            var columnRightConstraint = this.horizontalSize - 1 - row;
            var isColumnWithinLeftConstraint = column > columnLeftConstraint;
            var isColumnWithinRightConstraint = column <= columnRightConstraint;
            var isCorrectColumn = isColumnWithinLeftConstraint && isColumnWithinRightConstraint;

            var isTopRightPartOfBatman = isCorrectRow && isCorrectColumn;

            return isTopRightPartOfBatman;
        }

        private bool CheckIfWritingTopLeftSection(int row, int column)
        {
            var isCorrectRow = row < this.topAndBottomSize;
            var isCorrectColumn = column < this.size && column >= row;

            var isTopLeftPartOfBatman = isCorrectRow && isCorrectColumn;

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