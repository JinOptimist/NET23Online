using MazeCore.Cells;
using MazeCore.Characters.Interfaces;
using MazeCore.Interfaces;

namespace MazeCore.Characters
{
    public abstract class BaseCharacter : BaseCell, IBaseCharacter
    {

        private int _coins;
        private int _hp;
        private int _speed;
        private int _key;
        private int _burning;
        private int _superPower;
        private bool _isDead;

        protected BaseCharacter(IMaze maze) : base(maze)
        {
            _coins = 0;
            _hp = 100;
            _speed = 1;
            _key = 0;
            _burning = 0;
            _superPower = 0;
        }
        public string Name { get; set; }

        public int Hp {
            get {
                return _hp;
            }
            set {
                _hp = Math.Clamp(value, 0, 100);
            }
        }
        public int Coins {
            get {
                return _coins;
            }
            set {
                _coins = Math.Max(0, value);
            }
        }
        public int Speed {
            get {
                return _speed;
            }
            set {
                _speed = Math.Max(1, value);
            }
        }
        public int Key {
            get {
                return _key;
            }
            set {
                _key = Math.Max(0, value);
            }
        }
        public int SuperPower {
            get {
                return _superPower;
            }
            set {
                _superPower = Math.Max(0, value);
            }
        }

        public int Burning {
            get {
                return _burning;
            }
            set {
                _burning = Math.Max(0, value);
            }
        }
        public bool IsDead => _isDead;
        public void ProcessBurnEffect()
        {
            if (_burning < 0)
            {
                return;
            }

            Hp--;
            Maze.EventHistory.Add($"You've lost 1 HP from burning. Your HP: {Hp}");

            _burning--;

            if (_burning == 0)
            {
                Maze.EventHistory.Add($"You put out the fire");
            }
        }

        public void Die()
        {
            _isDead = true;
            Hp = 0;
            Maze.EventHistory.Add($"Character died  with 0 HP");
        }
    }
}
