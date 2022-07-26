using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDados : RepositorioBase<Veiculo, MapeadorVeiculo>, IRepositorioVeiculo
    {
        protected override string sqlInserir =>
           @"INSERT INTO [TBVEICULO]
                 (
		            [GRUPODEVEICULOS],
                    [MODELO],
                    [MARCA],
                    [PLACA],
                    [COR],
                    [TIPODECOMBUSTIVEL],
                    [CAPACIDADEDOTANQUE],
                    [ANO],
                    [KMPERCORRIDO],
                    [FOTO]
		         )
            VALUES
                (
		            @GRUPODEVEICULOS,
                    @MODELO,
                    @MARCA,
                    @PLACA,
                    @COR,
                    @TIPODECOMBUSTIVEL,
                    @CAPACIDADEDOTANQUE,
                    @ANO,
                    @KMPERCORRIDO,
                    @FOTO
			);";
        protected override string sqlEditar =>
          @"UPDATE [TBVEICULO]
                SET
		            [GRUPODEVEICULOS] = @GRUPODEVEICULOS,
                    [MODELO] = @MODELO,
                    [MARCA] = @MARCA,
                    [PLACA] = @PLACA,
                    [COR] = @COR,
                    [TIPODECOMBUSTIVEL] = @TIPODECOMBUSTIVEL,
                    [CAPACIDADEDOTANQUE] = @CAPACIDADEDOTANQUE,
                    [ANO] = @ANO,
                    [KMPERCORRIDO] = @KMPERCORRIDO,
                    [FOTO] = @FOTO
                WHERE
                    [ID] = @ID";
        protected override string sqlExcluir =>
        @"DELETE FROM [TBVEICULO]
                WHERE [ID] = @ID";
        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],
	            [GRUPODEVEICULOS],
                [MODELO],
                [MARCA],
                [PLACA],
                [COR],
                [TIPODECOMBUSTIVEL],
                [CAPACIDADEDOTANQUE],
                [ANO],
                [KMPERCORRIDO],
                [FOTO]
               
            FROM
                [TBVEICULO]
            WHERE
                [ID] = @ID";
        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],
	            [GRUPODEVEICULOS],
                [MODELO],
                [MARCA],
                [PLACA],
                [COR],
                [TIPOCOMBUSTIVEL],
                [CAPACIDADEDOTANQUE],
                [ANO],
                [KMPERCORRIDO],
                [FOTO]           
            FROM
                [TBVEICULO]";

        protected string sqlSelecionarPlaca =>
            @"SELECT 
                [ID],
	            [GRUPODEVEICULOS],
                [MODELO],
                [MARCA],
                [PLACA],
                [COR],
                [TIPOCOMBUSTIVEL],
                [CAPACIDADEDOTANQUE],
                [ANO],
                [KMPERCORRIDO],
                [FOTO]           
            FROM
                [TBVEICULO]

            WHERE
                [PLACA] = @PLACA";

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPlaca, new SqlParameter("PLACA", placa));
        }
    }
}
