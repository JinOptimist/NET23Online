using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public class BotPlayerDigitCandidate
    {
        enum DigitStatus
        {
            Unchecked,
            Confirmed,
            Possible
        }
        private DigitStatus Status { get; set; }
        private string Value { get; set; }

        public BotPlayerDigitCandidate(string value) 
        {
            this.Value = value;
            this.Status = DigitStatus.Unchecked;
        }

        //This method only for testing
        public void WriteAllField()
        {
            Console.WriteLine(Value);
            Console.WriteLine(Status);
        }
    }
}
