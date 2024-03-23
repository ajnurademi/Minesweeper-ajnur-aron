using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class PlayMoveOriginator
    {
        public Field[,] CopieArray { get; set; }

        public void RestoreState(Board state)
        {
            CopieArray = state.GameBoardArray;
        }
    }
}
