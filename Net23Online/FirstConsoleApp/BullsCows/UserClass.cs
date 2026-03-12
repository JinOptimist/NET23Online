using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class UserClass
    {
        public UserClass()
        {
            UserInterface();
        }
        Game game1;
        private void UserInterface()
        {
            Random random = new Random();
            random.Next(1000,9999);
            while (game1.GameOver == true)
            {
                var userValue = "";
                int i = 0;
                while (i >= 1)
                {
                    Console.WriteLine("Input 4х-digit value");
                    userValue = Console.ReadLine();
                    if (userValue.Length < 4 || userValue.Length > 4)
                    {
                        Console.WriteLine("Please input 4х-digit value");
                    }
                    else
                    {
                        i++;
                        game1=new Game(random.ToString(), userValue);
                    }
                    if (userValue.Length >= 4)
                    {


                    }
                }                
            }
        }
    }         
}
