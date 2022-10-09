using System.Collections.Generic;
using Models;

namespace Services.Interface
{
    public interface IAdotanteServices
    {
        bool InsertAdotante(Adotante adotante);        
        bool UpdateAdotante(string cpf, string parametro, string value);
        bool UpdateEndereco(string cpf, string value, string value2, string value3, string value4, string value5);
        bool GetSpecific(string cpf);
        Adotante GetOne(string cpf);
        List<Adotante> GetAll();

    }
}
