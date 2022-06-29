using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override void ConfigurarParametros(Cliente registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("CPF", registro.Cpf);
            comando.Parameters.AddWithValue("CNPJ", registro.Cnpj);
            comando.Parameters.AddWithValue("TIPODECLIENTE", registro.TipoDeCliente);
            comando.Parameters.AddWithValue("CNH", registro.Cnh);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);
 
        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["CLIENTE_ID"]);
            var nome = Convert.ToString(leitorRegistro["CLIENTE_NOME"]);
            var cpf = Convert.ToString(leitorRegistro["CLIENTE_CPF"]);
            var cnpj = Convert.ToString(leitorRegistro["CLIENTE_CNPJ"]);
            var tipo_de_cliente = Convert.ToString(leitorRegistro["CLIENTE_TIPODECLIENTE"]);
            var cnh = Convert.ToBoolean(leitorRegistro["CLIENTE_CNH"]);
            var endereco = Convert.ToString(leitorRegistro["CLIENTE_ENDERECO"]);
            var email = Convert.ToString(leitorRegistro["CLIENTE_EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["CLIENTE_TELEFONE"]);
            

            Cliente cliente = new Cliente()
            {
                Id = id,
                Nome = nome,
                Cpf = cpf,
                Cnpj = cnpj,
                TipoDeCliente = tipo_de_cliente,
                Cnh = cnh,
                Endereco = endereco,
                Email = email,
                Telefone = telefone
            };

            return cliente;
        }
    }
}
