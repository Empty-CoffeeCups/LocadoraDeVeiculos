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
            comando.Parameters.AddWithValue("GRUPODEVEICULOS_ID", registro.GruposDeVeiculos);
            comando.Parameters.AddWithValue("MODELO", registro.Modelo);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("TIPODECOMBUSTIVEL", registro.TipoDeCombustivel);
            comando.Parameters.AddWithValue("CAPACIDADEDOTANQUE", registro.CapacidadeDoTanque);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("KMPERCORRIDO", registro.KmPercorrido);
            byte[] data;
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                registro.Foto.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                data = stream.ToArray();
            }
            comando.Parameters.AddWithValue("FOTO", data);

        }
        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["VEICULO_ID"]);
            int idGrupo = Convert.ToInt32(leitorRegistro["GRUPODEVEICULOS_ID"]);
            var modelo = Convert.ToString(leitorRegistro["VEICULO_MODELO"]);
            var marca = Convert.ToString(leitorRegistro["VEICULO_MARCA"]);
            var placa = Convert.ToString(leitorRegistro["VEICULO_PLACA"]);
            var cor = Convert.ToString(leitorRegistro["VEICULO_COR"]);
            var tipoDeCombustivel = Convert.ToInt32(leitorRegistro["VEICULO_TIPODECOMBUSTIVEL"]);
            var capacidadeDoTanque = Convert.ToInt32(leitorRegistro["VEICULO_CAPACIDADEDOTANQUE"]);
            var ano = Convert.ToDateTime(leitorRegistro["VEICULO_ANO"]);
            var kmPercorrido = Convert.ToInt32(leitorRegistro["VEICULO_KMPERCORRIDO"]);
            byte[] data = (byte[])leitorRegistro["VEICULO_FOTO"];
            var foto = Image.FromStream(new System.IO.MemoryStream(data));

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
                Foto = (Bitmap)foto

            };
               
             
            return veiculo;
        }
    }
}
