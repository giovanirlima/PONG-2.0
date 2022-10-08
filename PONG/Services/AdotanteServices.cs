using System.Collections.Generic;
using System.Data.SqlClient;
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

        public List<Adotante> GetAll()
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var adotantes = db.Query<Adotante>(Adotante.SELECT);
                return (List<Adotante>) adotantes;
            }
        }
    }
}
