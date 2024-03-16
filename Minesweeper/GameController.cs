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
        //public Sound Sound { get; set; }
        public View ViewGame { get; set; }

        //private BoardCreator BoardCreator { get; set; }
        private Board GameBoard { get; set; }

        public Sound Sound { get; set; }

        public GameController()
        {
            this.ViewGame = new View();
            //this.Sound = new Sound();
            this.Guidance = new Guidance();
            //this.BoardCreator = new BoardCreator();
        }





        public void StartGame()
        {
            //Thread soundThread = new Thread(() =>
            //{
            //    Sound.PlayBackgroundSound();
            //});
            //soundThread.Start();

            Console.Write("Bitte wählen Sie ein Level aus (E/M/D): ");
            string userChoice = Console.ReadLine();
            this.ViewGame.SelectDifficulty(userChoice);

            




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
