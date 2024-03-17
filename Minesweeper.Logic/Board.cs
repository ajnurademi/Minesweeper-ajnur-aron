using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            CreateBoard();
        }

        public void Reveal(int posX, int posY)
        {


            GameBoardArray[posX, posY].IsRevealed = true;
            GameBoardArray[posX, posY].CountMinesAround = CalcMinesAroundMe(posX, posY);

            if(GameBoardArray[posX, posY].CountMinesAround == 0)
            {
                // top
                if(GameBoardArray[posX, posY + 1] != null)
                {
                    GameBoardArray[posX, posY + 1].IsRevealed = true;

                    //top-right
                    if (GameBoardArray[posX + 1, posY + 1] != null)
                    {
                         GameBoardArray[posX + 1, posY + 1].IsRevealed = true;
                    }

                    //top-left
                    if (GameBoardArray[posX - 1, posY + 1] != null)
                    {
                        GameBoardArray[posX - 1, posY + 1].IsRevealed = true;
                    }
                }

                // bottom 
                if (GameBoardArray[posX, posY - 1] != null)
                {
                    GameBoardArray[posX, posY - 1].IsRevealed = true;

                    //bottom-left
                    if (GameBoardArray[posX - 1, posY - 1] != null)
                    {
                        GameBoardArray[posX - 1, posY - 1].IsRevealed = true;
                    }

                    // bottom-right               
                    if (GameBoardArray[posX + 1, posY - 1] != null)
                    {
                        GameBoardArray[posX + 1, posY - 1].IsRevealed = true;
                    }
                }

                // left 
                if (GameBoardArray[posX -1 , posY] != null)
                {
                    GameBoardArray[posX - 1, posY].IsRevealed= true; 
                }

                // right 
                if (GameBoardArray[posX + 1, posY] != null)
                {
                    GameBoardArray[posX + 1, posY].IsRevealed = true; 
                }
            }
        }

        private int CalcMinesAroundMe(int posX, int posY)
        {
            GameBoardArray[posX, posY].CountMinesAround = 0;
            int Count = GameBoardArray[posX, posY].CountMinesAround;

            if (GameBoardArray[posX, posY + 1] != null && GameBoardArray[posX, posY + 1].IsMine) // top
            {
                Count++;
            }
             
            if(GameBoardArray[posX + 1, posY] != null) // right
            {
                if(GameBoardArray[posX + 1, posY].IsMine) //right
                {
                    Count++;
                }
                if(GameBoardArray[posX + 1, posY + 1].IsMine) // top right
                {
                    Count++;
                }
                if (GameBoardArray[posX + 1, posY - 1].IsMine) //bottom right
                {
                    Count++;
                }
            }

            if(GameBoardArray[posX, posY - 1] != null && GameBoardArray[posX, posY - 1].IsMine) //bottom
            {
                Count++;
            }

            if(GameBoardArray[posX - 1, posY] != null && GameBoardArray[posX - 1, posY].IsMine) //left
            {
                if(GameBoardArray[posX - 1, posY].IsMine) //left
                {
                    Count++;
                }
                if(GameBoardArray[posX - 1, posY + 1].IsMine) //top left
                {
                    Count++;
                }
                if (GameBoardArray[posX - 1, posY + 1].IsMine) //bottom left
                {
                    Count++;
                }
            }
            return Count;
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

        public void PrintBoard(Board board)
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
                    if (GameBoardArray[i, j].IsRevealed)
                    {
                        if (GameBoardArray[i, j].IsMine)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            int minesAround = GameBoardArray[i, j].CountMinesAround;
                            string minesAroundString = minesAround.ToString();
                            Console.Write(minesAroundString);
                            Console.Write(minesAround == 0 ? "" : "");
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
