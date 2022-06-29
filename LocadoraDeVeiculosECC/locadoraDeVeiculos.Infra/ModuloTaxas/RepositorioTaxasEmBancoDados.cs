using FluentValidation.Results;
using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloTaxas
{
    public class RepositorioTaxasEmBancoDados : RepositorioBase<Taxas, MapeadorTaxas>,
        IRepositorioTaxas
    {
      

        #region Sql Queries
        protected override string sqlInserir =>
            @"INSERT INTO [TBTAXAS] 
                (
                    [DESCRICAO],
                    [VALOR],
	            )
	            VALUES
                (
                    @DESCRICAO,
                    @VALOR
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBTAXAS]	
		        SET
			        [DESCRICAO] = @DESCRICAO,
                    [VALOR] = @VALOR
		        WHERE
			        [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBTAXAS]
		        WHERE
			        [ID] = @ID";

        protected override string sqlSelecionarTodos =>
             @"SELECT 
		            [ID], 
		            [DESCRICAO],
                    [VALOR]
	            FROM 
		            [TBTAXAS]";
        protected override string sqlSelecionarPorId =>
           @"SELECT 
		            [ID], 
		            [DESCRICAO],
                    [VALOR]
	            FROM 
		            [TBTAXAS]
		        WHERE
                    [ID] = @ID";

        #endregion

       



       
    }
}
