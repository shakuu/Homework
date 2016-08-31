using System.Text;

using _02_Kitty.Engine.Contracts;
using _02_Kitty.Engine.Enums;
using _02_Kitty.Results.Contracts;

namespace _02_Kitty.Results
{
    public class ResultTracker : IResult
    {
        private bool isDeadlocked;
        private int food;
        private int coderSouls;
        private int deadlocks;
        private int jumps;

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
                this.jumps++;
            }

            return this.isDeadlocked;
        }

        public string GetResultLog()
        {
            var result = new StringBuilder();
            if (this.isDeadlocked)
            {
                result.AppendLine("You are deadlocked, you greedy kitty!");
                result.AppendFormat(string.Format("Jumps before deadlock: {0}", this.jumps));
            }
            else
            {
                result.AppendLine(string.Format("Coder souls collected: {0}", this.coderSouls));
                result.AppendLine(string.Format("Food collected: {0}", this.food));
                result.AppendLine(string.Format("Deadlocks: {0}", this.deadlocks));
            }

            return result.ToString();
        }

        private bool EvaluateDeadlock(IPathCell pathCell)
        {
            this.deadlocks++;

            var isDeadlocked = false;
            if (pathCell.IsOddPosition)
            {
                isDeadlocked = this.ResolveDeadlock(pathCell, CellConentType.Food, this.food);
            }
            else
            {
                isDeadlocked = this.ResolveDeadlock(pathCell, CellConentType.CoderSoul, this.coderSouls);
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
                this.food--;
            }
            else
            {
                this.coderSouls--;
            }
        }

        private void CollectCellContent(IPathCell pathCell)
        {
            switch (pathCell.ContentType)
            {
                case CellConentType.CoderSoul:
                    this.coderSouls++;
                    break;
                case CellConentType.Food:
                    this.food++;
                    break;
                default:
                    break;
            }

            pathCell.IsCollected = true;
            pathCell.ContentType = CellConentType.Empty;
        }
    }
}
