using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Minesweeper.Logic
{
    public class Board
    {
        public Field[,] GameBoardArray { get; set; }
        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public int MinesCount { get; set; }
        public string userInput { get; set; }
        public PlayMoveHistory moveHistory { get; set; }

        /// <summary>
        /// Initializes a new instance of the Board class using the provided game strategy.
        /// </summary>
        /// <param name="strategy"></param>
        public Board(IStrategyLevel strategy)
        {
            this.Xsize = strategy.Xsize;
            this.Ysize = strategy.Ysize;
            this.MinesCount = strategy.MinesCount;
            this.moveHistory = new PlayMoveHistory();

            CreateBoard();
        }

        /// <summary>
        /// Saves the current state of the game board to the move history.
        /// </summary>
        public void Save()
        {
            Field[,] clone = Clone();
            this.moveHistory.SaveState(clone);
        }

        /// <summary>
        /// Undoes the last move by retrieving the previous state of the game board from the move history.
        /// </summary>
        public Field[,] Undo()
        {
            return moveHistory.Pop();
        }

        // State
        /// <summary>
        /// Clones the current state of the game board.
        /// </summary>
        public Field[,] Clone()
        {
            Field[,] clone = new Field[Xsize, Ysize];

            for (int i = 0; i < Xsize; i++)
            {
                for (int j = 0; j < Ysize; j++)
                {
                    clone[i, j] = new Field
                    {
                        PosX = i,
                        PosY = j,
                        CountMinesAround = GameBoardArray[i, j].CountMinesAround,
                        IsRevealed = GameBoardArray[i, j].IsRevealed,
                        IsMine = GameBoardArray[i, j].IsMine,
                        IsFlagged = GameBoardArray[i, j].IsFlagged
                    };
                }
            }

            return clone;
        }

        /// <summary>
        /// Reveals the specified cell at the given position on the game board.
        /// If the cell has no neighboring mines, adjacent cells are also revealed recursively.
        /// </summary>
        /// <param name="posX">The X-coordinate of the cell to reveal.</param>
        /// <param name="posY">The Y-coordinate of the cell to reveal.</param>
        public void Reveal(int posX, int posY)
        {
            GameBoardArray[posX, posY].IsRevealed = true;

            if (GameBoardArray[posX, posY].CountMinesAround == 0)
            {
                // bottom
                if (posY < Ysize - 1 && !GameBoardArray[posX, posY + 1].IsRevealed)
                {
                    Reveal(posX, posY + 1);
                }

                // top 
                if (posY > 0 && !GameBoardArray[posX, posY - 1].IsRevealed)
                {
                    Reveal(posX, posY - 1);
                }

                // left 
                if (posX > 0 && !GameBoardArray[posX - 1, posY].IsRevealed)
                {
                    Reveal(posX - 1, posY);
                }

                // right
                if (posX < Xsize - 1 && !GameBoardArray[posX + 1, posY].IsRevealed)
                {
                    Reveal(posX + 1, posY);
                }

                // top-left
                if (posX > 0 && posY > 0 && !GameBoardArray[posX - 1, posY - 1].IsRevealed)
                {
                    Reveal(posX - 1, posY - 1);
                }

                // top-right
                if (posX < Xsize - 1 && posY > 0 && !GameBoardArray[posX + 1, posY - 1].IsRevealed)
                {
                    Reveal(posX + 1, posY - 1);
                }

                // bottom-left
                if (posX > 0 && posY < Ysize - 1 && !GameBoardArray[posX - 1, posY + 1].IsRevealed)
                {
                    Reveal(posX - 1, posY + 1);
                }

                // bottom-right
                if (posX < Xsize - 1 && posY < Ysize - 1 && !GameBoardArray[posX + 1, posY + 1].IsRevealed)
                {
                    Reveal(posX + 1, posY + 1);
                }
            }
        }

        /// <summary>
        /// Calculates the number of mines surrounding the specified cell at the given position.
        /// </summary>
        /// <param name="posX">The X-coordinate of the cell.</param>
        /// <param name="posY">The Y-coordinate of the cell.</param>
        /// <returns>The count of mines surrounding the specified cell.</returns>
        public int CalcMinesAroundMe(int posX, int posY)
        {
            GameBoardArray[posX, posY].CountMinesAround = 0;
            int Count = GameBoardArray[posX, posY].CountMinesAround;

            if (posY < Ysize - 1)
            {
                if (GameBoardArray[posX, posY + 1].IsMine) // top
                {
                    Count++;
                }
            }

            if (posX < Xsize - 1)
            {
                if (GameBoardArray[posX + 1, posY].IsMine) //right
                {
                    Count++;
                }
                if (posY < Ysize - 1)
                {
                    if (GameBoardArray[posX + 1, posY + 1].IsMine) // bottom right
                    {
                        Count++;
                    }
                }
                if (posY > 0)
                {
                    if (GameBoardArray[posX + 1, posY - 1].IsMine) //top right
                    {
                        Count++;
                    }
                }
            }

            if (posY > 0)
            {

                if (GameBoardArray[posX, posY - 1].IsMine) //top
                {
                    Count++;
                }
            }

            if (posX > 0)
            {
                if (GameBoardArray[posX - 1, posY].IsMine) //left
                {
                    Count++;
                }
                if (posY < Ysize - 1)
                {
                    if (GameBoardArray[posX - 1, posY + 1].IsMine) //bottom left
                    {
                        Count++;
                    }
                }
                if (posY > 0)
                {
                    if (GameBoardArray[posX - 1, posY - 1].IsMine) //top left
                    {
                        Count++;
                    }
                }
            }
            return Count;
        }

        /// <summary>
        /// Creates the game board by initializing each cell with its properties such as position, mine count, revealed status, mine presence, and flagged status.
        /// </summary>
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

        /// <summary>
        /// Randomly generates mines on the game board until the specified number of mines is reached.
        /// </summary>
        public void GenerateMines()
        {
            Random random = new Random(); // 10 
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
            for (int i = 0; i < Xsize; i++)
            {
                for (int j = 0; j < Ysize; j++)
                {
                    this.GameBoardArray[i, j].CountMinesAround = CalcMinesAroundMe(i, j);
                }
            }
        }

        /// <summary>
        /// Prints the game board to the console, with a delay of 1000 milliseconds (1 second) before displaying.
        /// </summary>
        /// <param name="board">The game board to be printed.</param>
        public void PrintBoard(Board board)
        {
            Console.Clear();

            if (this.userInput != "U")
            {
                Save();
            }

            Thread.Sleep(750);
            Console.WriteLine();
            Console.Write("    ");
            for (int i = 0; i < board.Xsize; i++)
            {
                Console.Write(String.Format(" {0:00} ", i + 1));
            }
            Console.WriteLine();
            Console.WriteLine("  +" + new string('-', board.Xsize * 4));

            for (int j = 0; j < board.Ysize; j++)
            {
                Console.Write(String.Format("{0:00} |", j + 1));
                for (int i = 0; i < board.Xsize; i++)
                {
                    Console.Write(" ");
                    if (board.GameBoardArray[i, j].IsRevealed)
                    {
                        DisplayCell(i, j);
                        if (board.GameBoardArray[i, j].IsMine)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            int minesAround = board.GameBoardArray[i, j].CountMinesAround;
                            string minesAroundString = minesAround == 0 ? "" : minesAround.ToString();
                            Console.Write(minesAroundString);
                        }
                    }
                    else
                    {
                        if (board.GameBoardArray[i, j].IsFlagged)
                        {
                            Console.Write("F");
                        }
                        else
                        {
                            Console.Write("■");
                        }
                    }
                    Console.Write(" |");
                }
                Console.WriteLine();
                Console.WriteLine("  +" + new string('-', board.Xsize * 4));
            }
        }

        /// <summary>
        /// Makes the Count of how many mines are around a Field colorful.
        /// </summary>
        private void DisplayCell(int posX, int posY)
        {
            int minesAround = CalcMinesAroundMe(posX, posY);

            // Nur etwas ausgeben, wenn minesAround größer als 0 ist
            if (minesAround > 0)
            {
                string element = minesAround.ToString();

                switch (element)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case "6":
                    case "7":
                    case "8":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default:
                        break;
                }

                Console.Write(element + "");
                Console.ResetColor();
            }
            else
            {
                Console.Write(" ");
            }
        }
    }
}