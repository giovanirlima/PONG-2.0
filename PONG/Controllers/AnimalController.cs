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

        public List<Animal> GetAll()
        {
            return _animalServices.GetAll();
        }



        #region Animal DP
        public bool InsertAnimalDP(Animal animal)
        {
            return _animalServices.InsertAnimalDP(animal);
        }
        #endregion
    }
}
