using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApp.BullsAndCowsGameBySleepaidyAndYato
{
    public class BotPlayerDigitBullsCandidate
    {
        public enum DigitStatus
        {
            Unchecked,
            Confirmed,
            Possible
        }
        public string Value { get; private set; }
        private DigitStatus _status { get; set; }        

        public BotPlayerDigitBullsCandidate(string value) 
        {
            this.Value = value;
            this._status = DigitStatus.Unchecked;
        }

        //This method only for testing
        public void WriteAllField()
        {
            Console.WriteLine(Value);
            Console.WriteLine(_status);
        }

        public void SetStatus(DigitStatus status)
        {
            this._status = status;
        }
    }
}



