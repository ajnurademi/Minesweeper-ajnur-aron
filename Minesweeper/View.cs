using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class View
    {
        public BoardCreator BoardCreator { get; set; } = new BoardCreator();
        public IStrategyLevel StrategyLevel { get; set; }
        public StrategyLevelFactory StrategyLevelFactory { get; set; } = new StrategyLevelFactory();
        private string userInput { get; set; }
        public Board GameBoard { get; set; }
        
        /// <summary>
        /// Sets the game difficulty based on the selected option and creates the game board accordingly.
        /// </summary>
        /// <param name="option">The selected difficulty option.</param>
        public void SelectDifficulty(string option)
        {
            BoardCreator.Strategy = StrategyLevelFactory.StrategyLevelInput(option);
            this.GameBoard = BoardCreator.CreateBoard();
        }

        /// <summary>
        /// Sets the user input based on the provided input.
        /// </summary>
        /// <param name="input">The input string provided by the user.</param>
        /// 
        public void SelectUserInput(string input)
        {
            if (input == "F" || input == "RM" || input == "O" || input == "U" || input == "Q")
            {
                this.userInput = input;
                this.GameBoard.userInput = this.userInput;

                if(this.userInput == "U")
                {
                    this.GameBoard.GameBoardArray = this.GameBoard.Undo();

                    GameBoard.PrintBoard(GameBoard);
                }
            }
            else
            {
                Console.Write("Select a correct input");
            }
        }

        /// <summary>
        /// Selects the coordinates (X, Y) provided by the user and processes the choice.
        /// </summary>
        /// <param name="y">The Y-coordinate provided by the user.</param>
        /// <param name="x">The X-coordinate provided by the user.</param>
        public void SelectCoordinateXandY(int x, int y)
        {
            if (x >= 0 && x < this.GameBoard.Xsize && y >= 0 && y < this.GameBoard.Ysize)
            {
                processUserChoice(x, y);
            }
            else
            {
                Console.WriteLine("Selected coordinates are out of bounds. Please select valid coordinates.");
            }
        }

        /// <summary>
        /// Processes the user's choice for revealing, flagging, or removing flags on the game board based on the provided coordinates (X, Y).
        /// If the user's input is invalid, prompts the user to enter valid coordinates.
        /// </summary>
        /// <param name="x">The X-coordinate of the user's choice.</param>
        /// <param name="y">The Y-coordinate of the user's choice.</param>
        private void processUserChoice(int x, int y)
        {
            if (this.userInput == "O" && GameBoard.GameBoardArray[x, y] != null)
            {
                GameBoard.GameBoardArray[x, y].IsRevealed = true;
                GameBoard.Reveal(x, y);
            }
            else if (this.userInput == "F" && GameBoard.GameBoardArray[x, y] != null)
            {
                if (!GameBoard.GameBoardArray[x, y].IsFlagged && GameBoard.GameBoardArray[x, y] != null) 
                {
                    GameBoard.GameBoardArray[x, y].IsFlagged = true;
                }
                else
                {
                    Console.WriteLine($"Flag already exists at ({x + 1}, {y + 1})");
                }
            }
            else if (this.userInput == "RM")
            {
                if (GameBoard.GameBoardArray[x, y].IsFlagged)
                {
                    GameBoard.GameBoardArray[x, y].IsFlagged = false;
                }
                else
                {
                    Console.WriteLine($"No flag to remove at ({x + 1}, {y + 1})");
                }
            }
            
            else
            {
                Console.WriteLine("Oh this was a Wrong Input;");

                Console.Write("\nPlease enter the X coordinate: ");
                string xCoordinate = Console.ReadLine();
                int xCoordinateInt = int.Parse(xCoordinate);
                xCoordinateInt = xCoordinateInt - 1;

                Console.Write("\nPlease enter the Y coordinate: ");
                string yCoordinate = Console.ReadLine();
                int yCoordinateInt = int.Parse(yCoordinate);
                yCoordinateInt = yCoordinateInt - 1;
                SelectCoordinateXandY(xCoordinateInt, yCoordinateInt);
            }
        }
    }
}