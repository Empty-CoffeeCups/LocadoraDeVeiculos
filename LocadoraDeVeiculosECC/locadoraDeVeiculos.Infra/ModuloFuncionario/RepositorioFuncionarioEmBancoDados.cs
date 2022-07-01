using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioFuncionarioEmBancoDados:
        RepositorioBase<Funcionario, MapeadorFuncionario>,
        IRepositorioFuncionario
    {
        #region sql Queries
        protected override string sqlInserir =>
             @"INSERT INTO [TBFUNCIONARIO]
                   (
                   [NOME],
                   [USUARIO],
                   [SENHA],
                   [DATADEENTRADA],
                   [SALARIO],
                   [ADMIN]
                    )
             VALUES
               (
                   @NOME,
                   @USUARIO,
                   @SENHA,
                   @DATADEDENTRADA,
                   @SALARIO,
                   @ADMIN
                );  SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
             @" UPDATE [TBFUNCIONARIO]
                    SET 
                   [NOME] = @NOME,
                   [USUARIO] = @USUARIO,
                   [SENHA] = @SENHA,
                   [DATADEENTRADA] = @DATADEENTRADA,
                   [SALARIO] = @SALARIO,
                   [ADMIN] = @ADMIN

                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
          @"DELETE FROM [TBFUNCIONARIO]
                WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
          @"SELECT 
                   [ID] FUNCIONARIO_ID,       
                   [NOME] FUNCIONARIO_NOME,
                   [USUARIO] FUNCIONARIO_USUARIO,
                   [SENHA] FUNCIONARIO_SENHA,
                   [DATADEENTRADA] FUNCIONARIO_DATADEENTRADA,
                   [SALARIO] FUNCIONARIO_SALARIO,
                   [ADMIN] FUNCIONARIO_ADMIN
            FROM
                [TBFUNCIONARIO]
            WHERE 
             [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                   [ID] FUNCIONARIO_ID,       
                   [NOME] FUNCIONARIO_NOME,
                   [USUARIO] FUNCIONARIO_USUARIO,
                   [SENHA] FUNCIONARIO_SENHA,
                   [DATADEENTRADA] FUNCIONARIO_DATADEENTRADA,
                   [SALARIO] FUNCIONARIO_SALARIO,
                   [ADMIN] FUNCIONARIO_ADMIN
            FROM
                [TBFUNCIONARIO]";

        private string sqlSelecionarPorNome =>
                @"SELECT 
                   [ID] FUNCIONARIO_ID,       
                   [NOME] FUNCIONARIO_NOME,
                   [USUARIO] FUNCIONARIO_USUARIO,
                   [SENHA] FUNCIONARIO_SENHA,
                   [DATADEENTRADA] FUNCIONARIO_DATADEENTRADA,
                   [SALARIO] FUNCIONARIO_SALARIO,
                   [ADMIN] FUNCIONARIO_ADMIN
            FROM
                [TBFUNCIONARIO]
            WHERE 
                [NOME] = @NOME";

        private string sqlSelecionarPorUsuario =>
            @"SELECT 
                   [ID] FUNCIONARIO_ID,       
                   [NOME] FUNCIONARIO_NOME,
                   [USUARIO] FUNCIONARIO_USUARIO,
                   [SENHA] FUNCIONARIO_SENHA,
                   [DATADEENTRADA] FUNCIONARIO_DATADEENTRADA,
                   [SALARIO] FUNCIONARIO_SALARIO,
                   [ADMIN] FUNCIONARIO_ADMIN
            FROM
                [TBFUNCIONARIO]
            WHERE 
                [USUARIO] = @USUARIO";

        #endregion


        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return SelecionarPorParametro(sqlSelecionarPorNome, new SqlParameter("NOME", nome));
        }

        public Funcionario SelecionarFuncionarioPorUsuario(string usuario)
        {
            return SelecionarPorParametro(sqlSelecionarPorUsuario, new SqlParameter("USUARIO", usuario));
        }
    }
}
