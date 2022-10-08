using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Animal
    {
        #region Constant
        public readonly static string INSERT = "INSERT Animal VALUES(@FAMILIA, @RACA, @SEXO, @NOME)";
        public readonly static string INSERTAD = "INSERT Animais_Disponiveis VALUES(@CHIP)";
        public readonly static string SELECT = "SELECT * FROM Animal";
        public readonly static string SELECTAD = "SELECT * FROM Animais_Disponiveis";
        public readonly static string DELETEPA = "DELETE Animais_Disponiveis WHERE CHIP = @CHIP";
        public readonly static string DELETE = "DELETE Animal WHERE CHIP = @CHIP";
        #endregion

        #region Properts
        public int CHIP { get; set; }
        public string Familia { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public string Nome { get; set; }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"CHIP: {CHIP}\nNome: {Nome}\nFamilia: {Familia}\nRaça: {Raca}\nSexo: {Sexo}\n";
        }
        #endregion
    }
}
