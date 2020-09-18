using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using System;
using ShelterConsole.BusinessLogic;
using ShelterConsole.DataAccess.Interfaces;
using ShelterConsole.DataAccess.Repositories;
using ShelterConsole.Models;

namespace UnitTests {
    public class ShelterLogicBuilder {
        private IShelterRepository _shelterRepository;

        public ShelterLogicBuilder WithShelterRepository(ShelterRepository shelterRepository) {
            _shelterRepository = shelterRepository;
            return this;
        }

        public ShelterLogic Build() {
            if (_shelterRepository == null) {
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
    public class ShelterLogicTests {

        [TestMethod]
        public void SendAnimalToShelter_WithCat_ReturnsTrue() {
            //Arrange
            var shelterLogicBuilder = new ShelterLogicBuilder();
            var shelterLogic = shelterLogicBuilder.Build();
            var cat = new Cat();

            //Act
            var result = shelterLogic.SendAnimalToShelter(cat);

            //Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void SendAnimalToShelter_WithInvalidAnimal_ThrowsException() {
            //Arrange
            var shelterLogicBuilder = new ShelterLogicBuilder();
            var shelterLogic = shelterLogicBuilder.Build();
            var animal = new Animal();

            //Act
            Action result = () => shelterLogic.SendAnimalToShelter(animal);

            //Assert
            result.Should().Throw<Exception>();
        }

    }
}
