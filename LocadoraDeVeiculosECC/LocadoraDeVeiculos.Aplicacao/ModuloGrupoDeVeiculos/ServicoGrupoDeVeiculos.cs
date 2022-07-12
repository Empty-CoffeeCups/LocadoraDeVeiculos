using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
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
        //TODO: VALIDAÇÕES DE GRUPOS DE VEÍCULOS

        private RepositorioGrupoDeVeiculosEmBancoDados repositorioGrupoVeiculos;

        public ServicoGrupoDeVeiculos(RepositorioGrupoDeVeiculosEmBancoDados repositorioGrupoVeiculos)
        {
            this.repositorioGrupoVeiculos = repositorioGrupoVeiculos;
        }

        public ValidationResult Inserir(GrupoDeVeiculos arg)
        {
            Log.Logger.Information("Tentando inserir grupo de veiculos...{@GrupoDeVeiculos}", arg);

            var resultadoValidacao = ValidarGrupoDeVeiculos(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculos.Inserir(arg);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Grupo De Veiculos{GrupoDeVeiculosNomeDoGrupo} -> Motivo: {erro}", arg.NomeDoGrupo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculos arg)
        {
            Log.Logger.Information("Tentando editar grupo de veiculos...{@GrupoDeVeiculos}", arg);

            var resultadoValidacao = ValidarGrupoDeVeiculos(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioGrupoVeiculos.Editar(arg);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Grupo De Veiculos{GrupoDeVeiculosNomeDoGrupo} -> Motivo: {erro}", arg.NomeDoGrupo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult ValidarGrupoDeVeiculos(GrupoDeVeiculos arg)
        {
            ValidadorGrupoDeVeiculos validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(arg);

            return resultadoValidacao;
        }
    }
}
