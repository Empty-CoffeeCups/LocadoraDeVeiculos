using locadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest 
    {
        private RepositorioClienteEmBancoDados repositorio;

        public RepositorioClienteEmBancoDadosTest(RepositorioClienteEmBancoDados repositorio)
        {
            this.repositorio = repositorio;
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        private Cliente NovoCliente()
        {
            return new Cliente("Lucas De Aguiar", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages Centro", "lucasomior@gmail.com", "(61) 3784-8355");
        }

        [TestMethod]
        public void Deve_inserir_novo_cliente()
        {
            //arrange
            var cliente = NovoCliente();

            //action
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

        }

        [TestMethod]
        public void Deve_editar_novo_cliente()
        {
            //arrange
            var cliente = NovoCliente();

            //action
            repositorio.Editar(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

        }

        [TestMethod]
        public void Deve_excluir_novo_cliente()
        {
            //arrange
            var cliente = NovoCliente();

            //action
            repositorio.Excluir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorId(cliente.Id);

        }
    }
}
