using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class GameController
    {
        public bool Win { get; set; } = false;
        public bool Lose { get; set; } = false;
        public Guidance Guidance { get; set; } 
        public View ViewGame { get; set; }
        private Board gameBoard { get; set; }
        public Sound Sound { get; set; }
        private string userInput { get; set; }

        /// <summary>
        /// Initializes a new instance of the GameController class.
        /// </summary>
        public GameController()
        {
            this.ViewGame = new View();
            this.Guidance = new Guidance();
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            Thread.Sleep(100);
            Console.Write("\nChoose Level (E = Easy / M = Medium / D = Difficult): ");
            string userChoiceDifficulty = Console.ReadLine();
            Console.Write("\n");
            Thread.Sleep(1000);

            userChoiceDifficulty = userChoiceDifficulty.ToUpper();
            this.ViewGame.SelectDifficulty(userChoiceDifficulty);

            this.gameBoard = this.ViewGame.BoardCreator.CreateBoard();
            this.gameBoard.GenerateMines();
            this.gameBoard.PrintBoard(this.gameBoard);

            while (true)
            {
                if (this.gameBoard != null)
                {
                    this.ViewGame.GameBoard = this.gameBoard;
                    UserInteraction();
                    this.gameBoard.PrintBoard(this.gameBoard);
                }
                else
                {
                    Console.WriteLine("Error creating Gameboard");
                }
            }
        }

        /// <summary>
        /// Resets the game.
        /// </summary>
        public void ResetGame()
        {
            Console.Clear();
            StartGame();
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        public void EndGame()
        {
            int countMineFlagged = 0;

            for (int i = 0; i < gameBoard.Xsize; i++)
            {
                for (int j = 0; j < gameBoard.Ysize; j++)
                {
                    Field currentField = gameBoard.GameBoardArray[i, j];

                    if (currentField.IsMine && currentField.IsFlagged)
                    {
                        countMineFlagged++;
                    }

                    if (currentField.IsMine && currentField.IsRevealed)
                    {
                        this.Lose = true;
                        gameBoard.Save();
                        Guidance.PrintLose();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Do you want to undo the move? (Undo = U)");
                        Console.ResetColor();
                        this.userInput = Console.ReadLine();
                        this.userInput = this.userInput.ToUpper();
                        if (userInput == "U")
                        {
                            this.ViewGame.SelectUserInput(userInput);
                            return; 
                        }
                        return;
                    }
                }
            }

            if (countMineFlagged == gameBoard.MinesCount)
            {
                this.Win = true;
                Guidance.PrintWin();
            }
        }

        /// <summary>
        /// Manages user interaction during the game.
        /// </summary>
        private void UserInteraction()
        {
            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine("\n\nPlease insert what you want to do (f.E. o = open Field) | type {SG} if you want to see the Short Guidance");
                this.userInput = Console.ReadLine();
                this.userInput = this.userInput.ToUpper();
                if (this.userInput == "R")
                {
                    ResetGame();
                    break;
                }
                if (this.userInput == "U")
                {
                    this.ViewGame.SelectUserInput(userInput);
                    break; 
                }
                if (this.userInput == "Q")
                {
                    Environment.Exit(0);
                    break;
                }
                if (userInput == "F" || userInput == "RM" || userInput == "O" || userInput == "U" || userInput == "Q" || userInput == "SG")
                {
                    if (this.userInput == "SG")
                    {
                        this.Guidance.ShortGuidanceUserInteraction();
                        continue;
                    }
                    this.ViewGame.SelectUserInput(userInput);
                    break;
                }
                else
                {
                    Console.WriteLine("This was a wrong input. Please have a look at the guidance.");
                }
            }
            if(this.userInput != "U")
            {
                int xCoordinateInt;
                while (true)
                {
                    Console.Write("\nPlease enter the X coordinate: ");
                    xCoordinateInt = 0;
                    while (true)
                    {
                        string xCoordinate = Console.ReadLine();
                        if (int.TryParse(xCoordinate, out xCoordinateInt))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a Number :)");
                        }
                    }

                    if (xCoordinateInt <= gameBoard.Xsize)
                    {

                        xCoordinateInt = xCoordinateInt - 1;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This number is not shown on the board. Please enter another Coordinate.");
                    }
                }

                int yCoordinateInt;
                while (true)
                {
                    Console.Write("\nPlease enter the Y coordinate: ");
                    string yCoordinate = Console.ReadLine();
                    yCoordinateInt = int.Parse(yCoordinate);
                    if (yCoordinateInt <= gameBoard.Ysize)
                    {
                        yCoordinateInt = yCoordinateInt - 1;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This number is not shown on the board. Please enter another Coordinate.");
                    }
                }
                this.ViewGame.SelectCoordinateXandY(xCoordinateInt, yCoordinateInt);
            }
            EndGame();
            Console.Clear();
        }
    }
}