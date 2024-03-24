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

        [TestMethod]
        public void StrategyLevelInput_LevelMedium_ReturnsLevelMedium()
        {
            // Arrange
            var factory = new StrategyLevelFactory();

            // Act
            var strategy = factory.StrategyLevelInput("M");

            // Assert
            Assert.IsInstanceOfType(strategy, typeof(LevelMedium));
        }

        [TestMethod]
        public void StrategyLevelInput_LevelDifficult_ReturnsLevelDifficult()
        {
            // Arrange
            var factory = new StrategyLevelFactory();

            // Act
            var strategy = factory.StrategyLevelInput("D");

            // Assert
            Assert.IsInstanceOfType(strategy, typeof(LevelDifficult));
        }

        [TestMethod]
        public void StrategyLevelInput_wrongInput_ReturnsDefaultLevelEasy()
        {
            // Arrange
            var factory = new StrategyLevelFactory();

            // Act
            var strategy = factory.StrategyLevelInput("dasdgdfhsdh");

            // Assert
            Assert.IsInstanceOfType(strategy, typeof(LevelEasy));
        }
    }
}
