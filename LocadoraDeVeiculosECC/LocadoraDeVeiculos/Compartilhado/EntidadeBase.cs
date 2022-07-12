using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id{ get; set; }

        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Atualizar(T registro);
    }
}
