using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public class BotPlayer : Player
    {
        private BullsAndCowsGame _game { get; set; }
        private List<string> _uniqueDigitNumbers { get; set; }
        private List<BotPlayerDigitBullsCandidate> _uniqueDigits {  get; set; }
        private string _lastGuess {  get; set; }

        public BotPlayer()
        {
            GenerateUniqueDigitNumbers();
            CreateUniqueDigitsList();
        }
        public void SetGame (BullsAndCowsGame game)
        {
            _game = game;
        }

        //this method created only for testing
        public void WriteAllField()
        {
            _uniqueDigitNumbers.ForEach(Console.WriteLine);
            for(int i = 0; i < _uniqueDigits.Count; i++)
            {
                _uniqueDigits[i].WriteAllField();
            }
        }

        public override string MakeGuess()
        {
            switch (this._game.Round)
            {
                case 0:
                    return "1234";
                case 1:
                    return "5678";
                case 2:
                    var oneFound = false;
                    var nineFound = false;
                    foreach (var digit in _uniqueDigits)
                    {
                        if (digit.Value == "9")
                        {
                            nineFound = true;
                        }
                        if (digit.Value == "1")
                        {
                            oneFound = true;
                        }
                    }
                    if(nineFound && oneFound) 
                    {
                        return "9043";
                    }
                    else
                    {
                        return "9087";
                    }
                default:
                    
            }
        }
        public override void ProcessGuessResult(int Bulls, int Cows)
        {
            
            Console.WriteLine($"{Bulls}B {Cows}C.");
            if (Bulls + Cows == 0)
            {
                for(int i = _uniqueDigits.Count - 1; i >= 0; i--)
                {
                    if (_lastGuess.Contains(_uniqueDigits[i].Value))
                    {
                        _uniqueDigits.RemoveAt(i);
                    }
                }
            }
            else if (Bulls + Cows > 0)
            {
                foreach (var digit in _uniqueDigits)
                {
                    if (_lastGuess.Contains(digit.Value))
                    {
                        digit.SetStatus(BotPlayerDigitBullsCandidate.DigitStatus.Possible);
                    }
                }
            }
        }
        private void GenerateUniqueDigitNumbers()
        {
            _uniqueDigitNumbers = new List<string>();
            for (int firstDigit = 0; firstDigit < 10; firstDigit++)
            {
                for (int secondDigit = 0; secondDigit < 10; secondDigit++)
                {
                    if (secondDigit == firstDigit)
                    {
                        continue;
                    }
                    for (int thirdDigit = 0; thirdDigit < 10; thirdDigit++)
                    {
                        if (thirdDigit == firstDigit || thirdDigit == secondDigit)
                        {
                            continue;
                        }
                        for (int fourthDigit = 0; fourthDigit < 10; fourthDigit++)
                        {
                            if (fourthDigit == firstDigit || fourthDigit == secondDigit || fourthDigit == thirdDigit)
                            {
                                continue;
                            }
                            this._uniqueDigitNumbers.Add(firstDigit.ToString() + secondDigit.ToString() +
                                thirdDigit.ToString() + fourthDigit.ToString());
                        }
                    }
                }
            }
        }

        private void CreateUniqueDigitsList()
        {
            this._uniqueDigits = new List<BotPlayerDigitBullsCandidate>  {   
                                                    new BotPlayerDigitBullsCandidate("0"), 
                                                    new BotPlayerDigitBullsCandidate("1"), 
                                                    new BotPlayerDigitBullsCandidate("2"), 
                                                    new BotPlayerDigitBullsCandidate("3"), 
                                                    new BotPlayerDigitBullsCandidate("4"), 
                                                    new BotPlayerDigitBullsCandidate("5"), 
                                                    new BotPlayerDigitBullsCandidate("6"), 
                                                    new BotPlayerDigitBullsCandidate("7"),
                                                    new BotPlayerDigitBullsCandidate("8"),
                                                    new BotPlayerDigitBullsCandidate("9"),
                                                };
        }
    }
}
