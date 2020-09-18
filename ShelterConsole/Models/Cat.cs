using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ShelterConsole.Models {
    public class Cat : Animal {
        public int AgeInCatYears
        {
            get
            {
                return AgeInHumanYears * 25;
            }
        }

    }
}
