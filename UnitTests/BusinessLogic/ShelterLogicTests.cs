using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterConsole.BusinessLogic;
using ShelterConsole.DataAccess.Repositories;
using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterConsole.BusinessLogic.Tests
{
    [TestClass]
    public class ShelterLogicTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Expected cat, dog, snake, hamster, rabbit received animal")]
        public void BuyAnimalTest()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            var cat = new Animal { Name = "cat", AgeInHumanYears = 2 };
            shelter.AddAnimal(cat);
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 9.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };
            logic.BuyAnimal<Animal>(person);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Something went wrong")]
        public void SendAnimalToShelterTest()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            var cat = new Animal { Name = "cat", AgeInHumanYears = 2 };
            shelter.AddAnimal(cat);
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 9.99,
                OwnedAnimals = new Dictionary<string, Animal>
                {
                    { cat.Name, cat }
                }
            };
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            logic.SendAnimalToShelter(rabbit, person);
        }

        [TestMethod()]
        public void BuyAnimalTest1()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            var cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 9.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };
            Animal expected = null;
            var actual = logic.BuyAnimal<Cat>(person, cat.Name);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Expected cat, dog, snake, hamster, rabbit received animal")]
        public void BuyAnimalTest2()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            var cat = new Animal { Name = "cat", AgeInHumanYears = 2 };
            shelter.AddAnimal(cat);
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 9.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };
            logic.BuyAnimal<Animal>(person, cat.Name);
        }

        [TestMethod()]
        public void GetNumberOfAnimalsInShelterTest()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            var cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            shelter.AddAnimal(cat);
            var expected = "1 cat(s) in the shelter\n0 dog(s) in the shelter\n0 snake(s) in the shelter" +
                    $"\n0 hamster(s) in the shelter\n0 rabbit(s) in the shelter";
            var actual = logic.GetNumberOfAnimalsInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void GetNumberOfAnimalsInShelterTest_String()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            var cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            shelter.AddAnimal(cat);
            var expected = "1 cat(s) in the shelter";
            var actual = logic.GetNumberOfAnimalsInShelter(cat.GetType().Name.ToLower());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception), "Wrong type of animal")]
        public void GetNumberOfAnimalsInShelterTest1()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            var cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            shelter.AddAnimal(cat);

            logic.GetNumberOfAnimalsInShelter("alligator");
        }
    }
}