using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterConsole.Models.Tests
{
    [TestClass]
    public class AnimalTests
    {

        [TestMethod]
        public void GetAnimalAge()
        {
            var animal = new Animal { Name = "cat1", AgeInHumanYears = 3 };
            var expected = 3;
            var actual = animal.AgeInHumanYears;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetAnimalPrice()
        {
            var animal = new Animal { Name = "cat1", AgeInHumanYears = 3, Price = 12.99 };
            var expected = 12.99;
            var actual = animal.Price;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetCatAge()
        {
            var animal = new Cat { Name = "cat1", AgeInHumanYears = 3 };
            var expected = 75;
            var actual = animal.AgeInCatYears;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetDogAge()
        {
            var animal = new Dog { Name = "dog1", AgeInHumanYears = 3 };
            var expected = 45;
            var actual = animal.AgeInDogYears;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetSnakeAge()
        {
            var animal = new Snake { Name = "snake1", AgeInHumanYears = 3 };
            var expected = 54;
            var actual = animal.AgeInSnakeYears;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetHamsterAge()
        {
            var animal = new Hamster { Name = "hamster1", AgeInHumanYears = 3 };
            var expected = 174;
            var actual = animal.AgeInHamsterYears;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetRabbitAge()
        {
            var animal = new Rabbit { Name = "rabbit1", AgeInHumanYears = 3 };
            var expected = 60;
            var actual = animal.AgeInRabbitYears;
            Assert.AreEqual(expected, actual);
        }

    }
}
