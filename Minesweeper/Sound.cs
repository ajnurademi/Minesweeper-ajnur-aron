using System;
using System.Media;

namespace Minesweeper
{
    public class Sound
    {
        /// <summary>
        /// Plays the Win Sound
        /// </summary>
        public static void PlayWinSound()
        {
            SoundPlayer sound = new SoundPlayer("win_sound.wav");
            sound.PlaySync();
        }

        /// <summary>
        /// Plays the Lose Sound 
        /// </summary>
        public static void PlayLoseSound()
        {
            SoundPlayer sound = new SoundPlayer("gameover_sound.wav");
            sound.PlaySync();
        }
    }
}