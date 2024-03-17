using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public GameController()
        {
            this.ViewGame = new View();
            this.Guidance = new Guidance();
        }

        public void StartGame()
        {
            Console.Write("Bitte wählen Sie ein Level aus (E = Easy / M = Medium / D = Difficult): ");
            string userChoiceDifficulty = Console.ReadLine();
            userChoiceDifficulty = userChoiceDifficulty.ToUpper();
            this.ViewGame.SelectDifficulty(userChoiceDifficulty);

            this.gameBoard = this.ViewGame.BoardCreator.CreateBoard();
            this.gameBoard.PrintBoard(this.gameBoard);
            //this.ViewGame.GameBoard = this.gameBoard;
            //UserInteraction();
            //this.gameBoard.PrintBoard(this.gameBoard);
            this.gameBoard.GenerateMines();

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
                    Console.WriteLine("Fehler beim Erstellen des Spielbretts.");
                }
            }
        }

        public void ResetGame()
        {
            Console.WriteLine("Not Implemented");
        }

        public void EndGame() 
        {
            Console.WriteLine("Not Implemented");
        }

        private void UserInteraction()
        {
            Console.WriteLine("Bitte geben Sie ein was sie machen möchten (z.B. o = Feld aufdecken) ");
            string userInput = Console.ReadLine();
            userInput = userInput.ToUpper();
            this.ViewGame.SelectUserInput(userInput);

            Console.Write("Bitte geben Sie die X-Koordinate ein: ");
            string xCoordinate = Console.ReadLine();
            int xCoordinateInt = int.Parse(xCoordinate);
            xCoordinateInt = xCoordinateInt - 1;

            Console.Write("Bitte geben Sie die Y-Koordinate ein: ");
            string yCoordinate = Console.ReadLine();
            int yCoordinateInt = int.Parse(yCoordinate);
            yCoordinateInt = yCoordinateInt - 1;

            this.ViewGame.SelectCoordinateXandY(xCoordinateInt, yCoordinateInt);

            Console.Clear();
        }
    }
}
