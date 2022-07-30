using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase<Devolucao>
    {
        public Locacao Locacao { get; set; }
        public int KmVeiculo { get; set; }
        public decimal NivelDoTanque { get; set; }
        public DateTime DataDeDevolucao { get; set; }
        public List<Taxas> Taxas { get; set; }
        public decimal ValorTotal { get; set; }

        public Devolucao()
        {

        }

        public Devolucao(Locacao locacao, int kmVeiculo, decimal nivelDoTanque, DateTime dataDeDevolucao, List<Taxas> taxas, decimal valorTotal)
        {
            Locacao = locacao;
            KmVeiculo = kmVeiculo;
            NivelDoTanque = nivelDoTanque;
            DataDeDevolucao = dataDeDevolucao;
            Taxas = taxas;
            ValorTotal = valorTotal;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Locacao);
            hash.Add(KmVeiculo);
            hash.Add(NivelDoTanque);
            hash.Add(DataDeDevolucao);
            hash.Add(Taxas);
            hash.Add(ValorTotal);
            return hash.ToHashCode();
        }
        public override void Atualizar(Devolucao registro)
        {
            Id = registro.Id;
            Locacao = registro.Locacao;
            KmVeiculo = registro.KmVeiculo;
            NivelDoTanque = registro.NivelDoTanque;
            DataDeDevolucao = registro.DataDeDevolucao;
            Taxas = registro.Taxas;
            ValorTotal = registro.ValorTotal;
        }
        public override bool Equals(object obj)
        {
            return obj is Devolucao devolucao &&
                  Id == devolucao.Id &&
                  Locacao == devolucao.Locacao &&
                  KmVeiculo == devolucao.KmVeiculo &&
                  NivelDoTanque == devolucao.NivelDoTanque &&
                  DataDeDevolucao == devolucao.DataDeDevolucao &&
                  Taxas == devolucao.Taxas &&
                  ValorTotal == devolucao.ValorTotal;
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public Locacao Clonar()
        {
            return MemberwiseClone() as Locacao;
        }
    }
}
