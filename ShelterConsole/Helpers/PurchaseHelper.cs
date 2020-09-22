using ShelterConsole.DataAccess.Interfaces;
using ShelterConsole.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterConsole.Helpers
{
    public class PurchaseHelper
    {
        private IShelterRepository _shelterRepository;
        public PurchaseHelper(IShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }
        /// <summary>
        /// Rob's Purchase method
        /// </summary>
        /// <returns></returns>
        /// 
        public Animal PurchaseAnimal<T>(Person person, string identifier = null)
        {
            var satanicBeast = _shelterRepository.GetAnimal<T>(identifier);
            // check if the cat is not null, if null inform user about it
            //if (satanicBeast == null) throw new Exception("This is a very rare null animal, you cannot has it");
            if (person.Money < satanicBeast.Price) throw new Exception($"{person.Name} cannot afford this majestic creature.");
            // cat need to be removed after selling it
            Console.WriteLine($"{person.Name} is buying {satanicBeast.Name} for £{satanicBeast.Price}.");
            _shelterRepository.RemoveAnimal(satanicBeast);
            person.OwnedAnimals.Add(satanicBeast.Name, satanicBeast);
            person.Money -= satanicBeast.Price;
            Console.WriteLine($"{satanicBeast.GetType().Name} successfully bought" +
                $"\n{person.Name} has £{System.Math.Round(person.Money, 2)} left.");

            return satanicBeast;
        }

    }
}
