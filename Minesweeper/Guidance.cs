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

        /// <summary>
        /// Prints the game guidance including level selection, game mechanics, legend, and end options.
        /// </summary>
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
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Legende:");
            Console.WriteLine("  - '■' repräsentiert eine bedeckte Zelle.");
            Console.WriteLine("  - '*' ist eine Mine.");
            Console.WriteLine("  - 'F' ist eine Flagge, die eine mögliche Mine markiert.");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Ende/Reset:");
            Console.WriteLine("  - 'Q' Beende Minesweeper");
            Console.WriteLine("  - 'R' Reset Minesweeper");
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        /// <summary>
        /// Displays the start screen with the Minesweeper logo and prompts the user to continue.
        /// </summary>
        public void StartScreen()
        {
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" |  \\/  (_)                                                  ");
            Console.WriteLine(" | \\  / |_ _ __   ___  ____ __      __ __   __   ___ _ __  ___");
            Console.WriteLine(" | |\\/| | | '_ \\ / _ \\/ __\\ \\ \\ /\\ / / _ \\/ _ \\ '_ \\ / _ \\ '__|");
            Console.WriteLine(" | |  | | | | | |  __/\\__  \\ \\ V  V /  __/  __/ |_) |  __/ |   ");
            Console.WriteLine(" |_|  |_|_|_| |_|\\___||___/   \\_/\\_/ \\___|\\___| .__/ \\___|_|   ");
            Console.WriteLine("      |___ \\ / _ \\ / _ \\ / _ \\                | |              ");
            Console.WriteLine(" __  __ __) | | | | | | | | | |               |_|              ");
            Console.WriteLine(" \\ \\/ /|__ <| | | | | | | | | |                              ");
            Console.WriteLine("  >  < ___) | |_| | |_| | |_| |                              ");
            Console.WriteLine(" /_/\\_\\____/ \\___/ \\___/ \\___/                               ");
            Console.WriteLine("                                                              ");
            Console.WriteLine();
            Console.WriteLine("   _    _                _     _                  _   ___           _    _      ");
            Console.WriteLine("  /_\\  (_)_ _ _  _ _ _  | |   /_\\  _ _ ___ _ _   | | / __| ___ _ __| |_ (_)__ _ ");
            Console.WriteLine(" / _ \\ | | ' \\ || | '_| | |  / _ \\| '_/ _ \\ ' \\  | | \\__ \\/ _ \\ '_ \\ ' \\| / _` |");
            Console.WriteLine("/_/ \\_\\| |_||_\\__,_|_|  | | /_/ \\_\\_| \\___/_||_| | | |___/\\___/ .__/_||_|_\\__,_|");
            Console.WriteLine("     |__/               |_|                      |_|          |_|                ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPress any Key to continue 😊");
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a message indicating that the player has won the game.
        /// </summary>
        public void PrintWin()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" __     __          __          __           _ \n");
            Console.Write(" \\ \\   / /          \\ \\        / /          | |\n");
            Console.Write("  \\ \\_/ /__  _   _   \\ \\  /\\  / /__  _ __   | |\n");
            Console.Write("   \\   / _ \\| | | |   \\ \\/  \\/ / _ \\| '_ \\  | |\n");
            Console.Write("    | | (_) | |_| |    \\  /\\  / (_) | | | | |_|\n");
            Console.Write("    |_|\\___/ \\__,_|     \\/  \\/ \\___/|_| |_| (_)\n");
            Console.Write("                                               \n");
            Sound.PlayWinSound();
            Console.ResetColor();
            
        }

        /// <summary>
        /// Prints a message indicating that the player has lost the game.
        /// </summary>
        public void PrintLose()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("__     __           _               _   _ ");
            Console.WriteLine(" \\ \\   / /          | |             | | | |");
            Console.WriteLine("  \\ \\_/ /__  _   _  | |     ___  ___| |_| |");
            Console.WriteLine("   \\   / _ \\| | | | | |    / _ \\/ __| __| |");
            Console.WriteLine("    | | (_) | |_| | | |___| (_) \\__ \\ |_|_|");
            Console.WriteLine("    |_|\\___/ \\__,_| |______\\___/|___/\\__(_)");
            Console.WriteLine();
            Console.WriteLine("Wait until the sound has finished playing!!!");
            Sound.PlayLoseSound();
            Console.ResetColor();
            
        }
    }
}
