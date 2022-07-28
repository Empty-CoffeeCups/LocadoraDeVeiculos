using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxas
{
    public class MapeadorTaxasOrm : IEntityTypeConfiguration<Taxas>
    {
        public void Configure(EntityTypeBuilder<Taxas> builder)
        {
            builder.ToTable("TBTaxas");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Descricao).HasColumnType("varchar(300)").IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.TipoCalculo).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
