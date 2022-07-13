using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class RepositorioVeiculoEmBancoDados : RepositorioBase<Veiculo, MapeadorVeiculo>
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
			);SELECT SCOPE_IDENTITY();";
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
                [ID] VEICULO_ID,
	            [GRUPODEVEICULOS] VEICULO_GRUPODEVEICULOS,
                [MODELO] VEICULO_MODELO,
                [MARCA] VEICULO_MARCA,
                [PLACA] VEICULO_PLACA,
                [COR] VEICULO_COR,
                [TIPODECOMBUSTIVEL] VEICULO_TIPODECOMBUSTIVEL,
                [CAPACIDADEDOTANQUE] VEICULO_CAPACIDADEDOTANQUE,
                [ANO] VEICULO_ANO,
                [KMPERCORRIDO] VEICULO_KMPERCORRIDO,
                [FOTO] VEICULO_FOTO
               
            FROM
                [TBVEICULO]
            WHERE
                [ID] = @ID";
        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID] VEICULO_ID,
	            [GRUPODEVEICULOS] VEICULO_GRUPODEVEICULOS,
                [MODELO] VEICULO_MODELO,
                [MARCA] VEICULO_MARCA,
                [PLACA] VEICULO_PLACA,
                [COR] VEICULO_COR,
                [TIPODECOMBUSTIVEL] VEICULO_TIPODECOMBUSTIVEL,
                [CAPACIDADEDOTANQUE] VEICULO_CAPACIDADEDOTANQUE,
                [ANO] VEICULO_ANO,
                [KMPERCORRIDO] VEICULO_KMPERCORRIDO,
                [FOTO] VEICULO_FOTO
               
            FROM
                [TBVEICULO]";
    }
}
