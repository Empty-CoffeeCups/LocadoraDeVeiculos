using locadoraDeVeiculos.Infra.ModuloCliente;
using locadoraDeVeiculos.Infra.ModuloCondutor;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
using locadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.PDF.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.PDF.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloDevolucao;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxas;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorManual : IServiceLocator
    {
        private Dictionary<string, ControladorBase> controladores;

        public ServiceLocatorManual()
        {
            controladores = new Dictionary<string, ControladorBase>();

            ConfigurarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }

        private void ConfigurarControladores()
        {
            var configuracao = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("ConfiguracaoAplicacao.json")
                 .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var contextoDadosOrm = new LocadoraDeVeiculosDbContext(connectionString);

            controladores = new Dictionary<string, ControladorBase>();

            var repositorioCliente = new RepositorioClienteOrm(contextoDadosOrm);
            var servicoCliente = new ServicoCliente(repositorioCliente, contextoDadosOrm);
            controladores.Add("ControladorClientes", new ControladorClientes(servicoCliente));

            var repositorioFuncionario = new RepositorioFuncionarioOrm(contextoDadosOrm);
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, contextoDadosOrm);
            controladores.Add("ControladorFuncionarios", new ControladorFuncionarios(servicoFuncionario));

            var repositorioTaxa = new RepositorioTaxasOrm(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add("ControladorTaxas", new ControladorTaxas(servicoTaxa));

          
            var repositorioGrupoVeiculos = new RepositorioGrupoDeVeiculosOrm(contextoDadosOrm);
            var servicoGrupoDeVeiculos = new ServicoGrupoDeVeiculos(repositorioGrupoVeiculos, contextoDadosOrm);
            controladores.Add("ControladorGrupoDeVeiculos", new ControladorGrupoDeVeiculos(servicoGrupoDeVeiculos));

            var repositorioPlanoDeCobranca = new RepositorioPlanoDeCobrancaOrm(contextoDadosOrm);
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca, contextoDadosOrm);
            controladores.Add("ControladorPlanoDeCobranca", new ControladorPlanoDeCobranca(servicoPlanoDeCobranca, servicoGrupoDeVeiculos));

            var repositorioCondutor = new RepositorioCondutorOrm(contextoDadosOrm);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor, contextoDadosOrm);
            controladores.Add("ControladorCondutores", new ControladorCondutores(servicoCondutor, servicoCliente));

            var repositorioVeiculo = new RepositorioVeiculoOrm(contextoDadosOrm);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo, contextoDadosOrm);
            controladores.Add("ControladorVeiculo", new ControladorVeiculo(servicoVeiculo, servicoGrupoDeVeiculos));

            GeradorRelatorioLocacao geradorRelatorioLocacao = new GeradorRelatorioLocacao();
            var repositorioLocacao = new RepositorioLocacaoOrm(contextoDadosOrm);
            var servicoLocacao = new ServicoLocacao(repositorioLocacao, contextoDadosOrm, geradorRelatorioLocacao);
            controladores.Add("ControladorLocacoes", new ControladorLocacoes(servicoLocacao, servicoFuncionario, servicoCliente, servicoCondutor,servicoVeiculo, servicoPlanoDeCobranca, servicoTaxa));

            GeradorRelatorioDevolucao geradorRelatorioDevolucao = new GeradorRelatorioDevolucao();
            var repositorioDevolucao = new RepositorioDevolucaoOrm(contextoDadosOrm);
            var servicoDevolucao = new ServicoDevolucao(repositorioDevolucao , contextoDadosOrm,geradorRelatorioDevolucao);
            controladores.Add("ControladorDevolucoes", new ControladorDevolucoes(servicoDevolucao, servicoLocacao, servicoTaxa, servicoPlanoDeCobranca));
            
            
        }
    }
}
