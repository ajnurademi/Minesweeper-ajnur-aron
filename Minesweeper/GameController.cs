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
        public bool Win { get; set; }
        public bool Lose { get; set; }
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
            Console.Write("Bitte wählen Sie ein Level aus (E/M/D): ");
            string userChoiceDifficulty = Console.ReadLine();
            userChoiceDifficulty = userChoiceDifficulty.ToUpper();
            this.ViewGame.SelectDifficulty(userChoiceDifficulty);

            this.gameBoard = this.ViewGame.BoardCreator.CreateBoard();
            if (gameBoard != null)
            {
                this.ViewGame.GameBoard = this.gameBoard;
                gameBoard.PrintBoard(gameBoard);
                
                UserInteraction();
                gameBoard.PrintBoard(gameBoard);
            }
            else
            {
                Console.WriteLine("Fehler beim Erstellen des Spielbretts.");
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

        public void UserInteraction()
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

            //this.Guidance.PrintWin();
        }
    }
}
