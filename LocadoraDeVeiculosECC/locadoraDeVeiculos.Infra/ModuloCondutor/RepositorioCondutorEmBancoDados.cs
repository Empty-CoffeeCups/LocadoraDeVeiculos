using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloCondutor
{
    public class RepositorioCondutorEmBancoDados : RepositorioBase<Condutor, MapeadorCondutor>,
        IRepositorioCondutor


    { 
        protected override string sqlInserir =>
            @"INSERT INTO [TBCONDUTOR]
                (   
                    [ID],
                    [NOME], 
                    [CPF],
                    [CNH],                    
                    [VALIDADECNH],    
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO],
                    [CLIENTE_ID]    
                )
            VALUES
                (
                    @ID,
                    @NOME,
                    @CPF,
                    @CNH,
                    @VALIDADECNH,
                    @EMAIL,
                    @TELEFONE,
                    @ENDERECO,
                    @CLIENTE_ID
                );";


        protected override string sqlEditar =>
            @"UPDATE [TBCONDUTOR]
                SET
                    [NOME] = @NOME,
                    [CPF] = @CPF,
                    [CNH] = @CNH,
                    [VALIDADECNH] = @VALIDADECNH,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE,
                    [ENDERECO] = @ENDERECO,
                    [CLIENTE_ID] = @CLIENTE_ID
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCONDUTOR]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    [ID],
		            [NOME], 
                    [CPF],
                    [CNH],                    
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO],
                    [CLIENTE_ID]
	            FROM 
		            [TBCONDUTOR]
		        WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    [ID],
		            [NOME], 
                    [CPF],
                    [CNH],                    
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO], 
                    [CLIENTE_ID]
	            FROM 
		            [TBCONDUTOR]";

        private string sqlSelecionarPorCliente =>
            @"SELECT
                    [ID],
		            [NOME], 
                    [CPF],
                    [CNH],                    
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO],
                    [CLIENTE_ID]
	            FROM 
		            [TBCONDUTOR]
                WHERE 
                    [CLIENTE_ID] = @CLIENTE_ID";

        private string sqlSelecionarCpf =>
            @"SELECT
                    [ID],
                    [NOME], 
                    [CPF],
                    [CNH],                    
                    [VALIDADECNH],
                    [EMAIL],
                    [TELEFONE],                    
                    [ENDERECO],
                    [CLIENTE_ID] 
	            FROM 
		            [TBCONDUTOR]
                WHERE 
                    [CPF] = @CPF";

        public Condutor SelecionarCondutorPorCliente(Guid id)
        {
            return SelecionarPorParametro(sqlSelecionarPorCliente, new SqlParameter("CLIENTE_ID", id));
        }

        public Condutor SelecionarCondutorPorCpf(string cpf)
        {
            return SelecionarPorParametro(sqlSelecionarCpf, new SqlParameter("CPF", cpf));
        }

    }
}
