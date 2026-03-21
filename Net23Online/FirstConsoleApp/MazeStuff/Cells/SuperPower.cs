using FirstConsoleApp.MazeStuff.Characters;
using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells;

public class SuperPower : BaseCell
{
    public SuperPower(IMaze maze) : base(maze)
    {
    }
    
    public override char Symbol => 'P';

    public override bool Interaction(IBaseCharacter character)
    {

        if (character.Coins < 2)
        {
            return true;
        }

        MazeSoundPlayer soundPlayer = new MazeSoundPlayer();
        soundPlayer.PlayMusic("superpower_sound.wav");

        Maze.EventHistory.Add("SuperPower! +Hp. You can break the wall.");
            
        Maze.Surface.Remove(this);
        var ground = new Ground(Maze) { 
            X = X,
            Y = Y,
        };
        Maze.Surface.Add(ground);

        character.Hp++;
        character.SuperPower++;
        character.Coins -= 2;
        return true;
    }
}