using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaEmBancoDados :
        RepositorioBase<PlanoDeCobranca, MapeadorPlanoDeCobranca>,
        IRepositorioPlanoDeCobranca
    {
        #region sql Queries

        protected override string sqlInserir =>
            @"INSERT INTO [TBPLANODECOBRANCA]
                (
                    [TIPODEPLANO], 
                    [VALORDIARIO],
                    [VALORKMINCLUSO],                    
                    [PRECOKMRODADO],
                    [GRUPODEVEICULOS_ID]
                )
            VALUES
                (
                    @TIPODEPLANO,
                    @VALORDIARIO,
                    @VALORKMINCLUSO,
                    @PRECOKMRODADO,
                    @GRUPODEVEICULOS_ID
                ); SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBPLANODECOBRANCA]
                SET
                    [TIPODEPLANO] = @TIPODEPLANO,
                    [VALORDIARIO] = @VALORDIARIO,
                    [VALORKMINCLUSO] = @VALORKMINCLUSO,
                    [PRECOKMRODADO] = @PRECOKMRODADO,
                    [GRUPODEVEICULOS_ID] = @GRUPODEVEICULOS_ID
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANODECOBRANCA]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    [ID],
		            [TIPODEPLANO], 
                    [VALORDIARIO],
                    [VALORKMINCLUSO],                    
                    [PRECOKMRODADO],
                    [GRUPODEVEICULOS_ID]  
	            FROM 
		            [TBPLANODECOBRANCA]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    [ID],
		            [TIPODEPLANO], 
                    [VALORDIARIO],
                    [VALORKMINCLUSO],                    
                    [PRECOKMRODADO],
                    [GRUPODEVEICULOS_ID]  
	            FROM 
		            [TBPLANODECOBRANCA]";

        private string sqlSelecionarPorGrupo =>
            @"SELECT
                    [ID],
		            [TIPODEPLANO], 
                    [VALORDIARIO],
                    [VALORKMINCLUSO],                    
                    [PRECOKMRODADO],
                    [GRUPODEVEICULOS_ID]    
	            FROM 
		            [TBPLANODECOBRANCA]
                WHERE 
                    [GRUPODEVEICULOS_ID] = @GRUPODEVEICULOS_ID";

        private string sqlSelecionarPorTipoPlano =>
            @"SELECT
                    [ID],
		            [TIPODEPLANO], 
                    [VALORDIARIO],
                    [VALORKMINCLUSO],                    
                    [PRECOKMRODADO],
                    [GRUPODEVEICULOS_ID]    
	            FROM 
		            [TBPLANODECOBRANCA]
                WHERE 
                    [TIPODEPLANO] = @TIPODEPLANO";
        #endregion

        public PlanoDeCobranca SelecionarPlanoPorGrupo(int id)
        {
            return SelecionarPorParametro(sqlSelecionarPorGrupo, new SqlParameter("GRUPODEVEICULOS_ID", id));
        }

        public PlanoDeCobranca SelecionarPlanoPorTipoPlano(string tipoPlano)
        {
            return SelecionarPorParametro(sqlSelecionarPorTipoPlano, new SqlParameter("TIPODEPLANO", tipoPlano));
        }

    }
}
