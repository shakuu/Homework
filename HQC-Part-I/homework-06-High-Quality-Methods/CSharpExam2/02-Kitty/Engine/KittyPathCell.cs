using _02_Kitty.Engine.Contracts;
using _02_Kitty.Engine.Enums;

namespace _02_Kitty.Engine
{
    public class KittyPathCell : IPathCell
    {
        private CellConentType contentType;
        private bool isCollected;
        private bool isOddPosition;

        public KittyPathCell(CellConentType contentType, bool isOddPosition)
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
    }
}
