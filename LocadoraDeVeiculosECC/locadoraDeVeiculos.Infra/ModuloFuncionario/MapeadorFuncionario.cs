using locadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraDeVeiculos.Infra.ModuloFuncionario
{
    public class MapeadorFuncionario : MapeadorBase<Funcionario>
    {
        public override void ConfigurarParametros(Funcionario registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("USUARIO", registro.Usuario);
            comando.Parameters.AddWithValue("SENHA", registro.Senha);
            comando.Parameters.AddWithValue("DATADEENTRADA", registro.DataDeEntrada);
            comando.Parameters.AddWithValue("SALARIO", registro.Salario);
            comando.Parameters.AddWithValue("ADMIN", registro.Admin);
          

        }

        public override Funcionario ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["FUNCIONARIO_ID"]);
            var nome = Convert.ToString(leitorRegistro["FUNCIONARIO_NOME"]);
            var login = Convert.ToString(leitorRegistro["FUNCIONARIO_USUARIO"]);
            var senha = Convert.ToString(leitorRegistro["FUNCIONARIO_SENHA"]);
            var dataAdmissao = Convert.ToDateTime(leitorRegistro["FUNCIONARIO_DATA_ENTRADA"]);
            var salario = Convert.ToDecimal(leitorRegistro["FUNCIONARIO_SALARIO"]);
            var ehAdmin = Convert.ToBoolean(leitorRegistro["FUNCIONARIO_IS_ADMIN"]);
          

            var f = new Funcionario();
            f.Id = id;
            f.Nome = nome;
            f.Usuario = login;
            f.Senha = senha;
            f.DataDeEntrada = dataAdmissao;
            f.Salario = salario;
            f.Admin = ehAdmin;
           

            return f;
        }
    }
}
