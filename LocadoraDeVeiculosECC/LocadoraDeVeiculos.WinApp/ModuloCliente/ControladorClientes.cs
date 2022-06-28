using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorClientes
    {
        private readonly IRepositorioCliente repositorioClientes;
        private TabelaClienteControl tabelaClientes;

        public ControladorClientes(IRepositorioCliente repositorio)
        {
            this.repositorioClientes = repositorio;
        }

        public void Inserir()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();
            tela.Clientes = new Cliente();

            tela.GravarRegistro = repositorioClientes.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public void Editar()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Clientes = clienteSelecionado;

            tela.GravarRegistro = repositorioClientes.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }


        }

        public void Excluir()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Cliente?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioClientes.Excluir(clienteSelecionado);
                CarregarClientes();
            }
        }

        public UserControl ObtemListagem()
        {

            tabelaClientes = new TabelaClienteControl();

            CarregarClientes();

            return tabelaClientes;
        }


        public ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }


        private Cliente ObtemClienteSelecionado()
        {
            var Id = tabelaClientes.ObtemNumeroTaxaSelecionada();

            return repositorioClientes.SelecionarPorId(Id);
        }

        private void CarregarClientes()
        {
            List<Cliente> cliente = repositorioClientes.SelecionarTodos();

            tabelaClientes.AtualizarRegistros(cliente);

        }
    }
}
