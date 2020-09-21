using ShelterConsole.Models;
using System;

namespace ShelterConsole.DataAccess.Interfaces
{
    public interface IShelterRepository
    {
        bool AddAnimal(Animal animal);

        Animal GetAnimal<T>(string identifier = null);
        int GetNumberOfCatsInShelter();
        int GetNumberOfDogsInShelter();
        int GetNumberOfSnakesInShelter();
        int GetNumberOfHamstersInShelter();
        int GetNumberOfRabbitsInShelter();
        int GetNumberOfAnimalsInShelter(Type typeOfAnimal);

        bool IsShelterEmpty();
        bool IsShelterFull();
        bool RemoveAnimal(Animal animal);
    }
}