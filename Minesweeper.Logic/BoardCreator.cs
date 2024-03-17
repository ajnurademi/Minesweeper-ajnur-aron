using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class BoardCreator
    {
        public IStrategyLevel Strategy { get; set; }

        /// <summary>
        /// Creates a new game board based on the selected strategy.
        /// </summary>
        /// <returns>A new Board object initialized with the selected strategy, or null if the strategy is not set.</returns>
        public Board CreateBoard()
        {
            if(this.Strategy != null)
            {
                return new Board(this.Strategy);
            }

            return null;
        }
    }
}
