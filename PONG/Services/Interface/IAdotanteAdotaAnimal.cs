using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.Interface
{
    public interface IAdotanteAdotaAnimal
    {
        bool InsertAAAnimal(AdotanteAdotaAnimal animal);
        bool DeleteADisponivel(int chip);
        int GetQuantidadeAnimaisAdotados(string cpf);
        bool GetSpecific(int aaa);
        AdotanteAdotaAnimal GetAAAnimal(string cpf);
        List<AdotanteAdotaAnimal> GetAll();
    }
}
