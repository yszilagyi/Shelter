using ShelterConsole.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShelterConsole.Models
{
    public class Person
    {
        public Person instance;
        public string Name { get; set; }
        public int Age { get; set; }
        public double Money { get; set; }

        public Dictionary<string, Animal> OwnedAnimals;

        //public Animal BuyAnimal(string typeOfAnimal)
        //{
        //    return ShelterLogic.BuyAnimal(typeOfAnimal, instance );

        //}


    }
}
