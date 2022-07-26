using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxas
{
    public class RepositorioTaxasOrm : IRepositorioTaxas
    {
        private DbSet<Taxas> taxas;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioTaxasOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            taxas = dbContext.Set<Taxas>(); ;
            this.dbContext = dbContext;
        }

        public void Inserir(Taxas novoRegistro)
        {
            taxas.Add(novoRegistro);
        }

        public void Editar(Taxas registro)
        {
            taxas.Update(registro);
        }

        public void Excluir(Taxas registro)
        {
            taxas.Remove(registro);
        }

        public Taxas SelecionarPorId(Guid id)
        {
            return taxas.SingleOrDefault(x => x.Id == id);
        }

        public Taxas SelecionarTaxaPorDescricao(string descricao)
        {
            return taxas.FirstOrDefault(x => x.Descricao == descricao);
        }

        public List<Taxas> SelecionarTodos()
        {
            return taxas.ToList();
        }

    }
}
