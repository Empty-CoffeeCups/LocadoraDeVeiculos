using System;
using Taikandi;

namespace LocadoraDeVeiculos.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public Guid Id{ get; set; }

        protected EntidadeBase()
        {
            Id = SequentialGuid.NewGuid();
        }

        public abstract void Atualizar(T registro);
    }
}
