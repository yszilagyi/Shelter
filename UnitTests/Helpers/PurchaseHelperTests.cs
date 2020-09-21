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

        public void PurchaseAnimalTest()
        {
            var shelter = new ShelterRepository(1);
            var logic = new ShelterLogic(shelter);
            Cat cat = null;
            shelter.AddAnimal(cat);
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };

            person.BuyAnimal<Cat>(logic);

        }
    }
}