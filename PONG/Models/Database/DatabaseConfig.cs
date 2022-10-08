using System.IO;
using Microsoft.Extensions.Configuration;

namespace Models.Database
{
    public class DatabaseConfig
    {
        #region Microsoft.Extensions.Configuration 
        public static IConfigurationRoot Configuration { get; set; }
        #endregion

        #region Obter Conexao
        public static string GetConexao()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            return Configuration["ConnectionStrings:DefaultConnection"];
        }
        #endregion
    }
}
