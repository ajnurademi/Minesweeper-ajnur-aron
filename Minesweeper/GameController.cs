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

            while (this.Win == false && this.Lose == false)
            {
                if (this.gameBoard != null)
                {
                    this.ViewGame.GameBoard = this.gameBoard;
                    UserInteraction();
                    this.gameBoard.PrintBoard(this.gameBoard);
                }
                else
                {
                    Console.WriteLine("Error by creating Gameboard");
                }
            }
            if (this.Win == true || this.Lose == true)
            {
                EndGame();
            }
        }

        /// <summary>
        /// Resets the game.
        /// </summary>
        public void ResetGame()
        {
            Console.WriteLine("Not Implemented");
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        public void EndGame()
        {
            int CountMineFlagged = 0;
            
            for (int i = 0; i < gameBoard.Xsize; i++)
            {
                for (int j = 0; j < gameBoard.Ysize; j++)
                {
                    Field currentField = gameBoard.GameBoardArray[i, j];
                   
                    if (currentField.IsMine && currentField.IsFlagged)
                    {
                        CountMineFlagged++;
                        break;
                    }
                }
            }

            if (this.Win && CountMineFlagged == gameBoard.MinesCount)
            {
                Guidance.PrintWin();
            }
            else
            {
                Guidance.PrintLose(); 
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
                Console.WriteLine("\n\nPlease insert what you want to do (f.E. o = open Field) ");
                string userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
                if(userInput == "F" || userInput == "RM" || userInput == "O" || userInput == "U" || userInput == "Q")
                {
                    this.ViewGame.SelectUserInput(userInput);
                    break;
                }
                else
                {
                    Console.WriteLine("This was a wrong input. Please have a look at the guidance.");
                }

            }

            int xCoordinateInt;
            while (true)
            {
                Console.Write("\nBitte geben Sie die X-Koordinate ein: ");
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
                    Console.WriteLine("This numbers is not shown on the board. Please enter another Coordinate.");
                }
            }

            int yCoordinateInt;
            while (true)
            {
                Console.Write("\nBitte geben Sie die Y-Koordinate ein: ");
                string yCoordinate = Console.ReadLine();
                yCoordinateInt = int.Parse(yCoordinate);
                if (yCoordinateInt <= gameBoard.Ysize)
                {
                    yCoordinateInt = yCoordinateInt - 1;
                    break;
                }
                else
                {
                    Console.WriteLine("This numbers is not shown on the board. Please enter another Coordinate.");
                }
            }

            this.ViewGame.SelectCoordinateXandY(xCoordinateInt, yCoordinateInt);

            Console.Clear();

        }
    }
}
