using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class StrategyLevelFactory
    {
        /// <summary>
        /// Determines the strategy level based on the user's input.
        /// </summary>
        /// <param name="opt">The user's input representing the selected level: "E" for Easy, "M" for Medium, or "D" for Difficult.</param>
        /// <returns>
        /// An instance of the IStrategyLevel interface corresponding to the selected level:
        /// - LevelEasy for "E".
        /// - LevelMedium for "M".
        /// - LevelDifficult for "D".
        /// If the input is null or invalid, the default option (Easy) is returned.
        /// </returns>
        public IStrategyLevel StrategyLevelInput(string opt)
        {
            if (opt != null)
            { 
                if (opt == "E")
                {
                    IStrategyLevel levelE = new LevelEasy();
                    return levelE;
                }
                if (opt == "M")
                {

                    IStrategyLevel levelM = new LevelMedium();
                    return levelM;
                }

                if (opt == "D")
                {
                    IStrategyLevel levelD = new LevelDifficult();
                    return levelD;
                }
            }

            Console.WriteLine("Using default Option (Easy)\n");
            IStrategyLevel defaulStrategy = new LevelEasy();
            return defaulStrategy;
        }
    }
}
