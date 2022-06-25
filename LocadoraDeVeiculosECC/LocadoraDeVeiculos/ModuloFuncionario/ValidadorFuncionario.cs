using FluentValidation;



namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario() {

            RuleFor(x => x.Nome)
                .MinimumLength(3)
                .NotNull().NotEmpty();
            
            RuleFor(x => x.Usuario)
                .MinimumLength(3)
                .NotNull().NotEmpty();

            RuleFor(x => x.Senha)
                .MinimumLength(3)
                .NotNull().NotEmpty();

            RuleFor(x => x.DataDeEntrada)
                .NotNull().NotEmpty();
            
            RuleFor(x => x.Salario)
                .NotNull().NotEmpty();

            RuleFor(x => x.Admin)
                .NotNull().NotEmpty();


        }
    }
}
