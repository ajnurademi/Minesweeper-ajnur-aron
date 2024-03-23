using System;
using System.Media;

namespace Minesweeper
{
    public class Sound
    {
        public bool BackgroundMusicOn { get; set; } = true;
        public bool SoundEffectsOn { get; set; }

        /// <summary>
        /// Spielt den Hintergrundsound ab.
        /// </summary>
        public static void PlayBackgroundSound()
        {
            SoundPlayer sound = new SoundPlayer("background_sound.wav");
            sound.PlayLooping(); 
        }

        /// <summary>
        /// Spielt den Sieges-Sound ab.
        /// </summary>
        public static void PlayWinSound()
        {
            SoundPlayer sound = new SoundPlayer("win_sound.wav");
            sound.PlaySync();
        }

        /// <summary>
        /// Spielt den Verlierer-Sound ab.
        /// </summary>
        public static void PlayLoseSound()
        {
            SoundPlayer sound = new SoundPlayer("gameover_sound.wav");
            sound.PlaySync();
        }
    }
}
