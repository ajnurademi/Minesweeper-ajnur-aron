using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class LevelEasy : IStrategyLevel
    {
        public int Xsize { get;  }

        public int Ysize { get;  }

        public int MinesCount { get; }


        public LevelEasy()
        {
            this.Xsize = 8;
            this.Ysize = 8;
            this.MinesCount = 10;
        }

    }
}
