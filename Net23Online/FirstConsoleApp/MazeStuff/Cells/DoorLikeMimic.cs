using FirstConsoleApp.MazeStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class DoorLikeMimic : Mimic
    {
        public DoorLikeMimic(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => Doors.SYMBOL;
    }
}
