using Minesweeper.Logic;

namespace Minesweeper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var model = new Model(20);

            while (true)
            {
                // Paint Game anhand Model

                Console.Clear();

                Console.WriteLine("Bitte Koordinate eingeben:");
                var coordinate = Console.ReadLine();

                model.DoTurn(coordinate);
            }

        }
    }
}
