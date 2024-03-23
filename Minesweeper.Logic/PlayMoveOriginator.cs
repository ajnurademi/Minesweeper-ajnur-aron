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

        /// <summary>
        /// Restores the state of the game board from the specified <paramref name="state"/>.
        /// </summary>
        /// <param name="state">The state containing the game board array to restore.</param>
        public void RestoreState(Board state)
        {
            CopieArray = state.GameBoardArray;
        }
    }
}
