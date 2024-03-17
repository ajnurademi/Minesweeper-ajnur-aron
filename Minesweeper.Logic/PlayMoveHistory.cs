using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class PlayMoveHistory
    {
        public Stack<Board> BoardStack { get; set; }

        public PlayMoveHistory()
        {
            BoardStack = new Stack<Board>();
        }

        public void Push(Board board)
        {
            BoardStack.Push(board);
        }

        public Board Pop()
        {
            if (BoardStack.Count > 0)
            {
                return BoardStack.Pop();
            }
            else
            {
                return null;
            }
        }

    }
}
