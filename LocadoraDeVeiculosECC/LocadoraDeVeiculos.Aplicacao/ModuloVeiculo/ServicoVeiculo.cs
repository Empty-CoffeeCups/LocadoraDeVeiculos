using FluentResults;
using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.Compartilhado;
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
        private IRepositorioVeiculo repositorioVeiculo;
        private IContextoPersistencia contextoPersistencia;

        public ServicoVeiculo(IRepositorioVeiculo repositorioVeiculo, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.contextoPersistencia = contextoPersistencia;
        }
        public Result<Veiculo> Inserir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando inserir Veiculo... {@f}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Veiculo {VeiculoId} - {Motivo}",
                       veiculo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculo.Inserir(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veiculo {VeiculoId} inserido com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<Veiculo> Editar(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando editar Veiculo... {@f}", veiculo);

            Result resultadoValidacao = ValidarVeiculo(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Veiculo {VeiculoId} - {Motivo}",
                       veiculo.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioVeiculo.Editar(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veiculo {VeiculoId} editado com sucesso", veiculo.Id);

                return Result.Ok(veiculo);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiuculoId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Veiculo veiculo)
        {
            Log.Logger.Debug("Tentando excluir Veiculo... {@f}", veiculo);

            try
            {
                repositorioVeiculo.Excluir(veiculo);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Veiculo {VeiculoId} excluído com sucesso", veiculo.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiucloId}", veiculo.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result<Veiculo> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Veiculo";

                Log.Logger.Error(ex, msgErro + "{VeiculoId}", id);

                return Result.Fail(msgErro);
            }
        }
        public Result<List<Veiculo>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioVeiculo.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Veiculos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }
        private Result ValidarVeiculo(Veiculo veiculo)
        {
            ValidadorVeiculo validador = new ValidadorVeiculo();

            var resultadoValidacao = validador.Validate(veiculo);

            List<Error> errors = new List<Error>();

            foreach (ValidationFailure r in resultadoValidacao.Errors)
            {
                errors.Add(new Error(r.ErrorMessage));
            }

            if (resultadoValidacao.IsValid)
            {
                if (veiculo.Placa != "              ")
                    if (PlacaDuplicada(veiculo))
                        errors.Add(new Error("Placa do veiculo já cadastrada"));
            }
            if (errors.Any())
            {
                return Result.Fail(errors);
            }

            return Result.Ok();
        }
        private bool PlacaDuplicada(Veiculo veiculo)
        {
            var veiculoEncontrado = repositorioVeiculo.SelecionarVeiculoPorPlaca(veiculo.Placa);

            return veiculoEncontrado != null &&
                   veiculoEncontrado.Placa == veiculo.Placa &&
                   veiculoEncontrado.Id != veiculo.Id;
        }
    }
}
