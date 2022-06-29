using FluentValidation;
using FluentValidation.Validators;
namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                   .MinimumLength(3).WithMessage("O nome deve possuir no mínimo 3 caracteres")
                   .NotNull().NotEmpty();
            RuleFor(x => x.Endereco)
                .MinimumLength(3).WithMessage("O endereço deve possuir no mínimo 3 caracteres")
                .NotNull().NotEmpty();
            RuleFor(x => x.Cpf)
                .Matches(@"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)").WithMessage("Deve possuir um cpf válido");
            RuleFor(x => x.Cnpj)
                .Matches(@"(^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$)").WithMessage("Deve possuir um cnpj válido");
            RuleFor(x => x.TipoDeCliente)
                   .NotNull().NotEmpty().WithMessage("Deve ser inserido um tipo de cliente");
            RuleFor(x => x.Cnh)
                   .NotNull().NotEmpty().WithMessage("Deve ser inserido um cnh");
            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Deve ser inserido um email válido")
                .NotNull().NotEmpty().WithMessage("Deve ser inserido um email");
            RuleFor(x => x.Telefone)
                .NotNull().NotEmpty()
                .Matches(@"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})").WithMessage("Deve possuir um telefone válido");
            

        }
    }
}
