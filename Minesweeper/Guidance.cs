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
            Console.WriteLine("Anleitung:");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Level auswählen:");
            Console.WriteLine("Einfach (Easy): E");
            Console.WriteLine("Mittel (Medium): M");
            Console.WriteLine("Schwierig (Difficult): D");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Spielmechanik");
            Console.WriteLine(" - 'f' Flagge setzen");
            Console.WriteLine(" - 'r' Flagge entfernen");
            Console.WriteLine(" - 'o' Feld aufdecken");
            Console.WriteLine(" - 'u' Undo");
            Console.WriteLine(" - 'q' Spiel beenden");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Legende:");
            Console.WriteLine("  - '■' repräsentiert eine bedeckte Zelle.");
            Console.WriteLine("  - 'M' ist eine Mine.");
            Console.WriteLine("  - '@' ist eine Flagge, die eine mögliche Mine markiert.");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Start/Ende:");
            Console.WriteLine("  - 'S' Starte Minesweeper x3000 ");
            Console.WriteLine("  - 'E' Beende Minesweeper");
            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }
}
