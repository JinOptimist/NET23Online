using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.MazeAudio
{
    public class MazeAudioPlayer : IAudioPlayer
    {
        public void Play(string fileName, float volume = 0.3F, bool loop = false)
        {
            new MazeSoundPlayer().PlayMusic(fileName, volume, loop);
        }
    }
}
