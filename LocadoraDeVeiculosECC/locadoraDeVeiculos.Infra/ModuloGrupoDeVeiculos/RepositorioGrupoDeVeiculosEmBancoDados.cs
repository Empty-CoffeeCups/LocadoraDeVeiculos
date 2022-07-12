using FluentValidation.Results;
using locadoraDeVeiculos.Infra.Compartilhado;
using locadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioGrupoDeVeiculosEmBancoDados : RepositorioBase<GrupoDeVeiculos, MapeadorGrupoDeVeiculos>,
        IRepositorioGrupoDeVeiculos
    {
       
        #region Sql Queries
        protected override string sqlInserir =>
            @"INSERT INTO [TBGRUPODEVEICULOS] 
                (
                    [ID],
                    [NOMEDOGRUPO]
	            )
	            VALUES
                (
                    @ID,
                    @NOMEDOGRUPO
                );";

        protected override string sqlEditar =>
            @"UPDATE [TBGRUPODEVEICULOS]	
		        SET
			        [NOMEDOGRUPO] = @NOMEDOGRUPO
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBGRUPODEVEICULOS]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarPorId =>
             @"SELECT 
                [ID] GRUPODEVEICULO_ID,       
                [NOMEDOGRUPO] GRUPODEVEICULO_NOMEDOGRUPO
            FROM
                [TBGRUPODEVEICULOS]
            WHERE 
             [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID] GRUPODEVEICULO_ID,       
                [NOMEDOGRUPO] GRUPODEVEICULO_NOMEDOGRUPO
            FROM
                [TBGRUPODEVEICULOS]";


        #endregion


       

    }
}
