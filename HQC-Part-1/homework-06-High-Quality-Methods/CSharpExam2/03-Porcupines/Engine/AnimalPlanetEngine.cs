using System;
using System.Collections.Generic;

using _03_Porcupines.Animals.Contracts;
using _03_Porcupines.Animals.Enums;
using _03_Porcupines.Engine.Contracts;
using _03_Porcupines.Forests.Contracts;

namespace _03_Porcupines.Engine
{
    public class AnimalPlanetEngine : IEngine
    {
        private const string CommandWordsSeparator = " ";

        private const string RabbitCallSign = "R";
        private const string PorcupineCallSign = "P";

        private const string EndCommmand = "END";

        private IAnimal rabbit;
        private IAnimal porcupine;
        private IForest forest;
        private Func<string, string, MovementType, IMovement> movementCreator;

        public AnimalPlanetEngine(IRabbit rabbit, IPorcupine porcupine, IForest forest, Func<string, string, MovementType, IMovement> movementCreator)
        {
            if (rabbit == null)
            {
                throw new ArgumentNullException("rabbit");
            }

            if (porcupine == null)
            {
                throw new ArgumentNullException("porcupine");
            }

            if (movementCreator == null)
            {
                throw new ArgumentNullException("movementCreator");
            }

            if (forest == null)
            {
                throw new ArgumentNullException("forest");
            }

            this.forest = forest;
            this.rabbit = rabbit;
            this.porcupine = porcupine;
            this.movementCreator = movementCreator;
        }

        public bool EvaluateNextCommand(string command)
        {
            var shouldContinueExectution = true;

            var commandWords = this.GetCommandWords(command);
            if (commandWords[0] == AnimalPlanetEngine.EndCommmand)
            {
                shouldContinueExectution = false;
                return shouldContinueExectution;
            }

            switch (commandWords[0].ToUpper())
            {
                case AnimalPlanetEngine.RabbitCallSign:
                    this.Move(commandWords, this.rabbit);
                    break;
                case AnimalPlanetEngine.PorcupineCallSign:
                    this.Move(commandWords, this.porcupine);
                    break;
                default:
                    throw new ArgumentException("Unknown command.");
            }

            return shouldContinueExectution;
        }

        public string GetResult()
        {
            throw new NotImplementedException();
        }

        private void Move(IList<string> commandWords, IAnimal animal)
        {
            var movementToEvaluate = this.movementCreator.Invoke(commandWords[1], commandWords[2], animal.MovementType);
            var startingPosition = animal.Position;

            var newAnimalPosition = this.forest.EvaluateMovement(startingPosition, movementToEvaluate, animal);

            animal.Position = newAnimalPosition.Clone();
        }

        private IList<string> GetCommandWords(string command)
        {
            var separators = new[] { AnimalPlanetEngine.CommandWordsSeparator };
            var commandWords = command
                .Trim()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return commandWords;
        }
    }
}
