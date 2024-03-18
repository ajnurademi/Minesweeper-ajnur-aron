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

        public PlayMoveHistory()
        {
            BoardStack = new Stack<Field[,]>();
        }

        public void Push(Field[,] clone)
        {
            BoardStack.Push(clone);
        }

        public Field[,] Pop()
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
