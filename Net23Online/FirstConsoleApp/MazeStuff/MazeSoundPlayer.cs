using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff
{
    public class MazeSoundPlayer : IAudioPlayer
    {
        private readonly IAudioOutput _outputDevice;
        private readonly Func<string, IAudioFile> _audioFactory;

        public MazeSoundPlayer(IAudioOutput outputDevice, Func<string, IAudioFile> audioFactory)
        {
            _outputDevice = outputDevice;
            _audioFactory = audioFactory;
        }

        public void Play(string fileName, float volume = 0.3f, bool loop = false)
        {
            var fullPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                @"MazeStuff\Sounds",
                fileName
            );

            var audioFile = _audioFactory(fullPath);

            audioFile.Volume = Math.Clamp(volume, 0f, 1f);

            var waveProvider = audioFile.GetWaveProvider();

            _outputDevice.Init(waveProvider);
            _outputDevice.Play();
        }
    }
}