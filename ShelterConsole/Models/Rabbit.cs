using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterConsole.Models
{
     public class Rabbit : Animal
    {
        public int AgeInRabbitYears
        {
            get
            {
                return AgeInHumanYears * 20;
            }
        }
    }
}
