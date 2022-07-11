using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public PlanoDeCobranca()
        {
        }

        public string TipoDePlano { get; set; }
        public Decimal ValorDiario { get; set; }
        public Decimal ValorKmIncluso { get; set; }
        public Decimal PrecoKmRodado { get; set; }
        public GrupoDeVeiculos GrupoDeVeiculo { get; set; }

        public PlanoDeCobranca(string tipoDePlano, decimal valorDiario, decimal valorKmIncluso, decimal precoKmRodado, GrupoDeVeiculos grupoVeiculo)
        {
            TipoDePlano = tipoDePlano;
            ValorDiario = valorDiario;
            ValorKmIncluso = valorKmIncluso;
            PrecoKmRodado = precoKmRodado;
            GrupoDeVeiculo = grupoVeiculo;
        }

        public override void Atualizar(PlanoDeCobranca registro)
        {
            Id = registro.Id;
            TipoDePlano = registro.TipoDePlano;
            ValorDiario = registro.ValorDiario;
            ValorKmIncluso = registro.ValorKmIncluso;
            PrecoKmRodado = registro.PrecoKmRodado;
            GrupoDeVeiculo = registro.GrupoDeVeiculo;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(TipoDePlano);
            hash.Add(ValorDiario);
            hash.Add(ValorKmIncluso);
            hash.Add(PrecoKmRodado);
            hash.Add(GrupoDeVeiculo);
            return hash.ToHashCode();
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   Id == cobranca.Id &&
                   EqualityComparer<GrupoDeVeiculos>.Default.Equals(GrupoDeVeiculo, cobranca.GrupoDeVeiculo) &&
                   TipoDePlano == cobranca.TipoDePlano &&
                   ValorDiario == cobranca.ValorDiario &&
                   ValorKmIncluso == cobranca.ValorKmIncluso &&
                   PrecoKmRodado == cobranca.PrecoKmRodado;
        }

        public PlanoDeCobranca Clonar()
        {
            return MemberwiseClone() as PlanoDeCobranca;
        }
    }
}
