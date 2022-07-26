using locadoraDeVeiculos.Infra.ModuloFuncionario;
using locadoraDeVeiculos.Infra.ModuloVeiculo;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo;
using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {

        private readonly RepositorioGrupoDeVeiculosEmBancoDados repositorioGrupoDeVeiculos = new RepositorioGrupoDeVeiculosEmBancoDados();
        private TabelaVeiculoControl listagemVeiculos;
        private readonly ServicoVeiculo servicoVeiculo;

        public ControladorVeiculo(ServicoVeiculo servicoVeiculo)
        {

            this.servicoVeiculo = servicoVeiculo;
        }

        public override void Inserir()
        {
            var grupos = repositorioGrupoDeVeiculos.SelecionarTodos();

            TelaCadastroVeiculoForm tela = new TelaCadastroVeiculoForm(grupos);
           
            tela.Veiculo = new Veiculo();

            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }
        public override void Editar()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Edição veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var grupos = repositorioGrupoDeVeiculos.SelecionarTodos();

            TelaCadastroVeiculoForm tela = new TelaCadastroVeiculoForm(grupos);

            tela.Veiculo = veiculoSelecionado.Clone();

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }
        public override void Excluir()
        {
            var id = listagemVeiculos.ObtemNumeroVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um Veiculo primeiro",
                    "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o Veiculo?", "Exclusão de Veiculo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(planoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public override UserControl ObtemListagem()
        {
            listagemVeiculos = new TabelaVeiculoControl();

            CarregarVeiculos();

            return listagemVeiculos;
        }
        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = repositorioVeiculo.SelecionarTodos();

            listagemVeiculos.AtualizarRegistros(veiculos);

            TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veiculo(s)");

        }
        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxVeiculo();
        }
        private Veiculo ObtemVeiculoSelecionado()
        {
            var numero = listagemVeiculos.ObtemNumeroVeiculoSelecionado();

            return repositorioVeiculo.SelecionarPorId(numero);
        }

    }
}
