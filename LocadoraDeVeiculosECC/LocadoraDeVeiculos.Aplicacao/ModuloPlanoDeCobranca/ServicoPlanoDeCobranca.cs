using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Serilog;
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
            Log.Logger.Information("Tentando inserir Plano de cobrança...{@plano de cobranca}", arg);

            var resultadoValidacao = ValidarPlanoDeCobranca(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Inserir(arg);
                Log.Logger.Information("Plano de cobrança {@Plano de cobrançaId}", arg.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Plano de cobrança {Plano de cobrançaNome} -> Motivo: {erro}", arg.TipoDePlano, erro.ErrorMessage);
                }
            }
            return resultadoValidacao;
        }

        public ValidationResult Editar(PlanoDeCobranca arg)
        {
            Log.Logger.Information("Tentando editar Plano de cobrança...{@plano de cobranca}", arg);

            var resultadoValidacao = ValidarPlanoDeCobranca(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Editar(arg);
                Log.Logger.Information("Plano de cobrança {@Plano de cobrançaId}", arg.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Plano de cobrança {Plano de cobrançaNome} -> Motivo: {erro}", arg.TipoDePlano, erro.ErrorMessage);
                }
            }

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
