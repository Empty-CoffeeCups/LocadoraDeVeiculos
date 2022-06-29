using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloTaxas
{
    public class ServicoTaxa
    {
        private RepositorioTaxasEmBancoDados repositorioTaxa;

        public ServicoTaxa(RepositorioTaxasEmBancoDados repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxas arg)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Editar(Taxas arg)
        {
            throw new NotImplementedException();
        }
    }
}
