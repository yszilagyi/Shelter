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
        public Animal PurchaseAnimal<T>(string identifier = null)
        {
            var satanicBeast = _shelterRepository.GetAnimal<T>(identifier);
            // check if the cat is not null, if null inform user about it
            if (satanicBeast == null) throw new Exception("This is a very rare null animal, you cannot has it");

            // cat need to be removed after selling it
            _shelterRepository.RemoveAnimal(satanicBeast);

            Console.WriteLine($"{satanicBeast.GetType().Name} successfully bought");
            return satanicBeast;
        }

    }
}
