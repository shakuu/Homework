using System;

using Task1.ClassChef.Contracts;

namespace Task2.RefactorIfStatements
{
    public static class Tasks
    {
        public static void CookPeeledVegetable(IChef chef, IVegetable vegetable, IOven oven)
        {
            if (vegetable == null)
            {
                return;
            }

            IMeal preparedMeal;
            if (vegetable.IsPealed && !vegetable.IsRotten)
            {
                preparedMeal = chef.Cook(oven);
            }
        }

        public static void ShouldVisitCell(int x, int minX, int maxX, int y, int minY, int maxY)
        {
            var cellShouldBeVisited = CheckIfCellShouldBeVisited(x, y);
            var cellIsInBounds = CheckIfCellCoordinatesAreInBounds(x, minX, maxX, y, minY, maxY);

            if (cellIsInBounds && cellShouldBeVisited)
            {
                VisitCell(x, y);
            }
        }

        private static void VisitCell(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static bool CheckIfCellShouldBeVisited(int x, int y)
        {
            throw new NotImplementedException();
        }

        private static bool CheckIfCellCoordinatesAreInBounds(int x, int minX, int maxX, int y, int minY, int maxY)
        {
            throw new NotImplementedException();
        }
    }
}
