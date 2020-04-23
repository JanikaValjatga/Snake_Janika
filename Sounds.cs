using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Snake_Janika
{
    class Sounds
    {
        public Sounds()
        {            
        }

        public void MainMusic()
        {
            var mainMusic = new MediaPlayer();
            string url = @"C:\Users\Lenovo\Desktop\Snake\Music\Fon.mp3";
            mainMusic.Open(new Uri(url, UriKind.Relative));
            mainMusic.Volume = 15;
            mainMusic.Play();
        }

        public void EatSound()
        {
            var eatsound = new MediaPlayer();
            string url = @"C:\Users\Lenovo\Desktop\Snake\Music\hrust.mp3";
            eatsound.Open(new Uri(url, UriKind.Relative));
            eatsound.Volume = 100;
            eatsound.Play();
        }
        public void GameOver()
        {
            var gameover = new MediaPlayer();
            string url = @"C:\Users\Lenovo\Desktop\Snake\Music\Gameover.mp3";
            gameover.Open(new Uri(url, UriKind.Relative));
            gameover.Volume = 100;
            gameover.Play();
        }
    }
}
