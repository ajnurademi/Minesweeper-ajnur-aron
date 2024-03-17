using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class Field
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int CountMinesAround { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }

        public void Reveal(Field[,] gameBoard)
        {
            if (IsRevealed || IsFlagged)
                return;

            IsRevealed = true;

            if (IsMine)
                return;

            CountMinesAround = CalcMinesAroundMe(gameBoard);
            
            if (CountMinesAround == 0)
            {
                for (int i = PosX - 1; i <= PosX + 1; i++)
                {
                    for (int j = PosY - 1; j <= PosY + 1; j++)
                    {
                        if (i >= 0 && i < gameBoard.GetLength(0) && j >= 0 && j < gameBoard.GetLength(1))
                        {
                            if (i == PosX && j == PosY)
                                continue;

                            gameBoard[i, j].Reveal(gameBoard);
                        }
                    }
                }
            }
        }

        private int CalcMinesAroundMe(Field[,] gameBoard)
        {
            int minesCount = 0;

            if (IsMine == false)
            {
                for (int i = PosX - 1; i <= PosX + 1; i++)
                {
                    for (int j = PosY - 1; j <= PosY + 1; j++)
                    {
                        if (i >= 0 && i < gameBoard.GetLength(0) && j >= 0 && j < gameBoard.GetLength(1))
                        {
                            if (i == PosX && j == PosY)
                                continue;

                            if (gameBoard[i, j].IsMine)
                                minesCount++;
                        }
                    }
                }
            }
            else
            {
                
            }
            return minesCount;
        }
    }
}
