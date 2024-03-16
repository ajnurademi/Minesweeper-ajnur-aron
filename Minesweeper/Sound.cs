using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks.Sources;
using System.Runtime.CompilerServices;
using System.Drawing;
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
