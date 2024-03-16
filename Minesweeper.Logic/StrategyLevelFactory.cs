using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    public class StrategyLevelFactory
    {

        public IStrategyLevel StrategyLevelInput(string opt)
        {
            
            if (opt != null)
            { 

                if (opt == "E")
                {
                    IStrategyLevel levelE = new LevelEasy();
                    Console.WriteLine(levelE.Xsize);
                    return levelE;
                }
                if (opt == "M")
                {

                    IStrategyLevel levelM = new LevelMedium();
                    Console.WriteLine(levelM.Xsize); 
                    return levelM;
                }

                if (opt == "D")
                {
                    IStrategyLevel levelD = new LevelDifficult();
                    Console.WriteLine(levelD.Ysize);
                    return levelD;
                }
               
            }

            Console.WriteLine("Using default Option (Easy)");
            IStrategyLevel defaulStrategy = new LevelEasy();
            return defaulStrategy;
        }

    }
}
