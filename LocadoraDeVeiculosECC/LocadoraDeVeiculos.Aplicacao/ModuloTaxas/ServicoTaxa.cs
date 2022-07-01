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
            var resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Inserir(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxas arg)
        {
            var resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Editar(arg);

            return resultadoValidacao;
        }

       
        private ValidationResult ValidarTaxa(Taxas arg)
        {
            ValidadorTaxas validador = new ValidadorTaxas();

            var resultadoValidacao = validador.Validate(arg);

            return resultadoValidacao;
        }
    }
}
