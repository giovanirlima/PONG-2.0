using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Models;
using Models.Database;
using Services.Interface;

namespace Services
{
    public class AdotanteAdotaAnimalServices : IAdotanteAdotaAnimal
    {
        private string _conexao;

        public AdotanteAdotaAnimalServices()
        {
            _conexao = DatabaseConfig.GetConexao();
        }
        public bool InsertAAAnimal(AdotanteAdotaAnimal p)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(AdotanteAdotaAnimal.INSERT, p);
                return true;
            }
        }
        public bool DeleteADisponivel(int chip)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"DELETE FROM Animais_Disponiveis WHERE CHIP = @CHIP";
                db.Execute(query, chip);
                return true;
            }
        }
        public AdotanteAdotaAnimal GetAAAnimal(string cpf)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"SELECT * FROM AdotanteAdotaAnimal WHERE CPF = {cpf}";
                var adotanteAdotaAnimal = db.Query<AdotanteAdotaAnimal>(AdotanteAdotaAnimal.SELECT).FirstOrDefault();
                return adotanteAdotaAnimal;
            }
        }
        public bool GetSpecific(int chip)
        {
            AdotanteAdotaAnimal adotanteAdotaAnimal = new();

            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"SELECT * FROM Animais_Disponiveis WHERE CHIP = {chip}";
                adotanteAdotaAnimal = db.Query<AdotanteAdotaAnimal>(query).FirstOrDefault();

                if (adotanteAdotaAnimal != null)
                {
                    return true;
                }
                return false;
            }
        }
        public List<AdotanteAdotaAnimal> GetAll()
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var adotanteAdotaAnimal = db.Query<AdotanteAdotaAnimal>(AdotanteAdotaAnimal.SELECT);
                return (List<AdotanteAdotaAnimal>)adotanteAdotaAnimal;
            }
        }

    }
}
