using System;

using _03_Porcupines.Animals.Enums;
using _03_Porcupines.Engine.Contracts;
using _03_Porcupines.Engine.Enums;

namespace _03_Porcupines.Engine
{
    public class AnimalMovement : IMovement
    {
        private const string DirectionUp = "T";
        private const string DirectionDown = "B";
        private const string DirectionLeft = "L";
        private const string DirectionRight = "R";

        private IPosition delta;
        private MovementType movementType;
        private DirectionType directionType;

        public AnimalMovement(IPosition delta, MovementType movementType, DirectionType directionType)
        {
            if (delta == null)
            {
                throw new ArgumentException("delta");
            }

            this.delta = delta;
            this.movementType = movementType;
            this.directionType = directionType;
        }

        public DirectionType DirectionType
        {
            get
            {
                return this.directionType;
            }
        }

        public IPosition Delta
        {
            get
            {
                return this.delta;
            }
        }

        public MovementType MovementType
        {
            get
            {
                return this.movementType;
            }
        }

        public static Func<int, int, IPosition> PositionGenerator { get; set; }

        public static IMovement CreateMovement(string directionCommand, string distanceCommand, MovementType movementType)
        {
            var directionType = ParseDirectionCommand(directionCommand);
            var delta = ParseDistanceCommand(distanceCommand, directionType);
            var movement = new AnimalMovement(delta, movementType, directionType);

            return movement;
        }

        private static IPosition ParseDistanceCommand(string distanceToParse, DirectionType directionType)
        {
            int distance;
            var isParsed = int.TryParse(distanceToParse, out distance);
            if (!isParsed)
            {
                throw new ArgumentException("distance");
            }

            if (PositionGenerator == null)
            {
                throw new ArgumentException("PositionGenerator");
            }

            IPosition delta = null;
            switch (directionType)
            {
                case DirectionType.Up:
                    delta = PositionGenerator.Invoke(-distance, 0);
                    break;
                case DirectionType.Down:
                    delta = PositionGenerator.Invoke(+distance, 0);
                    break;
                case DirectionType.Left:
                    delta = PositionGenerator.Invoke(0, -distance);
                    break;
                case DirectionType.Right:
                    delta = PositionGenerator.Invoke(0, +distance);
                    break;
                default:
                    throw new ArgumentException();
            }

            return delta;
        }

        private static DirectionType ParseDirectionCommand(string directionToParse)
        {
            DirectionType directionType;
            switch (directionToParse)
            {
                case AnimalMovement.DirectionUp:
                    directionType = DirectionType.Up;
                    break;
                case AnimalMovement.DirectionDown:
                    directionType = DirectionType.Down;
                    break;
                case AnimalMovement.DirectionLeft:
                    directionType = DirectionType.Left;
                    break;
                case AnimalMovement.DirectionRight:
                    directionType = DirectionType.Right;
                    break;
                default:
                    throw new ArgumentException("direction");
            }

            return directionType;
        }
    }
}
