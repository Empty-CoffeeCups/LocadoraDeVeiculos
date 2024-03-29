﻿using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : IRepositorioCondutor
    {
        private DbSet<Condutor> condutores;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioCondutorOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            condutores = dbContext.Set<Condutor>();
            this.dbContext = dbContext;
        }

        public void Inserir(Condutor novoRegistro)
        {
            condutores.Add(novoRegistro);
        }

        public void Editar(Condutor registro)
        {
            condutores.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            condutores.Remove(registro);
        }

        public Condutor SelecionarCondutorPorCliente(Guid cliente)
        {
            return condutores.FirstOrDefault(x => x.Cliente.Id == cliente);
        }
        public Condutor SelecionarCondutorPorCpf(string cpf)
        {
            return condutores.FirstOrDefault(x => x.Cpf == cpf);
        }

        public Condutor SelecionarPorId(Guid id)
        {
            return condutores.SingleOrDefault(x => x.Id == id);
        }

        public List<Condutor> SelecionarTodos()
        {
            return condutores
                .Include(x => x.Cliente)
                .ToList();
        }
    }
}
