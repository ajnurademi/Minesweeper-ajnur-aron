using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class View
    {
        public BoardCreator BoardCreator { get; set; } = new BoardCreator();
        public IStrategyLevel StrategyLevel { get; set; }
        public StrategyLevelFactory StrategyLevelFactory { get; set; } = new StrategyLevelFactory(); 

        private Board gameBoard { get; set; }

        //public void PrintBoard(Board board)
        //{
        //    Console.Write("   ");
        //    for (int j = 0; j < board.Ysize; j++)
        //    {
        //        Console.Write(String.Format("{0:00}", j) + " ");
        //    }
        //    Console.WriteLine();

        //    Console.WriteLine("  +" + new string('-', board.Ysize * 4));

        //    for (int i = 0; i < board.Xsize; i++)
        //    {
        //        Console.Write(String.Format("{0:00}", i) + " ");
        //        for (int j = 0; j < board.Ysize; j++)
        //        {
        //            Console.Write(" ");
        //            if (board.GameBoard[i, j].IsRevealed)
        //            {
        //                if (board.GameBoard[i, j].IsMine)
        //                    Console.Write("*");
        //                else
        //                    Console.Write(board.GameBoard[i, j].CountMinesAround == 0 ? " " : board.GameBoard[i, j].CountMinesAround.ToString());
        //            }
        //            else
        //            {
        //                Console.Write("?");
        //            }
        //            Console.Write(" |");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public void SelectDifficulty(string option)
        {
            BoardCreator.Strategy = StrategyLevelFactory.StrategyLevelInput(option);
            this.gameBoard = BoardCreator.CreateBoard();
        }  

        public void SelectUserInput(string input)
        {
            Console.WriteLine("Benutzereingabe: " + input);
        }

        public void SelectCoordinateXandY(string x, string y)
        {
            Console.WriteLine("Not Implemented" + x + "," + y);
        }
    }
}


//using Minesweeper.Logic;
//using System;

//namespace Minesweeper
//{
//    public class View
//    {
//        public BoardCreator BoardCreator { get; set; }
//        public IStrategyLevel StrategyLevel { get; set; }
//        public StrategyLevelFactory StrategyLevelFactory { get; set; }
//        private Board gameBoard { get; set; }

//        public void PrintBoard(Board board)
//        {
//            Console.Write("   ");
//            for (int j = 0; j < board.Ysize; j++)
//            {
//                Console.Write(String.Format("{0:00}", j) + " ");
//            }
//            Console.WriteLine();

//            Console.WriteLine("  +" + new string('-', board.Ysize * 4));

//            for (int i = 0; i < board.Xsize; i++)
//            {
//                Console.Write(String.Format("{0:00}", i) + " ");
//                for (int j = 0; j < board.Ysize; j++)
//                {
//                    Console.Write(" ");
//                    if (board.GameBoard[i, j].IsRevealed)
//                    {
//                        if (board.GameBoard[i, j].IsMine)
//                            Console.Write("*");
//                        else
//                            Console.Write(board.GameBoard[i, j].CountMinesAround == 0 ? " " : board.GameBoard[i, j].CountMinesAround.ToString());
//                    }
//                    else
//                    {
//                        Console.Write("?");
//                    }
//                    Console.Write(" |");
//                }
//                Console.WriteLine();
//            }
//        }

//        public void SelectDifficulty(string option)
//        {
//            BoardCreator.Strategy = StrategyLevelFactory.StrategyLevelInput(option);
//            this.gameBoard = BoardCreator.CreateBoard();
//        }

//        public void SelectUserInput(string input)
//        {
//            Console.WriteLine("Not Implemented" + input);
//        }

//        public void SelectCoordinateXandY(string x, string y)
//        {
//            Console.WriteLine("Not Implemented" + x + "," + y);
//        }
//    }

//    public class BoardCreator
//    {
//        public IStrategyLevel Strategy { get; set; }

//        public Board CreateBoard()
//        {
//            return new Board(Strategy);
//        }
//    }

//    public class Board
//    {
//        public Field[,] GameBoard { get; set; }
//        public int Xsize { get; set; }
//        public int Ysize { get; set; }
//        public int MinesCount { get; set; }

//        public Board(IStrategyLevel strategy)
//        {
//            this.Xsize = strategy.Xsize;
//            this.Ysize = strategy.Ysize;
//            this.MinesCount = strategy.MinesCount;

//            // Erstelle das Board
//            CreateBoard();
//        }

//        // Methode zum Erstellen des Boards
//        private void CreateBoard()
//        {
//            // Initialisiere das Spielbrett mit Feldern
//            GameBoard = new Field[Xsize, Ysize];
//            for (int i = 0; i < Xsize; i++)
//            {
//                for (int j = 0; j < Ysize; j++)
//                {
//                    GameBoard[i, j] = new Field
//                    {
//                        PosX = i,
//                        PosY = j,
//                        CountMinesAround = 0,
//                        IsRevealed = false,
//                        IsMine = false,
//                        IsFlagged = false
//                    };
//                }
//            }
//        }

//        // Methode zum Generieren von Minen
//        public void GenerateMines()
//        {
//            Random random = new Random();
//            int minesPlaced = 0;
//            while (minesPlaced < MinesCount)
//            {
//                int x = random.Next(0, Xsize);
//                int y = random.Next(0, Ysize);
//                if (!GameBoard[x, y].IsMine)
//                {
//                    GameBoard[x, y].IsMine = true;
//                    minesPlaced++;
//                }
//            }
//        }
//    }

//    public class Field
//    {
//        public int PosX { get; set; }
//        public int PosY { get; set; }
//        public int CountMinesAround { get; set; }
//        public bool IsRevealed { get; set; }
//        public bool IsMine { get; set; }
//        public bool IsFlagged { get; set; }
//    }

//    public interface IStrategyLevel
//    {
//        int Xsize { get; set; }
//        int Ysize { get; set; }
//        int MinesCount { get; set; }
//    }

//    public class StrategyLevelFactory
//    {
//        public IStrategyLevel StrategyLevelInput(string option)
//        {
//            switch (option.ToLower())
//            {
//                case "easy":
//                    return new EasyLevelStrategy();
//                case "medium":
//                    return new MediumLevelStrategy();
//                case "difficult":
//                    return new DifficultLevelStrategy();
//                default:
//                    throw new ArgumentException("Invalid option");
//            }
//        }
//    }

//    public class EasyLevelStrategy : IStrategyLevel
//    {
//        public int Xsize { get; set; } = 8;
//        public int Ysize { get; set; } = 8;
//        public int MinesCount { get; set; } = 10;
//    }

//    public class MediumLevelStrategy : IStrategyLevel
//    {
//        public int Xsize { get; set; } = 10;
//        public int Ysize { get; set; } = 12;
//        public int MinesCount { get; set; } = 20;
//    }

//    public class DifficultLevelStrategy : IStrategyLevel
//    {
//        public int Xsize { get; set; } = 15;
//        public int Ysize { get; set; } = 15;
//        public int MinesCount { get; set; } = 20;
//    }

//    class Program
//    {
//        static void Main(string[] args)
//        {
//            View view = new View();
//            view.StrategyLevelFactory = new StrategyLevelFactory();

//            // Beispielverwendung mit Easy-Level-Strategie
//            view.SelectDifficulty("easy");
//            view.gameBoard.GenerateMines();
//            Console.WriteLine("Easy Board:");
//            view.PrintBoard(view.gameBoard);
//            Console.WriteLine();

//            // Beispielverwendung mit Medium-Level-Strategie
//            view.SelectDifficulty("medium");
//            view.gameBoard.GenerateMines();
//            Console.WriteLine("Medium Board:");
//            view.PrintBoard(view.gameBoard);
//            Console.WriteLine();

//            // Beispielverwendung mit Difficult-Level-Strategie
//            view.SelectDifficulty("difficult");
//            view.gameBoard.GenerateMines();
//            Console.WriteLine("Difficult Board:");
//            view.PrintBoard(view.gameBoard);
//        }
//    }
//}
