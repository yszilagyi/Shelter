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
            Snake snake = new Snake { Name = "snake1", AgeInHumanYears = 3 };
            Hamster hamster = new Hamster { Name = "hamster" };
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            Rabbit rabbit2 = new Rabbit { Name = "rabbit2", AgeInHumanYears = 8 };
            Person person = new Person { Name = "John", Age = 18, Money = 29.99, OwnedAnimals = new Dictionary<string, Animal>() };
            Person person2 = new Person { Name = "Zac", Age = 24, Money = 51.99, OwnedAnimals = new Dictionary<string, Animal>() };

            ShelterLogic logic = new ShelterLogic(new ShelterRepository(maxNumberOfAnimals));
            logic.SendAnimalToShelter(cat);
            logic.SendAnimalToShelter(cat2);
            logic.SendAnimalToShelter(dog);
            logic.SendAnimalToShelter(dog2);
            Console.WriteLine(logic.GetNumberOfCatsInShelter());
            Console.WriteLine(logic.GetNumberOfDogsInShelter());
            Cat cat4 = (Cat)logic.BuyAnimal("cat", person);
            Console.WriteLine(cat4.Name);
            Dog dog4 = (Dog)logic.BuyAnimal("dog", person2);
            Console.WriteLine(dog4.Name);
            person.OwnedAnimals.Add(rabbit2.Name, rabbit2);
            //Console.WriteLine(person.OwnedAnimals[0].Name);
            Console.WriteLine(logic.GetNumberOfAnimalsInShelter());
            Console.WriteLine($"{person.Name} owns {person.OwnedAnimals.Count}: {string.Join(", ", person.OwnedAnimals.Keys)}");
            //Console.WriteLine(logic.GetNumberOfCatsInShelter());
            //Console.WriteLine(logic.GetNumberOfDogsInShelter());
            //Dog dog5 = (Dog)logic.BuyAnimal("alligator");
        }
    }
}
