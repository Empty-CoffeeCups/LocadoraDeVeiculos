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
        
        private TabelaClienteControl listagemClientes;
        private readonly ServicoCliente servicoCliente;

        public ControladorClientes(ServicoCliente servicoCliente)
        {
            this.servicoCliente = servicoCliente;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroClienteForm();

            tela.Clientes = new Cliente();

            tela.GravarRegistro = servicoCliente.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Editar()
        {
            var id = listagemClientes.ObtemIdClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                    "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCliente.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            var tela = new TelaCadastroClienteForm();

            tela.Clientes = funcionarioSelecionado.Clone();

            tela.GravarRegistro = servicoCliente.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarClientes();

        }

        public override void Excluir()
        {
            var id = listagemClientes.ObtemIdClienteSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Cliente primeiro",
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCliente.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Cliente?", "Exclusão de Cliente",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCliente.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarClientes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            var resultado = servicoCliente.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Cliente> clientes = resultado.Value;

                listagemClientes.AtualizarRegistros(clientes);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} Cliente(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Cliente",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
