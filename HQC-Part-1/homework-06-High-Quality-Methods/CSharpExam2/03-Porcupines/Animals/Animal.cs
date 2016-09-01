using System;

using _03_Porcupines.Animals.Contracts;
using _03_Porcupines.Animals.Enums;
using _03_Porcupines.Engine.Contracts;

namespace _03_Porcupines.Animals
{
    public class Animal : IAnimal
    {
        private int pointsCollected;
        private IPosition position;
        private MovementType movementType;


        protected Animal(IPosition position, MovementType movementType)
        {
            if (position == null)
            {
                throw new ArgumentNullException("position");
            }

            this.position = position;
            this.movementType = movementType;
        }

        public MovementType MovementType
        {
            get
            {
                return this.movementType;
            }
        }

        public int PointsCollected
        {
            get
            {
                return this.pointsCollected;
            }

            set
            {
                this.pointsCollected = value;
            }
        }

        public IPosition Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }
    }
}
