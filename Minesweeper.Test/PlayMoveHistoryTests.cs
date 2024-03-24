using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Test
{
    [TestClass]
    public class PlayMoveHistoryTests
    {
        [TestMethod]
        public void SaveState_Stack_Add()
        {
            //Arrange
            IStrategyLevel strategy = new LevelMedium();
            Board boardtest = new Board(strategy);

            //Act
            boardtest.Save();
            boardtest.Save();

            //Assert
            Assert.IsNotNull(boardtest.moveHistory.BoardStack);
            Assert.AreEqual(2 ,boardtest.moveHistory.BoardStack.Count);
        }


        [TestMethod]

        public void Pop_Stack_remove()
        {
            //Arrange
            IStrategyLevel strategy = new LevelMedium();
            Board boardtest = new Board(strategy);

            //Act
            boardtest.Save();
            boardtest.Save();
            boardtest.Save();
            boardtest.Save();
            boardtest.Undo();


            //Assert
            Assert.IsNotNull(boardtest.moveHistory.BoardStack);
            Assert.AreEqual(3, boardtest.moveHistory.BoardStack.Count);

        }
    }
}
