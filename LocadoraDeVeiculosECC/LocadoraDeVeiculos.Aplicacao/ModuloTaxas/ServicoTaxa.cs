﻿using FluentResults;
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
  
        private IRepositorioTaxas repositorioTaxas;

        public ServicoTaxa(IRepositorioTaxas repositorioTaxas)
        {
            this.repositorioTaxas = repositorioTaxas;
        }

        public Result<Taxas> Inserir(Taxas taxas)
        {
            Log.Logger.Debug("Tentando inserir Taxas... {@f}", taxas);

            Result resultadoValidacao = ValidarTaxas(taxas);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Taxas {TaxasId} - {Motivo}",
                       taxas.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxas.Inserir(taxas);

                Log.Logger.Information("Taxas {TaxasId} inserido com sucesso", taxas.Id);

                return Result.Ok(taxas);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir Taxas";

                Log.Logger.Error(ex, msgErro + "{TaxasId}", taxas.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxas> Editar(Taxas taxas)
        {
            Log.Logger.Debug("Tentando editar Cliente... {@f}", taxas);

            Result resultadoValidacao = ValidarTaxas(taxas);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Taxas {TaxasId} - {Motivo}",
                       taxas.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxas.Editar(taxas);

                Log.Logger.Information("Taxas {TaxasId} editado com sucesso", taxas.Id);

                return Result.Ok(taxas);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar Taxas";

                Log.Logger.Error(ex, msgErro + "{TaxasId}", taxas.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxas taxas)
        {
            Log.Logger.Debug("Tentando excluir Taxas... {@f}", taxas);

            try
            {
                repositorioTaxas.Excluir(taxas);

                Log.Logger.Information("Taxas {TaxasId} excluído com sucesso", taxas.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Taxas";

                Log.Logger.Error(ex, msgErro + "{TaxasId}", taxas.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Taxas>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxas.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Taxas";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxas> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxas.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o Taxas";

                Log.Logger.Error(ex, msgErro + "{TaxasId}", id);

                return Result.Fail(msgErro);
            }
        }

        //Métodos Privados

        private Result ValidarTaxas(Taxas taxas)
        {
            var validador = new ValidadorTaxas();

            var resultadoValidacao = validador.Validate(taxas);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }
    }
}
