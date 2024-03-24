using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public interface IStrategyLevel
    {
        int Xsize { get; }
        int Ysize { get; }
        int MinesCount { get; }
    }
}