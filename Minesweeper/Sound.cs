/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Minesweeper
{
    public class Sound
    {

        public bool BackgroundMusicOn { get; set; }
        public bool SoundEffectsOn { get; set; }


        public static void PlaySound(string filePath)
        {
            var assembly = typeof(UI).Assembly;

            var resStream = assembly.GetManifestResourceStream($"Minesweeper.Sounds.{filePath}");

            if (resStream is null)
            {
                return;
            }
            var pathOfAssembly = typeof(Program).Assembly.Location;
            SoundPlayer musicPlayer = new SoundPlayer(resStream);
            musicPlayer.Play();
        }
    }
}
*/