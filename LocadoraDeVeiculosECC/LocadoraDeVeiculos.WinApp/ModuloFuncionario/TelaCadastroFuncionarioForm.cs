using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionarioForm : Form
    {
        private Funcionario funcionarios;
        public Func<Funcionario,ValidationResult> GravarRegistro { get; set; }
        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();
        }

        public Funcionario Funcionarios
        {
            get { return funcionarios; }
            set
            {
                funcionarios = value;

                textBoxId.Text = funcionarios.Id.ToString();
                textBoxNome.Text = funcionarios.Nome.ToString();
                textBoxUsuario.Text = funcionarios.Usuario.ToString();
                textBoxSenha.Text = funcionarios.Senha.ToString();
                textBoxData.Text = funcionarios.DataDeEntrada.ToString();
                checkBoxAdmin.Enabled = funcionarios.Admin;

            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            funcionarios.Nome = textBoxNome.Text;
            funcionarios.Usuario = textBoxUsuario.Text;
            funcionarios.Senha = textBoxSenha.Text;
            funcionarios.DataDeEntrada = DateTime.Parse(textBoxData.Text);
            funcionarios.Salario = textBoxSalario.Text;
            funcionarios.Admin = checkBoxAdmin.Checked;
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
    }
}
