using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo
{
    public class ServicoVeiculo
    {
        private RepositorioVeiculoEmBancoDados repositorioVeiculo;

        public ServicoCliente(RepositorioVeiculoEmBancoDados repositorioVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
        }

        public ValidationResult Inserir(Veiculo arg)
        {
            Log.Logger.Information("Tentando inserir cliente...{@cliente}", arg);

            var resultadoValidacao = ValidarVeiculo(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioVeiculo.Inserir(arg);
                Log.Logger.Information("Cliente {@clienteId}", arg.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Cliente{ClienteNome} -> Motivo: {erro}", arg.Modelo, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }
    }
}
