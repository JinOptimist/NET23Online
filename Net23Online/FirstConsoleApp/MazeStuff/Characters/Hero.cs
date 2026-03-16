namespace FirstConsoleApp.MazeStuff.Characters
{
    public class Hero : BaseCharacter
    {
        public Hero(Maze maze) : base(maze)
        {
        }

        public override char Symbol => '@';

        public override bool Interaction(BaseCharacter character)
        {
            throw new NotImplementedException();
        }

    }
}
