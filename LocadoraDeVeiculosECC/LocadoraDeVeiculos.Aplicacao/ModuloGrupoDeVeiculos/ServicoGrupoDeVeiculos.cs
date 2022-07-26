using FluentResults;
using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos
{
    public class ServicoGrupoDeVeiculos
    {
        

        private IRepositorioGrupoDeVeiculos repositorioGrupoDeVeiculos;
        private IContextoPersistencia contextoPersistencia;

        public ServicoGrupoDeVeiculos(IRepositorioGrupoDeVeiculos repositorioGrupoDeVeiculos, IContextoPersistencia contexto)
        {
            this.repositorioGrupoDeVeiculos = repositorioGrupoDeVeiculos;
            this.contextoPersistencia = contexto;
        }

        public Result<GrupoDeVeiculos> Inserir(GrupoDeVeiculos grupoDeVeiculos)
        {
            Log.Logger.Debug("Tentando inserir Grupo De Veiculos... {@f}", grupoDeVeiculos);

            Result resultadoValidacao = ValidarGrupoDeVeiculos(grupoDeVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Grupo De Veiculos {GrupoDeVeiculosId} - {Motivo}",
                       grupoDeVeiculos.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioGrupoDeVeiculos.Inserir(grupoDeVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo De Veiculos {GrupoDeVeiculosId} inserido com sucesso", grupoDeVeiculos.Id);

                return Result.Ok(grupoDeVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Grupo De Veiculos";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculosId}", grupoDeVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoDeVeiculos> Editar(GrupoDeVeiculos grupoDeVeiculos)
        {
            Log.Logger.Debug("Tentando editar Cliente... {@f}", grupoDeVeiculos);

            Result resultadoValidacao = ValidarGrupoDeVeiculos(grupoDeVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Grupo De Veiculos {GrupoDeVeiculosId} - {Motivo}",
                       grupoDeVeiculos.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioGrupoDeVeiculos.Editar(grupoDeVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo De Veiculos {GrupoDeVeiculosId} editado com sucesso", grupoDeVeiculos.Id);

                return Result.Ok(grupoDeVeiculos);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Grupo De Veiculos";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculosId}", grupoDeVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(GrupoDeVeiculos grupoDeVeiculos)
        {
            Log.Logger.Debug("Tentando excluir Grupo De Veiculos... {@f}", grupoDeVeiculos);

            try
            {
                repositorioGrupoDeVeiculos.Excluir(grupoDeVeiculos);

                contextoPersistencia.GravarDados();

                Log.Logger.Information("Grupo De Veiculos {GrupoDeVeiculosId} excluído com sucesso", grupoDeVeiculos.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Grupo De Veiculos";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculos_Id}", grupoDeVeiculos.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<GrupoDeVeiculos>> SelecionarTodos()
        {
            Log.Logger.Debug("Tentando selecionar grupo de veiculos...");

            try
            {
                Log.Logger.Information("Grupos de veicúlos selecionados com sucesso");

                return Result.Ok(repositorioGrupoDeVeiculos.SelecionarTodos());

            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Grupos De Veiculos";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<GrupoDeVeiculos> SelecionarPorId(Guid id)
        {
            Log.Logger.Debug("Tentando selecionar grupo de veículos {GrupoDeVeiculosId}...", id);

            try
            {
                return Result.Ok(repositorioGrupoDeVeiculos.SelecionarPorId(id));

                Log.Logger.Information("Grupo de Veículos {GrupoDeVeiculosId} selecionado com sucesso", id);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Grupo De Veiculos";

                Log.Logger.Error(ex, msgErro + "{GrupoDeVeiculosId}", id);

                return Result.Fail(msgErro);
            }
        }


        //Métodos Privados

        private Result ValidarGrupoDeVeiculos(GrupoDeVeiculos grupoDeVeiculos)
        {
            var validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(grupoDeVeiculos);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
    }
}
