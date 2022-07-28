using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {
            RuleFor(x => x.Funcionario)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cliente)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Condutor)
                .NotNull()
                .NotEmpty();

            // RuleFor(x => x.Veiculo) // Ainda dar merge em veiculo
            //    .NotNull()
            //    .NotEmpty();

            RuleFor(x => x.Taxas)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.PlanoDeCobranca)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataLocacao)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataDevolucaoPrevista)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ValorTotalPrevisto)
                .NotNull()
                .NotEmpty();
        }
    }
}
