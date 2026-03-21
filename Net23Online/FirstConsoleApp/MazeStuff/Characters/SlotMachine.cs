using FirstConsoleApp.MazeStuff.Characters.Interfaces;
using FirstConsoleApp.MazeStuff.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.MazeStuff.Characters
{
    public class SlotMachine : BaseCharacter, IBaseCharacter
    {
        private Random _random = new Random();



        public SlotMachine(IMaze maze) : base(maze)
        {
            Coins = 100;
            Keys = 10;
        }

        public override char Symbol => 'S';

        public List<string> Jokes { get; set; } = new List<string>
        {
            "Let me guess: someone stole your sweet roll?",
            "Why did the programmer get lost in the maze? He forgot to implement backtracking!",
            "I'm reading a book about mazes. I just can't find my way out of it.",
            "How to know you've been in a maze too long? You start talking to the walls... and they answer!",
            "Why was the slot machine placed in the maze? To give players at least one chance at an easy win!"
        };

        public List<object> Winnings { get; set; } = new List<object>()
        {


        };

        public override bool Interaction(IBaseCharacter character)
        {                            
            if(character.Coins >= -5)
            {
                character.Coins--;
                this.Coins++;
            }
            else 
            {
                Maze.EventHistory.Add("You have no more coins");
                return false;
            }

            var winValue = _random.Next(0, 5);
            if (winValue == 0)
            {
                WinMoney(character);                
            }
            else if (winValue == 1)
            {
                WinKeys(character);
            }
            else if (winValue == 2)
            {
                WinJoke();
            }
            else
            {
                Lose();
            }
            return false;
        }

        public void WinMoney(IBaseCharacter character)
        {
            if (Coins <= 0)
            {
                Maze.EventHistory.Add($"You won coins, but they ran out!");                
            }
            else
            {
                var winCoins = _random.Next(1, 10);
                character.Coins += winCoins;

                Coins -= winCoins;
                Maze.EventHistory.Add($"You won {winCoins} coins!");
            }
        }
        public void WinKeys(IBaseCharacter character)
        {
            if (Keys <= 0)
            {
                Maze.EventHistory.Add($"You won keys, but they ran out!");                
            }
            else
            {
                var winKeys = _random.Next(1, 4);
                character.Keys += winKeys;
                Keys -= winKeys;
                Maze.EventHistory.Add($"You won {winKeys} keys!");
            }
                
        }

        public void WinJoke()
        {
            var winJoke = _random.Next(1, Jokes.Count);
            var joke = Jokes[winJoke];

            Maze.EventHistory.Add($"You won piece of joke: {joke}");
        }

        public void Lose()
        {
            Maze.EventHistory.Add("You lose :(");
        }


    }
}
