using LocadoraDeVeiculos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class Taxas : EntidadeBase<Taxas>
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public Taxas(string descricao, decimal valor)
        {
            Descricao = descricao;
            Valor = valor;
        }

        public Taxas() { }

        public override void Atualizar(Taxas registro)
        {
            Descricao = registro.Descricao;
            Valor = registro.Valor;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Descricao, Valor);
        }
        public override string ToString()
        {
            return Descricao + " - " + Valor;
        }
        public Taxas Clone() {
            return MemberwiseClone() as Taxas;
        }
    }
}
