using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    internal class ControladorFuncionarios
    {
        private readonly IRepositorioFuncionario repositorioFuncionarios;
        private TabelaFuncionarioControl tabelaFuncionarios;

        public ControladorFuncionarios(IRepositorioFuncionario repositorio)
        {
            this.repositorioFuncionarios = repositorio;
        }

        public void Inserir()
        {
            TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm();
            tela.Funcionarios = new Funcionario();

            tela.GravarRegistro = repositorioFuncionarios.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public void Editar()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm();

            tela.Funcionarios = funcionarioSelecionado;

            tela.GravarRegistro = repositorioFuncionarios.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }


        }

        public void Excluir()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Exclusão de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Funcionario?",
                "Exclusão de Funcionario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioFuncionarios.Excluir(funcionarioSelecionado);
                CarregarFuncionarios();
            }
        }

        public UserControl ObtemListagem()
        {

            tabelaFuncionarios = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return tabelaFuncionarios;
        }


        public ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxFuncionario();
        }


        private Funcionario ObtemFuncionarioSelecionado()
        {
            var Id = tabelaFuncionarios.ObtemNumeroTaxaSelecionada();

            return repositorioFuncionarios.SelecionarPorId(Id);
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionario = repositorioFuncionarios.SelecionarTodos();

            tabelaFuncionarios.AtualizarRegistros(funcionario);

        }

    }
}

