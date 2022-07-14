using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public partial class TelaCadastroPlanoDeCobranca : Form
    {
        private PlanoDeCobranca plano;
        

        public TelaCadastroPlanoDeCobranca(List<GrupoDeVeiculos> grupos)
        {
            InitializeComponent();
            this.ConfigurarTela();
            ConfigInicialDaTela();
            CarregarGrupos(grupos);
        }

        public PlanoDeCobranca Plano
        {
            get { return plano; }
            set
            {
                plano = value;
                cbGrupoDeVeiculo.SelectedItem = plano.GrupoDeVeiculo;
                cbTipoDePlano.SelectedItem = plano.TipoDePlano;

                txtDiario.Text = plano.ValorDiario.ToString();
                txtKmIncluso.Text = plano.ValorKmIncluso.ToString();
                txtKmRodado.Text = plano.PrecoKmRodado.ToString();

            }
        }

        private void CarregarGrupos(List<GrupoDeVeiculos> grupos)
        {
            cbGrupoDeVeiculo.Items.Clear();

            foreach (var item in grupos)
            {
                cbGrupoDeVeiculo.Items.Add(item);
            }
        }

        public Func<PlanoDeCobranca, ValidationResult> GravarRegistro { get; set; }





        //Métodos Privados

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string valorComPontoDiario = txtDiario.Text.Replace(",", ".");
            string valorComVirgulaDiario = txtDiario.Text.Replace(".", ",");



            string valorComPontoKmIncluso = txtKmIncluso.Text.Replace(",", ".");
            string valorComVirgulaKmIncluso = txtKmIncluso.Text.Replace(".", ",");

       



            string valorComPontoPrecoKm = txtKmRodado.Text.Replace(",", ".");
            string valorComVirgulaPrecoKm = txtKmRodado.Text.Replace(".", ",");

           

            plano.GrupoDeVeiculo = (GrupoDeVeiculos)cbGrupoDeVeiculo.SelectedItem;
            plano.TipoDePlano = (string)cbTipoDePlano.SelectedItem;
            plano.ValorDiario = Convert.ToDecimal(valorComVirgulaDiario);
            plano.ValorKmIncluso = Convert.ToDecimal(valorComVirgulaKmIncluso);
            plano.PrecoKmRodado = Convert.ToDecimal(valorComVirgulaPrecoKm);


            var resultadoValidacao = GravarRegistro(plano);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }



        private void cbTipoDePlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoDePlano.SelectedItem == "Plano Diário")
            {
                txtDiario.Clear();
                txtKmIncluso.Clear();
                txtKmRodado.Clear();

                txtKmIncluso.Text = "0";
                txtKmIncluso.Enabled = false;

                txtDiario.Enabled = true;
                txtKmRodado.Enabled = true;
            }
            else if (cbTipoDePlano.SelectedItem == "Km Controlado")
            {
                txtDiario.Clear();
                txtKmIncluso.Clear();
                txtKmRodado.Clear();

                txtDiario.Enabled = true;
                txtKmIncluso.Enabled = true;
                txtKmRodado.Enabled = true;

            }
            else if (cbTipoDePlano.SelectedItem == "Km Livre")
            {
                txtDiario.Clear();
                txtKmIncluso.Clear();
                txtKmRodado.Clear();

                txtKmIncluso.Text = "0";
                txtKmIncluso.Enabled = false;
                txtKmRodado.Text = "0";
                txtKmRodado.Enabled = false;

                txtDiario.Enabled = true;
            }
        }

        private void ConfigInicialDaTela()
        {
            cbTipoDePlano.Enabled = true;
            txtDiario.Enabled = false;
            txtKmIncluso.Enabled = false;
            txtKmRodado.Enabled = false;
        }

        private void cbGrupoDeVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTipoDePlano.Enabled = true;
        }

        private void TelaCadastroPlanoDeCobrancaForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroPlanoDeCobrancaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

       

    }
}
