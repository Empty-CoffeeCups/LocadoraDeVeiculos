using FluentResults;
using FluentValidation.Results;
using locadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public partial class TelaCadastroCondutorForm : Form
    {
        private Condutor condutor;
        RepositorioClienteEmBancoDados repositorioCliente = new RepositorioClienteEmBancoDados();
        public TelaCadastroCondutorForm(List<Cliente> clientes)
        {
            InitializeComponent();
            CarregarClientes(clientes);
           

        }

        public Func<Condutor, Result<Condutor>> GravarRegistro { get; set; }

        public Condutor Condutor
        {
            get
            {
                return condutor;
            }
            set
            {
                condutor = value;

                cmbCliente.SelectedItem = condutor.Cliente;
                txtNome.Text = condutor.Nome;
                txtCpf.Text = condutor.Cpf;
                txtCnh.Text = condutor.Cnh;
                dateTimePickerValidadeCnh.Value = DateTime.Now.Date;
                txtEmail.Text = condutor.Email;
                txtTelefone.Text = condutor.Telefone;
                txtEndereco.Text = condutor.Telefone;
            }
        }


        //Métodos Privados

        private void CarregarClientes(List<Cliente> clientes)
        {
            cmbCliente.Items.Clear();

            foreach (var item in clientes)
            {
                cmbCliente.Items.Add(item);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            condutor.Nome = txtNome.Text;
            condutor.Cpf = txtCpf.Text;
            condutor.Cnh = txtCnh.Text;
            condutor.ValidadeCnh = dateTimePickerValidadeCnh.Value;
            condutor.Email = txtEmail.Text;
            condutor.Telefone = txtTelefone.Text;
            condutor.Endereco = txtEndereco.Text;
            condutor.Cliente = (Cliente)cmbCliente.SelectedItem;

            if (dateTimePickerValidadeCnh.Value < DateTime.Today)
            {
                TelaMenuPrincipalForm.Instancia.AtualizarRodape("Registro inválido (CNH Vencido)");
                DialogResult = DialogResult.None;

                return;
            }

            var resultadoValidacao = GravarRegistro(condutor);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void checkBoxClienteCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1)
            {
                TelaMenuPrincipalForm.Instancia.AtualizarRodape("Registro Inválido(Cliente não selecionado)");
                DialogResult = DialogResult.None;

                return;
            }

            if (checkBoxClienteCondutor.Checked == true)
            {
                pegarCliente();
            }

            if (checkBoxClienteCondutor.Checked == false)
            {
                limparTextos();
            }
        }

        private void limparTextos()
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtTelefone.Clear();
        }

        private void pegarCliente()
        {
            var clientes = repositorioCliente.SelecionarTodos();

            var clienteSelecionado = (Cliente)cmbCliente.SelectedItem;

            foreach (var cliente in clientes)
            {
                if (clienteSelecionado.Nome == cliente.Nome)
                {
                    if (clienteSelecionado.Cpf != "")
                    {
                        txtNome.Text = cliente.Nome;
                        txtCpf.Text = cliente.Cpf;
                        txtCnh.Text = cliente.Cnh;
                        txtEmail.Text = cliente.Email;
                        txtEndereco.Text = cliente.Endereco;
                        txtTelefone.Text = cliente.Telefone;
                    }
                    else
                    {
                        checkBoxClienteCondutor.Checked = false;
                        TelaMenuPrincipalForm.Instancia.AtualizarRodape("Não foi possível realizar o cadastro(Cadastro negado a empresas)");
                        DialogResult = DialogResult.None;

                        return;
                    }

                }
            }
        }

    }
}
