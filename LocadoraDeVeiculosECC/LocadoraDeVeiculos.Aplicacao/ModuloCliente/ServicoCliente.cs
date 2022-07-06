using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteEmBancoDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente arg)
        {
            Log.Logger.Information("Tentando inserir cliente...{@cliente}", arg);

            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Inserir(arg);
                Log.Logger.Information("Cliente {@clienteId}", arg.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Cliente{ClienteNome} -> Motivo: {erro}", arg.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente arg)
        {
            Log.Logger.Information("Tentando editar cliente...{@cliente}", arg);

            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Editar(arg);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Cliente{ClienteNome} -> Motivo: {erro}", arg.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult ValidarCliente(Cliente arg)
        {
            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(arg);

            return resultadoValidacao;
        }
    }
}
