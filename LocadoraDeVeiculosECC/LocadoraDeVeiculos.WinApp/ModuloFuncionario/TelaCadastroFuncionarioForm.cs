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
        public Func<Funcionario,ValidationResult> GravarRegistro { get; set; }
        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();
        }

        public Funcionario Funcionarios
        {
            get { return funcionario; }
            set
            {
                funcionario = value;

                textBoxId.Text = funcionario.Id.ToString();
                textBoxNome.Text = funcionario.Nome.ToString();
                textBoxUsuario.Text = funcionario.Usuario.ToString();
                textBoxSenha.Text = funcionario.Senha.ToString();
                textBoxData.Text = funcionario.DataDeEntrada.ToString();
                textBoxSalario.Text = funcionario.Salario.ToString();
                checkBoxAdmin.Enabled = funcionario.Admin;

            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            funcionario.Nome = textBoxNome.Text;
            funcionario.Usuario = textBoxUsuario.Text;
            funcionario.Senha = textBoxSenha.Text;
            funcionario.DataDeEntrada = DateTime.Parse(textBoxData.Text);
            funcionario.Salario = Decimal.Parse(textBoxSalario.Text);
            funcionario.Admin = checkBoxAdmin.Checked;
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
