using Minesweeper.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Minesweeper.Test
{
    [TestClass]
    public class StrategyLevelFactoryTests
    {
        [TestMethod]
        public void StrategyLevelInput_LevelEasy_ReturnsLevelEasy()
        {
            // Arrange
            var factory = new StrategyLevelFactory();

            // Act
            var strategy = factory.StrategyLevelInput("E");

            // Assert
            Assert.IsInstanceOfType(strategy, typeof(LevelEasy));
        }
    }
}
