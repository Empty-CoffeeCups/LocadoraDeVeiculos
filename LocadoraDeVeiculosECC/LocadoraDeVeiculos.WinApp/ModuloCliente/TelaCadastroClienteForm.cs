using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
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

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{

    public partial class TelaCadastroClienteForm : Form
    {
        private Cliente cliente;
        public TelaCadastroClienteForm()
        {
            InitializeComponent();
        }
        public Cliente Clientes
        {
            get => cliente;
            set
            {
                cliente = value;

                if (cliente.Id != 0)
                    PreencherDadosNaTela();
                else
                {
                    HabilitarPessoaFisica();
                    radioButtonPessoaFisica.Checked = true;
                    DesabilitarPessoaJuridica();
                }

            }
        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            ObterDadosTela();

            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarPessoaFisica();
            DesabilitarPessoaJuridica();
        }

        private void radioButtonPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            HabilitarPessoaJuridica();
            DesabilitarPessoaFisica();
        }


        //Métodos Privados

        private void ObterDadosTela()
        {
            cliente.Nome = textBoxNome.Text;
            cliente.Email = textBoxEmail.Text;
            cliente.Telefone = textBoxTelefone.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Cnpj = txtCnpj.Text;
            cliente.Cnh = txtCnh.Text;
            cliente.Endereco = textBoxEndereco.Text;
            cliente.TipoDeCliente = ObterTipoCliente();
           
        }

        private void PreencherDadosNaTela()
        {
            textBoxNome.Text = cliente.Nome;
            textBoxEmail.Text = cliente.Email;
            textBoxTelefone.Text = cliente.Telefone;
            txtCpf.Text = cliente.Cpf;
            txtCnpj.Text = cliente.Cnpj;
            txtCnh.Text = cliente.Cnh;
            textBoxEndereco.Text = cliente.Endereco;
            PreencherTipoCliente();
        }

        private void PreencherTipoCliente()
        {
            if (cliente.TipoDeCliente == TipoCliente.PessoaFisica)
            {
                radioButtonPessoaFisica.Checked = true;
                DesabilitarPessoaJuridica();
                HabilitarPessoaFisica();
                txtCpf.Text = cliente.Cpf;
            }
            else if (cliente.TipoDeCliente == TipoCliente.PessoaJuridica)
            {
                radioButtonPessoaJuridica.Checked = true;
                DesabilitarPessoaFisica();
                HabilitarPessoaJuridica();
                txtCnpj.Text = cliente.Cnpj;
            }
        }

        private void HabilitarPessoaFisica()
        {
            txtCpf.Enabled = true;
        }

        private void HabilitarPessoaJuridica()
        {
            txtCnpj.Enabled = true;
        }

        private void DesabilitarPessoaFisica()
        {
            txtCpf.Clear();
            txtCpf.Enabled = false;
        }

        private void DesabilitarPessoaJuridica()
        {
            txtCnpj.Clear();
            txtCnpj.Enabled = false;
        }

        private TipoCliente ObterTipoCliente()
        {
            TipoCliente retorno = TipoCliente.PessoaFisica;

            if (radioButtonPessoaFisica.Checked && string.IsNullOrEmpty(txtCpf.Text) == false)
                retorno = TipoCliente.PessoaFisica;
            else if (radioButtonPessoaJuridica.Checked && string.IsNullOrEmpty(txtCnpj.Text) == false)
                retorno = TipoCliente.PessoaJuridica;

            return retorno;
        }
    }
}
