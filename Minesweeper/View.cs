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

        public void SelectDifficulty(string option)
        {
            BoardCreator.Strategy = StrategyLevelFactory.StrategyLevelInput(option);
            this.GameBoard = BoardCreator.CreateBoard();
        }

        public void SelectUserInput(string input)
        {
            if (input != null || input == "F" || input == "RM" || input == "O" || input == "U" || input == "Q")
            {
                this.userInput = input;
            }
            else
            {
                Console.Write("Select a correct input");
            }
        }

        public void SelectCoordinateXandY(int y, int x)
        {
            if (x != null || y != null)
            {
                if (x < this.GameBoard.Xsize || y < this.GameBoard.Ysize)
                {
                    processUserChoice(x, y);
                }
            }
            else
            {
                Console.Write("Selected coordinates are out of bounds. Please select valid coordinates.");
            }
        }

        private void processUserChoice(int x, int y)
        {
            if (this.userInput == "O")
            {
                GameBoard.GameBoardArray[x, y].IsRevealed = true;
            }
            else if (this.userInput == "F")
            {
                if (!GameBoard.GameBoardArray[x, y].IsFlagged)
                {
                    GameBoard.GameBoardArray[x, y].IsFlagged = true;
                    Console.WriteLine($"Flag placed at ({x + 1}, {y + 1})");
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
                    Console.WriteLine($"Flag removed from ({x + 1}, {y + 1})");
                }
                else
                {
                    Console.WriteLine($"No flag to remove at ({x + 1}, {y + 1})");
                }
            }
        }
    }
}
