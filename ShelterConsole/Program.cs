using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using ShelterConsole.BusinessLogic;
using ShelterConsole.DataAccess.Repositories;

namespace ShelterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxNumberOfAnimals = 5;
            Cat cat = new Cat { Name = "cat1", AgeInHumanYears = 3 };
            Cat cat2 = new Cat { Name = "cat2" };
            Dog dog = new Dog { Name = "dog1", AgeInHumanYears = 2 };
            Dog dog2 = new Dog { Name = "dog2", AgeInHumanYears = 8 };

            ShelterLogic logic = new ShelterLogic(new ShelterRepository(maxNumberOfAnimals));
            logic.SendAnimalToShelter(cat);
            logic.SendAnimalToShelter(cat2);
            logic.SendAnimalToShelter(dog);
            logic.SendAnimalToShelter(dog2);
            Console.WriteLine(logic.GetNumberOfCatsInShelter());
            Console.WriteLine(logic.GetNumberOfDogsInShelter());
            Cat cat4 = (Cat)logic.BuyAnimal("cat");
            Console.WriteLine(cat4.Name);
            Dog dog4 = (Dog)logic.BuyAnimal("dog");
            Console.WriteLine(dog4.Name);
            Console.WriteLine(logic.GetNumberOfCatsInShelter());
            Console.WriteLine(logic.GetNumberOfDogsInShelter());
            Dog dog5 = (Dog)logic.BuyAnimal("alligator");
        }
    }
}
