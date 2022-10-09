using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Models;
using Models.Database;
using Services.Interface;

namespace Services
{
    public class AdotanteServices : IAdotanteServices
    {
        private string _conexao;

        public AdotanteServices()
        {
            _conexao = DatabaseConfig.GetConexao();
        }

        public bool InsertAdotante(Adotante adotante)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Adotante.INSERT, adotante);
                return true;
            }
        }
        public bool UpdateAdotante(string cpf, string paramentro, string value)
        {
            using (var db = new SqlConnection(_conexao))
            {
                var query = $"UPDATE Pessoa SET {paramentro} = '{value}' WHERE CPF = '{cpf}'";
                db.Execute(query);
                return true;
            }
        }
        public bool UpdateEndereco(string cpf, string value, string value2, string value3, string value4, string value5)
        {
            using (var db = new SqlConnection(_conexao))
            {
                var query = $"UPDATE Pessoa SET Rua = '{value}', Numero = '{value2}', Bairro = '{value3}', Cidade = '{value4}', Estado = '{value5}' WHERE CPF = '{cpf}'";
                db.Execute(query);
                return true;
            }
        }
        public bool GetSpecific(string cpf)
        {            
            Adotante adotante = new();

            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"SELECT * FROM Pessoa WHERE CPF = {cpf}";
                adotante = db.Query<Adotante>(query).FirstOrDefault();

                if (adotante != null)
                {
                    return true;
                }              
                return false;
            }
        }
        public Adotante GetOne(string cpf)
        {           
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"SELECT * FROM Pessoa WHERE CPF = '{cpf}'";
                var adotante = db.Query<Adotante>(query).FirstOrDefault();

                return adotante;
            }
        }
        public List<Adotante> GetAll()
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var adotantes = db.Query<Adotante>(Adotante.SELECT);
                return (List<Adotante>)adotantes;
            }
        }
    }
}
