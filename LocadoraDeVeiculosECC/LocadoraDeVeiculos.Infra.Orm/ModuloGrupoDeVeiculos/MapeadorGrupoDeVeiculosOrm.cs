using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos
{
    public class MapeadorGrupoDeVeiculosOrm : IEntityTypeConfiguration<GrupoDeVeiculos>
    {
        public void Configure(EntityTypeBuilder<GrupoDeVeiculos> builder)
        {
            builder.ToTable("TBGrupoDeVeiculos");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.NomeDoGrupo).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
