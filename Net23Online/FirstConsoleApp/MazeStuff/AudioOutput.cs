using NAudio.Wave;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff
{
    public class AudioOutput : IAudioOutput
    {
        private readonly WaveOutEvent _waveOut = new WaveOutEvent();

        public void Init(IWaveProvider stream)
        {
            _waveOut.Init(stream);
        }

        public void Play()
        {
            _waveOut.Play();
        }
    }
}
    