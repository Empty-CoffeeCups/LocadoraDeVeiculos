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
            comando.Parameters.AddWithValue("TIPODECLIENTE", registro.TipoDeCliente);
            comando.Parameters.AddWithValue("CNH", registro.Cnh);
            comando.Parameters.AddWithValue("ENDERECO", registro.Endereco);
            comando.Parameters.AddWithValue("EMAIL", registro.Email);
            comando.Parameters.AddWithValue("TELEFONE", registro.Telefone);


            if (registro.TipoDeCliente == TipoCliente.PessoaJuridica)
                comando.Parameters.AddWithValue("DOCUMENTO", registro.Cnpj);
            else
                comando.Parameters.AddWithValue("DOCUMENTO", registro.Cpf);

        }

        public override Cliente ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["CLIENTE_ID"]);
            var nome = Convert.ToString(leitorRegistro["CLIENTE_NOME"]);
            var tipo = Convert.ToInt32(leitorRegistro["CLIENTE_TIPODECLIENTE"]);
            var cnh = Convert.ToString(leitorRegistro["CLIENTE_CNH"]);
            var endereco = Convert.ToString(leitorRegistro["CLIENTE_ENDERECO"]);
            var email = Convert.ToString(leitorRegistro["CLIENTE_EMAIL"]);
            var telefone = Convert.ToString(leitorRegistro["CLIENTE_TELEFONE"]);
            var documento = Convert.ToString(leitorRegistro["CLIENTE_DOCUMENTO"]);


            Cliente cliente = new Cliente()
            {
                Id = id,
                Nome = nome,
                Cnh = cnh,
                Endereco = endereco,
                Email = email,
                Telefone = telefone
            };

            ConfigurarTipoCliente(tipo, documento, cliente);

            return cliente;
        }

        private void ConfigurarTipoCliente(int tipo, string documento, Cliente cliente)
        {
            if (tipo == 0)
            {
                cliente.TipoDeCliente = TipoCliente.PessoaFisica;
                cliente.Cpf = documento;
            }
            else if (tipo == 1)
            {
                cliente.TipoDeCliente = TipoCliente.PessoaJuridica;
                cliente.Cnpj = documento;
            }
        }
    }
}
