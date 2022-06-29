using FluentValidation.Results;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        //   ValidationResult Inserir(T novoRegistro);

        //   ValidationResult Editar(T registro);

        //   ValidationResult Excluir(T registro);

        void Inserir(T novoRegistro);

        void Editar(T registro);

        void Excluir(T registro);

        List<T> SelecionarTodos();

        T SelecionarPorId(int Id);
    }
}
