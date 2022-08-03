using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloDevolucao
{
    [TestClass]
    public class DevolucaoTest
    {
        public DevolucaoTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]

        public void LocacaoValida()
        {
            Locacao locacao = new Locacao();

            List<Taxas> taxas = new List<Taxas>();
        

            Devolucao  devolucao = new Devolucao(null, 150,150,DateTime.Now,taxas,1500);

            ValidadorDevolucao validadorDevolucao = new ValidadorDevolucao();

            var resultado1 = validadorDevolucao.Validate(devolucao);

            Assert.AreEqual("'Locacao' não pode ser nulo.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void KmVeiculoValido()
        {
            Locacao locacao = new Locacao();

            List<Taxas> taxas = new List<Taxas>();


            Devolucao devolucao = new Devolucao(locacao, default, 150, DateTime.Now, taxas, 1500);

            ValidadorDevolucao validadorDevolucao = new ValidadorDevolucao();

            var resultado1 = validadorDevolucao.Validate(devolucao);

            Assert.AreEqual("'Km Veiculo' deve ser informado.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void NivelDoTanqueValido()
        {
            Locacao locacao = new Locacao();

            List<Taxas> taxas = new List<Taxas>();


            Devolucao devolucao = new Devolucao(locacao, 150, default, DateTime.Now, taxas, 1500);

            ValidadorDevolucao validadorDevolucao = new ValidadorDevolucao();

            var resultado1 = validadorDevolucao.Validate(devolucao);

            Assert.AreEqual("'Nivel Do Tanque' deve ser informado.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void DataDevolucaoValida()
        {
            Locacao locacao = new Locacao();

            List<Taxas> taxas = new List<Taxas>();


            Devolucao devolucao = new Devolucao(locacao, 150,150, default, taxas, 1500);

            ValidadorDevolucao validadorDevolucao = new ValidadorDevolucao();

            var resultado1 = validadorDevolucao.Validate(devolucao);

            Assert.AreEqual("'Data De Devolucao' deve ser informado.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]

        public void ValorTotalValido()
        {
            Locacao locacao = new Locacao();

            List<Taxas> taxas = new List<Taxas>();


            Devolucao devolucao = new Devolucao(locacao, 150, 150, DateTime.Now, taxas, default);

            ValidadorDevolucao validadorDevolucao = new ValidadorDevolucao();

            var resultado1 = validadorDevolucao.Validate(devolucao);

            Assert.AreEqual("'Valor Total' deve ser informado.", resultado1.Errors[0].ErrorMessage);
        }
    }
}
