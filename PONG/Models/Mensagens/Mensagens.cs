using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mensagens
{
    public class Mensagens
    {

        public static void SucessCadastrado()
        {
            Console.WriteLine("\nCADASTRADO COM SUCESSO!");
        }
        public static void FailCadastrado()
        {
            Console.WriteLine("\nFALHA AO CADASTRAR!");
        }
        public static void SucessAlteracao()
        {
            Console.WriteLine("\nALTERADO COM SUCESSO!");
        }
        public static void FailAlteracao()
        {
            Console.WriteLine("\nFALHA AO ALTERAR");
        }
    }
}
