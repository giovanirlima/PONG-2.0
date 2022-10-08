﻿using System.Collections.Generic;
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

        public bool GetSpecific(int chip)
        {
            Adotante adotante = new();

            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var query = $"SELECT * FROM Animal WHERE CHIP = {chip}";
                adotante = db.Query<Adotante>(query).FirstOrDefault();

                if (adotante != null)
                {
                    return true;
                }
                return false;
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



        #region AnimalDP
        public bool InsertAnimalDP(Animal animal)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Animal.INSERTAD, animal);
                return true;
            }
        }
        #endregion


    }
}
