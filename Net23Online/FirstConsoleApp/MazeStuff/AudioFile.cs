using NAudio.Wave;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff
{
    public class AudioFile : IAudioFile
    {
        private readonly AudioFileReader _reader;

        public AudioFile(string path)
        {
            _reader = new AudioFileReader(path);
        }

        public float Volume
        {
            get => _reader.Volume;
            set => _reader.Volume = value;
        }

        public IWaveProvider GetWaveProvider()
        {
            return _reader;
        }
    }
}