using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterConsole.BusinessLogic;
using ShelterConsole.DataAccess.Repositories;
using ShelterConsole.Helpers;
using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterConsole.Helpers.Tests
{
    [TestClass()]
    public class PurchaseHelperTests
    {
        [TestMethod()]
        public void PurchaseAnimal_NullShelterTest()
        {
            var shelter = new ShelterRepository(0);
            var logic = new ShelterLogic(shelter);
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };

            Animal expected = null;
            var actual = person.BuyAnimal<Cat>(logic);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "John cannot afford this majestic creature.")]
        public void PurchaseAnimal_NotEnoughMoney()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            var cat = new Cat { Name = "cat1", AgeInHumanYears = 3, Price = 13.20 };
            shelter.AddAnimal(cat);
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 9.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };
            person.BuyAnimal<Cat>(logic);


        }
    }
}