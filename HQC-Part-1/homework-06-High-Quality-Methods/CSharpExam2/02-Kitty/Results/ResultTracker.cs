using System;

using _02_Kitty.Engine.Contracts;
using _02_Kitty.Engine.Enums;
using _02_Kitty.Results.Contracts;
using _02_Kitty.Utils.Contracts;

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
            this.jumps++;

            if (pathCell.ContentType == CellConentType.Deadlock)
            {
                this.isDeadlocked = this.EvaluateDeadlock(pathCell);
            }
            else if (!pathCell.IsCollected)
            {
                this.CollectCellContents(pathCell);
            }

            return this.isDeadlocked;
        }

        public string WriteResult(IWriter writer)
        {
            throw new NotImplementedException();
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

        private void CollectCellContents(IPathCell pathCell)
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
