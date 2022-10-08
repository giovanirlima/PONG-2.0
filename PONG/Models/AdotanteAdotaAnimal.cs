using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AdotanteAdotaAnimal
    {
        public readonly static string INSERT = "INSERT Pessoa_Adota_Animal VALUES(@CPF, @CHIP, @Quantidade);";
        public readonly static string SELECT = "SELECT * FROM Pessoa_Adota_Animal";
        public string CPF { get; set; }
        public int CHIP { get; set; }
        public int Quantidade { get; set; }

        public override string ToString()
        {
            return $"CPF: {CPF}\nCHIP: {CHIP}\nQuantidade: {Quantidade}\n";
        }
    }
}
