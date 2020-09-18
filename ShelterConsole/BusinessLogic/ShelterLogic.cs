using ShelterConsole.Models;
using ShelterConsole.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using ShelterConsole.DataAccess.Interfaces;
using System.Linq;

namespace ShelterConsole.BusinessLogic
{
    public class ShelterLogic
    {
        private readonly IShelterRepository _shelterRepository;
        private Dictionary<String, Type> d = new Dictionary<string, Type> {
                {"cat", typeof(Cat) },
                {"dog", typeof(Dog) },
                {"snake", typeof(Snake) },
                {"hamster", typeof(Hamster) },
                {"rabbit", typeof(Rabbit) }

            };

        public ShelterLogic(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public bool SendAnimalToShelter(Animal animal)
        {
            // make sure that the user try to send a dog or a cat, the shelter should not contain any 'generic' animals

            // use try catch during sending an animal, there is possiblity it can go wrong
            if (animal.GetType() == typeof(Cat) || animal.GetType() == typeof(Dog))
            {
                try
                {
                    _shelterRepository.AddAnimal(animal);
                }
                catch (Exception e)
                {
                    throw new Exception("Something went wrong", e);
                }
            }
            else
            {
                throw new Exception("Cannot give generic animal to the shelter.");
            }

            // if the type is wrong, throw an exception

            Console.WriteLine("Animal Successfully added");
            return true;
        }

        public Animal BuyAnimal(string typeOfAnimal, Person person)
        {
            if (_shelterRepository.IsShelterEmpty()) return null;

            //throw an exception if invalid kind of animal
            if (!d.ContainsKey(typeOfAnimal))
            {
                throw new ArgumentException($"Expected {string.Join(", ", d.Keys.ToList())}" +
                        $" received {typeOfAnimal}");
            }
            if (typeOfAnimal == ShelterConstants.Cat)
            {
                Cat cat = _shelterRepository.GetCat();
                // check if the cat is not null, if null inform user about it
                if (cat == null)
                {
                    Console.WriteLine("Cat not found");
                    return null;
                }
                _shelterRepository.RemoveAnimal(cat);
                person.OwnedAnimals.Add(cat.Name, cat);
                // cat need to be removed after selling it
                Console.WriteLine("Cat successfuly bought");
                return cat;
            }
            if (typeOfAnimal == ShelterConstants.Dog)
            {
                Dog dog = _shelterRepository.GetDog();
                // check if the dog is not null, if null inform user about it
                if (dog == null)
                {
                    Console.WriteLine("Dog not found");
                    return null;
                }
                // dog need to be removed after selling it
                Console.WriteLine("dog successfuly bought");
                _shelterRepository.RemoveAnimal(dog);
                person.OwnedAnimals.Add(dog.Name, dog);
                return dog;
            }
            if (typeOfAnimal == ShelterConstants.Snake)
            {
                Snake snake = _shelterRepository.GetSnake();
                // check if the dog is not null, if null inform user about it
                if (snake == null)
                {
                    Console.WriteLine("snake not found");
                    return null;
                }
                // dog need to be removed after selling it
                Console.WriteLine("snake successfuly bought");
                _shelterRepository.RemoveAnimal(snake);
                person.OwnedAnimals.Add(snake.Name, snake);
                return snake;

            }
            if (typeOfAnimal == ShelterConstants.Hamster)
            {
                Hamster hamster = _shelterRepository.GetHamster();
                // check if the dog is not null, if null inform user about it
                if (hamster == null)
                {
                    Console.WriteLine("Hamster not found");
                    return null;
                }
                // dog need to be removed after selling it
                Console.WriteLine("hamster successfuly bought");
                _shelterRepository.RemoveAnimal(hamster);
                person.OwnedAnimals.Add(hamster.Name, hamster);
                return hamster;
            }
            if (typeOfAnimal == ShelterConstants.Rabbit)
            {
                Rabbit rabbit = _shelterRepository.GetRabbit();
                // check if the dog is not null, if null inform user about it
                if (rabbit == null)
                {
                    Console.WriteLine("Rabbit not found");
                    return null;
                }
                // dog need to be removed after selling it
                Console.WriteLine("dog successfuly bought");
                _shelterRepository.RemoveAnimal(rabbit);
                person.OwnedAnimals.Add(rabbit.Name, rabbit);
                return rabbit;
            }
            throw new ArgumentNullException();
        }
        public string GetNumberOfAnimalsInShelter()
        {
            return $"{GetNumberOfCatsInShelter()}\n{GetNumberOfDogsInShelter()}\n{GetNumberOfSnakesInShelter()}" +
                $"\n{GetNumberOfHamstersInShelter()}\n{GetNumberOfRabbitsInShelter()}";
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
