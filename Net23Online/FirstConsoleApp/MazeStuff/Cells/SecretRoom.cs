using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    internal class SecretRoom : BaseCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        //public IMaze Maze { get; set; } //лабиринт которому принадлежит наша клетка
        public IMaze SecretMaze { get; set; } //отдельный лабиринт 5х5 для секретной комнаты
        private readonly MazeController _mazeController;

        public bool IsSecretMaze { get; set; }=true;
        //public bool InsideSecretRoom { get; set; }=false;

        public SecretRoom(IMaze maze) : base(maze) 
        {
            SecretMaze = new Maze();
            SecretMaze.IsSecretMaze = true;
        }

        public override char Symbol { get; } ='R';
        public override bool Interaction(IBaseCharacter character)
        {
            //InsideSecretRoom=true;

            Maze.EventHistory.Add("You find secret room!");

            var secretRoomConroller = new MazeController();// Передать серкретный лабиринт лабиринта 5х5, 
            secretRoomConroller.Play(5,5, SecretMaze.IsSecretMaze);


            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);
            //Replace();

            return true;
        }

        private void Replace()
        {
            Maze.Surface.Remove(this);
            var ground = new Ground(Maze)
            {
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);
        }


    }
}
