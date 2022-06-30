using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ControladorClientes : ControladorBase
    {
        private readonly IRepositorioCliente repositorioCliente;
        private TabelaClienteControl listagemClientes;
        private readonly ServicoCliente servicoCliente;

        public ControladorClientes(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }

        public  override void Inserir()
        {
            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Clientes = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Editar()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

            tela.Clientes = clienteSelecionado.Clone();

            tela.GravarRegistro = servicoCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarClientes();
        }

        public override void Excluir()
        {
            Cliente clienteSelecionado = ObtemClienteSelecionado();

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o cliente?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                repositorioCliente.Excluir(clienteSelecionado);

            CarregarClientes();
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemClientes == null)
                listagemClientes = new TabelaClienteControl();

            CarregarClientes();

            return listagemClientes;
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            listagemClientes.AtualizarRegistros(clientes);

            TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
        }

        private Cliente ObtemClienteSelecionado()
        {
            var id = listagemClientes.ObtemIdClienteSelecionado();

            return repositorioCliente.SelecionarPorId(id);
        }
    }
}
