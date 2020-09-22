using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterConsole.BusinessLogic;
using ShelterConsole.DataAccess.Repositories;
using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterConsole.Models.Tests
{
    [TestClass()]
    public class PersonTests
    {


        [TestMethod()]
        public void BuyAnimalTest()
        {
            int maxNumberOfAnimals = 5;
            Rabbit rabbit2 = new Rabbit { Name = "rabbit2", AgeInHumanYears = 8, Price = 5 };
            ShelterRepository shelterRepository = new ShelterRepository(maxNumberOfAnimals);
            shelterRepository.AddAnimal(rabbit2);
            ShelterLogic logic = new ShelterLogic(shelterRepository);

            Person person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };

            person.BuyAnimal<Rabbit>(logic, rabbit2.Name);

        }
        [TestMethod()]
        public void BuyAnimalTest_NoAnimalInitialized()
        {
            int maxNumberOfAnimals = 5;
            Rabbit rabbit2 = new Rabbit { Name = "rabbit2", AgeInHumanYears = 8, Price = 5 };
            ShelterRepository shelterRepository = new ShelterRepository(maxNumberOfAnimals);
            shelterRepository.AddAnimal(rabbit2);
            ShelterLogic logic = new ShelterLogic(shelterRepository);

            Person person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };

            person.BuyAnimal<Rabbit>(logic);

        }
        [TestMethod()]
        
        public void IsntOldEnoughToBuyAnimal()
        {
            Person person = new Person
            {
                Name = "John",
                Age = 17,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };
            var expected = false;
            var actual = person.IsOldEnoughToBuyAnimal();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        
        public void IsOldEnoughToBuyAnimal()
        {
            Person person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };
            var expected = true;
            var actual = person.IsOldEnoughToBuyAnimal();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ShowAnimalsTest()
        {
            Person person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };
            var expected = "John owns 0 animal(s)";
            var actual = person.ShowAnimals();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "John is not old enough to buy a pet.")]
        public void BuyAnimalTest_NotOldEnough()
        {
            int maxNumberOfAnimals = 5;
            Rabbit rabbit2 = new Rabbit { Name = "rabbit2", AgeInHumanYears = 8, Price = 5 };
            ShelterRepository shelterRepository = new ShelterRepository(maxNumberOfAnimals);
            shelterRepository.AddAnimal(rabbit2);
            ShelterLogic logic = new ShelterLogic(shelterRepository);

            Person person = new Person
            {
                Name = "John",
                Age = 17,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };

            person.BuyAnimal<Rabbit>(logic);

        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "John is not old enough to buy a pet.")]
        public void BuyAnimalTest_NotOldEnoughTest()
        {
            int maxNumberOfAnimals = 5;
            Rabbit rabbit2 = new Rabbit { Name = "rabbit2", AgeInHumanYears = 8, Price = 5 };
            ShelterRepository shelterRepository = new ShelterRepository(maxNumberOfAnimals);
            shelterRepository.AddAnimal(rabbit2);
            ShelterLogic logic = new ShelterLogic(shelterRepository);

            Person person = new Person
            {
                Name = "John",
                Age = 17,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };

            person.BuyAnimal<Rabbit>(logic, rabbit2.Name);

        }
    }
}