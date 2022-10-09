using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Models;
using Models.Database;
using Services.Interface;

namespace Services
{
    public class AnimalServices : IAnimalServices
    {
        static string _conexao;

        public AnimalServices()
        {
            _conexao = DatabaseConfig.GetConexao();
        }

        public bool InsertAnimal(Animal animal)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Animal.INSERT, animal);
                return true;
            }            
        }
        public bool UpdateAdotante(int chip, string paramentro, string value)
        {
            using (var db = new SqlConnection(_conexao))
            {
                var query = $"UPDATE Animal SET {paramentro} = '{value}' WHERE CHIP = '{chip}'";
                db.Execute(query);
                return true;
            }
        }
        public bool GetSpecific(int chip)
        {       
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"SELECT * FROM Animal WHERE CHIP = {chip}";
                var animal = db.Query<Animal>(query).FirstOrDefault();

                if (animal != null)
                {
                    return true;
                }
                return false;
            }
        }
        public Animal GetOne(int chip)
        {
            Adotante adotante = new();

            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"SELECT * FROM Animal WHERE CHIP = '{chip}'";
                var animal = db.Query<Animal>(query).FirstOrDefault();

                return animal;
            }
        }
        public List<Animal> GetAll()
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var animal = db.Query<Animal>(Animal.SELECT);
                return (List<Animal>)animal;
            }
        }        
        public bool InsertAnimalDP(Animal animal)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Animal.INSERTAD, animal);
                return true;
            }
        }
        public bool GetSpecificAAA(int chip)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"SELECT * FROM Animais_Disponiveis WHERE CHIP = '{chip}'";
                var count = db.Query<int>(query).FirstOrDefault();

                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }               
    }
}
