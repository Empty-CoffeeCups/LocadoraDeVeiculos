using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {
        public ValidadorDevolucao()
        {
            RuleFor(x => x.Locacao)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.KmVeiculo)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.DataDeDevolucao)
                .NotNull()
                .NotEmpty();


            RuleFor(x => x.NivelDoTanque)
                .NotNull()
                .NotEmpty()
                .GreaterThan(-1);

            RuleFor(x => x.ValorTotal)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

        }
    }
}
