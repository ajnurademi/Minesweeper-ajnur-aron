using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class LevelMedium : IStrategyLevel
    {
        public int Xsize { get; set; } = 16;
        public int Ysize { get; set; } = 16;
        public int MinesCount { get; set; } = 40;
    }
}