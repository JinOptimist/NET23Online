using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Game
    {
        public Game(string secretValue, string valueFromUser)
        {
            RealizationGame(secretValue, valueFromUser);
        }
        public Game()
        {
                
        }
        public bool GameOver = false;
        private void RealizationGame(string secretValue, string valueFromUser)
        {
            valueFromUser = "1234";
            //var secretValue=random.Next(1000,9999);
            secretValue = "1456";
            var massSecretValue= new char[secretValue.ToString().Length];
            var massValueFromUser = new char[valueFromUser.ToString().Length];
            var integ = 0;
            var bullOrCow = " ";
            var bull = 0;
            var cow = 0;
            for (int i = 0; i < secretValue.ToString().Length; i++)
            {
                massSecretValue[i] = secretValue.ToString()[i];
            }
            for (int i = 0; i < valueFromUser.ToString().Length; i++)
            {
                massValueFromUser[i] = valueFromUser.ToString()[i];
            }
            while(integ<3)
            {
                if ((massSecretValue[integ].ToString()).Contains(valueFromUser))
                {
                    cow++;
                    //bullOrCow += " Бык";
                    //bull++;
                }
                if (massSecretValue[integ] == massValueFromUser[integ])
                {
                    bull++;
                    //bullOrCow += " Корова";
                    //cow++;
                }
                integ++;
                if (bull==4)
                {
                    GameOver = true;
                }
            }
            Console.Write(cow + "Сow, "+ bull + " bull;");
        }
    }
}
