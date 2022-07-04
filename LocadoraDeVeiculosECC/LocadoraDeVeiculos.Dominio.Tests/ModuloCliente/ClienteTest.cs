using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloCliente
{
    [TestClass]
    public class ClienteTest
    {
        public ClienteTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]
        public void NomeValido()
        {
           
            Cliente cliente = new Cliente("Lu", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages Centro", "lucasomior@gmail.com", "(61) 3784-8355");

            ValidadorCliente validadorCliente = new ValidadorCliente();

            var resultado1 = validadorCliente.Validate(cliente);

            Assert.AreEqual("O nome deve possuir no mínimo 3 caracteres", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CpfValido()
        {

            Cliente cliente = new Cliente("Lucas de Aguiar", "592.636.50-30", "44.792.231/0001-50", "83534234300", "Lages Centro", "lucasomior@gmail.com", "(61)3784-8355");

            ValidadorCliente validadorCliente = new ValidadorCliente();

            var resultado1 = validadorCliente.Validate(cliente);

            Assert.AreEqual("Deve possuir um cpf válido", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void EndereçoValido()
        {

            Cliente cliente = new Cliente("Lucas de Aguiar", "592.636.550-30", "44.792.231/0001-50", "83534234300", "La", "lucasomior@gmail.com", "(61)3784-8355");

            ValidadorCliente validadorCliente = new ValidadorCliente();

            var resultado1 = validadorCliente.Validate(cliente);

            Assert.AreEqual("O endereço deve possuir no mínimo 3 caracteres", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CnpjValido()
        {

            Cliente cliente = new Cliente("Lucas de Aguiar", "592.636.550-30", "44.792.231/001-50", "83534234300", "Lages", "lucasomior@gmail.com", "(61)3784-8355");

            ValidadorCliente validadorCliente = new ValidadorCliente();

            var resultado1 = validadorCliente.Validate(cliente);

            Assert.AreEqual("Deve possuir um cnpj válido", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void TipoDeClienteValido()
        {

            Cliente cliente = new Cliente("Lucas de Aguiar", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages", "lucasomior@gmail.com", "(61)3784-8355");

            ValidadorCliente validadorCliente = new ValidadorCliente();

            var resultado1 = validadorCliente.Validate(cliente);

            Assert.AreEqual("Deve ser inserido um tipo de cliente", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void CnhValida()
        {
          
            Cliente cliente = new Cliente("Lucas de Aguiar", "592.636.550-30", "44.792.231/0001-50", "",  "Lages", "lucasomior@gmail.com", "(61)3784-8355");

            ValidadorCliente validadorCliente = new ValidadorCliente();

            var resultado1 = validadorCliente.Validate(cliente);

            Assert.AreEqual("Deve ser inserido um cnh", resultado1.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void EmailValido()
        {

            Cliente cliente = new Cliente("Lucas de Aguiar", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages", "lucasomior", "(61)3784-8355");

            ValidadorCliente validadorCliente = new ValidadorCliente();

            var resultado1 = validadorCliente.Validate(cliente);

            Assert.AreEqual("Deve ser inserido um email válido", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void TelefoneValido()
        {

            Cliente cliente = new Cliente("Lucas de Aguiar", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages", "lucasomior@gmail.com", "(61)34-8355");

            ValidadorCliente validadorCliente = new ValidadorCliente();

            var resultado1 = validadorCliente.Validate(cliente);

            Assert.AreEqual("Deve possuir um telefone válido", resultado1.Errors[0].ErrorMessage);
        }
    }
}
