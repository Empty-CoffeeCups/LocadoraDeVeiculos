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
        private readonly IRepositorioTaxas repositorioTaxa;
        private TabelaTaxasControl listagemTaxa;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorTaxas(IRepositorioTaxas repositorioTaxa, ServicoTaxa servicoTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
            this.servicoTaxa = servicoTaxa;
        }

        public  override void Inserir()
        {
            var tela = new TelaCadastroTaxasForm();
            tela.Taxas = new Taxas();
            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Editar()
        {
            Taxas taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroTaxasForm();

            tela.Taxas = taxaSelecionada;

            tela.GravarRegistro = servicoTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarTaxas();
        }

        public override void Excluir()
        {
            Taxas taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
            "Exclusão de Taxa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
        }

        private Taxas ObtemTaxaSelecionada()
        {
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            return repositorioTaxa.SelecionarPorId(id);
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
            List<Taxas> taxas = repositorioTaxa.SelecionarTodos();
            listagemTaxa.AtualizarRegistros(taxas);
            TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} taxa(s)");
        }

    }
}
