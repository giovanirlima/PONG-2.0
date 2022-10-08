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
