using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloGrupoDeVeiculos
{
    [TestClass]
    public class GrupoDeVeiculosTest
    {
        public GrupoDeVeiculosTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }


        [TestMethod]
        public void NomeValido()
        {
            GrupoDeVeiculos grupoDeVeiculos = new GrupoDeVeiculos("");

            ValidadorGrupoDeVeiculos validadorPaciente = new ValidadorGrupoDeVeiculos();

            var resultado1 = validadorPaciente.Validate(grupoDeVeiculos);

            Assert.AreEqual("Deve ser inserido um nome", resultado1.Errors[0].ErrorMessage);
        }

    }
}
