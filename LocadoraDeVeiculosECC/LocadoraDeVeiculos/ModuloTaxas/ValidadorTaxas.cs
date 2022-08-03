using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxas
{
    public class ValidadorTaxas : AbstractValidator<Taxas>
    {
        public ValidadorTaxas()
        {
            RuleFor(x => x.Descricao)
                .NotNull().NotEmpty().WithMessage("Deve ser inserido uma descrição");

            RuleFor(x => x.Valor)
                .NotNull().NotEmpty().WithMessage("Deve ser inserido um valor");

            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("Valor deve ser maior do que 0");

            RuleFor(x => x.TipoCalculo)
                .NotNull().NotEmpty().WithMessage("Deve ser inserido um tipoCalculo");
        }
    }
}
