using ShelterConsole.Models;
using ShelterConsole.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using ShelterConsole.DataAccess.Interfaces;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ShelterConsole.Helpers;

namespace ShelterConsole.BusinessLogic
{
    public class ShelterLogic
    {
        private readonly IShelterRepository _shelterRepository;
        private readonly Dictionary<string, Type> d = new Dictionary<string, Type> {
                {"cat", typeof(Cat) },
                {"dog", typeof(Dog) },
                {"snake", typeof(Snake) },
                {"hamster", typeof(Hamster) },
                {"rabbit", typeof(Rabbit) }
            };
        private PurchaseHelper _purchaseHelper;


        public ShelterLogic(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
            _purchaseHelper = new PurchaseHelper(_shelterRepository);

        }

        public bool SendAnimalToShelter(Animal animal, Person person)
        {

            if (person.OwnedAnimals.Count == 0)
            {
                throw new Exception("You don't have any animals to send to shelter.");
            }
            else
            {
                if (!d.ContainsValue(animal.GetType()))
                {
                    throw new Exception("Wrong kind of animal!");
                }
                else if (person.OwnedAnimals.TryGetValue(animal.Name, out animal))
                {
                    Console.WriteLine($"{person.Name} is sending {animal.Name} to Shelter.");
                    _shelterRepository.AddAnimal(animal);
                    person.OwnedAnimals.Remove(animal.Name);
                }
                else

                {
                    throw new Exception("Something went wrong");
                }

                return true;
            }
        }

        public Animal BuyAnimal<T>(Person person)
        {

            if (_shelterRepository.IsShelterEmpty()) return null;

            //throw an exception if invalid kind of animal
            if (!d.ContainsValue(typeof(T)))
            {
                throw new ArgumentException($"Expected {string.Join(", ", d.Keys.ToList())}" +
                        $" received {typeof(T).Name.ToLower()}");
            }
            var type = d.FirstOrDefault(x => x.Value == typeof(T)).Value;

            return _purchaseHelper.PurchaseAnimal<T>(person);

        }

        public Animal BuyAnimal<T>(Person person, string identifier)
        {

            if (_shelterRepository.IsShelterEmpty()) return null;

            //throw an exception if invalid kind of animal
            if (!d.ContainsValue(typeof(T)))
            {
                throw new ArgumentException($"Expected {string.Join(", ", d.Keys.ToList())}" +
                        $" received {typeof(T).Name.ToLower()}");
            }
            var type = d.FirstOrDefault(x => x.Value == typeof(T)).Value;

            return _purchaseHelper.PurchaseAnimal<T>(person, identifier);

        }
        public string GetNumberOfAnimalsInShelter()
        {
            return $"{GetNumberOfCatsInShelter()}\n{GetNumberOfDogsInShelter()}\n{GetNumberOfSnakesInShelter()}" +
                $"\n{GetNumberOfHamstersInShelter()}\n{GetNumberOfRabbitsInShelter()}";
        }

        public string GetNumberOfAnimalsInShelter(string animal)
        {
            Type value;
            if (d.ContainsKey(animal))
            {
                var current = d.TryGetValue(animal, out value);
            }
            else
            {
                throw new Exception("Wrong type of animal");
            }
            return $"{_shelterRepository.GetNumberOfAnimalsInShelter(value)} {value.Name.ToLower()}(s) in the shelter";
        }
        public string GetNumberOfCatsInShelter()
        {
            return $"{_shelterRepository.GetNumberOfCatsInShelter()} cat(s) in the shelter";
        }

        public string GetNumberOfDogsInShelter()
        {
            return $"{_shelterRepository.GetNumberOfDogsInShelter()} dog(s) in the shelter";
        }
        public string GetNumberOfSnakesInShelter()
        {
            return $"{_shelterRepository.GetNumberOfSnakesInShelter()} snake(s) in the shelter";
        }
        public string GetNumberOfHamstersInShelter()
        {
            return $"{_shelterRepository.GetNumberOfHamstersInShelter()} hamster(s) in the shelter";
        }
        public string GetNumberOfRabbitsInShelter()
        {
            return $"{_shelterRepository.GetNumberOfRabbitsInShelter()} rabbit(s) in the shelter";
        }

    }
}
