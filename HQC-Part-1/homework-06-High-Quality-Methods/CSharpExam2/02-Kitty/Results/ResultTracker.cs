using System.Text;

using _02_Kitty.Engine.Contracts;
using _02_Kitty.Engine.Enums;
using _02_Kitty.Results.Contracts;

namespace _02_Kitty.Results
{
    public class ResultTracker : IResult
    {
        private bool isDeadlocked;
        private int collectedFoodCount;
        private int collectedCoderSoulsCount;
        private int encounteredDeadlocksCount;
        private int jumpsMadeCount;

        public ResultTracker()
        {
        }

        public bool EvaluateCell(IPathCell pathCell)
        {
            if (pathCell.ContentType == CellConentType.Deadlock)
            {
                this.isDeadlocked = this.EvaluateDeadlock(pathCell);
            }
            else if (!pathCell.IsCollected)
            {
                this.CollectCellContent(pathCell);
            }

            if (!this.isDeadlocked)
            {
                this.jumpsMadeCount++;
            }

            return this.isDeadlocked;
        }
        
        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.isDeadlocked)
            {
                result.AppendLine("You are deadlocked, you greedy kitty!");
                result.AppendFormat(string.Format("Jumps before deadlock: {0}", this.jumpsMadeCount));
            }
            else
            {
                result.AppendLine(string.Format("Coder souls collected: {0}", this.collectedCoderSoulsCount));
                result.AppendLine(string.Format("Food collected: {0}", this.collectedFoodCount));
                result.AppendLine(string.Format("Deadlocks: {0}", this.encounteredDeadlocksCount));
            }

            return result.ToString();
        }

        private bool EvaluateDeadlock(IPathCell pathCell)
        {
            this.encounteredDeadlocksCount++;

            var isDeadlocked = false;
            if (pathCell.IsOddPosition)
            {
                isDeadlocked = this.ResolveDeadlock(pathCell, CellConentType.Food, this.collectedFoodCount);
            }
            else
            {
                isDeadlocked = this.ResolveDeadlock(pathCell, CellConentType.CoderSoul, this.collectedCoderSoulsCount);
            }

            return isDeadlocked;
        }

        private bool ResolveDeadlock(IPathCell pathCell, CellConentType typeToPayWith, int value)
        {
            var isDeadlocked = false;
            if (value > 0)
            {
                this.PayToResolveDeadlock(typeToPayWith);
                pathCell.ContentType = typeToPayWith;
                pathCell.IsCollected = false;
            }
            else
            {
                isDeadlocked = true;
            }

            return isDeadlocked;
        }

        private void PayToResolveDeadlock(CellConentType typeToPayWith)
        {
            if (typeToPayWith == CellConentType.Food)
            {
                this.collectedFoodCount--;
            }
            else
            {
                this.collectedCoderSoulsCount--;
            }
        }

        private void CollectCellContent(IPathCell pathCell)
        {
            switch (pathCell.ContentType)
            {
                case CellConentType.CoderSoul:
                    this.collectedCoderSoulsCount++;
                    break;
                case CellConentType.Food:
                    this.collectedFoodCount++;
                    break;
                default:
                    break;
            }

            pathCell.IsCollected = true;
            pathCell.ContentType = CellConentType.Empty;
        }
    }
}
