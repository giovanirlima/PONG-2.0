using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;
using Services.Interface;

namespace Controllers
{
    public class AnimalController
    {
        private IAnimalServices _animalServices;

        public AnimalController()
        {
            _animalServices = new AnimalServices();
        }

        public bool InsertAnimal(Animal animal)
        {
            return _animalServices.InsertAnimal(animal);
        }
        public bool UpdateAnimal(int chip, string paramentro, string value)
        {
            return _animalServices.UpdateAdotante(chip, paramentro, value);
        }
        public bool GetSpecif(int chip)
        {
            return _animalServices.GetSpecific(chip);
        }
        public Animal GetOne(int chip)
        {
            return _animalServices.GetOne(chip);
        }
        public List<Animal> GetAll()
        {
            return _animalServices.GetAll();
        }

        #region Animal DP
        public bool InsertAnimalDP(Animal animal)
        {
            return _animalServices.InsertAnimalDP(animal);
        }
        public bool GetSpecificAAA(int chip)
        {
            return _animalServices.GetSpecificAAA(chip);
        }
        #endregion
    }
}
