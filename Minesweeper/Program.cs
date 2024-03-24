//using Microsoft.EntityFrameworkCore;
using Minesweeper.Logic;
using System.Runtime.CompilerServices;

namespace Minesweeper
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            GameController controller = new GameController();
            controller.Guidance.StartScreen();
            Console.ReadLine();
            Console.Clear();
            controller.Guidance.PrintGuidance();
            controller.StartGame();
        }
    }
}