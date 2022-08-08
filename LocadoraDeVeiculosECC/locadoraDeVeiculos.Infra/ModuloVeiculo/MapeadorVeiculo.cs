using locadoraDeVeiculos.Infra.Compartilhado;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        RepositorioGrupoDeVeiculosEmBancoDados repositorioGrupoDeVeiculos = new RepositorioGrupoDeVeiculosEmBancoDados();
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("GRUPODEVEICULOS", registro.GruposDeVeiculos.Id);
            comando.Parameters.AddWithValue("MODELO", registro.Modelo);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("TIPODECOMBUSTIVEL", registro.TipoDeCombustivel);
            comando.Parameters.AddWithValue("CAPACIDADEDOTANQUE", registro.CapacidadeDoTanque);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("KMPERCORRIDO", registro.KmPercorrido);
            byte[] data;
            comando.Parameters.AddWithValue("FOTO", registro.Foto);

        }
        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var idGrupo = Guid.Parse(leitorRegistro["GRUPODEVEICULOS"].ToString());
            var modelo = Convert.ToString(leitorRegistro["MODELO"]);
            var marca = Convert.ToString(leitorRegistro["MARCA"]);
            var placa = Convert.ToString(leitorRegistro["PLACA"]);
            var cor = Convert.ToString(leitorRegistro["COR"]);
            var tipoDeCombustivel = Convert.ToInt32(leitorRegistro["TIPODECOMBUSTIVEL"]);
            var capacidadeDoTanque = Convert.ToInt32(leitorRegistro["CAPACIDADEDOTANQUE"]);
            var ano = Convert.ToDateTime(leitorRegistro["ANO"]);
            var kmPercorrido = Convert.ToInt32(leitorRegistro["KMPERCORRIDO"]);
            byte[] data = (byte[])leitorRegistro["FOTO"];
            var foto = data;

            var veiculo = new Veiculo()
            {
                Id = id,
                GruposDeVeiculos = repositorioGrupoDeVeiculos.SelecionarPorId(idGrupo),
                Modelo = modelo,
                Marca = marca,
                Placa = placa,
                Cor = cor,
                TipoDeCombustivel = (TipoCombustivel)tipoDeCombustivel,
                CapacidadeDoTanque = capacidadeDoTanque,
                Ano = ano,
                KmPercorrido = kmPercorrido,
                Foto = foto
            };
               
             
            return veiculo;
        }
    }
}
