using System;

using _03_Porcupines.Animals.Enums;
using _03_Porcupines.Engine.Contracts;
using _03_Porcupines.Engine.Enums;

namespace _03_Porcupines.Engine
{
    public class AnimalMovement : IMovement
    {
        private const string DirectionUp = "U";
        private const string DirectionDown = "D";
        private const string DirectionLeft = "L";
        private const string DirectionRight = "R";

        private int distance;
        private MovementType movementType;
        private DirectionType directionType;

        public AnimalMovement(int distance, MovementType movementType, DirectionType directionType)
        {
            this.distance = distance;
            this.movementType = MovementType;
            this.directionType = directionType;
        }

        public DirectionType DirectionType
        {
            get
            {
                return this.directionType;
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
        }

        public MovementType MovementType
        {
            get
            {
                return this.movementType;
            }
        }

        public static IMovement CreateMovement(string directionCommand, string distanceCommand, MovementType movementType)
        {
            var distance = ParseDistanceCommand(distanceCommand);
            var directionType = ParseDirectionCommand(directionCommand);
            var movement = new AnimalMovement(distance, movementType, directionType);

            return movement;
        }

        private static int ParseDistanceCommand(string distanceToParse)
        {
            int distance;
            var isParsed = int.TryParse(distanceToParse, out distance);
            if (!isParsed)
            {
                throw new ArgumentException("distance");
            }

            return distance;
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
