using ShelterConsole.Models;

namespace ShelterConsole.DataAccess.Interfaces {
    public interface IShelterRepository {
        bool AddAnimal(Animal animal);
        Cat GetCat();
        Dog GetDog();
        Snake GetSnake();
        Hamster GetHamster();
        Rabbit GetRabbit();

        int GetNumberOfCatsInShelter();
        int GetNumberOfDogsInShelter();
        int GetNumberOfSnakesInShelter();
        int GetNumberOfHamstersInShelter();
        int GetNumberOfRabbitsInShelter();

        bool IsShelterEmpty();
        bool IsShelterFull();
        bool RemoveAnimal(Animal animal);
    }
}