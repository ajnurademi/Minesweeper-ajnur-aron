using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class Board
    {
        public Field[,] GameBoard { get; set; }
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public int MinesCount { get; set; }

        public Board(IStrategyLevel strategy)
        {
            this.Xsize = strategy.Xsize;
            this.Ysize = strategy.Ysize;
            this.MinesCount = strategy.MinesCount;

            // Erstelle das Board
            CreateBoard();
        }

        // Methode zum Erstellen des Boards
        private void CreateBoard()
        {
            // Initialisiere das Spielbrett mit Feldern
            GameBoard = new Field[Xsize, Ysize];
            for (int i = 0; i < Xsize; i++)
            {
                for (int j = 0; j < Ysize; j++)
                {
                    GameBoard[i, j] = new Field
                    {
                        PosX = i,
                        PosY = j,
                        CountMinesAround = 0,
                        IsRevealed = false,
                        IsMine = false,
                        IsFlagged = false
                    };
                }
            }
        }

        // Methode zum Generieren von Minen
        public void GenerateMines()
        {
            Random random = new Random();
            int minesPlaced = 0;
            while (minesPlaced < MinesCount)
            {
                int x = random.Next(0, Xsize);
                int y = random.Next(0, Ysize);
                if (!GameBoard[x, y].IsMine)
                {
                    GameBoard[x, y].IsMine = true;
                    minesPlaced++;
                }
            }
        }

        // Methode zum Drucken des Boards
        public void PrintBoard()
        {
            Console.Write("    ");
            for (int j = 0; j < Ysize; j++)
            {
                Console.Write(String.Format(" {0:00} ", j + 1));
            }
            Console.WriteLine();

            Console.WriteLine("  +" + new string('-', Ysize * 4));

            for (int i = 0; i < Xsize; i++)
            {
                Console.Write(String.Format("{0:00} |", i + 1));
                for (int j = 0; j < Ysize; j++)
                {
                    Console.Write(" ");
                    if (GameBoard[i, j].IsRevealed)
                    {
                        if (GameBoard[i, j].IsMine)
                            Console.Write("*");
                        else
                            Console.Write(GameBoard[i, j].CountMinesAround == 0 ? " " : GameBoard[i, j].CountMinesAround.ToString());
                    }
                    else
                    {
                        Console.Write("?");
                    }
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
        }
    }
}
