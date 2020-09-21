using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using System;
using ShelterConsole.BusinessLogic;
using ShelterConsole.DataAccess.Interfaces;
using ShelterConsole.DataAccess.Repositories;
using ShelterConsole.Models;
using System.Collections.Generic;

namespace UnitTests
{
    public class ShelterLogicBuilder
    {
        private IShelterRepository _shelterRepository;

        public ShelterLogicBuilder WithShelterRepository(ShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
            return this;
        }

        public ShelterLogic Build()
        {
            if (_shelterRepository == null)
            {
                var shelterRepositoryMock = new Mock<IShelterRepository>();
                shelterRepositoryMock.Setup(s => s.AddAnimal(It.IsAny<Animal>())).Returns(true);
                shelterRepositoryMock.Setup(s => s.RemoveAnimal(It.IsAny<Animal>())).Returns(true);
                shelterRepositoryMock.Setup(s => s.IsShelterEmpty()).Returns(false);
                shelterRepositoryMock.Setup(s => s.IsShelterFull()).Returns(false);
                shelterRepositoryMock.Setup(s => s.GetNumberOfCatsInShelter()).Returns(2);
                shelterRepositoryMock.Setup(s => s.GetNumberOfDogsInShelter()).Returns(2);
                _shelterRepository = shelterRepositoryMock.Object;
            }
            return new ShelterLogic(_shelterRepository);
        }
    }

    [TestClass]
    public class ShelterLogicTests
    {



        [TestMethod]
        public void SendAnimalToShelter_ReturnsZeroAnimals()
        {
            //Arrange
            var shelterLogicBuilder = new ShelterLogicBuilder();
            var shelterLogic = shelterLogicBuilder.Build();
            var cat = new Cat { Name = "cat1", AgeInHumanYears = 3, Price = 13.20 };
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>() {
                    { cat.Name, cat }
                }
            };

            var expected = 0;

            //Act
            person.SendAnimalToShelter(shelterLogic, cat);
            var actual = person.OwnedAnimals.Count;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "You don't have any animals to send to shelter.")]
        public void SendAnimalToShelter_ZeroAnimals_ThrowsException()
        {
            //Arrange
            var shelterLogicBuilder = new ShelterLogicBuilder();
            var shelterLogic = shelterLogicBuilder.Build();
            var animal = new Animal();
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>()
            };

            shelterLogic.SendAnimalToShelter(animal, person);


        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception), "Wrong kind of animal!")]
        public void SendAnimalToShelter_InvalidAnimal_ThrowsException()
        {
            //Arrange
            var shelterLogicBuilder = new ShelterLogicBuilder();
            var shelterLogic = shelterLogicBuilder.Build();
            var cat = new Animal { Name = "cat1", AgeInHumanYears = 3, Price = 13.20 };
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>() {
                    { cat.Name, cat }
                }
            };

            //Act

            shelterLogic.SendAnimalToShelter(cat, person);
            //Assert

        }
        [TestMethod]
        [ExpectedException(typeof(System.Exception), "")]
        public void SendAnimalToShelter_NullShelter_ThrowsException()
        {
            //Arrange
            ShelterLogic logic = new ShelterLogic(new ShelterRepository(0));
            var cat = new Animal { Name = "cat1", AgeInHumanYears = 3, Price = 13.20 };
            var person = new Person
            {
                Name = "John",
                Age = 18,
                Money = 29.99,
                OwnedAnimals = new Dictionary<string, Animal>() {
                    { cat.Name, cat }
                }
            };

            //Act

            logic.SendAnimalToShelter(cat, person);
            //Assert

        }
        //[TestMethod]
        //[ExpectedException(typeof(System.Exception), "")]
        //public void SendAnimalToShelter_Shelter_ThrowsException()
        //{
        //    //Arrange
        //    ShelterLogic logic = new ShelterLogic(new ShelterRepository(5));
        //    var cat = new Animal { Name = "cat1", AgeInHumanYears = 3, Price = 13.20 };
        //    var person = new Person
        //    {
        //        Name = "John",
        //        Age = 18,
        //        Money = 29.99,
        //        OwnedAnimals = new Dictionary<string, Animal>() {
        //            { cat.Name, cat }
        //        }
        //    };

        //Act

        // logic.SendAnimalToShelter(cat, person);
        //Assert

        // }


    }
}
