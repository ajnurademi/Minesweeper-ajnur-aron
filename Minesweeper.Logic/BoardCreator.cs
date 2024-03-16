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
