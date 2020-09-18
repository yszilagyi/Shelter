using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ShelterConsole.Models {
    public class Dog : Animal {
        public int AgeInDogYears
        {
            get
            {
                return AgeInHumanYears * 15;
            }
        }
    }
}
