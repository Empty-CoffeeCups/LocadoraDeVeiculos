using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ControladorFuncionarios : ControladorBase
    {
       
        private TabelaFuncionarioControl? listagemFuncionarios;
        private readonly ServicoFuncionario servicoFuncionario;

        public ControladorFuncionarios(ServicoFuncionario servicoFuncionario)
        {
            listagemFuncionarios = new TabelaFuncionarioControl();
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionarios = new Funcionario();

            tela.GravarRegistro = servicoFuncionario.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }


        public override void Editar()
        {
            var id = listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoFuncionario.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionarios = funcionarioSelecionado.Clone();

            tela.GravarRegistro = servicoFuncionario.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarFuncionarios();

        }

        public override void Excluir()
        {
            var id = listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoFuncionario.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o funcionário?", "Exclusão de Funcionário",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionarios();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //Métodos Privados

        private void CarregarFuncionarios()
        {
            var resultado = servicoFuncionario.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Funcionario> funcionarios = resultado.Value;

                listagemFuncionarios.AtualizarRegistros(funcionarios);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Funcionário",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemFuncionarios == null)
                listagemFuncionarios = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return listagemFuncionarios;
        }

        
    }
}

