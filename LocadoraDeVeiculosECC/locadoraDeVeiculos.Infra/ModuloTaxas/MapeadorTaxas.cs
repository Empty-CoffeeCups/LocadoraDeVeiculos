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
    public class MapeadorTaxas : MapeadorBase<Taxas>
    {
        public override void ConfigurarParametros(Taxas registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("DESCRICAO", registro.Descricao);
            comando.Parameters.AddWithValue("VALOR", registro.Valor);
       
        }

        public override Taxas ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["TAXA_ID"]);
            var descricao = Convert.ToString(leitorRegistro["TAXA_DESCRICAO"]);
            var valor = Convert.ToDecimal(leitorRegistro["TAXA_VALOR"]);
            


            var taxa = new Taxas();
            taxa.Id = id;
            taxa.Descricao = descricao;
            taxa.Valor = valor;
           

            return taxa;
        }
    }
}
