using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ShelterConsole.DataAccess.Interfaces;
using System.Threading;
using System.Reflection;

namespace ShelterConsole.DataAccess.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private List<Animal> _animals;
        public String[] _animalsInShelter;
        private int _maxNumberOfAnimals;
        public Animal[] GetInheritedClasses(Animal animal)
        {
            //if you want the abstract classes drop the !TheType.IsAbstract but it is probably to instance so its a good idea to keep it.
            var x = Assembly.GetAssembly(typeof(Animal)).GetTypes().Where(TheType => TheType.IsClass
                        && TheType.IsSubclassOf(typeof(Animal)));
            return new Animal[0];
        }

        public ShelterRepository(int maxNumberOfAnimals)
        {
            _animals = new List<Animal>();
            _maxNumberOfAnimals = maxNumberOfAnimals;
        }

        public bool AddAnimal(Animal animal)
        {
            // if the shelter is full throw an exception
            if (IsShelterFull()) throw new Exception("Shelter is full");
            _animals.Add(animal);
            Console.WriteLine("Adding animal to a shelter...");
            // return true if the operation go well

            return true;
        }




        public Cat GetCat()
        {
            // if the shelter is empty throw an exception
            if (IsShelterEmpty()) throw new Exception("Shelter is empty");

            //loop through the list of animals to find a cat
            foreach (Animal animal in _animals)
            {
                if (animal.GetType() == typeof(Cat))
                {
                    return (Cat)animal;
                }
            }
            // return null if you didn't find a cat
            return null;
        }

        public Dog GetDog()
        {
            // if the shelter is empty throw an exception
            if (IsShelterEmpty()) throw new Exception("Shelter is empty");
            //loop through the list of animals to find a dog
            for (int i = 0; i < _animals.Count; i++)
            {
                if (_animals[i].GetType() == typeof(Dog))
                {
                    return (Dog)_animals[i];
                }
            }
            // return null if you didn't find a dog
            return null;
        }

        public Snake GetSnake()
        {
            // if the shelter is empty throw an exception
            if (IsShelterEmpty()) throw new Exception("Shelter is empty");

            //loop through the list of animals to find a cat
            foreach (Animal animal in _animals)
            {
                if (animal.GetType() == typeof(Snake))
                {
                    return (Snake)animal;
                }
            }
            // return null if you didn't find a cat
            return null;
        }
        public Hamster GetHamster()
        {
            // if the shelter is empty throw an exception
            if (IsShelterEmpty()) throw new Exception("Shelter is empty");

            //loop through the list of animals to find a cat
            foreach (Animal animal in _animals)
            {
                if (animal.GetType() == typeof(Hamster))
                {
                    return (Hamster)animal;
                }
            }
            // return null if you didn't find a cat
            return null;
        }

        public Rabbit GetRabbit()
        {
            // if the shelter is empty throw an exception
            if (IsShelterEmpty()) throw new Exception("Shelter is empty");

            //loop through the list of animals to find a cat
            foreach (Animal animal in _animals)
            {
                if (animal.GetType() == typeof(Rabbit))
                {
                    return (Rabbit)animal;
                }
            }
            // return null if you didn't find a cat
            return null;
        }

        public bool RemoveAnimal(Animal animal)
        {
            // if the animal is null throw an exception
            if (animal.Equals(null)) throw new Exception("Animal is empty");
            // if the shelter is empty throw an exception
            if (IsShelterEmpty()) throw new Exception("Shelter is empty");
            try
            {
                _animals.Remove(animal);
                Console.WriteLine($"{animal.Name} removed from the shelter");
            }
            catch (Exception e)
            {
                throw new Exception("Something went wrong", e);
            }
            // return true if the operation go well
            return true;
        }

        public int GetNumberOfCatsInShelter()
        {
            if (IsShelterEmpty()) return 0;
            int i = 0;
            int numberOfCats = 0;
            while (i < _animals.Count)
            {
                if (_animals[i].GetType() == typeof(Cat))
                {
                    numberOfCats++;
                }
                i++;
            }

            return numberOfCats;
        }

        public int GetNumberOfDogsInShelter()
        {
            if (IsShelterEmpty()) return 0;
            int numberOfDogs = 0;

            foreach (Animal animal in _animals)
            {
                if (animal.GetType() == typeof(Dog))
                {
                    numberOfDogs++;
                }
            }

            return numberOfDogs;
        }

        public int GetNumberOfSnakesInShelter()
        {
            if (IsShelterEmpty()) return 0;
            int i = 0;
            int numberOfSnakes = 0;
            while (i < _animals.Count)
            {
                if (_animals[i].GetType() == typeof(Snake))
                {
                    numberOfSnakes++;
                }
                i++;
            }

            return numberOfSnakes;
        }

        public int GetNumberOfHamstersInShelter()
        {
            if (IsShelterEmpty()) return 0;
            int i = 0;
            int numberOfHamsters = 0;
            while (i < _animals.Count)
            {
                if (_animals[i].GetType() == typeof(Hamster))
                {
                    numberOfHamsters++;
                }
                i++;
            }

            return numberOfHamsters;
        }

        public int GetNumberOfRabbitsInShelter()
        {
            if (IsShelterEmpty()) return 0;
            int i = 0;
            int numberOfRabbits = 0;
            while (i < _animals.Count)
            {
                if (_animals[i].GetType() == typeof(Rabbit))
                {
                    numberOfRabbits++;
                }
                i++;
            }

            return numberOfRabbits;
        }

        public bool IsShelterEmpty()
        {
            if (!_animals.Any())
            {
                Console.WriteLine("There are no animals in the shelter");
                return true;
            }
            return false;
        }

        public bool IsShelterFull()
        {
            if (_animals.Count == _maxNumberOfAnimals)
            {
                Console.WriteLine("The shelter is full");
                return true;
            }
            return false;
        }
    }
}
