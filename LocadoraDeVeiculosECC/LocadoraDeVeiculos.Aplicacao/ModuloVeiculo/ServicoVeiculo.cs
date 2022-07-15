using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private RepositorioVeiculoEmBancoDados repositorioVeiculo;

        public ServicoVeiculo(RepositorioVeiculoEmBancoDados repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo arg)
        {
            Log.Logger.Information("Tentando inserir veiculo...{@veiculo}", arg);

            var resultadoValidacao = ValidarVeiculo(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(arg);
                Log.Logger.Information("Veiculo {@veiculoId}", arg.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir veiculo{Modelo} -> Motivo: {erro}", arg.Modelo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }
        public ValidationResult Editar(Veiculo arg)
        {
            Log.Logger.Information("Tentando editar veiculo...{@veiculo}", arg);

            var resultadoValidacao = ValidarVeiculo(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Editar(arg);
                Log.Logger.Information("Veiculo {@VeiculoId}", arg.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Veiculo {VeiculoModelo} -> Motivo: {erro}", arg.Modelo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }
        private ValidationResult ValidarVeiculo(Veiculo arg)
        {
            ValidadorVeiculo validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(arg);

            return resultadoValidacao;
        }
    }
}
