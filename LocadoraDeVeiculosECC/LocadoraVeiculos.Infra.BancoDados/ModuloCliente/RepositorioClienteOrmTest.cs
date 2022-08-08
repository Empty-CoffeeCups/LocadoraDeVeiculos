using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.BancoDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteOrmTest
    {
        private ServicoCliente servicoCliente;

        private LocadoraDeVeiculosDbContext dbContext;

        private IRepositorioCliente irepositorioCliente;

        private IContextoPersistencia contextoPersistencia;

        public RepositorioClienteOrmTest()
        {
            dbContext = new LocadoraDeVeiculosDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DbLocadoraDeVeiculosOrm;Integrated Security=True;Pooling=False");
            servicoCliente = new ServicoCliente(irepositorioCliente, contextoPersistencia);
        }


        [TestMethod]
        public void Deve_inserir_novo_cliente()
        {
            Cliente cliente = new Cliente("Marlon", "582.636.550-30", "43.792.231/0001-50", "825342343", "Florianopolis", "marlon@gmail.com", "(61) 3984-8355");

            servicoCliente.Inserir(cliente);

            Cliente clienteEncontrado = servicoCliente.SelecionarPorId(cliente.Id).Value;

            Assert.AreEqual(cliente, clienteEncontrado);



        }
    }
}
