//using Microsoft.EntityFrameworkCore;
using Minesweeper.Logic;
using System.Runtime.CompilerServices;

namespace Minesweeper
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            GameController controller = new GameController();
            controller.Guidance.PrintGuidance();
            controller.StartGame();


            //// Beispielverwendung mit Easy-Level-Strategie
            //IStrategyLevel easyStrategy = new EasyLevelStrategy();
            //Board easyBoard = new Board(easyStrategy);
            //easyBoard.GenerateMines();
            //Console.WriteLine("Easy Board:");
            //easyBoard.PrintBoard();
            //Console.WriteLine();

            //// Beispielverwendung mit Medium-Level-Strategie
            //IStrategyLevel mediumStrategy = new MediumLevelStrategy();
            //Board mediumBoard = new Board(mediumStrategy);
            //mediumBoard.GenerateMines();
            //Console.WriteLine("Medium Board:");
            //mediumBoard.PrintBoard();
            //Console.WriteLine();

            //// Beispielverwendung mit Difficult-Level-Strategie
            //IStrategyLevel difficultStrategy = new DifficultLevelStrategy();
            //Board difficultBoard = new Board(difficultStrategy);
            //difficultBoard.GenerateMines();
            //Console.WriteLine("Difficult Board:");
            //difficultBoard.PrintBoard();
        }
    }
}
