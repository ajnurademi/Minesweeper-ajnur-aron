using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class View
    {
       public BoardCreator BoardCreator { get; set; }
       public Difficulty Difficulty { get; set; }
       
       public void PrintBoard(Board board)
        {
            console.WriteLine("not Implemented" + board);
        } 

       public void SelectDifficulty(int num)
        {
            Console.WriteLine("Not Implemented" + num);
        }

        public void SelectUserInput(string input)
        {
            Console.WriteLine("Not Implemented" + input);
        }

        public void SelectCoordinateXandY(string x, string y)
        {
            Console.WriteLine("Not Implemented" + x + "," + y);
        }
    }
}
