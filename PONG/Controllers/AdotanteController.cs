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
        public bool UpdateAdotante(string cpf, string paramentro, string value)
        {
            return _adotanteServices.UpdateAdotante(cpf, paramentro, value);
        }
        public bool UpdateEndereco(string cpf, string value, string value2, string value3, string value4, string value5)
        {
            return _adotanteServices.UpdateEndereco(cpf, value, value2, value3, value4, value5);
        }
        public bool GetSpecific(string cpf)
        {
            return _adotanteServices.GetSpecific(cpf);
        }
        public Adotante GetOne(string cpf)
        {
            return _adotanteServices.GetOne(cpf);
        }
        public List<Adotante> GetAll()
        {
            return _adotanteServices.GetAll();
        }
    }
}
