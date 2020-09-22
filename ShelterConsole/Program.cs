using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using ShelterConsole.BusinessLogic;
using ShelterConsole.DataAccess.Repositories;
using System.Linq;

namespace ShelterConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            //const int maxNumberOfAnimals = 5;
            //Cat cat = new Cat { Name = "cat1", AgeInHumanYears = 3, Price = 13.20 };
            //Cat cat2 = new Cat { Name = "cat2", Price = 45 };
            //Dog dog = new Dog { Name = "dog1", AgeInHumanYears = 2, Price = 22.99 };
            //Dog dog2 = new Dog { Name = "dog2", AgeInHumanYears = 8 };
            //Snake snake = new Snake { Name = "snake1", AgeInHumanYears = 3, Price = 5.99 };
            //Hamster hamster = new Hamster { Name = "hamster" };
            //Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            //Rabbit rabbit2 = new Rabbit { Name = "rabbit2", AgeInHumanYears = 8 };
            //Person person = new Person
            //{
            //    Name = "John",
            //    Age = 18,
            //    Money = 29.99,
            //    OwnedAnimals = new Dictionary<string, Animal>() {
            //    { cat.Name, cat },
            //    { cat2.Name, cat2 }
            //}
            //};
            //Person person2 = new Person
            //{
            //    Name = "Zac",
            //    Age = 24,
            //    Money = 51.99,
            //    OwnedAnimals = new Dictionary<string, Animal>()
            //{
            //    {dog.Name, dog },
            //    {dog2.Name, dog2 }
            //}
            //};

            //person.ShowAnimals();
            //ShelterRepository shelter = new ShelterRepository(maxNumberOfAnimals);
            //ShelterLogic logic = new ShelterLogic(shelter);


            //person.BuyAnimal<Rabbit>(logic);
            //logic.SendAnimalToShelter(cat, person);
            //person.ShowAnimals();
            //logic.GetNumberOfAnimalsInShelter();
            //logic.SendAnimalToShelter(cat2, person);
            //person.ShowAnimals();
            //logic.GetNumberOfAnimalsInShelter();



            //person.OwnedAnimals.Add(rabbit2.Name, rabbit2);
            //person2.BuyAnimal<Cat>(logic, cat2.Name);
            //person2.ShowAnimals();
            //person2.SendAnimalToShelter(logic, dog);
            //person2.ShowAnimals();

        }
    }
}
