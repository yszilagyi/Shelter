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

        public void ShowAnimals()
        {
            Console.WriteLine($"{Name} owns {OwnedAnimals.Count} animal(s): {string.Join(", ", OwnedAnimals.Keys)}");
        }
        public void BuyAnimal<T>(ShelterLogic shelter)
        {

            shelter.BuyAnimal<T>(this);
        }

        public void BuyAnimal<T>(ShelterLogic shelter, string identifier)
        {

            shelter.BuyAnimal<T>(this, identifier);
        }

    }
}
