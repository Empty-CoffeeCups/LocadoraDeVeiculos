using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobrancaOrm : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TBPlanoDeCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.TipoDePlano).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.ValorDiario).IsRequired();
            builder.Property(x => x.ValorKmIncluso).IsRequired();
            builder.Property(x => x.PrecoKmRodado).IsRequired();
            builder.HasOne(x => x.GrupoDeVeiculo);
        }
    }
}
