namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        public Rock(int hitPoints, Point position)
            : base(position)
        {
            this.HitPoints = hitPoints;
            this.Size = this.HitPoints / 2;
        }

        protected int Size { get; private set; }

        public int Quantity
        {
            get
            {
                return this.Size;
            }
        }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }
    }
}
