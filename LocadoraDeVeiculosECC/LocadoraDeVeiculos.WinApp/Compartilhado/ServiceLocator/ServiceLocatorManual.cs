using locadoraDeVeiculos.Infra.ModuloCliente;
using locadoraDeVeiculos.Infra.ModuloCondutor;
using locadoraDeVeiculos.Infra.ModuloFuncionario;
using locadoraDeVeiculos.Infra.ModuloTaxas;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloTaxas;
using System;
using System.Collections.Generic;
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
            InicializarControladores();
        }

        public T Get<T>() where T : ControladorBase
        {
            var tipo = typeof(T);

            var nomeControlador = tipo.Name;

            return (T)controladores[nomeControlador];
        }

        private void InicializarControladores()
        {
            controladores = new Dictionary<string, ControladorBase>();

            var repositorioCliente = new RepositorioClienteEmBancoDados();
            var servicoCliente = new ServicoCliente(repositorioCliente);
            controladores.Add("ControladorClientes", new ControladorClientes(servicoCliente));

            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            controladores.Add("ControladorFuncionarios", new ControladorFuncionarios(servicoFuncionario));

            var repositorioTaxa = new RepositorioTaxasEmBancoDados();
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            controladores.Add("ControladorTaxa", new ControladorTaxas(servicoTaxa));

            var repositorioGrupoVeiculos = new RepositorioGrupoDeVeiculosEmBancoDados();
            var servicoGrupoVeiculo = new ServicoGrupoDeVeiculos(repositorioGrupoVeiculos);
            controladores.Add("ControladorGrupoVeiculos", new ControladorGrupoDeVeiculos(servicoGrupoVeiculo));

            var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            controladores.Add("ControladorCondutor", new ControladorCondutores(servicoCondutor));
        }
    }
}
