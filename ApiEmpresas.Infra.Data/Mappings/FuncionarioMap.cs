using ApiEmpresas.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Mappings
{
    //classe de mapeamento para a entidade funcionario
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        //método para mapear a entidade 
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabela
            builder.ToTable("FUNCIONARIO");

            //chave primaria
            builder.HasKey(f => f.IdFuncionario);

            //mapeamneto dos campos da entidade
            builder.Property(f => f.IdFuncionario)
                .HasColumnName("IDFUNCIONARIO")
                .IsRequired();

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DATAADMISSAO")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.IdEmpresa)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            #region mapeamento de relacionamento 1 para muitos

            builder.HasOne(f => f.Empresa) //Funcionário TEM 1 Empresa
                .WithMany(e => e.Funcionarios) //Empresa TEM MUITOS Funcionários
                .HasForeignKey(f => f.IdEmpresa); //chave estrangeira

            #endregion

            #region Mapeamento de campos únicos

            builder.HasIndex(f => f.Cpf)
                .IsUnique();

            builder.HasIndex(f => f.Matricula)
                .IsUnique();

            #endregion
        }
    }
}
