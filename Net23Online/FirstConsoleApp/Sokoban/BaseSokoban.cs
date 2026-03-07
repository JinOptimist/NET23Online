using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.Sokoban
{
    public abstract class BaseSokoban
    {
        protected DifficultySettings _settings;

        public void Play()
        {
            SetupBeforeStart();
        }

        protected abstract void SetupBeforeStart();
    }
}
