using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloDevolucao
{
    public class ServicoDevolucao
    {
        private IRepositorioDevolucao repositorioDevolucao;
        private IContextoPersistencia contextoPersistencia;

        public ServicoDevolucao(IRepositorioDevolucao repositorioDevolucao, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioDevolucao = repositorioDevolucao;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result<Devolucao> Inserir(Devolucao devolucao)
        {
            Log.Logger.Debug("Tentando inserir Devolucao... {@f}", devolucao);

            Result resultadoValidacao = ValidarDevolucao(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Devolucao {DevolucaoId} - {Motivo}",
                       devolucao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioDevolucao.Inserir(devolucao);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Devolucao {DevolucaoId} inserido com sucesso", devolucao.Id);

                return Result.Ok(devolucao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Devolucao";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Devolucao> Editar(Devolucao devolucao)
        {
            Log.Logger.Debug("Tentando editar Devolucao... {@f}", devolucao);

            Result resultadoValidacao = ValidarDevolucao(devolucao);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Devolucao {DevolucaoId} - {Motivo}",
                       devolucao.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioDevolucao.Editar(devolucao);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Devolucao {DevolucaoId} editado com sucesso", devolucao.Id);

                return Result.Ok(devolucao);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Devolucao";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Devolucao devolucao)
        {
            Log.Logger.Debug("Tentando excluir Devolucao... {@f}", devolucao);

            try
            {
                repositorioDevolucao.Excluir(devolucao);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Devolucao {DevolucaoId} excluído com sucesso", devolucao.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Devolucao";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", devolucao.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Devolucao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioDevolucao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Devolucoes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Devolucao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioDevolucao.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a Devolucao";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", id);

                return Result.Fail(msgErro);
            }
        }

        //Métodos Privados

        //Métodos Privados

        private Result ValidarDevolucao(Devolucao devolucao)
        {
            var validador = new ValidadorDevolucao();

            var resultadoValidacao = validador.Validate(devolucao);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

    }
}
