using System;
using System.Net;

namespace Models
{
    public class Adotante
    {
        #region Constant
        public readonly static string INSERT = "INSERT Pessoa VALUES(@CPF, @NOME, @NASCIMENTO, @SEXO, @RUA, @NUMERO, @BAIRRO, @CIDADE, @ESTADO, @TELEFONE)";
        public readonly static string SELECT = "SELECT * FROM Pessoa";
        public readonly static string SELECTESP = "SELECT * FROM Pessoa WHERE CPF = @CPF";
        public readonly static string DELETEPA = "DELETE Pessoa_Adota_Animal WHERE CPF = @CPF";
        public readonly static string DELETE = "DELETE Pessoa WHERE CPF = @CPF";
        #endregion

        #region Properts
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Nome: {Nome}\nCPF: {CPF}\nNascimento: {Nascimento.ToShortDateString()}\nSexo: {Sexo}\nEndereço: {Rua} º{Numero}, {Bairro}. {Cidade} - {Estado}\n";
        }
        #endregion
    }
}
