using _03_Porcupines.Forests.Contracts;
using _03_Porcupines.Forests.Enums;

namespace _03_Porcupines.Forests
{
    public class ForestCell : IForestCell
    {
        private int pointsValue;
        private bool isCollected;
        private ForestCellContentType contentType;

        public ForestCell(ForestCellContentType contentType, int pointsValue = 0)
        {
            this.pointsValue = pointsValue;
            this.contentType = contentType;
            this.isCollected = false;
        }

        public ForestCellContentType ContentType
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

        public int Points
        {
            get
            {
                return this.pointsValue;
            }
        }
    }
}
