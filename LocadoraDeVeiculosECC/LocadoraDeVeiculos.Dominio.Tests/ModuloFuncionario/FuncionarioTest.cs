using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTest
    {
        public FuncionarioTest()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("pt-BR");
        }

        [TestMethod]

        public void NomeValido()
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            Funcionario paciente = new Funcionario("L", "Lucas", "12345",data, 1500,true);

            ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();

            var resultado1 = validadorFuncionario.Validate(paciente);

            Assert.AreEqual("O nome deve possuir no mínimo 3 caracteres", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void UsuarioValido()
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            Funcionario paciente = new Funcionario("Lucas de Aguiar", "L", "12345", data, 1500, true);

            ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();

            var resultado1 = validadorFuncionario.Validate(paciente);

            Assert.AreEqual("O usuário deve possuir no mínimo 3 caracteres", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void SenhaValida()
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            Funcionario paciente = new Funcionario("Lucas de Aguiar", "Lucas", "12", data, 1500, true);

            ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();

            var resultado1 = validadorFuncionario.Validate(paciente);

            Assert.AreEqual("A senha deve possuir no mínimo 3 caracteres", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void SalarioValido()
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            Funcionario paciente = new Funcionario("Lucas de Aguiar", "Lucas", "12345", data, -3, true);

            ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();

            var resultado1 = validadorFuncionario.Validate(paciente);

            Assert.AreEqual("Valor de salário deve ser maior do que 0", resultado1.Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void DataValida()
        {
            DateTime data = new DateTime();
            
            Funcionario paciente = new Funcionario("Lucas de Aguiar", "Lucas", "12345", data, 1500, true);

            ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();

            var resultado1 = validadorFuncionario.Validate(paciente);

            Assert.AreEqual("Deve ser inserido uma data", resultado1.Errors[0].ErrorMessage);
        }


        [TestMethod]
        public void AdminValido()
        {
            DateTime data = new DateTime();
            data = DateTime.Now;
            bool admin = new bool();

            Funcionario paciente = new Funcionario("Lucas de Aguiar", "Lucas", "12345", data, 1500,admin);

            ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();

            var resultado1 = validadorFuncionario.Validate(paciente);

            Assert.AreEqual("Deve ser inserido um admin", resultado1.Errors[0].ErrorMessage);
        }
    }
}
