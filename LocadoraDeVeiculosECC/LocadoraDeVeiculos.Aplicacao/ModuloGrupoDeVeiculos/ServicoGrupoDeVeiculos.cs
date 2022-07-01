using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
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
            var resultadoValidacao = ValidarGrupoDeVeiculos(arg);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Inserir(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculos arg)
        {
            var resultadoValidacao = ValidarGrupoDeVeiculos(arg);

            if (resultadoValidacao.IsValid)
                repositorioGrupoVeiculos.Editar(arg);

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
