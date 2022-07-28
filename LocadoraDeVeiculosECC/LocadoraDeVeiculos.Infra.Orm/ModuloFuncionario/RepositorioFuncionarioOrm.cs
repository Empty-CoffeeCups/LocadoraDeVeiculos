using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : IRepositorioFuncionario
    {
        private DbSet<Funcionario> funcionarios;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioFuncionarioOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            funcionarios = dbContext.Set<Funcionario>();
            this.dbContext = dbContext;
        }

        public void Inserir(Funcionario novoRegistro)
        {
            funcionarios.Add(novoRegistro);
        }

        public void Editar(Funcionario registro)
        {
            funcionarios.Update(registro);
        }

        public void Excluir(Funcionario registro)
        {
            funcionarios.Remove(registro);
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return funcionarios.FirstOrDefault(x => x.Nome == nome);
        }

        public Funcionario SelecionarFuncionarioPorUsuario(string usuario)
        {
            return funcionarios.FirstOrDefault(x => x.Usuario == usuario);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            return funcionarios.SingleOrDefault(x => x.Id == id);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarios.ToList();
        }
    }
}
