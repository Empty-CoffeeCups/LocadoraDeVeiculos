using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloTaxas
{
    public class RepositorioTaxasEmBancoDados : IRepositorioTaxas
    {
        private const string enderecoBanco =
               "Data Source=(LocalDB)\\MSSqlLocalDB;" +
               "Initial Catalog=locadoraDeVeiculosDb;" +
               "Integrated Security=True;" +
               "Pooling=False";

        #region Sql Queries
        private const string sqlInserir =
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

        private const string sqlEditar =
            @"UPDATE [TBTAXAS]	
		        SET
			        [DESCRICAO] = @DESCRICAO,
                    [VALOR] = @VALOR
		        WHERE
			        [ID] = @ID";

        private const string sqlExcluir =
            @"DELETE FROM [TBTAXAS]
		        WHERE
			        [ID] = @ID";

        private const string sqlSelecionarTodos =
             @"SELECT 
		            [ID], 
		            [DESCRICAO],
                    [VALOR]
	            FROM 
		            [TBTAXAS]";
        private const string sqlSelecionarPorNumero =
           @"SELECT 
		            [ID], 
		            [DESCRICAO],
                    [VALOR]
	            FROM 
		            [TBTAXAS]
		        WHERE
                    [ID] = @ID";

        #endregion

        public ValidationResult Inserir(Taxas novaTaxa)
        {
            var validador = new ValidadorTaxas();

            var resultadoValidacao = validador.Validate(novaTaxa);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            ConfigurarParametrosTaxas(novaTaxa, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            novaTaxa.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxas taxa)
        {
            var validador = new ValidadorTaxas();

            var resultadoValidacao = validador.Validate(taxa);

            if (resultadoValidacao.IsValid == false)
                return resultadoValidacao;

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            ConfigurarParametrosTaxas(taxa, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public ValidationResult Excluir(Taxas taxa)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("NUMERO", taxa.Id);

            conexaoComBanco.Open();
            int numeroRegistrosExcluidos = comandoExclusao.ExecuteNonQuery();

            var resultadoValidacao = new ValidationResult();

            if (numeroRegistrosExcluidos == 0)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            conexaoComBanco.Close();

            return resultadoValidacao;
        }

        public List<Taxas> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorTaxa = comandoSelecao.ExecuteReader();

            List<Taxas> contatos = new List<Taxas>();

            while (leitorTaxa.Read())
            {
                Taxas taxa = ConverterParaTaxas(leitorTaxa);

                contatos.Add(taxa);
            }

            conexaoComBanco.Close();

            return contatos;
        }

        public Taxas SelecionarPorId(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorNumero, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();
            SqlDataReader leitorTaxa = comandoSelecao.ExecuteReader();

            Taxas taxa = null;
            if (leitorTaxa.Read())
                taxa = ConverterParaTaxas(leitorTaxa);

            conexaoComBanco.Close();

            return taxa;
        }

        private static Taxas ConverterParaTaxas(SqlDataReader leitorTaxa)
        {
            int id = Convert.ToInt32(leitorTaxa["ID"]);
            string descricao = Convert.ToString(leitorTaxa["DESCRICAO"]);
            decimal valor = Convert.ToDecimal(leitorTaxa["VALOR"]);

            var taxa = new Taxas
            {
                Id = id,
                Descricao = descricao,
                Valor = valor,

            };

            return taxa;
        }

        private static void ConfigurarParametrosTaxas(Taxas novaTaxa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", novaTaxa.Id);
            comando.Parameters.AddWithValue("DESCRICAO", novaTaxa.Descricao);
            comando.Parameters.AddWithValue("VALOR", novaTaxa.Valor);

        }

       
    }
}
