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
        public Sound Sound { get; set; }
        public View ViewGame { get; set; }
        private Board GameBoard { get; set; }

        public void StartGame()
        {
            Console.WriteLine("Not Implemented")
        }

        public void ResetGame()
        {
            Console.WriteLine("Not Implemented")
        }

        public void EndGame() 
        { 
            Console.WriteLine("Not Implemented")
        }
    }
}
