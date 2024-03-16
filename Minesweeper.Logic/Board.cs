using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class Board
    {
        public Field[,] GameBoard { get; set; }
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public int MinesCount { get; set; }


        public Board(IStrategyLevel strategy)
        {
            this.Xsize = strategy.Xsize;  
            this.Ysize = strategy.Ysize;
            this.MinesCount = strategy.MinesCount;
            

        }
        
        public void GenerateMines()
        {
            Console.WriteLine("Not Implemented!");
            
        }
    }
}
