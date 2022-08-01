using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    public class MapeadorVeiculoOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TBVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.GruposDeVeiculos);
            builder.Property(x => x.Modelo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Placa).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Cor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.TipoDeCombustivel).IsRequired();
            builder.Property(x => x.CapacidadeDoTanque).IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.KmPercorrido).IsRequired();
            builder.Property(x => x.Foto).HasColumnType("VARBINARY(MAX)").IsRequired();

        }

    }
}
