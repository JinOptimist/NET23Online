using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class SecretRoom : BaseCell
    {
        private const int MAX_HEIGHT = 5;
        private const int MAX_WIDTH = 5;
        public IMazeController secretRoomConroller = new MazeController(); //Перемистил с метода Interaction

        public IMaze SecretMaze { get; set; } //отдельный лабиринт для секретной комнаты
                                              //public bool IsSecretMaze { get; set; } = true;

        public SecretRoom(IMaze maze) : base(maze)
        {
            SecretMaze = new Maze();
            SecretMaze.IsSecretMaze = true;
        }

        public override char Symbol { get; } = 'R';
        public override bool Interaction(IBaseCharacter character)
        {
            Maze.EventHistory.Add("You find secret room!");
            Replace();

            //IMazeController secretRoomConroller = new MazeController();// Передать серкретный лабиринт. Передать в MazeController героя?
                                                                       // с типом MazeController тесты не работают. ImazeController

            secretRoomConroller.Play(MAX_HEIGHT, MAX_WIDTH, SecretMaze.IsSecretMaze, hero: (Hero)character);

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
