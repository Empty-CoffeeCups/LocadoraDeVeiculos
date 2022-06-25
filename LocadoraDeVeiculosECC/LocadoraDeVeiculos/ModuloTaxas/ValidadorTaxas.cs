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
                .NotNull().NotEmpty();

            RuleFor(x => x.Valor)
                .NotNull().NotEmpty();
        }
    }
}
