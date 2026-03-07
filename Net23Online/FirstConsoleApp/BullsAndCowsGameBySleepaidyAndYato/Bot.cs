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

        public List<Digit> CreateUniqueDigitsList()
        {
            var uniqueDigits = new List<Digit>  {   
                                                    new Digit("0"), 
                                                    new Digit("1"), 
                                                    new Digit("2"), 
                                                    new Digit("3"), 
                                                    new Digit("4"), 
                                                    new Digit("5"), 
                                                    new Digit("6"), 
                                                    new Digit("7"),
                                                    new Digit("8"),
                                                    new Digit("9"),
                                                };
            return uniqueDigits;
        }
    }
}
