using FluentResults;
using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.Compartilhado;
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

        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;
        private IContextoPersistencia contextoPersistencia;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca, IContextoPersistencia contexto)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.contextoPersistencia = contexto;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando inserir Plano De Cobranca... {@f}", planoDeCobranca);

            Result resultadoValidacao = ValidarPlanoDeCobranca(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Plano De Cobranca {PlanoDeCobrancaId} - {Motivo}",
                       planoDeCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano De Cobranca {PlanoDeCobrancaId} inserido com sucesso", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir Plano De Cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<PlanoDeCobranca> Editar(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando editar Plano De Cobranca... {@f}", planoDeCobranca);

            Result resultadoValidacao = ValidarPlanoDeCobranca(planoDeCobranca);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Plano De Cobranca {PlanoDeCobrancaId} - {Motivo}",
                       planoDeCobranca.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Editar(planoDeCobranca);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano De Cobranca {PlanoDeCobrancaId} editado com sucesso", planoDeCobranca.Id);

                return Result.Ok(planoDeCobranca);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar Plano De Cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoDeCobranca planoDeCobranca)
        {
            Log.Logger.Debug("Tentando excluir Plano De Cobranca... {@f}", planoDeCobranca);

            try
            {
                repositorioPlanoDeCobranca.Excluir(planoDeCobranca);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Plano De Cobranca {PlanoDeCobrancaId} excluído com sucesso", planoDeCobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Plano De Cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", planoDeCobranca.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Planos de Cobrança";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }


        public Result<PlanoDeCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar Plano De Cobranca";

                Log.Logger.Error(ex, msgErro + "{PlanoDeCobrancaId}", id);

                return Result.Fail(msgErro);
            }
        }

        //Métodos Privados

        private Result ValidarPlanoDeCobranca(PlanoDeCobranca planoDeCobranca)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(planoDeCobranca);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

    }
}
