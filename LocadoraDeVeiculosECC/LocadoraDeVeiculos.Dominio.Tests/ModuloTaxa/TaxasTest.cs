﻿using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloTaxa
{
    [TestClass]
    public class TaxasTest
    {
        public TaxasTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]
        public void DescricaoValida()
        {
            Taxas taxas = new Taxas("",100,TipoCalculo.Fixo);

            ValidadorTaxas validadorPaciente = new ValidadorTaxas();

            var resultado1 = validadorPaciente.Validate(taxas);

            Assert.AreEqual("Deve ser inserido uma descrição", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ValorValido()
        {
            Taxas taxas = new Taxas("Taxa Comum", -100, TipoCalculo.Fixo);

            ValidadorTaxas validadorPaciente = new ValidadorTaxas();

            var resultado1 = validadorPaciente.Validate(taxas);

            Assert.AreEqual("Valor deve ser maior do que 0", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void ValorNuloValido()
        {
            Taxas taxas = new Taxas("Taxa Comum", default, TipoCalculo.Fixo);

            ValidadorTaxas validadorPaciente = new ValidadorTaxas();

            var resultado1 = validadorPaciente.Validate(taxas);

            Assert.AreEqual("Deve ser inserido um valor", resultado1.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void TipoValido()
        {
             TipoCalculo tipo = new TipoCalculo();

            Taxas taxas = new Taxas("Taxa Comum", 100, tipo);

            ValidadorTaxas validadorPaciente = new ValidadorTaxas();

            var resultado1 = validadorPaciente.Validate(taxas);

            Assert.AreEqual("Deve ser inserido um tipoCalculo", resultado1.Errors[0].ErrorMessage);
        }



    }
}
