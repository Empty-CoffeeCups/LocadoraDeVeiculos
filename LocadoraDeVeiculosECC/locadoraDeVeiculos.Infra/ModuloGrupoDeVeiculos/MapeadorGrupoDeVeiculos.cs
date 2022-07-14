using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloGrupoDeVeiculos
{
    public class MapeadorGrupoDeVeiculos : MapeadorBase<GrupoDeVeiculos>
    {
        public override void ConfigurarParametros(GrupoDeVeiculos registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOMEDOGRUPO", registro.NomeDoGrupo);
        }

        public override GrupoDeVeiculos ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["GRUPODEVEICULO_ID"].ToString());
            var nome = Convert.ToString(leitorRegistro["GRUPODEVEICULO_NOMEDOGRUPO"]);

            var grupo = new GrupoDeVeiculos();
            grupo.Id = id;
            grupo.NomeDoGrupo= nome;

            return grupo;
        }
    }
}
