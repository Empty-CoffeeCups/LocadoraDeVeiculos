using locadoraDeVeiculos.Infra.Compartilhado;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
using locadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobranca : MapeadorBase<PlanoDeCobranca>
    {
        RepositorioGrupoDeVeiculosEmBancoDados repositorioGrupoDeVeiculos = new RepositorioGrupoDeVeiculosEmBancoDados();
        
        public override void ConfigurarParametros(PlanoDeCobranca registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("TIPODEPLANO", registro.TipoDePlano);
            comando.Parameters.AddWithValue("VALORDIARIO", registro.ValorDiario);
            comando.Parameters.AddWithValue("VALORKMINCLUSO", registro.ValorKmIncluso);
            comando.Parameters.AddWithValue("PRECOKMRODADO", registro.PrecoKmRodado);
            comando.Parameters.AddWithValue("GRUPODEVEICULOS_ID", registro.GrupoDeVeiculo.Id);
        }

        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorRegistro)
        {
            
            int id = Convert.ToInt32(leitorRegistro["ID"]);
            string tipoDePlano = Convert.ToString(leitorRegistro["TIPODEPLANO"]);
            Decimal valorDiaria = Convert.ToDecimal(leitorRegistro["VALORDIARIO"]);
            Decimal kmIncluso = Convert.ToDecimal(leitorRegistro["VALORKMINCLUSO"]);
            Decimal precoKm = Convert.ToDecimal(leitorRegistro["PRECOKMRODADO"]);
            int idGrupo = Convert.ToInt32(leitorRegistro["GRUPODEVEICULOS_ID"]);

            var plano = new PlanoDeCobranca
            {
                Id = id,
                TipoDePlano = tipoDePlano,
                ValorDiario = valorDiaria,
                ValorKmIncluso = kmIncluso,
                PrecoKmRodado = precoKm,
                GrupoDeVeiculo = repositorioGrupoDeVeiculos.SelecionarPorId(idGrupo)
            };

            return plano;

        }
        }
}
