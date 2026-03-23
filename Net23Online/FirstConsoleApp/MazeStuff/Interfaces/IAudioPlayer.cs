namespace FirstConsoleApp.MazeStuff.Interfaces
{
    public interface IAudioPlayer
    {
        void Play(string fileName, float volume = 0.3f, bool loop = false);
    }
}
