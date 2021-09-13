using System;
using System.Collections.Generic;

namespace Mastermind.Models
{
    public class Farbcode
    {
        private List<Farbpin> Code = new List<Farbpin>();
        public int CodeLaenge;

        public Farbcode(int codeLaenge)
        {
            //Hier wird die Codelänge übernommen und der Code wird vorgefüllt.
            CodeLaenge = codeLaenge;
            for (int i = 0; i < codeLaenge; i++)
            {
                Code.Add(null);
            }
        }


        public List<Farbpin> getPins()
        {
            //Eine einfache Get Methode.
            return Code;
        }

        public List<Farbpin> setPin(int position, Farbpin pin)
        {
            //Mit dieser Funktion kann man an einer bestimmten Position im Farbcode eine neue Farbe setzen. Das wird zum setzen des UserCodes benötigt. 
            if (pin != null && position >= 0 && position < CodeLaenge)
            {
                Code[position] = pin;
            }
            
            return Code;
        }

        public List<Farbpin> generieren(Colors[] farben)
        {                
            // In dieser Funktion wird ein zufälliger Code erstellt, der je nach Nutzereingabe eine bestimmte Länge und eine bestimmte Anzahl an Farben hat.
            if (farben != null)
            {
                Code.Clear();
                Random random = new Random();
                for (int i = 0; i < CodeLaenge; i++)
                {
                    Farbpin Pin = new Farbpin((Colors)farben.GetValue(random.Next(farben.Length)));
                    Code.Add(Pin);
                }
            }

            return Code;
        }


    }
}
