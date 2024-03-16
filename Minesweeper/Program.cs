//using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Minesweeper
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                GameController controller = new GameController();


                //Sound sound = new Sound();
                //sound.PlayBackgroundSound();

                controller.Guidance.PrintGuidance();
                controller.StartGame();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
