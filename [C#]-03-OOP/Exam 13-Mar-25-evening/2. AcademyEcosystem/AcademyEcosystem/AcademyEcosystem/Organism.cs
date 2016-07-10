namespace AcademyEcosystem
{
    public abstract class Organism : IOrganism
    {
        public bool IsAlive {get; protected set;}

        public Point Location { get; protected set; }

        public int Size { get; protected set; }

        public Organism(Point location, int size)
        {
            this.Location = location;
            this.Size = size;
            this.IsAlive = true;
        }

        public virtual void Update(int time)
        {
        }

        public virtual void RespondTo(IOrganism organism)
        {
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
