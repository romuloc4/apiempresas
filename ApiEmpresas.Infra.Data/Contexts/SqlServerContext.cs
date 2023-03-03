using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Contexts
{
    //Classe para configuração (contexto) do 
    //entityFrameWork no projeto Infra.data
    public class SqlServerContext : DbContext
    {
        //contrutor ara injeção de dependencia
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base (options)
        {

        }

        //sobescrever o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //informar cada classe de mapeamento do projeto
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        //declarar uma propiedad DbSet para cada entidade
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
