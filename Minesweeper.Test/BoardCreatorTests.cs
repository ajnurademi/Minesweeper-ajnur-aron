using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Test
{
    [TestClass]
    public class BoardCreatorTests
    {
        [TestMethod]
        public void CreateBoard_LevelEasy_ReturnsBoardObject()
        {
            // Arrange
            IStrategyLevel strategy = new LevelEasy();
            BoardCreator boardCreator = new BoardCreator();
            boardCreator.Strategy = strategy;

            // Act
            Board board = boardCreator.CreateBoard();

            // Assert
            Assert.IsNotNull(board);
            Assert.IsInstanceOfType(board, typeof(Board));
        }

        [TestMethod]
        public void CreateBoard_WithoutStrategy_ReturnsNull()
        {
            // Arrange
            BoardCreator boardCreator = new BoardCreator();

            // Act
            Board board = boardCreator.CreateBoard();

            // Assert
            Assert.IsNull(board);
        }
    }
}
