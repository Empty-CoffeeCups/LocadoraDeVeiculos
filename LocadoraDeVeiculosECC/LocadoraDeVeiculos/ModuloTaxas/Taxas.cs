using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.Compartilhado;
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
        public TipoCalculo TipoCalculo { get; set; }


        public Taxas(string descricao, decimal valor, TipoCalculo tipoCalculo)
        {
            Descricao = descricao;
            Valor = valor;
            TipoCalculo = tipoCalculo;
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
            return string.Format("{0}, {1}, {2}", Descricao, Valor, TipoCalculo.GetDescription());
        }
        public Taxas Clone() {
            return MemberwiseClone() as Taxas;
        }

        public override bool Equals(object obj)
        {
            Taxas t = obj as Taxas;

            if (t == null)
                return false;

            return
             t.Id.Equals(Id) &&
             t.Descricao.Equals(Descricao) &&
             t.Valor.Equals(Valor) &&
             t.TipoCalculo.Equals(TipoCalculo);

        }
    }
}
