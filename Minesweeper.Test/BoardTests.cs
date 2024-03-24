using Minesweeper.Logic;
using System.Xml.Schema;


namespace Minesweeper.Test
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void GenerateMines_LevelEasy()
        {
            // Arrange
            IStrategyLevel strategy = new LevelEasy();
            Board board = new Board(strategy);

            // Act
            board.GenerateMines();

            // Assert
            int mineCount = 0;
            foreach (Field field in board.GameBoardArray)
            {
                if (field.IsMine)
                {
                    mineCount++;
                }
            }
            Assert.AreEqual(board.MinesCount, mineCount);
        }

        [TestMethod]
        public void CalcMinesAroundMe_CorrectMineCount()
        {
            // Arrange
            Board board = new Board(new LevelEasy());
            board.GameBoardArray = new Field[,]
            {
                { new Field { IsMine = true }, new Field(), new Field() },
                { new Field(), new Field { IsMine = true }, new Field() },
                { new Field(), new Field(), new Field { IsMine = true } }
            };
            int posX = 1;
            int posY = 1;

            // Act
            int mineCount = board.CalcMinesAroundMe(posX, posY);

            // Assert
            Assert.AreEqual(2, mineCount);
        }

        [TestMethod]
        public void Reveal_NoMinesAround_CurrentCellRevealed()
        {
            // Arrange
            var board = new Board(new LevelEasy());
            board.Xsize = 3;
            board.Ysize = 3;
            board.GameBoardArray = new Field[,]
            {
                { new Field(), new Field(), new Field() },
                { new Field(), new Field(), new Field() },
                { new Field(), new Field(), new Field() }
            };

            // Act
            board.Reveal(1, 1);

            // Assert
            Assert.IsTrue(board.GameBoardArray[1, 1].IsRevealed); 
        }

        [TestMethod]
        public void Reveal_NoMinesAround_MultipleCellsRevealed()
        {
            // Arrange
            var board = new Board(new LevelEasy());
            board.Xsize = 5;
            board.Ysize = 5;
            board.GameBoardArray = new Field[,]
            {
                { new Field(), new Field(), new Field(), new Field(), new Field() },
                { new Field(), new Field(), new Field(), new Field(), new Field() },
                { new Field(), new Field(), new Field(), new Field(), new Field() },
                { new Field(), new Field(), new Field(), new Field(), new Field() },
                { new Field(), new Field(), new Field(), new Field(), new Field() }
            };

            // Act
            board.Reveal(2, 2);

            // Assert
            Assert.IsTrue(board.GameBoardArray[2, 2].IsRevealed); 
            Assert.IsTrue(board.GameBoardArray[1, 2].IsRevealed); 
            Assert.IsTrue(board.GameBoardArray[3, 2].IsRevealed); 
            Assert.IsTrue(board.GameBoardArray[2, 1].IsRevealed); 
            Assert.IsTrue(board.GameBoardArray[2, 3].IsRevealed); 
        }
    }
}