using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public class Bot
    {
        private List<DigitCandidate> uniqueDigits {  get; set; }
        private void GenerateUniqueDigitNumbers(List<string> uniqueDigitNumbers)
        {
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
                            uniqueDigitNumbers.Add(firstDigit.ToString() + secondDigit.ToString() +
                                thirdDigit.ToString() + fourthDigit.ToString());
                        }
                    }
                }
            }
        }

        public void CreateUniqueDigitsList()
        {
            uniqueDigits = new List<DigitCandidate>  {   
                                                    new DigitCandidate("0"), 
                                                    new DigitCandidate("1"), 
                                                    new DigitCandidate("2"), 
                                                    new DigitCandidate("3"), 
                                                    new DigitCandidate("4"), 
                                                    new DigitCandidate("5"), 
                                                    new DigitCandidate("6"), 
                                                    new DigitCandidate("7"),
                                                    new DigitCandidate("8"),
                                                    new DigitCandidate("9"),
                                                };
        }
    }
}
