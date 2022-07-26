using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos
{
    public class RepositorioGrupoDeVeiculosOrm : IRepositorioGrupoDeVeiculos
    {
        private DbSet<GrupoDeVeiculos> gruposDeVeiculos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioGrupoDeVeiculosOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            gruposDeVeiculos = dbContext.Set<GrupoDeVeiculos>();
            this.dbContext = dbContext;
        }

        public void Inserir(GrupoDeVeiculos novoRegistro)
        {
            gruposDeVeiculos.Add(novoRegistro);
        }

        public void Editar(GrupoDeVeiculos registro)
        {
            gruposDeVeiculos.Update(registro);
        }

        public void Excluir(GrupoDeVeiculos registro)
        {
            gruposDeVeiculos.Remove(registro);
        }

        public GrupoDeVeiculos SelecionarGrupoDeVeiculosPorNome(string nome)
        {
            return gruposDeVeiculos.FirstOrDefault(x => x.NomeDoGrupo == nome);
        }

        public GrupoDeVeiculos SelecionarPorId(Guid id)
        {
            return gruposDeVeiculos.SingleOrDefault(x => x.Id == id);
        }

        public List<GrupoDeVeiculos> SelecionarTodos()
        {
            return gruposDeVeiculos.ToList();
        }
    }
}
