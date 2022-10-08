using System;
using System.Data.SqlClient;
using Controllers;
using Models;

namespace PONG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var idade = DateTime.Parse(Console.ReadLine());



            Adotante adotante = new()
            {
                CPF = "42721218808",
                Nome = "Giovani Rocha Lima",
                Nascimento = idade,
                Sexo = "Masculino",
                Rua = "Alfredo Botta",
                Numero = "407",
                Bairro = "Jd Del Rey",
                Cidade = "Araraqrara",
                Estado = "São Paulo",
                Telefone = "16992804976"
            };


            Animal animal = new()
            {
                Familia = "Cachorro",
                Raca = "Pastor Alemão",
                Sexo = "Fêmea",
                Nome = "Sharp"
            };

            new AdotanteController().InsertAdotante(adotante);

            new AdotanteController().GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            new AnimalController().InsertAnimal(animal);

            new AnimalController().GetAll().ForEach(x => Console.WriteLine(x.ToString()));

            Console.WriteLine("Ufa");

            Console.Read();

        }
    }
}
