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
        private Cliente clientes;
        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        public TelaCadastroClienteForm()
        {
            InitializeComponent();
        }
        public Cliente Clientes
        {
            get { return clientes; }
            set
            {
                clientes = value;

                textBoxId.Text = clientes.Id.ToString();
                comboBoxTipoDePessoa.SelectedItem = clientes.TipoDeCliente;
                if (comboBoxTipoDePessoa.SelectedItem.Equals("Pessoa Fisica"))
                    textBoxCpfCnpj.Text = clientes.Cpf.ToString();
                else 
                    textBoxCpfCnpj.Text = clientes.Cnpj.ToString();
                checkBoxCnh.Enabled = clientes.Cnh;
                textBoxNome.Text = clientes.Nome.ToString();
                textBoxEndereco.Text = clientes.Endereco.ToString();
                textBoxEmail.Text = clientes.Email.ToString();
                textBoxTelefone.Text = clientes.Telefone.ToString();



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBoxTipoDePessoa.SelectedItem.Equals("Pessoa Fisica"))
            {
                clientes.TipoDeCliente = "Pessoa Fisica";
                clientes.Cpf = textBoxCpfCnpj.Text;
            }
            else
            {
                clientes.TipoDeCliente = "Pessoa Fisica";
                clientes.Cnpj = textBoxCpfCnpj.Text;
            }

            if (checkBoxCnh.Enabled)
            {
                clientes.Cnh = true;
            }
            else {
                clientes.Cnh = false;
            }

            clientes.Nome = textBoxNome.Text;
            clientes.Endereco = textBoxEndereco.Text;
            clientes.Email = textBoxEmail.Text;
            clientes.Telefone = textBoxTelefone.Text;
        }
    }
}
