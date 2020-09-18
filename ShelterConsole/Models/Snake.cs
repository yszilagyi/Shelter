using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterConsole.Models
{
    public class Snake : Animal
    {
        public int AgeInSnakeYears
        {
            get
            {
                return AgeInHumanYears * 18;
            }
        }
    }
}
