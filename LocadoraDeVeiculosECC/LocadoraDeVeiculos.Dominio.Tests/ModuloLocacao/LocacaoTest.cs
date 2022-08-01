using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloLocacao
{
    [TestClass]
    public class LocacaoTest
    {
        Cliente c = new Cliente();
        private Funcionario funcionario = new Funcionario("L", "Lucas", "12345", DateTime.Now, 1500, true);
        private  Cliente cliente = new Cliente("Lucas", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages Centro", "lucasomior@gmail.com", "(61) 3784-8355");
      //  Condutor condutor = new Condutor(cliente, "lucas", "207.087.820-19", "51166865764", DateTime.Now, "lucasaguiaresteves@gmail.com", "111111111", "Lages Centro");



        private PlanoDeCobranca plano;
        private List<Taxas> taxas;
        private DateTime dataLocacao = DateTime.Now;
        private DateTime dataDevolucaoPrevista = DateTime.Now;
        private decimal valorPrevisto = 100;

        public LocacaoTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
           
        }

       [TestMethod]
        public void FuncionarioValido()
        {

            Locacao locacao = new Locacao();
            locacao = ConfiguraLocacao();
            locacao.Funcionario = null;


            ValidadorLocacao validadorLocacao = new ValidadorLocacao();

            var resultado1 = validadorLocacao.Validate(locacao);

            Assert.AreEqual("'Funcionario' não pode ser nulo.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ClienteValido()
        {

            Locacao locacao = new Locacao();
            locacao = ConfiguraLocacao();
            locacao.Cliente = null;


            ValidadorLocacao validadorLocacao = new ValidadorLocacao();

            var resultado1 = validadorLocacao.Validate(locacao);

            Assert.AreEqual("'Cliente' não pode ser nulo.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CondutorValido()
        {

            Locacao locacao = new Locacao();
            locacao = ConfiguraLocacao();
            locacao.Condutor = null;


            ValidadorLocacao validadorLocacao = new ValidadorLocacao();

            var resultado1 = validadorLocacao.Validate(locacao);

            Assert.AreEqual("'Condutor' não pode ser nulo.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void PlanoValido()
        {

            Locacao locacao = new Locacao();
            locacao = ConfiguraLocacao();
            locacao.PlanoDeCobranca = null;


            ValidadorLocacao validadorLocacao = new ValidadorLocacao();

            var resultado1 = validadorLocacao.Validate(locacao);

            Assert.AreEqual("'PlanoDeCobranca' não pode ser nulo.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ValorValido()
        {

            Locacao locacao = new Locacao();
            locacao = ConfiguraLocacao();
            locacao.ValorTotalPrevisto = -2;


            ValidadorLocacao validadorLocacao = new ValidadorLocacao();

            var resultado1 = validadorLocacao.Validate(locacao);

            Assert.AreEqual("O valor deve ser maior ou igual a 0", resultado1.Errors[0].ErrorMessage);
        }

        private Locacao ConfiguraLocacao()
        {
            Locacao locacaoExemplo = new Locacao();
            locacaoExemplo.Funcionario = funcionario;
            locacaoExemplo.Cliente = cliente;
         //  locacaoExemplo.Condutor = condutor;
            locacaoExemplo.PlanoDeCobranca = plano;
            locacaoExemplo.DataLocacao = dataLocacao;
            locacaoExemplo.DataDevolucaoPrevista = dataDevolucaoPrevista;
            locacaoExemplo.Taxas = taxas;
            locacaoExemplo.ValorTotalPrevisto = valorPrevisto;

            return locacaoExemplo;
        }
    
    
    
    
    
    
    }


    
}
