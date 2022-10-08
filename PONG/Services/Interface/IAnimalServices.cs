using Models;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IAnimalServices
    {
        bool InsertAnimal(Animal animal);
        List<Animal> GetAll();
    }





}
