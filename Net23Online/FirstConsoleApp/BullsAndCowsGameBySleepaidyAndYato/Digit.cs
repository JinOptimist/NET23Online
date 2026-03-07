using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    internal class Digit
    {
        enum DigitStatus
        {
            Unchecked,
            Confirmed,
            Possible
        }
        private DigitStatus Status { get; set; }
        private string Value { get; set; }

        public Digit(string value) 
        {
            this.Value = value;
            this.Status = DigitStatus.Unchecked;
        }
    }
}
