using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloCliente
{
    public class RepositorioClienteEmBancoDados: RepositorioBase<Cliente, MapeadorCliente>,
        IRepositorioCliente
    {
        protected override string sqlInserir =>
           @"INSERT INTO [TBCLIENTE]
                 (
                    [ID],
		            [NOME],
                    [DOCUMENTO],
                    [TIPODECLIENTE],
                    [CNH],
                    [ENDERECO],
                    [EMAIL],
                    [TELEFONE]
		         )
            VALUES
                (
                    @ID,
		            @NOME, 
                    @DOCUMENTO,
                    @TIPODECLIENTE,
                    @CNH,
                    @ENDERECO,
                    @EMAIL,
                    @TELEFONE
			);";

        protected override string sqlEditar =>
           @"UPDATE [TBCLIENTE]
                SET
		            [NOME] = @NOME,
                    [DOCUMENTO] = @DOCUMENTO,
                   [TIPODECLIENTE] = @TIPODECLIENTE,
                    [CNH] = @CNH,
                    [ENDERECO] = @ENDERECO,
                    [EMAIL] = @EMAIL,
                    [TELEFONE] = @TELEFONE
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBCLIENTE]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
	            [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [TIPODECLIENTE] CLIENTE_TIPODECLIENTE,
                [CNH] CLIENTE_CNH,
                [ENDERECO] CLIENTE_ENDERECO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE
               
            FROM
                [TBCLIENTE]
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
	            [ID] CLIENTE_ID,
                [NOME] CLIENTE_NOME,
                [DOCUMENTO] CLIENTE_DOCUMENTO,
                [TIPODECLIENTE] CLIENTE_TIPODECLIENTE,
                [CNH] CLIENTE_CNH,
                [ENDERECO] CLIENTE_ENDERECO,
                [EMAIL] CLIENTE_EMAIL,
                [TELEFONE] CLIENTE_TELEFONE
            FROM
                [TBCLIENTE]";
    }
}
