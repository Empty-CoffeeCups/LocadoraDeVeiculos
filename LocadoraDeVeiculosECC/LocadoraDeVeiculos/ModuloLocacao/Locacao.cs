using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Condutor Condutor { get; set; }

      //  public Veiculo Veiculo { get; set; } Ainda dar merge em veiculo
        public PlanoDeCobranca PlanoDeCobranca { get; set; }
        public List<Taxas> Taxas { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public decimal ValorTotalPrevisto { get; set; }

        public Locacao()
        {

        }

        public Locacao(Funcionario funcionario, Cliente cliente, Condutor condutor, PlanoDeCobranca planoDeCobranca, List<Taxas> taxas, DateTime dataLocacao, DateTime dataDevolucaoPrevista)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            Condutor = condutor;
            PlanoDeCobranca = planoDeCobranca;
            Taxas = taxas;
            DataLocacao = dataLocacao;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
        }


        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Funcionario);
            hash.Add(Cliente);
            hash.Add(Condutor);
            hash.Add(PlanoDeCobranca);
            hash.Add(Taxas);
            hash.Add(DataLocacao);
            hash.Add(DataDevolucaoPrevista);
            hash.Add(ValorTotalPrevisto);
            return hash.ToHashCode();
        }

        public override void Atualizar(Locacao registro)
        {
            Id = registro.Id;
            Funcionario = registro.Funcionario;
            Cliente = registro.Cliente;
            Condutor = registro.Condutor;
            PlanoDeCobranca = registro.PlanoDeCobranca;
            Taxas = registro.Taxas;
            DataLocacao = registro.DataLocacao;
            DataDevolucaoPrevista = registro.DataDevolucaoPrevista;
            ValorTotalPrevisto = registro.ValorTotalPrevisto;
        }

        public override bool Equals(object? obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, locacao.Funcionario) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, locacao.Condutor) &&
                   //  EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) && Ainda dar merge em veiculo
                   EqualityComparer<PlanoDeCobranca>.Default.Equals(PlanoDeCobranca, locacao.PlanoDeCobranca) &&
                   EqualityComparer<List<Taxas>>.Default.Equals(Taxas, locacao.Taxas) &&
                   DataLocacao == locacao.DataLocacao &&
                   ValorTotalPrevisto == locacao.ValorTotalPrevisto; 
        }

        public override string ToString()
        {
            return Funcionario.Nome + " - " + Cliente.Nome + " - " + Condutor.Nome + "-" + PlanoDeCobranca.TipoDePlano + "-" + ValorTotalPrevisto;
        }

        public Locacao Clonar()
        {
            return MemberwiseClone() as Locacao;
        }

    }
}
