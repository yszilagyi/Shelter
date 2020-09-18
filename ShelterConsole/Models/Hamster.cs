using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ShelterConsole.Models
{
    public class Hamster : Animal
    {
        public int AgeInHamsterYears
        {
            get
            {
                return AgeInHumanYears * 58;
            }
        }
    }
}
