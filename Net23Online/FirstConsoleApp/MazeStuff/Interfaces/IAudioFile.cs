using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace FirstConsoleApp.MazeStuff.Interfaces
{
    public interface IAudioFile
    {
        float Volume { get; set; }
        IWaveProvider GetWaveProvider();
    }
}