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
        private Board GameBoard { get; set; }
        public Sound Sound { get; set; }

        public GameController()
        {
            this.ViewGame = new View();
            this.Guidance = new Guidance();

        }

        public void StartGame()
        {
            Console.Write("Bitte wählen Sie ein Level aus (E/M/D): ");
            string userChoice = Console.ReadLine();
            this.ViewGame.SelectDifficulty(userChoice);

            // Spielbrett abrufen und anzeigen
            Board gameBoard = this.ViewGame.BoardCreator.CreateBoard();
            if (gameBoard != null)
            {
                gameBoard.PrintBoard();
                // Benutzereingaben abfragen
                Console.WriteLine("Bitte geben Sie ein was sie machen möchten ? (z.B. o = Feld aufdecken) ");
                string userInput = Console.ReadLine();
                this.ViewGame.SelectUserInput(userInput);

                Console.WriteLine("Bitte geben Sie die X-Koordinate ein:");
                string xCoordinate = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie die Y-Koordinate ein:");
                string yCoordinate = Console.ReadLine();

                this.ViewGame.SelectCoordinateXandY(xCoordinate, yCoordinate);
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
    }
}
