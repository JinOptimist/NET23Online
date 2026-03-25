using MazeCore.Cells.Interfaces;

namespace MazeCore.Characters.Interfaces
{
    public interface IBaseCharacter : IBaseCell
    {
        int Burning { get; set; }
        int Coins { get; set; }
        int Hp { get; set; }
        int Key { get; set; }
        string Name { get; set; }
        int Speed { get; set; }
        public int SuperPower { get; set; }

        
        void ProcessBurnEffect();
    }
}