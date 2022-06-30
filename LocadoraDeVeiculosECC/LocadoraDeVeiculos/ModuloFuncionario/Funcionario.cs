using LocadoraDeVeiculos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }
        public string Usuario{ get; set; }
        public string Senha{ get; set; }
        public DateTime DataDeEntrada { get; set; }
        public decimal Salario { get; set; }
        public bool Admin { get; set; }

        public Funcionario() { }
        public Funcionario(string nome, string usuario, string senha, DateTime dataDeEntrada, decimal salario, bool admin)
        {
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            DataDeEntrada = dataDeEntrada;
            Salario = salario;
            Admin = admin;
        }

        public override void Atualizar(Funcionario registro)
        {
            Id = registro.Id;
            Nome = registro.Nome;
            Usuario = registro.Usuario;
            Senha = registro.Senha;
            DataDeEntrada = registro.DataDeEntrada;
            Admin = registro.Admin;
        }
        public override bool Equals(object obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Usuario == funcionario.Usuario &&
                   Senha == funcionario.Senha &&
                   DataDeEntrada == funcionario.DataDeEntrada &&
                   Admin == funcionario.Admin;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id,Nome,Usuario,Senha,DataDeEntrada,Admin);
        }
        public Funcionario Clonar() {
            return MemberwiseClone() as Funcionario;
        }
        public override string ToString()
        {
            return Nome;
        }
    }
}
