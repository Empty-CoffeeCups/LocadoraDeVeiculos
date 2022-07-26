using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionario : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TBFuncionario");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Usuario).HasColumnType("varchar(35)").IsRequired();
            builder.Property(x => x.Senha).HasColumnType("varchar(35)").IsRequired();
            builder.Property(x => x.DataDeEntrada).IsRequired();
            builder.Property(x => x.Salario).IsRequired();
            builder.Property(x => x.Admin).IsRequired();
        }
    }
}
