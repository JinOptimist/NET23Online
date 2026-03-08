using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public class BullsAndCowsGame
    {
        public int Round {  get; private set; }
        protected Player _player { get; set; }
        public void Play()
        {

        }
        public BullsAndCowsGame(Player player)
        {
            this.Round = 1;
            this._player = player;
            if (_player is BotPlayer botPlayer) 
            {
                botPlayer.SetGame(this);
            }
        }
        private void PlayOneRound()
        {
            //... ввод числа которое надо угадать
            //... проверка числа на корректность
            //далее ответ игрока (отгадывание числа)
            var guess = _player.MakeGuess();//игрок сообщает число
            //Сравнить числа
            _player.ProcessGuessResult(Bulls, Cows);

        } 
        protected string TakeTheNumberFromConsoleForBullsAndCows()
        {
            var numberFromConsoleForBullsAndCows = "";
            var isPlayerEnteredCorrectDigit = false;
            do
            {
                Console.WriteLine("Please enter a four-digit number with unique digits.");
                numberFromConsoleForBullsAndCows = Console.ReadLine();
                if (!numberFromConsoleForBullsAndCows.All(char.IsDigit) || numberFromConsoleForBullsAndCows.Length != 4)
                {
                    Console.WriteLine("Incorrect input. Please try again.");
                }
                else if (numberFromConsoleForBullsAndCows.Distinct().Count() != 4)
                {
                    Console.WriteLine("The input contains non-unique numbers. Please try again.");
                }
                else
                {
                    isPlayerEnteredCorrectDigit = true;
                }    

            } while (!isPlayerEnteredCorrectDigit);


            return numberFromConsoleForBullsAndCows;
        }
    }
}
