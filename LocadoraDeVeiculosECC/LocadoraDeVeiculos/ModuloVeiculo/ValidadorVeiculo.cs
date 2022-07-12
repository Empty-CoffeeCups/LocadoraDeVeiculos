using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .MinimumLength(3)
                .WithMessage("O modelo deve possuir no mínimo 3 caracteres").NotNull().NotEmpty();

            RuleFor(x => x.Marca)
                .MinimumLength(3)
                .WithMessage("A marca deve possuir no mínimo 3 caracteres").NotNull().NotEmpty();

            RuleFor(x => x.Placa)
                .NotNull()
                .WithMessage("O nome deve possuir no mínimo 3 caracteres").NotEmpty();

            RuleFor(x => x.Cor)
                .NotNull().NotEmpty();

            RuleFor(x => x.TipoDeCombustivel)
                .NotNull().NotEmpty();

            RuleFor(x => x.CapacidadeDoTanque)
               .NotNull().NotEmpty();

            RuleFor(x => x.Ano)
               .NotNull().NotEmpty();

            RuleFor(x => x.KmPercorrido)
               .NotNull().NotEmpty();

            RuleFor(x => x.Foto)
               .NotNull().NotEmpty();




        }

    }
}
