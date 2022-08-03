using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCondutor
{
    [TestClass]
    public class CondutorTest
    {
        public CondutorTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]

        public void NomeValido()
        {
            
            Cliente cliente = new Cliente("Lu", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages Centro", "lucasomior@gmail.com", "(61) 3784-8355");
            DateTime data = new DateTime();
            data = DateTime.Now;

            Condutor condutor = new Condutor(cliente, "l", "207.087.820-19", "51166865764",data, "lucasaguiaresteves@gmail.com", "111111111", "Lages Centro");

            ValidadorCondutor validadorFuncionario = new ValidadorCondutor();

            var resultado1 = validadorFuncionario.Validate(condutor);

            Assert.AreEqual("O nome deve possuir no mínimo 3 caracteres", resultado1.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void enderecoValido()
        {

            Cliente cliente = new Cliente("Lucas", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lag", "lucasomior@gmail.com", "(61) 3784-8355");
            DateTime data = new DateTime();
            data = DateTime.Now;

            Condutor condutor = new Condutor(cliente, "Lucas", "207.087.820-19", "51166865764", data, "lucasaguiaresteves@gmail.com", "111111111", "La");

            ValidadorCondutor validadorFuncionario = new ValidadorCondutor();

            var resultado1 = validadorFuncionario.Validate(condutor);

            Assert.AreEqual("O endereço deve possuir no mínimo 3 caracteres", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void cnhValido()
        {

            Cliente cliente = new Cliente("Lucas", "592.636.550-30", "44.792.231/0001-50", "51166865764", "Lag", "lucasomior@gmail.com", "(61) 3784-8355");
            DateTime data = new DateTime();
            data = DateTime.Now;

            Condutor condutor = new Condutor(cliente, "lucas", "207.087.820-19", null, data, "lucasaguiaresteves@gmail.com", "111111111", "Lages Centro");

            ValidadorCondutor validadorFuncionario = new ValidadorCondutor();

            var resultado1 = validadorFuncionario.Validate(condutor);

            Assert.AreEqual("'Cnh' não pode ser nulo.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void emailValido()
        {

            Cliente cliente = new Cliente("Lucas", "592.636.550-30", "44.792.231/0001-50", "51166865764", "Lag", "lucasomior@gmail.com", "(61) 3784-8355");
            DateTime data = new DateTime();
            data = DateTime.Now;

            Condutor condutor = new Condutor(cliente, "lucas", "207.087.820-19", "51166865764", data, "lucasaguiaresteves", "111111111", "Lages Centro");

            ValidadorCondutor validadorFuncionario = new ValidadorCondutor();

            var resultado1 = validadorFuncionario.Validate(condutor);

            Assert.AreEqual("Deve ser inserido um email válido", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void telefoneValido()
        {

            Cliente cliente = new Cliente("Lucas", "592.636.550-30", "44.792.231/0001-50", "51166865764", "Lag", "lucasomior@gmail.com", "(61) 3784-8355");
            DateTime data = new DateTime();
            data = DateTime.Now;

            Condutor condutor = new Condutor(cliente, "luc", "207.087.820-19", "51166865764", data, "lucasaguiaresteves@gmail.com", "111111", "Lages Centro");

            ValidadorCondutor validadorFuncionario = new ValidadorCondutor();

            var resultado1 = validadorFuncionario.Validate(condutor);

            Assert.AreEqual("Deve ser inserido um número válido", resultado1.Errors[0].ErrorMessage);
        }
    }
}
