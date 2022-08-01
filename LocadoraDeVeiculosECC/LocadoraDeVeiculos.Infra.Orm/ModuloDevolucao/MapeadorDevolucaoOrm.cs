using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao
{
    public class MapeadorDevolucaoOrm : IEntityTypeConfiguration<Devolucao>
    {
        public void Configure(EntityTypeBuilder<Devolucao> builder)
        {
            builder.ToTable("TBDevolucao");
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(x => x.Locacao)
                .WithMany().OnDelete(DeleteBehavior.NoAction);


            builder.Property(x => x.KmVeiculo).IsRequired();
            builder.Property(x => x.NivelDoTanque).IsRequired();
            builder.Property(x => x.DataDeDevolucao).IsRequired();

            builder.HasMany(x => x.Taxas)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.ValorTotal).IsRequired();

        }


    }
}
