﻿using locadoraDeVeiculos.Infra.Compartilhado;
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
            comando.Parameters.AddWithValue("TIPOCALCULO", registro.TipoCalculo);

        }

        public override Taxas ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["TAXA_ID"].ToString());
            var descricao = Convert.ToString(leitorRegistro["TAXA_DESCRICAO"]);
            var valor = Convert.ToDecimal(leitorRegistro["TAXA_VALOR"]);
            var tipoCalculo = Convert.ToInt32(leitorRegistro["TAXA_TIPOCALCULO"]);



            var taxa = new Taxas();
            taxa.Id = id;
            taxa.Descricao = descricao;
            taxa.Valor = valor;
            taxa.TipoCalculo = (TipoCalculo)tipoCalculo;

            return taxa;
        }
    }
}
