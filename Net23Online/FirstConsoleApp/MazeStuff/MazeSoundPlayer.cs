using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeSoundPlayer
    {
        public void PlayTheSound(string pathToTheSound, float volumeOfTheSound)
        {
            var currentlyPlayingSound = new AudioFileReader(pathToTheSound);
            currentlyPlayingSound.Volume = volumeOfTheSound;
            var outputDevice = new WaveOutEvent();
            outputDevice.Init(currentlyPlayingSound);
            outputDevice.Play();

        }

    }
}
