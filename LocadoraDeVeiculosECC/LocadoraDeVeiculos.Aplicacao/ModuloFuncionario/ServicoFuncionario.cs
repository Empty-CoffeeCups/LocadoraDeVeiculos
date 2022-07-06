using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public ValidationResult Inserir(Funcionario funcionario)
        {

            Log.Logger.Information("Tentando inserir funcionario...{@funcionario}", funcionario);

            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Inserir(funcionario);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Funcionario{FuncionarioNome} -> Motivo: {erro}", funcionario.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario funcionario)
        {
            Log.Logger.Information("Tentando editar funcionario...{@funcionario}", funcionario);

            ValidationResult resultadoValidacao = Validar(funcionario);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Editar(funcionario);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Funcionario{FuncionarioNome} -> Motivo: {erro}", funcionario.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Funcionario funcionario)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(funcionario);

            if (NomeDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (UsuarioDuplicado(funcionario))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorNome(funcionario.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == funcionario.Nome &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }

        private bool UsuarioDuplicado(Funcionario funcionario)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorUsuario(funcionario.Usuario);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Usuario == funcionario.Usuario &&
                   funcionarioEncontrado.Id != funcionario.Id;
        }
    }
}
