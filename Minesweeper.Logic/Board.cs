using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class Board
    {
        public Field[,] GameBoardArray { get; set; }
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

        private void CreateBoard()
        {
            GameBoardArray = new Field[Xsize, Ysize];
            for (int i = 0; i < Xsize; i++)
            {
                for (int j = 0; j < Ysize; j++)
                {
                    GameBoardArray[i, j] = new Field
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

        public void GenerateMines()
        {
            Random random = new Random();
            int minesPlaced = 0;

            for (int i = 0; i < Xsize; i++)
            {
                for (int j = 0; j < Ysize; j++)
                {
                    if (!GameBoardArray[i, j].IsRevealed)
                    {
                        while (minesPlaced < MinesCount)
                        {
                            int x = random.Next(0, Xsize);
                            int y = random.Next(0, Ysize);

                            if (!GameBoardArray[x, y].IsMine && !GameBoardArray[x, y].IsRevealed)
                            {
                                GameBoardArray[x, y].IsMine = true;
                                minesPlaced++;
                            }
                        }
                    }
                }
            }
        }


        public void PrintBoard(Board board)
        {
            Console.Clear();

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
                    if (GameBoardArray[i, j].IsRevealed)
                    {
                        if (GameBoardArray[i, j].IsMine)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            int minesAround = board.GameBoardArray[i, j].CountMinesAround;
                            string minesAroundString = minesAround.ToString();
                            Console.Write(minesAroundString);
                            Console.Write(minesAround == 0 ? "0" : minesAroundString);
                        }
                    }
                    else
                    {
                        Console.Write("■");
                    }
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
        }

    }
}

