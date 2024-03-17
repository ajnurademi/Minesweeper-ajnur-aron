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
            Console.WriteLine(" - 'rm' Flagge entfernen");
            Console.WriteLine(" - 'o' Feld aufdecken");
            Console.WriteLine(" - 'u' Undo");
            Console.WriteLine(" - 'q' Spiel beenden");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Legende:");
            Console.WriteLine("  - '■' repräsentiert eine bedeckte Zelle.");
            Console.WriteLine("  - 'M' ist eine Mine.");
            Console.WriteLine("  - '@' ist eine Flagge, die eine mögliche Mine markiert.");
            Console.WriteLine("  - '*' ist eine Mine");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Start/Ende:");
            Console.WriteLine("  - 'S' Starte Minesweeper x3000 ");
            Console.WriteLine("  - 'E' Beende Minesweeper");
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        public void StartScreen()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  __  __ _                                                   ");
            Console.WriteLine(" |  \\/  (_)                                                  ");
            Console.WriteLine(" | \\  / |_ _ __   ___  _____      _____  ___ _ __   ___ _ __ ");
            Console.WriteLine(" | |\\/| | | '_ \\ / _ \\/ __\\ \\ /\\ / / _ \\/ _ \\ '_ \\ / _ \\ '__|");
            Console.WriteLine(" | |  | | | | | |  __/\\__ \\ \\ V  V /  __/  __/ |_) |  __/ |   ");
            Console.WriteLine(" |_|  |_|_|_| |_|\\___||___/ \\_/\\_/ \\___|\\___| .__/ \\___|_|   ");
            Console.WriteLine("      |___ \\ / _ \\ / _ \\ / _ \\              | |              ");
            Console.WriteLine(" __  __ __) | | | | | | | | | |             |_|              ");
            Console.WriteLine(" \\ \\/ /|__ <| | | | | | | | | |                              ");
            Console.WriteLine("  >  < ___) | |_| | |_| | |_| |                              ");
            Console.WriteLine(" /_/\\_\\____/ \\___/ \\___/ \\___/                               ");
            Console.WriteLine("                                                              ");
            Console.WriteLine();
            Console.WriteLine("    _    _                _     _                  _   ___           _    _      ");
            Console.WriteLine("   /_\\  (_)_ _ _  _ _ _  | |   /_\\  _ _ ___ _ _   | | / __| ___ _ __| |_ (_)__ _ ");
            Console.WriteLine("  / _ \\ | | ' \\ || | '_| | |  / _ \\| '_/ _ \\ ' \\  | | \\__ \\/ _ \\ '_ \\ ' \\| / _` |");
            Console.WriteLine(" /_/ \\_\\|_|_||_\\__,|_|   | | /_/ \\_\\_| \\___/_||_| |_| |___/\\___/ .__/|_|_\\__,_|");
            Console.WriteLine("      |__/               |_|                      |_|          |_|                ");
            Console.ResetColor();
            Console.WriteLine("Press any Key to continue 😊");
        }

        public void PrintWin()
        {
            Console.Write(" __     __          __          __           _ \n");
            Console.Write(" \\ \\   / /          \\ \\        / /          | |\n");
            Console.Write("  \\ \\_/ /__  _   _   \\ \\  /\\  / /__  _ __   | |\n");
            Console.Write("   \\   / _ \\| | | |   \\ \\/  \\/ / _ \\| '_ \\  | |\n");
            Console.Write("    | | (_) | |_| |    \\  /\\  / (_) | | | | |_|\n");
            Console.Write("    |_|\\___/ \\__,_|     \\/  \\/ \\___/|_| |_| (_)\n");
            Console.Write("                                               \n");

        }
    }
}
