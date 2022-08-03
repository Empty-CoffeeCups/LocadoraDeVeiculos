using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome)
                  .MinimumLength(3).WithMessage("O nome deve possuir no mínimo 3 caracteres")
                  .NotNull().NotEmpty();
            RuleFor(x => x.Endereco)
                .MinimumLength(3).WithMessage("O endereço deve possuir no mínimo 3 caracteres")
                .NotNull().NotEmpty();

            RuleFor(x => x.Cnh)
                   .NotNull().NotEmpty().WithMessage("Deve ser inserido um cnh");
            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Deve ser inserido um email válido")
                .NotNull().NotEmpty().WithMessage("Deve ser inserido um email");

            RuleFor(X => X.Telefone)
                .NotEmpty().NotEmpty().WithMessage("Deve ser inserido um telefone")
                .MinimumLength(9).WithMessage("Deve ser inserido um número válido")
                .MaximumLength(9).WithMessage("Deve ser inserido um número válido");

            RuleFor(x => x.Cpf)
                .Matches(@"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)").WithMessage("Deve possuir um cpf válido");

            RuleFor(x => x.ValidadeCnh)
                   .NotNull().NotEmpty().WithMessage("Deve ser inserido uma validade");
        }
    }
}
