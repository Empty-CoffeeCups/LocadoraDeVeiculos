using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : IRepositorioLocacao
    {
        private DbSet<Locacao> locacoes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioLocacaoOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            locacoes = dbContext.Set<Locacao>();
            this.dbContext = dbContext;
        }

        public void Inserir(Locacao novoRegistro)
        {
            locacoes.Add(novoRegistro);
        }

        public void Editar(Locacao registro)
        {
            locacoes.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            locacoes.Remove(registro);
        }

        public Locacao SelecionarCondutorPorCliente(Guid cliente)
        {
            return locacoes.FirstOrDefault(x => x.Cliente.Id == cliente);
        }
        public Locacao SelecionarCondutorPorFuncionario(Guid funcionario)
        {
            return locacoes.FirstOrDefault(x => x.Funcionario.Id == funcionario);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            return locacoes.SingleOrDefault(x => x.Id == id);
        }

        public List<Locacao> SelecionarTodos()
        {
            return locacoes
                .Include(x => x.Cliente)
                .Include(x => x.Funcionario)
                .Include(x => x.Taxas)
                .Include(x => x.PlanoDeCobranca)
                .Include(x => x.Condutor)
                // .Include(x => x.Veiculo) esperando dar merge do modulo de veiculo
                .ToList();
        }

    }
}
