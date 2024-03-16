using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class LevelMedium : IStrategyLevel
    {
        public int Xsize { get;}
        public int Ysize { get;}
        public int MinesCount { get;}

        public LevelMedium()
        {
            Xsize = 16;
            Ysize = 16;
            MinesCount = 40;
        }

    }
}
