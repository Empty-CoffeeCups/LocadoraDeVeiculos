﻿using FluentResults;
using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionarioForm : Form
    {
        private Funcionario funcionario;
        
        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();
            DefinirDataAdmissaoMaxima();
        
        }

        public Funcionario Funcionarios
        {
            get => funcionario; 
            set
            {
                funcionario = value;
                PreencherDadosNaTela();
                
            }
        }

        public Func<Funcionario, Result<Funcionario>> GravarRegistro { get; set; }



        private void buttonGravar_Click(object sender, EventArgs e)
        {
            

            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(funcionario);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }
        private void TelaCadastroFuncionarioForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroFuncionarioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        { 
        }

        private void DefinirDataAdmissaoMaxima()
        {
            dateTimePickerDataDeEntrada.MaxDate = DateTime.Today;
        }

        

        private void PreencherDadosNaTela()
        {
            textBoxNome.Text = funcionario.Nome;
            textBoxUsuario.Text = funcionario.Usuario;
            textBoxSenha.Text = funcionario.Senha;
            textBoxSalario.Text = funcionario.Salario.ToString();

            if(funcionario.DataDeEntrada > DateTime.MinValue) 
             dateTimePickerDataDeEntrada.Value = funcionario.DataDeEntrada.Date;
            else
             dateTimePickerDataDeEntrada.Value = new DateTime(1900,01,01);
            

            if (funcionario.Admin == true)
                checkBoxAdmin.Checked = true;
            else
                checkBoxAdmin.Checked = false;
        }

        private void ObterDadosTela()
        {
            funcionario.Nome = textBoxNome.Text;
            funcionario.Usuario = textBoxUsuario.Text;
            funcionario.Senha = textBoxSenha.Text;

            if (string.IsNullOrEmpty(textBoxSalario.Text) == false)
            {
                var valorFormatado = textBoxSalario.Text.Replace(".", ",");

                var conversaoRealizada = decimal.TryParse(valorFormatado, out decimal resultado);
                if (conversaoRealizada)
                    funcionario.Salario = resultado;
            }

            funcionario.DataDeEntrada = dateTimePickerDataDeEntrada.Value;

            if (checkBoxAdmin.Checked == true)
                funcionario.Admin = true;
            else
                funcionario.Admin = false;
        }
    }
}
