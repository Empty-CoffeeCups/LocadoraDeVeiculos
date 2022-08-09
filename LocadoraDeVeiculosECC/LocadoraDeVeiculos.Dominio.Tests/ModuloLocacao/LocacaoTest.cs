using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
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
            //arrange
            var locacao = new Locacao(null, RetornaCliente(), RetornaCondutor(), RetornaVeiculo(), RetornaPlanoDeCobranca(), RetornaTaxa(), DateTime.Today.Date,DateTime.Now, 100);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Funcionario' não pode ser nulo.", resultado.Errors[0].ErrorMessage);
            
        }

        [TestMethod]
        public void ClienteValido()
        {
            //arrange
            var locacao = new Locacao(RetornaFuncionario(), null, RetornaCondutor(), RetornaVeiculo(), RetornaPlanoDeCobranca(), RetornaTaxa(), DateTime.Today.Date, DateTime.Now, 100);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Cliente' não pode ser nulo.", resultado.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void CondutorValido()
        {
            //arrange
            var locacao = new Locacao(RetornaFuncionario(), RetornaCliente(),null, RetornaVeiculo(), RetornaPlanoDeCobranca(), RetornaTaxa(), DateTime.Today.Date, DateTime.Now, 100);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Condutor' não pode ser nulo.", resultado.Errors[0].ErrorMessage);
        }

        public void VeiculoValido()
        {
            //arrange
            var locacao = new Locacao(RetornaFuncionario(), RetornaCliente(), RetornaCondutor(), null, RetornaPlanoDeCobranca(), RetornaTaxa(), DateTime.Today.Date, DateTime.Now, 100);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Veiculo' não pode ser nulo.", resultado.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void PlanoValido()
        {
            //arrange
            var locacao = new Locacao(RetornaFuncionario(), RetornaCliente(), RetornaCondutor(), RetornaVeiculo(), null, RetornaTaxa(), DateTime.Today.Date, DateTime.Now, 100);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Plano De Cobranca' não pode ser nulo.", resultado.Errors[0].ErrorMessage);

        }

        [TestMethod]
        public void ValorValido()
        {
            //arrange
            var locacao = new Locacao(RetornaFuncionario(), RetornaCliente(), RetornaCondutor(),RetornaVeiculo(), RetornaPlanoDeCobranca(), RetornaTaxa(), DateTime.Today.Date, DateTime.Now, default);
            var validador = new ValidadorLocacao();

            //action
            var resultado = validador.Validate(locacao);

            //assert
            Assert.AreEqual("'Valor Total Previsto' deve ser informado.", resultado.Errors[0].ErrorMessage);

        }


        //Métodos Privados

        private Cliente RetornaCliente()
        {
            Cliente cliente = new Cliente("Lucas", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages Centro", "lucasomior@gmail.com", "(61) 3784-8355");

            return cliente;
        }

        private Funcionario RetornaFuncionario()
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            Funcionario funcionario = new Funcionario("L", "Lucas", "12345", data, 1500, true);

            return funcionario;
        }
        private GrupoDeVeiculos RetornaGrupoDeVeiculos()
        {
            GrupoDeVeiculos grupoDeVeiculos = new GrupoDeVeiculos("SUV");
            return grupoDeVeiculos;
        }

        private Condutor RetornaCondutor()
        {
            Cliente cliente = new Cliente("Lu", "592.636.550-30", "44.792.231/0001-50", "83534234300", "Lages Centro", "lucasomior@gmail.com", "(61) 3784-8355");
            DateTime data = new DateTime();
            data = DateTime.Now;

            Condutor condutor = new Condutor(cliente, "l", "207.087.820-19", "51166865764", data, "lucasaguiaresteves@gmail.com", "111111111", "Lages Centro");


            return condutor;
        }

        private Veiculo RetornaVeiculo()
        {
            GrupoDeVeiculos grupoDeVeiculos = new GrupoDeVeiculos("SUV");
            byte[] foto = new byte[3];
            Veiculo veiculo = new Veiculo(grupoDeVeiculos, "chevette", "chevrolet", "ABNT433", "Azul", TipoCombustivel.Etanol, 200, DateTime.Now, 150,foto);


            return veiculo;
        }

        private List<Taxas> RetornaTaxa()
        {
            Taxas taxa1 = new Taxas("", 100, TipoCalculo.Fixo);
            Taxas taxa2 = new Taxas("", 100, TipoCalculo.Fixo);

            List<Taxas> taxas = new List<Taxas>();
            taxas.Add(taxa1);
            taxas.Add(taxa2);

            return taxas;
        }

        private PlanoDeCobranca RetornaPlanoDeCobranca()
        {
            GrupoDeVeiculos grupo = new GrupoDeVeiculos("SUV");

            PlanoDeCobranca plano = new PlanoDeCobranca("Plano diário", -3, 100, 100, grupo);

            return plano;
        }

    }


    
}
