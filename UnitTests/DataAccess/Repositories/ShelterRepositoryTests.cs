using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterConsole.DataAccess.Repositories;
using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterConsole.DataAccess.Repositories.Tests
{
    [TestClass()]
    public class ShelterRepositoryTests
    {
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException), "This is a very rare null animal, you cannot has it")]
        public void GetNullAnimalTest()
        {
            var shelter = new ShelterRepository(1);
            //           Rabbit rabbit = null;

            shelter.GetAnimal<Rabbit>();


        }

        [TestMethod]
        public void GetNumberOfCatsInShelterTest_Zero()
        {
            var shelter = new ShelterRepository(1);
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            shelter.AddAnimal(rabbit);
            var expected = 0;
            var actual = shelter.GetNumberOfCatsInShelter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNumberOfDogsInShelterTest_Zero()
        {
            var shelter = new ShelterRepository(1);
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            shelter.AddAnimal(rabbit);
            var expected = 0;
            var actual = shelter.GetNumberOfDogsInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNumberOfSnakesInShelterTest_Zero()
        {
            var shelter = new ShelterRepository(1);
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            shelter.AddAnimal(rabbit);
            var expected = 0;
            var actual = shelter.GetNumberOfSnakesInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNumberOfHamstersInShelterTest_Zero()
        {
            var shelter = new ShelterRepository(1);
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            shelter.AddAnimal(rabbit);
            var expected = 0;
            var actual = shelter.GetNumberOfHamstersInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNumberOfRabbitsInShelterTest_Zero()
        {
            var shelter = new ShelterRepository(1);
            Cat cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            shelter.AddAnimal(cat);
            var expected = 0;
            var actual = shelter.GetNumberOfRabbitsInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNumberOfCatsInShelterTest()
        {
            var shelter = new ShelterRepository(1);
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            //shelter.AddAnimal(rabbit);
            var expected = 0;
            var actual = shelter.GetNumberOfCatsInShelter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNumberOfDogsInShelterTest()
        {
            var shelter = new ShelterRepository(1);
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            //shelter.AddAnimal(rabbit);
            var expected = 0;
            var actual = shelter.GetNumberOfDogsInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNumberOfSnakesInShelterTest()
        {
            var shelter = new ShelterRepository(1);
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            //shelter.AddAnimal(rabbit);
            var expected = 0;
            var actual = shelter.GetNumberOfSnakesInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNumberOfHamstersInShelterTest()
        {
            var shelter = new ShelterRepository(1);
            Rabbit rabbit = new Rabbit { Name = "rabbit", AgeInHumanYears = 2 };
            //shelter.AddAnimal(rabbit);
            var expected = 0;
            var actual = shelter.GetNumberOfHamstersInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNumberOfRabbitsInShelterTest()
        {
            var shelter = new ShelterRepository(1);
            Cat cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            //shelter.AddAnimal(cat);
            var expected = 0;
            var actual = shelter.GetNumberOfRabbitsInShelter();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNumberOfAnimalsInShelterTest()
        {
            var shelter = new ShelterRepository(1);
            Cat cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            shelter.AddAnimal(cat);
            var expected = 1;
            var actual = shelter.GetNumberOfAnimalsInShelter(cat.GetType());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNumberOfAnimalsInShelterTest_Zero()
        {
            var shelter = new ShelterRepository(1);
            Cat cat = new Cat { Name = "cat", AgeInHumanYears = 2 };

            var expected = 0;
            var actual = shelter.GetNumberOfAnimalsInShelter(cat.GetType());
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Shelter is full")]
        public void AddAnimal_ShelterIsFull()
        {
            var shelter = new ShelterRepository(1);
            Cat cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            Dog dog = new Dog { Name = "dog1", AgeInHumanYears = 2, Price = 22.99 };
            shelter.AddAnimal(cat);

            shelter.AddAnimal(dog);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Animal is empty")]
        public void RemoveAnimal_AnimalEmpty()
        {
            var shelter = new ShelterRepository(1);
            Cat cat = null;

            shelter.AddAnimal(cat);

            shelter.RemoveAnimal(cat);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Shelter is empty")]
        public void RemoveAnimal_ShelterEmpty()
        {
            var shelter = new ShelterRepository(1);
            Cat cat = new Cat { Name = "cat", AgeInHumanYears = 2 };
            shelter.RemoveAnimal(cat);
        }
    }
}