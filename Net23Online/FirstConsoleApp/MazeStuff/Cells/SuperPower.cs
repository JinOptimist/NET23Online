using FirstConsoleApp.MazeStuff.Characters;

namespace FirstConsoleApp.MazeStuff.Cells;

public class SuperPower : BaseCell
{
    //добавить в действие со стеной условие, если есть супер сила, то стена становится землей
    public SuperPower(Maze maze) : base(maze)
    {
    }
    
    public override char Symbol => 'P';

    public override bool Interaction(BaseCharacter character)
    {
        if (character is Hero hero && hero.Coins >= 2)
        {
            Maze.EventHistory.Add("SuperPower! +Hp. You can break the wall.");
            
            Maze.Surface.Remove(this);
            var ground = new Ground(Maze) { 
                X = X,
                Y = Y,
            };
            Maze.Surface.Add(ground);

            hero.Hp++;
            hero.SuperPower++;
            hero.Coins -= 2;
        }

        return true;
    }
}