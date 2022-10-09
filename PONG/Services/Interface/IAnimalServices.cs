using Models;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IAnimalServices
    {
        bool InsertAnimal(Animal animal);
        bool UpdateAdotante(int chip, string parametro, string value);
        bool GetSpecific(int chip);
        Animal GetOne(int chip);
        List<Animal> GetAll();


        #region AnimalDP
        bool InsertAnimalDP(Animal animal);
        bool GetSpecificAAA(int chip);        
        #endregion
    }





}
