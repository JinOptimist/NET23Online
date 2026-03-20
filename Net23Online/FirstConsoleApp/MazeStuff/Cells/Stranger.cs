using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Cells
{
    public class Stranger : BaseCell
    {
        Random _random;
        static double[] _weights = { 100.0, 100.0, 100.0 };
        double _minWeight = 10.0;
        double _factor = 0.3;

        public Stranger(IMaze maze) : base(maze)
        {
        }

        public override char Symbol => '.';

        public override bool Interaction(IBaseCharacter character)
        {
            Maze.EventHistory.Add("Suddenly appeared some Stranger.");
            Maze.EventHistory.Add("He is doing something to you.");
            string action = WeightedRandomSelection(character);
            Maze.EventHistory.Add(action);
            return true;
        }

        private string WeightedRandomSelection(IBaseCharacter character)
        {
            int selection = GetWeightedIndex();
            double reduction = _weights[selection] * _factor;
            if (_weights[selection] - reduction < _minWeight)
            {
                reduction = _weights[selection] - _minWeight;
            }

            _weights[selection] -= reduction;
            double bonus = reduction / (_weights.Length - 1);

            for (int j = 0; j < _weights.Length; j++)
            {
                if (j != selection)
                {
                    _weights[j] += bonus;
                }
            }

            switch (selection)
            {
                case 0:
                    {
                        character.Coins++;
                        return "He gave you 1 coin.";
                    }
                case 1:
                    {
                        character.Hp--;
                        return "He hit you.";
                    }
                default:
                    {
                        character.Hp++;
                        return "He heal you";
                    }
            }
        }

        private int GetWeightedIndex()
        {
            double totalWeight = _weights.Sum();
            double randomPoint = _random.NextDouble() * totalWeight;
            double currentSum = 0;
            for (int i = 0; i < _weights.Length; i++)
            {
                currentSum += _weights[i];
                if (randomPoint <= currentSum)
                {
                    return i;
                }
            }

            return _weights.Length - 1;
        }
    }
}
