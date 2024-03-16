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
       // public Difficulty Difficulty { get; set; }

       public IStrategyLevel StrategyLevel { get; set; }     

       public StrategyLevelFactory StrategyLevelFactory { get; set; } 

       private Board gameBoard { get; set; }
       
       public void PrintBoard(Board board)
        {
            Console.WriteLine("not Implemented" + board);
        }

        public void SelectDifficulty(string option)
        {
            BoardCreator.Strategy = StrategyLevelFactory.StrategyLevelInput(option);
            this.gameBoard = BoardCreator.CreateBoard();
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
