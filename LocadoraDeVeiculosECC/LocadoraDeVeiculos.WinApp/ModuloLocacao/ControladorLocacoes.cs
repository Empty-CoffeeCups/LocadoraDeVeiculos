using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ControladorLocacoes : ControladorBase
    {
        private TabelaLocacaoControl listagemLocacoes;
        private readonly ServicoLocacao servicoLocacao;
        private readonly ServicoFuncionario servicoFuncionario;
        private readonly ServicoCliente servicoCliente;
        private readonly ServicoCondutor servicoCondutor;
       // private readonly ServicoVeiculo servicoVeiculo; -- esperando merge de veiculo
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorLocacoes(ServicoLocacao servicoLocacao, ServicoFuncionario servicoFuncionario, ServicoCliente servicoCliente, ServicoCondutor servicoCondutor,/*ServicoVeiculo servicoVeiculo,*/ ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoTaxa servicoTaxa)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoFuncionario = servicoFuncionario;
            this.servicoCliente = servicoCliente;
            this.servicoCondutor = servicoCondutor;
           // this.servicoVeiculo = servicoVeiculo; -- esperando merge de veiculo
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            this.servicoTaxa = servicoTaxa;
        }


        public override void Inserir()
        {
            var resultadoSelecaoFuncionarios = servicoFuncionario.SelecionarTodos();

            if (resultadoSelecaoFuncionarios.IsFailed)
            {
                string erro = resultadoSelecaoFuncionarios.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoClientes = servicoCliente.SelecionarTodos();

            if (resultadoSelecaoClientes.IsFailed)
            {
                string erro = resultadoSelecaoClientes.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoCondutores = servicoCondutor.SelecionarTodos();

            if (resultadoSelecaoCondutores.IsFailed)
            {
                string erro = resultadoSelecaoCondutores.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            /* -- esperando merge de veiculo
            var resultadoSelecaoVeiculos = servicoVeiculo.SelecionarTodos();

            if (resultadoSelecaoVeiculos.IsFailed)
            {
                string erro = resultadoSelecaoVeiculos.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            */

            var resultadoSelecaoPlanosDeCobranca = servicoPlanoDeCobranca.SelecionarTodos();

            if (resultadoSelecaoPlanosDeCobranca.IsFailed)
            {
                string erro = resultadoSelecaoPlanosDeCobranca.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultadoSelecaoTaxas = servicoTaxa.SelecionarTodos();

            if (resultadoSelecaoTaxas.IsFailed)
            {
                string erro = resultadoSelecaoTaxas.Errors[0].Message;

                MessageBox.Show(erro,
                    "Inserção de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TelaCadastroLocacaoForm tela = new TelaCadastroLocacaoForm(resultadoSelecaoFuncionarios.Value, resultadoSelecaoClientes.Value, resultadoSelecaoCondutores.Value,/*  resultadoSelecaoVeiculos.Value,*/ resultadoSelecaoPlanosDeCobranca.Value, resultadoSelecaoTaxas.Value);

            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult result = tela.ShowDialog();

            if (result == DialogResult.OK)
            {
                CarregarLocacao();
            }
       

        }


        public override void Editar()
        {
            var id = listagemLocacoes.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Locacao primeiro",
                    "Edição de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultado.Value;

            var clientes = servicoCliente.SelecionarTodos().Value;
            var funcionarios = servicoFuncionario.SelecionarTodos().Value;
            var condutores = servicoCondutor.SelecionarTodos().Value;
            var planosDeCobranca = servicoPlanoDeCobranca.SelecionarTodos().Value;
            var taxas = servicoTaxa.SelecionarTodos().Value;

            var tela = new TelaCadastroLocacaoForm(funcionarios, clientes , condutores , planosDeCobranca, taxas);

            tela.Locacao = planoSelecionado.Clonar();

            tela.GravarRegistro = servicoLocacao.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacao();
        }

        public override void Excluir()
        {
            var id = listagemLocacoes.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma locação primeiro",
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultado.Value;

            if (MessageBox.Show("Deseja realmente excluir a locação?", "Exclusão de Locação",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacao();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locações", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Métodos Privados

        private void CarregarLocacao()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                listagemLocacoes.AtualizarRegistros(locacoes);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} locação(ões)");
            }
            else if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            listagemLocacoes = new TabelaLocacaoControl();

            CarregarLocacao();

            return listagemLocacoes;
        }

    }
}
