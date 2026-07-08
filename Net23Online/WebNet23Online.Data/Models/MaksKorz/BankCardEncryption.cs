using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models.MaksKorz
{
    public class BankCardEncryption//перенести в сервисы
    {
        public BankCardEncryption(string DUBC)
        {
            Replace(DUBC);
        }
        private void Replace(string DUBC)
        {
            var initially = Mirrored(DUBC);
            initially = initially.Replace("1", "*");
        }
        private string Mirrored(string DUBC)//принимает номер банковской карты
        {
            char[] arr = DUBC.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
