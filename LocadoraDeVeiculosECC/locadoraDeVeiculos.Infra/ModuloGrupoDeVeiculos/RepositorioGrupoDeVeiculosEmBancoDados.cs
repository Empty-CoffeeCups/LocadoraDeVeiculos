using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class RepositorioGrupoDeVeiculosEmBancoDados : IRepositorioGrupoDeVeiculos
    {
        private const string enderecoBanco =
               "Data Source=(LocalDB)\\MSSqlLocalDB;" +
               "Initial Catalog=locadoraDeVeiculosDb;" +
               "Integrated Security=True;" +
               "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
            @"INSERT INTO [TBGRUPODEVEICULOS] 
                (
                    [NOMEDOGRUPO]
	            )
	            VALUES
                (
                    @NOMEDOGRUPO
                );SELECT SCOPE_IDENTITY();";

        private const string sqlEditar =
            @"UPDATE [TBGRUPODEVEICULOS]	
		        SET
			        [NOMEDOGRUPO] = @NOMEDOGRUPO
		        WHERE
			        [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBGRUPODEVEICULOS]
		        WHERE
			        [ID] = @ID";

        private const string sqlSelecionarTodos =
            @"SELECT 
		            [ID], 
		            [NOMEDOGRUPO] 
	            FROM 
		            [TBGRUPODEVEICULOS]";

        private const string sqlSelecionarPorNumero =
           @"SELECT 
		            [ID], 
		            [NOMEDOGRUPO] 
	            FROM 
		            [TBGRUPODEVEICULOS]
		        WHERE
                    [ID] = @ID";
        #endregion


        public ValidationResult Inserir(GrupoDeVeiculos novaGrupoDeVeiculos)
        {
            var validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(novaGrupoDeVeiculos);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosGrupoDeVeiculos(novaGrupoDeVeiculos, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novaGrupoDeVeiculos.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Editar(GrupoDeVeiculos grupoDeVeiculos)
        {
            var validador = new ValidadorGrupoDeVeiculos();

            var resultadoValidacao = validador.Validate(grupoDeVeiculos);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosGrupoDeVeiculos(grupoDeVeiculos, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(GrupoDeVeiculos grupoDeVeiculos)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", grupoDeVeiculos.Id);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public List<GrupoDeVeiculos> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorGrupoDeVeiculos = comandoSelecao.ExecuteReader();

            List<GrupoDeVeiculos> grupoDeVeiculos = new List<GrupoDeVeiculos>();

            while (leitorGrupoDeVeiculos.Read())
            {
                GrupoDeVeiculos disciplina = ConverterParaGrupoDeVeiculos(leitorGrupoDeVeiculos);

                grupoDeVeiculos.Add(disciplina);
            }

            conexaoComBanco.Close();

            return grupoDeVeiculos;
        }

        public GrupoDeVeiculos SelecionarPorId(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();
            SqlDataReader leitorGrupoDeVeiculos = comandoSelecao.ExecuteReader();

            GrupoDeVeiculos grupoDeVeiculos = null;
            if (leitorGrupoDeVeiculos.Read())
                grupoDeVeiculos = ConverterParaGrupoDeVeiculos(leitorGrupoDeVeiculos);

            conexaoComBanco.Close();

            return grupoDeVeiculos;
        }

        private static GrupoDeVeiculos ConverterParaGrupoDeVeiculos(SqlDataReader leitorGrupoDeVeiculos)
        {
            int id = Convert.ToInt32(leitorGrupoDeVeiculos["ID"]);
            string nomeDoGrupo = Convert.ToString(leitorGrupoDeVeiculos["NOMEDOGRUPO"]);
            

            var grupoDeVeiculos = new GrupoDeVeiculos
            {
                Id = id,
                NomeDoGrupo = nomeDoGrupo,
            };

            return grupoDeVeiculos;
        }

        private static void ConfigurarParametrosGrupoDeVeiculos(GrupoDeVeiculos novoGrupoDeVeiculos, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novoGrupoDeVeiculos.Id);
            comando.Parameters.AddWithValue("NOMEDOGRUPO", novoGrupoDeVeiculos.NomeDoGrupo);
       
        }

    }
}
