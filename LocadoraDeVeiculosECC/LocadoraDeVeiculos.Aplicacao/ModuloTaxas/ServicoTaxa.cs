using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Serilog;
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
            Log.Logger.Information("Tentando inserir taxa...{@funcionario}", arg);

            var resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(arg);
                Log.Logger.Information("Taxa {@taxaId}", arg.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Taxa {TaxaTipoCalculo} -> Motivo: {erro}", arg.TipoCalculo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxas arg)
        {
            Log.Logger.Information("Tentando editar taxa...{@funcionario}", arg);

            var resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(arg);
                Log.Logger.Information("Taxa {@taxaId}", arg.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Taxa {TaxaTipoCalculo} -> Motivo: {erro}", arg.TipoCalculo, erro.ErrorMessage);
                }
            }

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
