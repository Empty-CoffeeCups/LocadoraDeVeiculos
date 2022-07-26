using locadoraDeVeiculos.Infra.ModuloCliente;
using locadoraDeVeiculos.Infra.ModuloCondutor;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
using locadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Infra.Orm;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxas;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloTaxas;
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

            var repositorioCliente = new RepositorioClienteEmBancoDados();
            var servicoCliente = new ServicoCliente(repositorioCliente);
            controladores.Add("ControladorClientes", new ControladorClientes(servicoCliente));

            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            controladores.Add("ControladorFuncionarios", new ControladorFuncionarios(servicoFuncionario));

            var repositorioTaxa = new RepositorioTaxasOrm(contextoDadosOrm);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa, contextoDadosOrm);
            controladores.Add("ControladorTaxas", new ControladorTaxas(servicoTaxa));

          
            var repositorioGrupoVeiculos = new RepositorioGrupoDeVeiculosOrm(contextoDadosOrm);
            var servicoGrupoDeVeiculos = new ServicoGrupoDeVeiculos(repositorioGrupoVeiculos, contextoDadosOrm);
            controladores.Add("ControladorGrupoDeVeiculos", new ControladorGrupoDeVeiculos(servicoGrupoDeVeiculos));

            var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            controladores.Add("ControladorCondutor", new ControladorCondutores(servicoCondutor));
        }
    }
}
