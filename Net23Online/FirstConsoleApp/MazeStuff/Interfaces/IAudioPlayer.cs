using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Interfaces
{
    public interface IAudioPlayer
    {
        void Play(string fileName, float volume, bool loop);
    }
}