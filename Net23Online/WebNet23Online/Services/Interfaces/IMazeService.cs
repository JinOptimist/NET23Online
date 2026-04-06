using MazeCore.Interfaces;
using WebNet23Online.Models.Maze;

namespace WebNet23Online.Services.Interfaces
{
    public interface IMazeService
    {
        IMaze BuildMaze(int width, int height, int seed);
        MazeViewModel Map(IMaze maze);
        void MoveRight();
        IMaze GetMaze();
    }
}