using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class LevelDifficult : IStrategyLevel
    {
        public int Xsize { get; }
        public int Ysize { get; }
        public int MinesCount { get; }


        public LevelDifficult()
        {
            this.Xsize = 30;
            this.Ysize = 16;
            this.MinesCount = 99;
        }

    }
}
