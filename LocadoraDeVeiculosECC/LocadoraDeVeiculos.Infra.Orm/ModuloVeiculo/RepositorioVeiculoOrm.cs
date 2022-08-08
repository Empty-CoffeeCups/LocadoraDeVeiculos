using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : IRepositorioVeiculo
    {
        private DbSet<Veiculo> veiculos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioVeiculoOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            veiculos = dbContext.Set<Veiculo>();
            this.dbContext = dbContext;
        }
        public void Inserir(Veiculo novoRegistro)
        {
            veiculos.Add(novoRegistro);
        }

        public void Editar(Veiculo registro)
        {
            veiculos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            veiculos.Remove(registro);
        }
        public Veiculo SelecionarPorId(Guid id)
        {
            return veiculos.SingleOrDefault(x => x.Id == id);
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return veiculos.FirstOrDefault(x => x.Placa == placa);
        }

        public List<Veiculo> SelecionarTodos()
        {
            return veiculos
                .Include(x => x.GruposDeVeiculos)
                .ToList();
        }
    }
}
