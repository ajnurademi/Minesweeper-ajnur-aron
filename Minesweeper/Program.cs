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
        }
    }
}
