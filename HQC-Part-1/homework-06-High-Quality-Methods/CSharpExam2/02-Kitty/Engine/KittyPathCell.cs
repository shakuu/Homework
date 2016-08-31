using System;
using System.Collections.Generic;

using _02_Kitty.Engine.Contracts;
using _02_Kitty.Engine.Enums;

namespace _02_Kitty.Engine
{
    public class KittyPathCell : IPathCell
    {
        private const char Food = '*';
        private const char CoderSoul = '@';
        private const char Deadlock = 'x';

        private CellConentType contentType;
        private bool isCollected;
        private bool isOddPosition;

        private KittyPathCell(CellConentType contentType, bool isOddPosition)
        {
            this.contentType = contentType;
            this.isOddPosition = isOddPosition;
            this.isCollected = false;
        }
        
        public CellConentType ContentType
        {
            get
            {
                return this.contentType;
            }

            set
            {
                this.contentType = value;
            }
        }

        public bool IsCollected
        {
            get
            {
                return this.isCollected;
            }

            set
            {
                this.isCollected = value;
            }
        }

        public bool IsOddPosition
        {
            get
            {
                return this.isOddPosition;
            }

            set
            {
                this.isOddPosition = value;
            }
        }

        public static IList<IPathCell> GenerateSequenceOfPathCells(string path)
        {
            var isOdd = false;
            var sequence = new List<IPathCell>();
            foreach (var symbol in path)
            {
                var newCellContent = GetCellContentType(symbol);
                var newPathCell = new KittyPathCell(newCellContent, isOdd);
                sequence.Add(newPathCell);
                isOdd = !isOdd;
            }

            return sequence;
        }

        private static CellConentType GetCellContentType(char symbol)
        {
            CellConentType result;
            switch (symbol)
            {
                case KittyPathCell.Food:
                    result = CellConentType.Food;
                    break;
                case KittyPathCell.CoderSoul:
                    result = CellConentType.CoderSoul;
                    break;
                case KittyPathCell.Deadlock:
                    result = CellConentType.Deadlock;
                    break;
                default:
                    throw new ArgumentNullException("content");
            }

            return result;
        }
    }
}
