using System.Collections.Generic;
using Models;
using Services;
using Services.Interface;

namespace Controllers
{
    public class AdotanteController
    {
        private IAdotanteServices _adotanteServices;

        public AdotanteController()
        {
            _adotanteServices = new AdotanteServices();
        }

        public bool InsertAdotante(Adotante adotante)
        {
            return _adotanteServices.InsertAdotante(adotante);
        }

        public bool GetSpecific(string cpf)
        {
            return _adotanteServices.GetSpecific(cpf);
        }

        public List<Adotante> GetAll()
        {
            return _adotanteServices.GetAll();
        }
    }
}
