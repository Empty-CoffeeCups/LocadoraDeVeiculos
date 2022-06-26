using LocadoraDeVeiculos.Dominio.ModuloTaxas;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxas
{
    public class ControladorTaxas
    {
        private readonly IRepositorioTaxas repositorioTaxa;
        private TabelaTaxasControl tabelaTaxas;

        public ControladorTaxas(IRepositorioTaxas repositorio)
        {
            this.repositorioTaxa = repositorio;
        }

        public  void Inserir()
        {
            TelaCadastroTaxasForm tela = new TelaCadastroTaxasForm();
            tela.Taxas = new Taxas();

            tela.GravarRegistro = repositorioTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public  void Editar()
        {
            Taxas taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTaxasForm tela = new TelaCadastroTaxasForm();

            tela.Taxas = taxaSelecionada;

            tela.GravarRegistro = repositorioTaxa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }


        }

        public void Excluir()
        {
            Taxas taxaSelecionada = ObtemTaxaSelecionada();

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a Taxa?",
                "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(taxaSelecionada);
                CarregarTaxas();
            }
        }

        public UserControl ObtemListagem()
        {

            tabelaTaxas = new TabelaTaxasControl();

            CarregarTaxas();

            return tabelaTaxas;
        }


        public  ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxa();
        }


        private Taxas ObtemTaxaSelecionada()
        {
            var numero = tabelaTaxas.ObtemNumeroTaxaSelecionada();

            return repositorioTaxa.SelecionarPorId(numero);
        }

        private void CarregarTaxas()
        {
            List<Taxas> taxas = repositorioTaxa.SelecionarTodos();

            tabelaTaxas.AtualizarRegistros(taxas);

        }

    }
}
