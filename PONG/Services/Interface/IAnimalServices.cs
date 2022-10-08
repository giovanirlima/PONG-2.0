using Models;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IAnimalServices
    {
        bool InsertAnimal(Animal animal);
        bool GetSpecific(int chip);
        List<Animal> GetAll();


        #region AnimalDP
        bool InsertAnimalDP(Animal animal);
        #endregion
    }





}
