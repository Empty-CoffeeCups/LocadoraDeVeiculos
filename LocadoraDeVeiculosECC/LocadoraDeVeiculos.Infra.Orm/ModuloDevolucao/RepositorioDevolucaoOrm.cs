using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao
{
    public class RepositorioDevolucaoOrm : IRepositorioDevolucao
    {
        private DbSet<Devolucao> devolucoes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioDevolucaoOrm(DbSet<Devolucao> devolucoes, LocadoraDeVeiculosDbContext dbContext)
        {
            devolucoes = dbContext.Set<Devolucao>();
            this.dbContext = dbContext;
        }

        public void Inserir(Devolucao novoRegistro)
        {
            devolucoes.Add(novoRegistro);
        }

        public void Editar(Devolucao registro)
        {
            devolucoes.Update(registro);
        }

        public void Excluir(Devolucao registro)
        {
            devolucoes.Remove(registro);
        }

        public Devolucao SelecionarPorId(Guid id)
        {
            return devolucoes.SingleOrDefault(x => x.Id == id);
        }

        public List<Devolucao> SelecionarTodos()
        {
            return devolucoes.ToList();
        }
    }
}
