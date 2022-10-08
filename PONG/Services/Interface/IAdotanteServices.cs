using System.Collections.Generic;
using Models;

namespace Services.Interface
{
    public interface IAdotanteServices
    {
        bool InsertAdotante(Adotante adotante);
        List<Adotante> GetAll();
    }
}
