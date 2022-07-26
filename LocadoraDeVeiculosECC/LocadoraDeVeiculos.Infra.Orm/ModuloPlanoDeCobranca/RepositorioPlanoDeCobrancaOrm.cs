using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobrancaOrm : IRepositorioPlanoDeCobranca
    {
        private DbSet<PlanoDeCobranca> planosDeCobranca;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioPlanoDeCobrancaOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            planosDeCobranca = dbContext.Set<PlanoDeCobranca>();
            this.dbContext = dbContext;
        }

        public void Inserir(PlanoDeCobranca novoRegistro)
        {
            planosDeCobranca.Add(novoRegistro);
        }

        public void Editar(PlanoDeCobranca registro)
        {
            planosDeCobranca.Update(registro);
        }

        public void Excluir(PlanoDeCobranca registro)
        {
            planosDeCobranca.Remove(registro);
        }

        public PlanoDeCobranca SelecionarPlanoPorGrupo(Guid id)
        {
            return planosDeCobranca.FirstOrDefault(x => x.GrupoDeVeiculo.Id == id);
        }

        public PlanoDeCobranca SelecionarPorId(Guid id)
        {
            return planosDeCobranca.SingleOrDefault(x => x.Id == id);
        }

        public List<PlanoDeCobranca> SelecionarTodos()
        {
            return planosDeCobranca.ToList();
        }

        public PlanoDeCobranca SelecionarPlanoPorTipoPlano(string tipoPlano)
        {
            return planosDeCobranca.FirstOrDefault(x => x.TipoDePlano == tipoPlano);
        }
    }
}
