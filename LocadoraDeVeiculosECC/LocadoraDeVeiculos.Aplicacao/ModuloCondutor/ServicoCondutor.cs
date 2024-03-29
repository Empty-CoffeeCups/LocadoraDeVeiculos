﻿using FluentResults;
using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;
        private IContextoPersistencia contextoPersistencia;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IContextoPersistencia contexto)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.contextoPersistencia = contexto;
        }

        public Result<Condutor> Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir Condutor... {@f}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Condutor {CondutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} inserido com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o Condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor condutor)
        {
            Log.Logger.Debug("Tentando editar Condutor... {@f}", condutor);

            Result resultadoValidacao = ValidarCondutor(condutor);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Condutor {CondutorId} - {Motivo}",
                       condutor.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(condutor);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} editado com sucesso", condutor.Id);

                return Result.Ok(condutor);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o Condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando excluir Condutor... {@f}", condutor);

            try
            {
                repositorioCondutor.Excluir(condutor);
                contextoPersistencia.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", condutor.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Condutores";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", id);

                return Result.Fail(msgErro);
            }
        }

        //Métodos Privados

        private Result ValidarCondutor(Condutor condutor)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(condutor);

            List<Error> errors = new List<Error>();

            foreach (ValidationFailure r in resultadoValidacao.Errors)
            {
                errors.Add(new Error(r.ErrorMessage));
            }

      
            if (resultadoValidacao.IsValid)
            {
                if (condutor.Cpf != "              ")
                    if (CpfDuplicado(condutor) && ClienteDuplicado(condutor))
                        errors.Add(new Error("CPF do Condutor já cadastrado para o Condutor"));
            }

            if (errors.Any())
            {
                return Result.Fail(errors);
            }

            return Result.Ok();
        }

        
        private bool ClienteDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCliente(condutor.Cliente.Id);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cliente.Id == condutor.Cliente.Id &&
                   condutorEncontrado.Id != condutor.Id;
        }
        private bool CpfDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCpf(condutor.Cpf);

            return condutorEncontrado != null &&
                   condutorEncontrado.Cpf == condutor.Cpf &&
                   condutorEncontrado.Id != condutor.Id;
        }

        
    }
}
