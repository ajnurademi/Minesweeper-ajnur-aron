using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Guidance
    {
        public string GuidanceContent { get; set; }

        public void PrintGuidance() {
            Console.WriteLine(GuidanceContent);
        }
    }
}
