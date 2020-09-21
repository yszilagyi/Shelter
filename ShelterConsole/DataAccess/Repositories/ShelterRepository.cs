using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ShelterConsole.DataAccess.Interfaces;
using System.Threading;
using System.Reflection;
using ShelterConsole.Utilities;
using System.Security.Cryptography;

namespace ShelterConsole.DataAccess.Repositories
{
    public class ShelterRepository : IShelterRepository
    {
        private Dictionary<String, Type> d = new Dictionary<string, Type> {
                {"cat", typeof(Cat) },
                {"dog", typeof(Dog) },
                {"snake", typeof(Snake) },
                {"hamster", typeof(Hamster) },
                {"rabbit", typeof(Rabbit) }

            };
        private List<Animal> _animals;
        public String[] _animalsInShelter;
        private int _maxNumberOfAnimals;
        //public Animal[] GetInheritedClasses(Animal animal)
        //{
        //    //if you want the abstract classes drop the !TheType.IsAbstract but it is probably to instance so its a good idea to keep it.
        //    var x = Assembly.GetAssembly(typeof(Animal)).GetTypes().Where(TheType => TheType.IsClass
        //                && TheType.IsSubclassOf(typeof(Animal)));
        //    return new Animal[0];
        //}

        public ShelterRepository(int maxNumberOfAnimals)
        {
            _animals = new List<Animal>();
            _maxNumberOfAnimals = maxNumberOfAnimals;
        }
        #region Add/Remove animals
        /// <summary>
        /// Add animal to shelter
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool AddAnimal(Animal animal)
        {
            // if the shelter is full throw an exception
            if (IsShelterFull()) throw new Exception("Shelter is full");
            _animals.Add(animal);
            Console.WriteLine("Adding animal to a shelter...");
            // return true if the operation go well

            return true;
        }
        /// <summary>
        /// Remove animal from shelter
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
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
        #endregion 
        #region Get animal to adopt

        public Animal GetAnimal<T>(string identifier = null)
        {

            if (IsShelterEmpty()) throw new Exception("Shelter is empty");
            var animals = (from animal in _animals where animal.GetType() == typeof(T) select animal).ToList();
            if (identifier != null)
            {
                //InvariantCultureIgnoreCase case does not matter, accents.
                return animals.FirstOrDefault(x => x.Name.Equals(identifier, StringComparison.InvariantCultureIgnoreCase));
            }
            return (from animal in _animals where animal.GetType() == typeof(T) select animal).FirstOrDefault();
        }
        #endregion
        #region Get numbers of animals
        /// <summary>
        /// Gets the number of Cats in the shelter
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfCatsInShelter()
        {
            return IsShelterEmpty()
                ? 0
                : (from animal in _animals where animal.GetType() == typeof(Cat) select animal).Count();
        }
        /// <summary>
        /// Gets the number of Dogs in the shelter
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfDogsInShelter()
        {
            return IsShelterEmpty()
                ? 0
                : (from animal in _animals where animal.GetType() == typeof(Dog) select animal).Count();
        }
        /// <summary>
        /// Gets the number of Snakes in the shelter
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfSnakesInShelter()
        {
            return IsShelterEmpty()
                ? 0
                : (from animal in _animals where animal.GetType() == typeof(Snake) select animal).Count();
        }
        /// <summary>
        /// Gets the number of Hamsters in the shelter
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfHamstersInShelter()
        {
            return IsShelterEmpty()
                ? 0
                : (from animal in _animals where animal.GetType() == typeof(Hamster) select animal).Count();
        }
        /// <summary>
        /// Gets the number of Rabbits in the shelter
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfRabbitsInShelter()
        {
            return IsShelterEmpty()
                ? 0
                : (from animal in _animals where animal.GetType() == typeof(Rabbit) select animal).Count();
        }
        /// <summary>
        /// Gets the number of specified animal(s) in the shelter
        /// </summary>
        /// <param name="typeOfAnimal"></param>
        /// <returns></returns>
        public int GetNumberOfAnimalsInShelter(Type typeOfAnimal)
        {

            return IsShelterEmpty()
                ? 0
                : (from animal in _animals where animal.GetType() == typeOfAnimal select animal).Count();
        }
        #endregion
        #region Shelter empty or full
        /// <summary>
        /// Checks whether shelter is empty
        /// </summary>
        /// <returns></returns>
        public bool IsShelterEmpty()
        {
            if (!_animals.Any())
            {
                Console.WriteLine("There are no animals in the shelter");
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks whether shelter is full
        /// </summary>
        /// <returns></returns>
        public bool IsShelterFull()
        {
            if (_animals.Count == _maxNumberOfAnimals)
            {
                Console.WriteLine("The shelter is full");
                return true;
            }
            return false;
        }
        #endregion
    }
}
