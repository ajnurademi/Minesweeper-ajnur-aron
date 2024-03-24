using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class LevelEasy : IStrategyLevel
    {
        public int Xsize { get; set; } = 8;
        public int Ysize { get; set; } = 8;
        public int MinesCount { get; set; } = 10;
    }
}