using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class PlayMoveHistory
    {
        public Stack<Field[,]> BoardStack { get; set; }

        /// <summary>
        /// Represents the move history of the Minesweeper game.
        /// </summary>
        public PlayMoveHistory()
        {
            BoardStack = new Stack<Field[,]>();
        }

        /// <summary>
        /// Saves the specified state of the game board to the move history.
        /// </summary>
        /// <param name="clone">The state of the game board to save.</param>
        public void SaveState(Field[,] clone)
        {
            BoardStack.Push(clone);
        }

        /// <summary>
        /// Retrieves and removes the most recent state of the game board from the move history.
        /// </summary>
        public Field[,] Pop()
        {
            if (BoardStack.Count > 0)
            {
                BoardStack.Pop();
                Field[,] arrayMovebefore = BoardStack.Peek(); 
                return arrayMovebefore;
            }
            else
            {
                return null;
            }
        }
    }
}