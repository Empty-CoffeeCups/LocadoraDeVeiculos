using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloPlanoDeCobranca
{
    [TestClass]
    public class PlanoDeCobrancaTest
    {
        public PlanoDeCobrancaTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]
        public void TipoDePlanoValido()
        {
            PlanoDeCobranca plano = new PlanoDeCobranca();

            ValidadorPlanoDeCobranca validadorPaciente = new ValidadorPlanoDeCobranca();

            var resultado1 = validadorPaciente.Validate(plano);

            Assert.AreEqual("'Tipo De Plano' não pode ser nulo.", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ValorDiarioValido()
        {
            GrupoDeVeiculos grupo = new GrupoDeVeiculos("SUV");

            PlanoDeCobranca plano = new PlanoDeCobranca("Plano diário", -3, 100, 100 , grupo);

            ValidadorPlanoDeCobranca validadorPaciente = new ValidadorPlanoDeCobranca();

            var resultado1 = validadorPaciente.Validate(plano);

            Assert.AreEqual("O valor diário deve ser maior ou igual a 0", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ValorKmInclusoValido()
        {
            GrupoDeVeiculos grupo = new GrupoDeVeiculos("SUV");

            PlanoDeCobranca plano = new PlanoDeCobranca("Plano diário", 100, -3, 100, grupo);

            ValidadorPlanoDeCobranca validadorPaciente = new ValidadorPlanoDeCobranca();

            var resultado1 = validadorPaciente.Validate(plano);

            Assert.AreEqual("O valor de Km Incluso deve ser maior ou igual a 0", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void PrecoKmRodadoValido()
        {
            GrupoDeVeiculos grupo = new GrupoDeVeiculos("SUV");

            PlanoDeCobranca plano = new PlanoDeCobranca("Plano diário", 100, 100, -3, grupo);

            ValidadorPlanoDeCobranca validadorPaciente = new ValidadorPlanoDeCobranca();

            var resultado1 = validadorPaciente.Validate(plano);

            Assert.AreEqual("O preço Km rodado deve ser maior ou igual a 0", resultado1.Errors[0].ErrorMessage);
        }

       
    }
}
