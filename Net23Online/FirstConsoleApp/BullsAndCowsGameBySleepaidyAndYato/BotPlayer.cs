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
        private List<string> UniqueDigitNumbers { get; set; }
        private List<BotPlayerDigitCandidate> UniqueDigits {  get; set; }        

        public BotPlayer()
        {
            GenerateUniqueDigitNumbers();
            CreateUniqueDigitsList();
        }


        //this method created only for testing
        public void WriteAllField()
        {
            UniqueDigitNumbers.ForEach(Console.WriteLine);
            for(int i = 0; i < UniqueDigits.Count; i++)
            {
                UniqueDigits[i].WriteAllField();
            }
        }
        private void GenerateUniqueDigitNumbers()
        {
            UniqueDigitNumbers = new List<string>();
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
                            UniqueDigitNumbers.Add(firstDigit.ToString() + secondDigit.ToString() +
                                thirdDigit.ToString() + fourthDigit.ToString());
                        }
                    }
                }
            }
        }

        private void CreateUniqueDigitsList()
        {
            UniqueDigits = new List<BotPlayerDigitCandidate>  {   
                                                    new BotPlayerDigitCandidate("0"), 
                                                    new BotPlayerDigitCandidate("1"), 
                                                    new BotPlayerDigitCandidate("2"), 
                                                    new BotPlayerDigitCandidate("3"), 
                                                    new BotPlayerDigitCandidate("4"), 
                                                    new BotPlayerDigitCandidate("5"), 
                                                    new BotPlayerDigitCandidate("6"), 
                                                    new BotPlayerDigitCandidate("7"),
                                                    new BotPlayerDigitCandidate("8"),
                                                    new BotPlayerDigitCandidate("9"),
                                                };
        }
    }
}
