namespace AcademyEcosystem
{
    /// <summary>
    /// Implement a command to create Grass.
    /// The Grass should be a plant and should have a Size of 2.
    /// </summary>
    public class Grass : Plant
    {
        private const int InitialSize = 2;

        public Grass(Point location)
            : base(location, Grass.InitialSize)
        {
        }

        /// <summary>
        /// The Grass should grow by 1 at each time unit
        /// (i.e. by as much as the timeElapsed parameter is in the Update method),
        /// if it IsAlive.
        /// </summary>
        /// <param name="time"></param>
        public override void Update(int time)
        {
            if (this.IsAlive)
            {
                this.Size += time;
            }
        }
    }
}
