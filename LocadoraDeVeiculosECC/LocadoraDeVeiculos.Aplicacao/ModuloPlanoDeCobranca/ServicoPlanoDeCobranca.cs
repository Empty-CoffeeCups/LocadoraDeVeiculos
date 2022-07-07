using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        //TODO: Refatorar Em Log

        private RepositorioPlanoDeCobrancaEmBancoDados repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(RepositorioPlanoDeCobrancaEmBancoDados repositorioPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public ValidationResult Inserir(PlanoDeCobranca arg)
        {
            var resultadoValidacao = ValidarPlanoDeCobranca(arg);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Inserir(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca arg)
        {
            var resultadoValidacao = ValidarPlanoDeCobranca(arg);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Editar(arg);

            return resultadoValidacao;
        }

        private ValidationResult ValidarPlanoDeCobranca(PlanoDeCobranca arg)
        {
            ValidadorPlanoDeCobranca validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(arg);

            return resultadoValidacao;
        }
    }
}
