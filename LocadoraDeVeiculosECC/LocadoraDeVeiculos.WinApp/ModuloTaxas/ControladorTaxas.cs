using LocadoraDeVeiculos.Aplicacao.ModuloTaxas;
using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxas
{
    public class ControladorTaxas : ControladorBase
    {
       
        private TabelaTaxasControl listagemTaxa;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorTaxas(ServicoTaxa servicoTaxas)
        {
            this.servicoTaxa = servicoTaxas;
        }

        public  override void Inserir()
        {
            var tela = new TelaCadastroTaxasForm();

            tela.Taxas = new Taxas();

            tela.GravarRegistro = servicoTaxa.Inserir;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Taxas primeiro",
                    "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            var tela = new TelaCadastroTaxasForm();

            tela.Taxas = funcionarioSelecionado.Clone();

            tela.GravarRegistro = servicoTaxa.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarTaxas();

        }

        public override void Excluir()
        {
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Taxas primeiro",
                    "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoTaxa.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a Taxas?", "Exclusão de Taxas",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoTaxa.Excluir(taxaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxas();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemTaxa == null)
                listagemTaxa = new TabelaTaxasControl();

            CarregarTaxas();

            return listagemTaxa;
        }

        private void CarregarTaxas()
        {
            var resultado = servicoTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxas> taxas = resultado.Value;

                listagemTaxa.AtualizarRegistros(taxas);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} Taxa(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Taxas",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
