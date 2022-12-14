using System.Collections.Generic;
using Models;
using Services;
using Services.Interface;

namespace Controllers
{
    public class AdotanteAdotaAnimalController
    {
        private IAdotanteAdotaAnimal _adotanteServices;

        public AdotanteAdotaAnimalController()
        {
            _adotanteServices = new AdotanteAdotaAnimalServices();
        }

        public bool InsertAAAnimal(AdotanteAdotaAnimal aaa)
        {
            return _adotanteServices.InsertAAAnimal(aaa);
        }

        public int GetQuantidadeAnimaisAdotados(string cpf)
        {
            return _adotanteServices.GetQuantidadeAnimaisAdotados(cpf);
        }
        public bool DeleteADisponivel(int chip)
        {
            return _adotanteServices.DeleteADisponivel(chip);
        }

        public AdotanteAdotaAnimal GetAAAnimal(string aaa)
        {
            return _adotanteServices.GetAAAnimal(aaa);
        }

        public bool GetSpecific(int chip)
        {
            return _adotanteServices.GetSpecific(chip);
        }
        public List<AdotanteAdotaAnimal> GetAll()
        {
            return _adotanteServices.GetAll();
        }
    }
}
