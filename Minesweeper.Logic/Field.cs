using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class Field
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int CountMinesAround { get; set; }
        public bool IsRevealed { get; set; }

        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }

        public void CountMinesAroundM()
        {
            Console.WriteLine("Not Implemented");
        }

        
    }
}
