using System;
using System.Media;


namespace Minesweeper
{
    public class Sound
    {

        public bool BackgroundMusicOn { get; set; } = true;
        public bool SoundEffectsOn { get; set; }


        public void PlayBackgroundSound()
        {
            //if(this.BackgroundMusicOn == true) 
            //{
                SoundPlayer sound = new SoundPlayer("background_sound.wav");
            sound.PlaySync();
            //}
        }
    }
}
