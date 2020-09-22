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



        public string ShowAnimals()
        {
            return ($"{Name} owns {OwnedAnimals.Count} animal(s){(string.Join(", ", OwnedAnimals.Keys))}".Trim());
        }
        public Animal BuyAnimal<T>(ShelterLogic shelter)
        {
            if (this.IsOldEnoughToBuyAnimal())
            {
                return shelter.BuyAnimal<T>(this);
            }
            else
            {
                throw new Exception($"{this.Name} is not old enough to buy a pet.");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="shelter">Shelter</param>
        /// <param name="identifier">Kind of animal</param>
        public Animal BuyAnimal<T>(ShelterLogic shelter, string identifier)
        {
            if (this.IsOldEnoughToBuyAnimal())
            {
                return shelter.BuyAnimal<T>(this, identifier);
            }
            else
            {
                throw new Exception($"{this.Name} is not old enough to buy a pet.");
            }
        }

        public void SendAnimalToShelter(ShelterLogic shelter, Animal animal)
        {
            shelter.SendAnimalToShelter(animal, this);
        }

        public bool IsOldEnoughToBuyAnimal()
        {
            return this.Age < 18
                ? false
                : true;

        }
    }
}
