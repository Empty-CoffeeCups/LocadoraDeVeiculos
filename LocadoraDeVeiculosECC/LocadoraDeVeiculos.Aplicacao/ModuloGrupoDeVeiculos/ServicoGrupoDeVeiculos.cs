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
            throw new NotImplementedException();
        }

        public ValidationResult Editar(GrupoDeVeiculos arg)
        {
            throw new NotImplementedException();
        }
    }
}
