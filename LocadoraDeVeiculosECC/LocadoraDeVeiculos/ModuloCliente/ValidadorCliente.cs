using FluentValidation;
using FluentValidation.Validators;
namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                   .MinimumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.Cpf)
                .Matches(@"(/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/)");
            RuleFor(x => x.Cnpj)
                .Matches(@"(/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/)");
            RuleFor(x => x.TipoDeCliente)
                   .NotNull().NotEmpty();
            RuleFor(x => x.Cnh)
                   .NotNull().NotEmpty();
            RuleFor(x => x.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .NotNull().NotEmpty();
            RuleFor(x => x.Telefone)
                .NotNull().NotEmpty().Matches(@"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})");
            

        }
    }
}
