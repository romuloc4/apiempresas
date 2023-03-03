using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Contexts
{
    public class SqlServerMigration : IDesignTimeDbContextFactory<SqlServerContext>
    {
        //Método utilizado pelo Migrations para inicializar a classe
        //SqlServerContext utilizando os atributos do appsettings.json
        public SqlServerContext CreateDbContext(String[] args)
        {
            //Lendo o aquivo appsettings.json
            var configurationBulder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBulder.AddJsonFile(path, false);

            //capturar a connectionstring mapeada dentro do arquivo
            var root = configurationBulder.Build();
            var connectionString = root.GetSection("ConnectionStrings")
                .GetSection("BDApiEmpresas").Value;

            //instanciar a classe SqlServerContext
            var builder = new DbContextOptionsBuilder<SqlServerContext>();
            builder.UseSqlServer(connectionString);

            return new SqlServerContext(builder.Options);
        }

    }
}
