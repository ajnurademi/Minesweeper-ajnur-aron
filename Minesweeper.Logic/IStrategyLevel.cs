using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public interface IStrategyLevel
    {
        int Xsize { get; set; }
        int Ysize { get; set; }
        int MinesCount { get; set; }

        IStrategyLevel CreateStrategy();
    }
}
