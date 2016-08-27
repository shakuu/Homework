using System;

using Minesweeper.Contracts;

namespace Minesweeper.Engine
{
    /// <summary>
    /// Implaments IEngine for Minesweeper.
    /// </summary>
    public class MinesweeperEngine : IGameEngine
    {
        private const string StartGameInstructionMessage = "Minesweeper! Available commands: top, restart, play, exit.";
        private const string PlaySelectedEmptyCellSuccessMessageTemplate = "Success! Position row: {0}, column: {1} is empty!";
        private const string PLaySekectedMineCellBoomMessageTemplate = "BOOM! There is a mine at row: {0}, column: {1}!";
        private const string PlayInvalidUserInputCoordinatesMessageTemplate = "Coordinates row: {0}, column: {1} are outside the play field!";
        private const string GameIsWonMessage = "Congrats! You won!";
        private const string ExitGameMessage = "Seeya later aligator!";

        private const string TopScoreCommand = "top";
        private const string RestartCommand = "restart";
        private const string ClickCommand = "play";
        private const string ExitCommand = "exit";

        private readonly int winConditionSuccsessfulTurns = 35;

        private int numberOfSuccessfulTurns = 0;

        private IGameBoard gameBoard;
        private IScoreBoard scoreBoard;
        private IUserInterface userInterface;

        private bool isRunning;
        private bool isGameOver;
        private bool isWon;

        /// <summary>
        /// Create a new MinesweeperEngine with the provided winCondition, IGameBoard, IScoreBoard and IUserInterface.
        /// </summary>
        /// <param name="winCondition"> The number of successful turns required to win the game. </param>
        /// <param name="gameBoard"> Required to check against. </param>
        /// <param name="scoreBoard"> Required to keep track of score history. </param>
        /// <param name="userInterface"> Required to display the game to the user. </param>
        /// <exception cref="ArgumentNullException"></exception>
        public MinesweeperEngine(int winCondition, IGameBoard gameBoard, IScoreBoard scoreBoard, IUserInterface userInterface)
        {
            this.CheckIfConstructorObjectIsNull(gameBoard);
            this.CheckIfConstructorObjectIsNull(scoreBoard);
            this.CheckIfConstructorObjectIsNull(userInterface);

            this.gameBoard = gameBoard;
            this.scoreBoard = scoreBoard;
            this.userInterface = userInterface;
            this.winConditionSuccsessfulTurns = winCondition;
        }

        /// <summary>
        /// Returns whether the app should keep feeding commands to the engine.
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
        }

        /// <summary>
        /// Prepare a new game.
        /// </summary>
        public void StartNewGame()
        {
            this.userInterface.DisplayMessage(MinesweeperEngine.StartGameInstructionMessage);

            this.gameBoard.GenerateNewGameBoard();
            this.numberOfSuccessfulTurns = 0;
            this.isRunning = true;
            this.isGameOver = false;
            this.isWon = false;

            this.userInterface.DisplayGameBoard(this.gameBoard);
        }

        /// <summary>
        /// Parse and execute a string command.
        /// Commands : 'top', 'restart', 'exit', '{row} {col}'
        /// </summary>
        /// <returns> Returns False when command is 'Exit'. </returns>
        public void ExecuteNextGameCycle()
        {
            var continueGameExecution = true;

            var command = this.userInterface.GetUserInput();
            var commandWords = this.ConvertCommandString(command);
            switch (commandWords[0])
            {
                case MinesweeperEngine.TopScoreCommand:
                    this.HandleTopScoreCommand();
                    break;
                case MinesweeperEngine.RestartCommand:
                    this.HandleRestartCommand();
                    break;
                case MinesweeperEngine.ClickCommand:
                    this.HandleClickCommand(commandWords[1], commandWords[2]);
                    break;
                case MinesweeperEngine.ExitCommand:
                    continueGameExecution = false;
                    break;
                default:
                    if (commandWords.Length >= 2)
                    {
                        this.HandleClickCommand(commandWords[0], commandWords[1]);
                    }

                    break;
            }

            this.userInterface.DisplayGameBoard(this.gameBoard);

            if (this.isWon || this.isGameOver)
            {
                if (this.isWon)
                {
                    this.userInterface.DisplayMessage(MinesweeperEngine.GameIsWonMessage);
                }

                this.AddNewScoreCardToScoreBoard(this.numberOfSuccessfulTurns);
                this.StartNewGame();
            }

            if (!continueGameExecution)
            {
                this.isRunning = continueGameExecution;
                this.userInterface.DisplayMessage(MinesweeperEngine.ExitGameMessage);
            }
        }

        private void HandleTopScoreCommand()
        {
            var scoreListToDisplay = this.scoreBoard.GetTopScores(5);
            this.userInterface.DisplayHighScore(scoreListToDisplay);
        }

        private void HandleRestartCommand()
        {
            this.StartNewGame();
        }

        private void HandleClickCommand(string row, string col)
        {
            int rowCoordinate;
            var isRowConverted = this.ConvertStringToNumber(row, out rowCoordinate);

            int colCoordinate;
            var isColConverted = this.ConvertStringToNumber(col, out colCoordinate);

            if (!isRowConverted || !isColConverted)
            {
                this.userInterface.DisplayMessage(string.Format(
                    MinesweeperEngine.PlayInvalidUserInputCoordinatesMessageTemplate, row, col));

                return;
            }

            var coordinateIsOutOfBounds = this.CheckCoordinatesOutOfGameBoardSize(rowCoordinate, colCoordinate);
            if (coordinateIsOutOfBounds)
            {
                this.userInterface.DisplayMessage(string.Format(
                    MinesweeperEngine.PlayInvalidUserInputCoordinatesMessageTemplate, row, col));

                return;
            }

            var isEmptyGameBoardCell = this.gameBoard.IsCellAtCoordinatesEmpty(rowCoordinate, colCoordinate);
            if (isEmptyGameBoardCell)
            {
                this.numberOfSuccessfulTurns++;
                this.isWon = this.CheckIfGameIsWon(this.numberOfSuccessfulTurns, this.winConditionSuccsessfulTurns);
                this.userInterface.DisplayMessage(string.Format(
                    MinesweeperEngine.PlaySelectedEmptyCellSuccessMessageTemplate, row, col));
            }
            else
            {
                this.isGameOver = true;
                this.userInterface.DisplayMessage(string.Format(
                    MinesweeperEngine.PLaySekectedMineCellBoomMessageTemplate, row, col));
            }

            this.gameBoard.UpdateCellContentAtCoordinates(rowCoordinate, colCoordinate);
        }

        private bool CheckCoordinatesOutOfGameBoardSize(int rowCoordinateToCheck, int columnCoordinateToCheck)
        {
            var isOutOfBounds = false;
            if (this.gameBoard.NumberOfRows <= rowCoordinateToCheck)
            {
                isOutOfBounds = true;
            }

            if (this.gameBoard.NumberOfColumns <= columnCoordinateToCheck)
            {
                isOutOfBounds = true;
            }

            return isOutOfBounds;
        }

        private bool CheckIfGameIsWon(int numberOfSuccessfulTurns, int winConditionSuccsessfulTurns)
        {
            var isWon = winConditionSuccsessfulTurns <= numberOfSuccessfulTurns;

            if (isWon)
            {
                this.userInterface.DisplayMessage(MinesweeperEngine.GameIsWonMessage);
            }

            return isWon;
        }

        private void AddNewScoreCardToScoreBoard(int score)
        {
            var userNickname = this.userInterface.GetUserNickname();

            this.scoreBoard.AddScoreCard(userNickname, score);
        }

        private bool ConvertStringToNumber(string number, out int convertedNumber)
        {
            var isSuccessfullyConverted = false;

            if (int.TryParse(number, out convertedNumber))
            {
                isSuccessfullyConverted = true;
            }

            return isSuccessfullyConverted;
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
