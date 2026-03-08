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
        private string _lastGuess { get; set; }

        public BotPlayer()
        {
            GenerateUniqueDigitNumbers();
        }
        public void SetGame(BullsAndCowsGame game)
        {
            _game = game;
        }

        public override string MakeGuess()
        {
            var guessNumber = "";
            if (this._game.Round == 1)
            {
                guessNumber = "1234";
            }
            else if (this._game.Round == 2)
            {
                guessNumber = "5678";
            }
            else if (this._game.Round == 3)
            {
                if (_uniqueDigitNumbers[_uniqueDigitNumbers.Count].Contains("9"))
                {
                    guessNumber = "90" + _uniqueDigitNumbers[0][0] + _uniqueDigitNumbers[0][1];
                }
            }
            else
            {
                guessNumber = _uniqueDigitNumbers[0];
            }
            return guessNumber;
        }
        public override void ProcessGuessResult(int bullsCount, int cowsCount)
        {
            FilterNumberCandidates(bullsCount, cowsCount);
        }

        private void FilterNumberCandidates(int bullsCount, int cowsCount)
        {
            int bullsCountNumberCandidates = 0;
            int cowsCountNumberCandidates = 0;
            for (int indexUniqueDigitNumbers = _uniqueDigitNumbers.Count; indexUniqueDigitNumbers >= 0; indexUniqueDigitNumbers--)
            {
                for (int indexDigit = 0; indexDigit < _uniqueDigitNumbers[indexUniqueDigitNumbers].Length; indexDigit++)
                {
                    if (_uniqueDigitNumbers[indexUniqueDigitNumbers][indexDigit] == this._lastGuess[indexDigit])
                    {
                        bullsCountNumberCandidates++;
                    }
                    else if (_uniqueDigitNumbers[indexUniqueDigitNumbers].Contains(this._lastGuess))
                    {
                        cowsCountNumberCandidates++;
                    }
                }
                if (bullsCountNumberCandidates != bullsCount || cowsCountNumberCandidates != cowsCount)
                {
                    _uniqueDigitNumbers.RemoveAt(indexUniqueDigitNumbers);
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
    }
}
