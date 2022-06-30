using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
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
        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        public TelaCadastroClienteForm()
        {
            InitializeComponent();
        }
        public Cliente Clientes
        {
            get { return cliente; }
            set
            {
                cliente = value;

                textBoxId.Text = cliente.Id.ToString();
                comboBoxTipoDePessoa.SelectedItem = cliente.TipoDeCliente;
                if (comboBoxTipoDePessoa.SelectedItem.Equals("Pessoa Fisica"))
                    textBoxCpfCnpj.Text = cliente.Cpf.ToString();
                else 
                    textBoxCpfCnpj.Text = cliente.Cnpj.ToString();
                checkBoxCnh.Enabled = cliente.Cnh;
                textBoxNome.Text = cliente.Nome.ToString();
                textBoxEndereco.Text = cliente.Endereco.ToString();
                textBoxEmail.Text = cliente.Email.ToString();
                textBoxTelefone.Text = cliente.Telefone.ToString();



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBoxTipoDePessoa.SelectedItem.Equals("Pessoa Fisica"))
            {
                cliente.TipoDeCliente = "Pessoa Fisica";
                cliente.Cpf = textBoxCpfCnpj.Text;
            }
            else
            {
                cliente.TipoDeCliente = "Pessoa Fisica";
                cliente.Cnpj = textBoxCpfCnpj.Text;
            }

            if (checkBoxCnh.Enabled)
            {
                cliente.Cnh = true;
            }
            else {
                cliente.Cnh = false;
            }

            cliente.Nome = textBoxNome.Text;
            cliente.Endereco = textBoxEndereco.Text;
            cliente.Email = textBoxEmail.Text;
            cliente.Telefone = textBoxTelefone.Text;
        }
    }
}
