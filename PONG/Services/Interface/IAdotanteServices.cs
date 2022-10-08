using System.Collections.Generic;
using Models;

namespace Services.Interface
{
    public interface IAdotanteServices
    {
        bool InsertAdotante(Adotante adotante);
        bool GetSpecific(string cpf);
        List<Adotante> GetAll();

    }
}
