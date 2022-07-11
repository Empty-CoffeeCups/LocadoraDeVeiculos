using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {

            RuleFor(x => x.TipoDePlano)
                   .NotNull().NotEmpty();

            RuleFor(x => x.ValorDiario)
                  .NotNull().NotEmpty()
                  .GreaterThanOrEqualTo(0).WithMessage("O valor diário deve ser maior ou igual a 0");

            RuleFor(x => x.ValorKmIncluso)
                  .GreaterThanOrEqualTo(0).WithMessage("O valor de Km Incluso deve ser maior ou igual a 0");

            RuleFor(x => x.PrecoKmRodado)
                  .GreaterThanOrEqualTo(0).WithMessage("O valor diário deve ser maior ou igual a 0");

            RuleFor(x => x.GrupoDeVeiculo)
                  .NotNull().NotEmpty();

        }
    }
}
