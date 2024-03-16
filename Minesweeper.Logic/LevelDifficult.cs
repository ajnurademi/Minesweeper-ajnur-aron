using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class LevelDifficult : IStrategyLevel
    {
        public int Xsize { get; set; } = 15;
        public int Ysize { get; set; } = 15;
        public int MinesCount { get; set; } = 20;
    }
}
