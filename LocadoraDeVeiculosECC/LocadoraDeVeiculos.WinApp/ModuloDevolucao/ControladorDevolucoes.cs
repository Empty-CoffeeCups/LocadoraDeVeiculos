using LocadoraDeVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public class ControladorDevolucoes : ControladorBase
    {
        private TabelaDevolucaoControl listagemDevolucoes;
        private readonly ServicoDevolucao servicoDevolucao;
        private readonly ServicoLocacao servicoLocacao;
        public ControladorDevolucoes(ServicoDevolucao servicoDevolucao, ServicoLocacao servicoLocacao)
        {
            this.servicoDevolucao = servicoDevolucao;
            this.servicoLocacao = servicoLocacao;
        }

        public override void Inserir()
        {
            var locacoes = servicoLocacao.SelecionarTodos().Value;

            TelaCadastroDevolucaoForm tela = new TelaCadastroDevolucaoForm(servicoLocacao);
            
            tela.Devolucao = new Devolucao();

            tela.GravarRegistro = servicoDevolucao.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarDevolucoes();
            }
        }

        public override void Editar()
        {
            var id = listagemDevolucoes.ObtemIdDevolucaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma devolução primeiro",
                    "Edição de Devoluções", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoDevolucao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de devoluções", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var devoluçãoSelecionada = resultado.Value;

            var tela = new TelaCadastroDevolucaoForm(servicoLocacao);

            tela.Devolucao = devoluçãoSelecionada;

            tela.GravarRegistro = servicoDevolucao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarDevolucoes();
        }

        public override void Excluir()
        {
            var id = listagemDevolucoes.ObtemIdDevolucaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma devolução primeiro",
                    "Exclusão de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoDevolucao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var devolucaoSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a devolução?", "Exclusão de Devolução",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoDevolucao.Excluir(devolucaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarDevolucoes();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Deoluções", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Métodos Privados

        private void CarregarDevolucoes()
        {
            var resultado = servicoDevolucao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Devolucao> devolucoes = resultado.Value;

                listagemDevolucoes.AtualizarRegistros(devolucoes);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {devolucoes.Count} devoluções");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Carregar listagem",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxDevolucao();
        }

        public override UserControl ObtemListagem()
        {
            listagemDevolucoes = new TabelaDevolucaoControl();

            CarregarDevolucoes();

            return listagemDevolucoes;
        }

        //Métodos Privados



    }
}
