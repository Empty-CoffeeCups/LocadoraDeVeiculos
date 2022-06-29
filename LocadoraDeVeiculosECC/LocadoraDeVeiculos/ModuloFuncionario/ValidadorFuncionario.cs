using FluentValidation;



namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario() {

            RuleFor(x => x.Nome)
                .MinimumLength(3).WithMessage("O nome deve possuir no mínimo 3 caracteres")
                .NotNull().NotEmpty();
            
            RuleFor(x => x.Usuario)
                .MinimumLength(3).WithMessage("O usuário deve possuir no mínimo 3 caracteres")
                .NotNull().NotEmpty();

            RuleFor(x => x.Senha)
                .MinimumLength(3).WithMessage("A senha deve possuir no mínimo 3 caracteres")
                .NotNull().NotEmpty();

            RuleFor(x => x.DataDeEntrada)
                .NotNull().NotEmpty().WithMessage("Deve ser inserido uma data");
            
            RuleFor(x => x.Salario)
                .NotNull().NotEmpty().WithMessage("Deve ser inserido um salário");

        

            RuleFor(x => x.Admin)
                .NotNull().NotEmpty().WithMessage("Deve ser inserido um valor");



        }
    }
}
