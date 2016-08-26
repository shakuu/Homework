using System;

using Minesweeper.Contracts;

namespace Minesweeper.Engine
{
    /// <summary>
    /// Implaments IEngine for Minesweeper.
    /// </summary>
    public class GameCommandsEngine : IEngine
    {
        private const string TopScoreCommand = "top";
        private const string RestartCommand = "restart";
        private const string ExitCommand = "exit";

        IGameBoard gameBoard;
        IScoreBoard scoreBoard;
        IUserInterface userInterface;

        /// <summary>
        /// Create a new GameCommandsEngine.
        /// </summary>
        /// <param name="gameBoard"> Required to check against. </param>
        /// <param name="scoreBoard"> Required to keep track of score history. </param>
        public GameCommandsEngine(IGameBoard gameBoard, IScoreBoard scoreBoard, IUserInterface userInterface)
        {
            this.CheckIfConstructorObjectIsNull(gameBoard);
            this.CheckIfConstructorObjectIsNull(scoreBoard);
            this.CheckIfConstructorObjectIsNull(userInterface);

            this.gameBoard = gameBoard;
            this.scoreBoard = scoreBoard;
            this.userInterface = userInterface;
        }

        /// <summary>
        /// Parse and execute a string command.
        /// Commands : 'top', 'restart', 'exit', '{row} {col}'
        /// </summary>
        /// <param name="command"> String to be parsed. </param>
        /// <returns> Returns False when command is 'Exit'. </returns>
        public bool ExecuteNextCommand(string command)
        {
            var continueGameExecution = true;

            var commandWords = this.ConvertCommandString(command);
            switch (commandWords[0])
            {
                case GameCommandsEngine.TopScoreCommand:
                    // TODO:
                    break;
                case GameCommandsEngine.RestartCommand:
                    // TODO:
                    break;
                case GameCommandsEngine.ExitCommand:
                    continueGameExecution = false;
                    break;
                default:
                    // TODO: 
                    break;
            }

            return continueGameExecution;
        }

        private string[] ConvertCommandString(string command)
        {
            var convertedCommand = command.Split(' ');

            return convertedCommand;
        }

        private void CheckIfConstructorObjectIsNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(obj.GetType().ToString());
            }
        }
    }
}
