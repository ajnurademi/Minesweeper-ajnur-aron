using System.Drawing;

namespace Minesweeper.Logic
{
    public class Model
    {
        private int size { get; set; }

        private Field[,] gameBoard = new Field[20, 20];

        public Model(int size) 
        { 
            this.size = size;
        }

        public void DoTurn(string coordinate)
        {

        }
    }

    public class Field
    {
    }
}
