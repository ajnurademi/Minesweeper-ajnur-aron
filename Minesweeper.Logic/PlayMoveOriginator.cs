using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class PlayMoveOriginator
    {
        public Field[,] GameBoardArray { get; set; }
        private IStrategyLevel strategy;

        public PlayMoveOriginator(IStrategyLevel strategy)
        {
            this.strategy = strategy;
        }

        public Board CreateState()
        {
            Board CopieBoard = new Board(strategy);
            CopieBoard.GameBoardArray = this.GameBoardArray;
            return CopieBoard;
        }

        public void RestoreState(Board state)
        {
            GameBoardArray = state.GameBoardArray;
        }
    }
}
